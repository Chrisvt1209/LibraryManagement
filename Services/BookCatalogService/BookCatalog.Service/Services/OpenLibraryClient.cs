using BookCatalog.Service.Models;
using System.Text;
using System.Text.Json;

namespace BookCatalog.Service.Services;

public class OpenLibraryClient(HttpClient httpClient)
{
    private const string SearchUrl = "https://openlibrary.org/search.json";

    public async Task<OpenLibrarySearchResult> SearchAsync(
        string? title = null,
        string? author = null,
        string? subject = null,
        int page = 1,
        int limit = 20,
        CancellationToken cancellationToken = default)
    {
        string url = BuildSearchUrl(title, author, subject, page, limit);

        HttpResponseMessage response = await httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        Stream stream = await response.Content.ReadAsStreamAsync(cancellationToken);

        OpenLibrarySearchResult? result = await JsonSerializer.DeserializeAsync<OpenLibrarySearchResult>(
            stream,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true },
            cancellationToken);

        return result ?? new OpenLibrarySearchResult();
    }

    private static string BuildSearchUrl(string? title, string? author, string? subject, int page, int limit)
    {
        StringBuilder query = new StringBuilder();

        AppendIfNotNull(query, "title", title);
        AppendIfNotNull(query, "author", author);
        AppendIfNotNull(query, "subject", subject);

        query.Append($"&page={page}");
        query.Append($"&limit={limit}");

        string queryString = query.ToString().TrimStart('&');
        return $"{SearchUrl}?{queryString}";
    }

    private static void AppendIfNotNull(StringBuilder builder, string key, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            builder.Append($"&{key}={Uri.EscapeDataString(value)}");
        }
    }
}
