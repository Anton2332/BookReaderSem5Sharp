namespace BLL2.DTO.Response;

public class BookCategoryResponseDTO
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}