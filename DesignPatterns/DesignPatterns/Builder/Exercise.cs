using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DesignPatterns.Builder
{
    public class Class
    {
        public string Name { get; private set; }
        public List<Field> Fields { get; private set; }

        public void AddName(string name)
        {
            Name = name;
        }

        public void AddField(Field field)
        {
            if(Fields == null)
                Fields = new List<Field>();
            Fields.Add(field);
        }
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder
                .AppendLine($"public class {Name}")
                .AppendLine("{");


            if (Fields != null)
            {
                foreach (var field in Fields)
                {
                    stringBuilder.AppendLine($"  {field}");
                }
            }

            stringBuilder.AppendLine("}");
            return stringBuilder.ToString();
        }
    }

    public class Field
    {
        public string DataType { get; private set; }
        public string Name { get; private set; }
        
        public Field(string name, string dataType)
        {
            Name = name;
            DataType = dataType;
        }

        public override string ToString()
        {
            return $"public {DataType} {Name};";
        }
    }

    public class CodeBuilder
    {
        private readonly Class _class = new Class();

        public CodeBuilder(string className)
        {
            _class.AddName(className);
        }

        public CodeBuilder AddField(string name, string datatype)
        {
            _class.AddField(new Field(name, datatype));
            return this;
        }

        public override string ToString()
        {
            return _class.ToString();
        }
        
        public static implicit operator Class(CodeBuilder codeBuilder)
        {
            return codeBuilder._class;
        }

    }

    public class Program
    {
        //static void Main(string[] args)
        //{
        //    var codeBuilder = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
        //    WriteLine(codeBuilder);

        //    ReadLine();
        //}
    }


}
