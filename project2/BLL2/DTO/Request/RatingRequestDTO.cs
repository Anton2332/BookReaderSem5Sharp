namespace BLL2.DTO.Request;

public class RatingRequestDTO
{
    public string UserId { get; set; }
    
    public float Ball { get; set; }
    
    public int BookId { get; set; }
}