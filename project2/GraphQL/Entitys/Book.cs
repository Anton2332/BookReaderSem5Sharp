namespace GraphQL.Entitys;

public class Book : EntityBase
{
    public byte[] Image { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    //     modelBuilder.Entity<YourEntityTypeHere>()
    // .Property( e => e.Text)
    //     .HasColumnType("text");
    public int LanguageId { get; set; }
    public Language Language { get; set; }
    
    public int StatusId { get; set; }
    public Status Status { get; set; }
    
    public ICollection<BookAuthor> BookAuthor { get; set; }
    public ICollection<BookCategory> BookCategory { get; set; }
    public ICollection<BookTag> BookTag { get; set; }

    public ICollection<Chapter> Chapters { get; set; }
    public ICollection<Rating> Ratings { get; set; }
}