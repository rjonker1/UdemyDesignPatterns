using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DesignPatterns.Builder
{
    public class Tests
    {
        private static string Preprocess(string s)
        {
            return s.Trim().Replace("\r\n", "\n");
        }

        [Fact]
        public void EmptyTest()
        {
            var cb = new CodeBuilder("Foo");
            //Assert.That(Preprocess(cb.ToString()), Is.EqualTo("public class Foo\n{\n}"));
            Assert.Equal("public class Foo\n{\n}", Preprocess(cb.ToString()));
        }

        [Fact]
        public void PersonTest()
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Assert.Equal(@"public class Person
{
  public string Name;
  public int Age;
}", Preprocess(cb.ToString()));
//            Assert.That(Preprocess(cb.ToString()),
//                Is.EqualTo(
//                    @"public class Person
//{
//  public string Name;
//  public int Age;
//}"
//                ));
        }
    }
}
