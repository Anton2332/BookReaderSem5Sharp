namespace BLL2.DTO.Response;

public class BookTagResponseDTO
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int TagId { get; set; }
    public string TagName { get; set; }
}