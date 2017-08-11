using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatterns.Prototype.ICloneable
{
    /* 
     * A partially or fully initialized object thaty you copy (clone) and make use of
     */
    public class Person : System.ICloneable //IClonable only offers shallow copy
    {
        public readonly string[] Names;
        public readonly Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        public object Clone()
        {
            return new Person(Names, Address); //shallow copy
        }
    }

    public class Address
    {
        public readonly string StreetName;
        public readonly int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }


    //public class ClonableDemo
    //{
    //    public static void Main(string[] args)
    //    {
    //        var person = new Person(new []{"John", "Smith"}, new Address("B Road", 34));
    //        WriteLine(person);

    //        var jane = (Person)person.Clone();
    //        WriteLine(jane);

    //        ReadLine();
    //    }
    //}
}
