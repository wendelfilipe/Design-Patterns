// See https://aka.ms/new-console-template for more information
using System.Drawing;
using System.Text;

Console.WriteLine("Hello, World!");

var hello = "hello";
var sb = new StringBuilder();
sb.Append("<p>");
sb.Append(hello);
sb.Append("</p>");
Console.WriteLine(sb);

var words = new[] {"hello", "world"};
sb.Clear();
sb.Append("<ul>");
foreach(var word in words)
{
    sb.AppendFormat("<li>{0}</li>", word);
}
sb.Append("</ul>");

Console.WriteLine(sb);

var builder = new HtmlBulder("ul");
builder.AddChild("li", "hello");
builder.AddChild("li", "world");
Console.WriteLine(builder.ToString());

public class HtmlElement
{
    public string Name, Text;
    public List<HtmlElement> Elements = new List<HtmlElement>();
    private const int indentSize = 2;

    public HtmlElement()
    {

    }

   public HtmlElement(string name, string text)
   {
        Name = name;
        Text = text;
   }

   private string ToStringImp(int indent)
    {
        var sb = new StringBuilder();
        var i = new string(' ', indentSize * indent);
        sb.AppendLine($"{i}<{Name}>");

        if (!string.IsNullOrWhiteSpace(Text))
        {
            sb.Append(new string(' ', indentSize * (indent + 1)));
            sb.AppendLine(Text);
        }

        foreach ( var e in Elements)
        {
            sb.Append(e.ToStringImp(indent + 1));
        }
        sb.AppendLine($"{i}</{Name}>");

        return sb.ToString();
    }

    public override string ToString()
    {
        return ToStringImp(0);
    }
}

public class HtmlBulder
{
    private readonly string rootName;
    HtmlElement root = new HtmlElement();

    public HtmlBulder(string rootName)
    {
        this.rootName = rootName;
        root.Name = rootName;
    }

    public void AddChild(string childName, string childText)
    {
        var e = new HtmlElement(childName, childText);
        root.Elements.Add(e);
    }

    public override string ToString()
    {
        return root.ToString();
    }

    public void Clear()
    {
        root = new HtmlElement{Name = rootName};    
    }
}