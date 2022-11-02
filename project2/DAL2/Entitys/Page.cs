using System.Net;

namespace DAL2.Entitys;

public class Page : EntityBase
{
    public int ChapterId { get; set; }
    public Chapter Chapter { get; set; }
    public DateTime CratedAt { get; set; }
    
    public byte[] Image { get; set; }
    
    public string Content { get; set; }
    
}