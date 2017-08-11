using static System.Console;

namespace DesignPatterns.Prototype.CopyConstructors
{
    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

    public class Person
    {
        public readonly string[] Names;
        public readonly Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public Person(Person other)
        {
            Names = other.Names;
            Address = new Address(other.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    //public class CopyConstructorDemo
    //{
    //    public static void Main(string[] args)
    //    {
    //        var john = new Person(new []{"John", "Apple"}, new Address("Meadowbrooke Lane", 34));
    //        WriteLine(john);

    //        var jane = new Person(john);
    //        jane.Address.HouseNumber = 88;
    //        Write(jane);

    //        ReadLine();
    //    }
    //}
}
