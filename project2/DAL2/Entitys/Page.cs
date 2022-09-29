using System.Xml.Linq;

namespace DAL2.Entitys;

public class Page : EntityBase
{
    public int ChapterId { get; set; }
    public Chapter Chapter { get; set; }
    public string XmlContent { get; set; }
    public XElement XmlValueWrapper
    {
        get { return XElement.Parse(XmlContent); }
        set { XmlContent = value.ToString(); }
    }
    // public XmlEntityMap()
    // {
    //     // ...
    //     this.Property(c => c.XmlContent).HasColumnType("xml");
    //
    //     this.Ignore(c => c.XmlValueWrapper);
    // }
}