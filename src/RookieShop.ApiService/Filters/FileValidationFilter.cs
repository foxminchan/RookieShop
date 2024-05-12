using FluentValidation;

namespace RookieShop.ApiService.Filters;

public sealed class FileValidationFilter : IEndpointFilter
{
    private const int MaxFileSize = 1048576;

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var request = context.HttpContext.Request;
        var formCollection = await request.ReadFormAsync();
        var files = formCollection.Files;

        if (files.Count == 0)
            return await next(context);

        foreach (var file in files)
        {
            switch (file.Length)
            {
                case 0:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    throw new ValidationException("File is empty.");
                case > MaxFileSize:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    throw new ValidationException($"File size is too large. Max file size is {MaxFileSize / 1024} KB.");
            }

            List<string> allowedExtensions = [".jpg", ".jpeg", ".png"];
            var extension = Path.GetExtension(file.FileName);

            if (allowedExtensions.Contains(extension)) continue;

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            throw new ValidationException($"File extension {extension} is not allowed.");
        }

        return await next(context);
    }
}