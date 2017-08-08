using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace DesignPatterns.Builder
{
    /*BUILDER: 
     * when piecewise object construction is complicated provide and api for doing it succinctly
     * WHY?
     * 
     */
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

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var space = new string(' ', indentSize * indent);
            sb.Append($"{space}<{Name}>\n");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.Append(Text);
                sb.Append("\n");
            }

            foreach (var htmlElement in Elements)
            {
                sb.Append(htmlElement.ToStringImpl((indent + 1)));
            }

            sb.Append($"{space}</{Name}>\n");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    public class HtmlBuilder
    {
        private readonly string _rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            _rootName = rootName;
            root.Name = rootName;
        }

        public HtmlBuilder AddChild(string childName, string childText)
        {
            var element = new HtmlElement(childName, childText);
            root.Elements.Add(element);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement{ Name = _rootName};
        }
    }

    //public class Demo
    //{
    //    static void Main(string[] args)
    //    {
    //        ///*
    //        // * Life without builder
    //        // * */
    //        var hello = "hello";
    //        var stringBuilder = new StringBuilder();
    //        stringBuilder.Append("<p>");
    //        stringBuilder.Append(hello);
    //        stringBuilder.Append("</p>");
    //        WriteLine(stringBuilder);

    //        var words = new[] { "hello", "world" };
    //        stringBuilder.Clear();
    //        stringBuilder.Append("<ul>");
    //        foreach (var word in words)
    //        {
    //            stringBuilder.AppendFormat("<li>{0}</li>", word);
    //        }
    //        stringBuilder.Append("</ul>");
    //        WriteLine(stringBuilder);

    //        //ordinary non-fluent builder
    //        var builder = new HtmlBuilder("ul");
    //        builder.AddChild("li", "Hello");
    //        builder.AddChild("li", "World");
    //        WriteLine(builder.ToString());

    //        //fluent builder
    //        builder = new HtmlBuilder("ul");
    //        builder.AddChild("li", "Hello").AddChild("li", "World");
    //        WriteLine(builder.ToString());

    //        //faceted Builder

    //        ReadLine();

    //    }

        
    //}


}
