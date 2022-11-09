namespace BLL2.DTO.Request;

public class PageRequestDTO
{
    public int ChapterId { get; set; }
    
    public DateTime CratedAt { get; set; }
    public byte[] Image { get; set; }
    public string Content { get; set; }
}