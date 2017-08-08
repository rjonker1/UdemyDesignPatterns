﻿using static System.Console;

namespace DesignPatterns.Builder
{
    /*
     * Several Builders required to build a facade  (facade pattern)
     */

    public class Person
    {
        //Address
        public string StreetAddress, Postcode, City;

        //company info
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }


    public class PersonBuilder //facade
    {
        //reference!
        protected Person person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public PersonAddressBuilder Stays => new PersonAddressBuilder(person);

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder InCity(string city)
        {
            person.City = city;
            return this;
        }
    }

    //public class Demo
    //{
    //    static void Main(string[] args)
    //    {
    //        var pb =new PersonBuilder();
    //        Person person = pb
    //            .Works.At("Sit").AsA("Enigeer").Earning(123000)
    //            .Stays.At("34 Happy Ave").InCity("Benoni").WithPostCode("2345");

    //        WriteLine(person);

    //        ReadLine();
    //    }
    //}
}
