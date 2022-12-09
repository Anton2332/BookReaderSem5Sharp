namespace API3.Config;

public class UrlsConfig
{
    public class BookOperations
    {
        public static string GetItemById(int id) => $"https://localhost:7045";
    }
    
    public string Book { get; set; }
    
    public string GrpcBook { get; set; }
}