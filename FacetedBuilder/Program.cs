// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var pb = new PersonBuilder();

Person person = pb.Lives.At("123 Lodon Road").In("London").WithPostCode("SWA142").Works.At("MyFinances").AsA("CEO").Earning(0);
Console.WriteLine(person);

public class Person
{
    public string StreetAddress, PostCode, City;

    public string Companyname, Position;
    public int AnnualIncome;

    public override string ToString()
    {
        return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(PostCode)}: {PostCode}, {nameof(City)}: {City}";
    }
}

public class PersonBuilder
{
    protected Person person = new Person();

    public PersonJobBuilder Works => new PersonJobBuilder(person);

    public PersonAddressBuilder Lives = new PersonAddressBuilder(person);

    public static implicit operator Person(PersonBuilder pb)
    {
        return pb.person;
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

    public PersonAddressBuilder WithPostCode(string postCode)
    {
        person.PostCode = postCode;
        return this;
    }

    public PersonAddressBuilder In(string city)
    {
        person.City = city;
        return this;
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
        person.Companyname = companyName;
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