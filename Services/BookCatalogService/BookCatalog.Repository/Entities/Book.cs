namespace BookCatalog.Repository.Entities;

public class Book
{
    public int Id { get; set; }
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public byte[]? CoverImage { get; set; }
    public DateOnly PublicationDate { get; set; }
    public decimal Price { get; set; }
    public int PageAmount { get; set; }
    public Genre Genre { get; set; }
    public Author Author { get; set; }
    public int AuthorId { get; set; }
}
