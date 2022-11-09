namespace BLL2.DTO.Response;

public class BookAuthorResponseDTO
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
}