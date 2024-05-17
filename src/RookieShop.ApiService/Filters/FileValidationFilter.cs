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
                    throw new ValidationException("File is empty.");
                case > MaxFileSize:
                    throw new ValidationException($"File size is too large. Max file size is {MaxFileSize / 1024} KB.");
            }

            List<string> allowedContentTypes = ["image/jpeg", "image/png", "image/jpg"];

            if (allowedContentTypes.Contains(file.ContentType)) continue;

            throw new ValidationException(
                $"File type is not allowed. Allowed file types are {string.Join(", ", allowedContentTypes)}.");
        }

        return await next(context);
    }
}