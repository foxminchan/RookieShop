using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Order.Models;
using RookieShop.Storefront.Areas.Order.Services;
using Stripe;
using Stripe.Checkout;
using PaymentMethod = RookieShop.Storefront.Areas.Basket.Models.PaymentMethod;

namespace RookieShop.Storefront.WebHooks;

[Route("api/stripe")]
public class StripeWebHook(
    ILogger<StripeWebHook> logger,
    IConfiguration configuration,
    IOrderService orderService) : Controller
{
    [HttpPost]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> Index()
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

        try
        {
            var stripeEvent = EventUtility.ConstructEvent(
                json,
                Request.Headers["Stripe-Signature"],
                configuration["StripeSettings:StripeWebhookSecret"]
            );

            if (stripeEvent.Type == Events.CheckoutSessionCompleted)
            {
                var session = stripeEvent.Data.Object as Session;
                var options = new SessionGetOptions();
                options.AddExpand("line_items");
                var sessionService = new SessionService();
                var stripeSession = await sessionService.GetAsync(session?.Id, options);

                logger.LogInformation("[{Controller}] PaymentIntentSucceeded: {SessionId}", nameof(StripeWebHook),
                    stripeSession.Id);

                var accountId = stripeSession.Metadata.First(x => x.Key == "accountId").Value;
                var street = stripeSession.Metadata.First(x => x.Key == "street").Value;
                var city = stripeSession.Metadata.First(x => x.Key == "city").Value;
                var province = stripeSession.Metadata.First(x => x.Key == "province").Value;

                logger.LogDebug("[{Controller}] Metadata: {AccountId}, {Street}, {City}, {Province}", nameof(StripeWebHook),
                    accountId, street, city, province);

                OrderRequest order = new()
                {
                    PaymentMethod = PaymentMethod.Card,
                    AccountId = Guid.Parse(accountId),
                    Street = street,
                    City = city,
                    Province = province,
                    ChargeId = stripeSession.PaymentIntentId,
                    Last4 = null,
                    Brand = null
                };

                logger.LogInformation("[{Controller}] Creating order for account {AccountId} with {@Order}",
                    nameof(StripeWebHook), order.AccountId, JsonSerializer.Serialize(order));

                await orderService.CreateOrderAsync(order, Guid.NewGuid());
            }
            else
            {
                logger.LogWarning("[{Controller}] Invalid event type: {Type}", nameof(StripeWebHook), stripeEvent.Type);
            }

            return Ok();
        }
        catch (StripeException e)
        {
            logger.LogError(e, "[{Controller}] Stripe error: {Message}", nameof(StripeWebHook), e.Message);
            return BadRequest();
        }
    }
}