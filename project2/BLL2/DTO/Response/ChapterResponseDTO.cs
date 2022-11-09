namespace BLL2.DTO.Response;

public class ChapterResponseDTO
{
    public string? UserId { get; set; }
    
    public int BookId { get; set; }
    
    public int ChapterId { get; set; }
    public string ChapterName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime PublishDateTime { get; set; }
    public DateTime PremiumPublishDateTime { get; set; }
}