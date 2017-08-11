using static System.Console;

namespace DesignPatterns.Prototype.DeepCopyInterface
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }

    public class Address : IPrototype<Address>
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

        public Address DeepCopy()
        {
            return new Address(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

    public class Person : IPrototype<Person>
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

        public Person DeepCopy()
        {
            return new Person(Names, Address.DeepCopy());
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

    //        //var jane = new Person(john);
    //        var jane = john.DeepCopy();
    //        jane.Address.HouseNumber = 88;
    //        Write(jane);

    //        ReadLine();
    //    }
    //}
}
