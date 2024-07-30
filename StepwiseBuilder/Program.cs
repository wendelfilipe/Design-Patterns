// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var car = CarBuilder.Create().OfType(CarType.Crossover).WithWheels(18).Build();

Console.WriteLine(car);

public enum CarType
{
    Sedan,
    Crossover
}

public class Car
{
    public CarType Type;
    public int WheelSize;
}

public interface ISpecifyCarType
{
    ISpecifyWheelSize OfType(CarType type);
}

public interface ISpecifyWheelSize
{
    IBuildCar WithWheels(int size);
}

public interface IBuildCar
{
    public Car Build();
}

public class CarBuilder
{
    private Car car = new Car();
    private class Impl : ISpecifyCarType, ISpecifyWheelSize, IBuildCar
    {
        public ISpecifyWheelSize OfType(CarType type)
        {
            car.Type = type;
            return this;
        }

        public IBuildCar WithWheels(int size)
        {
            if( car.type == CarType.Crossover && (size < 17 || size > 20))
            {
                throw new ArgumentException($"Wrong size of wheel for {car.Type}.");
            }
            if( car.type == CarType.Sedan && (size < 15 || size > 17))
            {
                throw new ArgumentException($"Wrong size of wheel for {car.Type}.");
            }

            car.WheelSize = size;
            return this;
        }

        public Car Build()
        {
            return car;
        }
    }
    public static ISpecifyCarType Create()
    {
        return new Impl();
    }
}