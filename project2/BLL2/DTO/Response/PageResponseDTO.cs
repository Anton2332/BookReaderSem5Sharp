namespace BLL2.DTO.Response;

public class PageResponseDTO
{
    public int Id { get; set; }
    public int ChapterId { get; set; }
    
    public DateTime CratedAt { get; set; }
    public byte[] Image { get; set; }
    public string Content { get; set; }
}