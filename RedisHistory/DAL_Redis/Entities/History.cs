namespace DAL_Redis.Entities;

public class History
{
    public string UserName { get; set; }
    public List<HistoryItem> Items { get; set; }
    public History(string userName)
    {
        UserName = userName;
    }
}