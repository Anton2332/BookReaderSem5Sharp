namespace DAL2.Entitys;

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
    
    public int BookStatus { get; set; }
    public Status Status { get; set; }
    
    public virtual ICollection<Author> Authors { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }

    public ICollection<Chapter> Chapters { get; set; }
    public ICollection<Rating> Ratings { get; set; }
}