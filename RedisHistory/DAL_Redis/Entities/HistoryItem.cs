namespace DAL_Redis.Entities;

public class HistoryItem
{
    public int BookId { get; set; }
    public int ChapterId { get; set; }
    public DateTime ReadAt { get; set; }
}