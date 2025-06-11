namespace BookCatalog.Service.Models;

public class OpenLibrarySearchResult
{
    public int NumFound { get; set; }

    public int Start { get; set; }

    public List<OpenLibraryBook> Docs { get; set; } = [];
}
