namespace DAL1.Model;

public class Comments : BaseComments
{
    public int Id { get; set; }
    public virtual UserComments? User { get; set; }
}