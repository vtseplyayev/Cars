using System;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            SedanCar car = new SedanCar
            {
                Name = "Lada",
                CarType = CarType.Car,
                MaxSpeed = 100,
                FuelRate = 10,
                MaxFuelCapacity = 50,
                CurrentFuelCapacity = 30,
                PassengerMax = 4,
                PassengerCount = 1
            };

            car.PowerReserve = car.CalcPowerReserve();

            Console.WriteLine($"Авто {car.Name}");
            Console.WriteLine($"При максимальном количестве топлива {car.MaxFuelCapacity}л. при расходе {car.FuelRate}л./100км. может проехать: {car.CalcMaxDistanceByFuel()}км.");
            Console.WriteLine($"При текущем количестве топлива {car.CurrentFuelCapacity}л. при расходе {car.FuelRate}л./100км. может проехать: {car.CalcDistanceByFuel()}км.");
            Console.WriteLine($"С пассажиром/ами={car.PassengerCount} может проехать расстояние={car.PowerReserve}");

            int carDistance = 100;

            Console.WriteLine($"Для того чтобы проехать дистанцию {carDistance}км. с дополнительными пассажиром/ами {car.PassengerCount}, необходимо {car.CalcFuelByDistance(carDistance)}л. топлива ");

            if (car.CalcTimeCar(carDistance) != "0")
                Console.WriteLine($"Авто проедет дистанцию {carDistance}км. со скорость {car.MaxSpeed}км/ч при текущем запасе хода {car.PowerReserve}км за {car.CalcTimeCar(carDistance)} ");
            else
                Console.WriteLine($"Авто не проедет дистанцию {carDistance}км. при текущем запасе хода {car.PowerReserve}км.");

            Console.WriteLine();

            CargoCar track = new CargoCar()
            {
                Name = "Kamaz",
                CarType = CarType.Cargo,
                MaxSpeed = 80,
                FuelRate = 20,
                MaxFuelCapacity = 200,
                CurrentFuelCapacity = 50,
                MaxCargoWeight = 2000,
                CurrentCargoWeight = 200
            };

            track.PowerReserve = track.CalcPowerReserve();

            Console.WriteLine($"Авто {track.Name}");
            Console.WriteLine($"При максимальном количестве топлива {track.MaxFuelCapacity}л. при расходе {track.FuelRate}л./100км. может проехать: {track.CalcMaxDistanceByFuel()}км.");
            Console.WriteLine($"При текущем количестве топлива {track.CurrentFuelCapacity}л. при расходе {track.FuelRate}л./100км. может проехать: {track.CalcDistanceByFuel()}км.");
            Console.WriteLine($"С грузом={track.CurrentCargoWeight}кг. может проехать расстояние={track.PowerReserve}");

            int trackDistance = 100;

            Console.WriteLine($"Для того чтобы проехать дистанцию {trackDistance}км. с дополнительными весом {track.CurrentCargoWeight}, необходимо {track.CalcFuelByDistance(trackDistance)}л. топлива ");

            if (track.CalcTimeCar(trackDistance) != "0")
                Console.WriteLine($"Авто проедет дистанцию {trackDistance}км. со скорость {track.MaxSpeed}км/ч при текущем запасе хода {track.PowerReserve}км за {track.CalcTimeCar(trackDistance)} ");
            else
                Console.WriteLine($"Авто не проедет дистанцию {trackDistance}км. при текущем запасе хода {track.PowerReserve}км");

            Console.WriteLine();
        }
    }

    public enum CarType
    {
        Car = 1,
        SportCar = 2,
        Cargo = 3
    }
}
