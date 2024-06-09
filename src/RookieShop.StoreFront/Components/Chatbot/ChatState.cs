using System.ComponentModel;
using System.Security.Claims;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using RookieShop.Storefront.Areas.Product.Services;
using System.Text.Json;
using Microsoft.SemanticKernel.ChatCompletion;
using RookieShop.Storefront.Areas.Basket.Models;
using RookieShop.Storefront.Areas.Basket.Services;
using RookieShop.Storefront.Areas.User.Models;

namespace RookieShop.Storefront.Components.Chatbot;

public sealed class ChatState
{
    private readonly IProductService _productService;
    private readonly IBasketService _basketService;
    private readonly ILogger _logger;
    private readonly Kernel _kernel;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly OpenAIPromptExecutionSettings _aiSettings = new()
        { ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions };

    public ChatState(
        IProductService productService,
        IBasketService basketService,
        IHttpContextAccessor httpContextAccessor,
        Kernel kernel,
        ILoggerFactory loggerFactory)
    {
        _productService = productService;
        _basketService = basketService;
        _httpContextAccessor = httpContextAccessor;
        _logger = loggerFactory.CreateLogger(typeof(ChatState));

        if (_logger.IsEnabled(LogLevel.Debug))
        {
            var completionService = kernel.GetRequiredService<IChatCompletionService>();
            _logger.LogDebug("ChatName: {Model}", completionService.Attributes["DeploymentName"]);
        }

        _kernel = kernel;
        _kernel.Plugins.AddFromObject(new CatalogInteractions(this));

        Messages = new(
            $"""
             You are an AI customer service agent for the online bookstore {nameof(RookieShop)}.
             You NEVER respond about topics other than {nameof(RookieShop)}.
             Your job is to help customers find books, answer questions about books, and help them with their orders.
             {nameof(RookieShop)} primarily sells books, souvenirs, artwork, comics, and other items related to the world of books.
             You try to be concise and only provide longer responses if necessary.
             If someone asks a question about anything other than {nameof(RookieShop)}, you should refuse to answer, and you instead ask if there's a topic related to {nameof(RookieShop)} that you can help with.
             """);
        Messages.AddAssistantMessage($"Hi! I'm the {nameof(RookieShop)} Concierge. How can I help?");
    }

    public ChatHistory Messages { get; }

    public async Task AddUserMessageAsync(string userText, Action onMessageAdded)
    {
        Messages.AddUserMessage(userText);
        onMessageAdded();

        try
        {
            var response = await _kernel
                .GetRequiredService<IChatCompletionService>()
                .GetChatMessageContentAsync(Messages, _aiSettings, _kernel);

            if (!string.IsNullOrWhiteSpace(response.Content))
            {
                Messages.Add(response);
            }
        }
        catch (Exception e)
        {
            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError(e, "Error getting chat completions.");
            }

            Messages.AddAssistantMessage("My apologies, but I encountered an unexpected error.");
        }

        onMessageAdded();
    }

    private sealed class CatalogInteractions(ChatState chatState)
    {
        [KernelFunction, Description("Gets information about the chat user")]
        public string GetUserInformation()
        {
            if (chatState._httpContextAccessor.HttpContext?.Items["Customer"] is not CustomerViewModel customer)
                return JsonSerializer.Serialize(new { Name = "Guest" });

            return JsonSerializer.Serialize(new
            {
                customer.Name,
                customer.Email,
                customer.Phone,
                customer.Gender
            });
        }

        [KernelFunction, Description($"Searches the {nameof(RookieShop)} catalog for a provided product description")]
        public async Task<string> SearchCatalog(string description)
        {
            try
            {
                var results = await chatState._productService.SearchProductsAsync(new()
                {
                    Context = description,
                    PageNumber = 1,
                    PageSize = 8
                });

                return JsonSerializer.Serialize(results);
            }
            catch (HttpRequestException e)
            {
                return Error(e, "An error occurred while searching the catalog.");
            }
        }

        [KernelFunction, Description($"Adds a product to the {nameof(RookieShop)} shopping cart")]
        public async Task<string> AddToCart(
            [Description("The id of the product to add to the shopping cart (basket)")]
            Guid productId)
        {
            try
            {
                var userId = chatState._httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId is null)
                {
                    return "You must be logged in to add items to your shopping cart.";
                }

                var product = await chatState._productService.GetProductByIdAsync(productId);

                BasketRequest basketItem = new()
                {
                    AccountId = Guid.Parse(userId),
                    ProductId = product.Id,
                    Price = product.PriceSale,
                    Quantity = 1
                };

                await chatState._basketService.AddToBasketAsync(basketItem, Guid.NewGuid());

                return "Item added to shopping cart.";
            }
            catch (HttpRequestException e)
            {
                return Error(e, "An error occurred while adding the product to the cart.");
            }
        }

        [KernelFunction, Description("Gets information about the contents of the user's shopping cart (basket)")]
        public async Task<string> GetCartContents()
        {
            try
            {
                var userId = chatState._httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId is null)
                {
                    return "You must be logged in to view your shopping cart.";
                }

                var basket = await chatState._basketService.GetBasketAsync(Guid.Parse(userId));

                return JsonSerializer.Serialize(basket);
            }
            catch (HttpRequestException e)
            {
                return Error(e, "An error occurred while getting the shopping cart contents.");
            }
        }

        private string Error(Exception e, string message)
        {
            if (chatState._logger.IsEnabled(LogLevel.Error))
            {
                chatState._logger.LogError(e, message);
            }

            return message;
        }
    }
}