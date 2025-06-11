using System.Text.Json.Serialization;

namespace BookCatalog.Service.Models;

public class OpenLibraryBook
{
    [JsonPropertyName("isbn")]
    public string? ISBN { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("author_name")]
    public List<string>? Authors { get; set; }

    [JsonPropertyName("first_publish_year")]
    public int? FirstPublishYear { get; set; }

    [JsonPropertyName("subject")]
    public List<string>? Subjects { get; set; }

    [JsonPropertyName("cover_i")]
    public int? CoverId { get; set; }

    public string? CoverImageUrl => CoverId != null
        ? $"https://covers.openlibrary.org/b/id/{CoverId}-L.jpg"
        : null;
}
