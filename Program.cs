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
    public class SedanCar : Car
    {
        private int passengerCount = 0;
        public int PassengerCount
        {
            get { return passengerCount; }
            set { CheckMaxPassenger(value); }
        }
        public int PassengerMax { get; set; }

        // each 1 passenger decrease 6% max power reserve
        private void CheckMaxPassenger(int passenger)
        {
            if (passenger > PassengerMax)
            {
                passengerCount = PassengerMax;
                Console.WriteLine("Количество пассажиров превышено. Установлено допустимое максимальное значение!");
            }
            else
                passengerCount = passenger;
        }

        public float CalcPowerReserve()
        {
            if (PassengerCount >= 1 && PassengerCount <= PassengerMax)
            {
                var passengerPercent = 100 - PassengerCount * 6;
                return (passengerPercent * CalcDistanceByFuel() / 100);
            }
            else
            {
                return CalcDistanceByFuel();
            }
        }

        public float CalcFuelByDistance(float distance)
        {
            var passengerPercent = 100 + PassengerCount * 6;

            var fuelCorrect = FuelRate * passengerPercent / 100;

            return distance / 100 * fuelCorrect;
        }
    }

    public class SportCar : Car
    {

    }

    public class CargoCar : Car
    {
        public float MaxCargoWeight { get; set; }

        private float currentCargoWeight;
        public float CurrentCargoWeight { get { return currentCargoWeight; } set { CheckMaxWeigth(value); } }

        // each 200kg decrease 4% max power reserve
        private void CheckMaxWeigth(float weigth)
        {
            if (weigth > MaxCargoWeight)
            {
                currentCargoWeight = MaxCargoWeight;
                Console.WriteLine("Количество веса превышено. Установлено допустимое максимальное значение!");
            }
            else
                currentCargoWeight = weigth;
        }

        private int CalcWeightIndex()
        {
            int count = 1;
            var tempCargoWeigth = currentCargoWeight;

            if (tempCargoWeigth > 200)
            {
                do
                {
                    tempCargoWeigth -= 200;
                    count++;

                } while (tempCargoWeigth > 200);
            }
            else if (tempCargoWeigth == 0)
                count = 0;

            return count;
        }

        public float CalcFuelByDistance(float distance)
        {

            var weigthPercent = 100 + CalcWeightIndex() * 4;
            var fuelCorrect = FuelRate * weigthPercent / 100;

            return distance / 100 * fuelCorrect;
        }

        public float CalcPowerReserve()
        {
            int count = CalcWeightIndex();

            if (count >= 1)
            {
                var weigthPercent = 100 - count * 4;
                return (weigthPercent * CalcDistanceByFuel() / 100);
            }
            else
            {
                return CalcDistanceByFuel();
            }
        }
    }

    public class Car : ICar
    {
        public string Name { get; set; } // for test
        public CarType CarType { get; set; }
        public float MaxSpeed { get; set; } // km/h
        public float FuelRate { get; set; } // l/100km
        public float MaxFuelCapacity { get; set; } // l
        public float CurrentFuelCapacity { get; set; } // l
        public float PowerReserve { get; set; } // km

        public float CalcDistanceByFuel()
        {
            return CurrentFuelCapacity / FuelRate * 100; // return by km
        }

        public float CalcMaxDistanceByFuel()
        {
            return MaxFuelCapacity / FuelRate * 100; // return by km
        }

        public string CalcTimeCar(float distance = 0)
        {
            if (distance > PowerReserve)
                return "0";
            else
            {
                float calc = distance / MaxSpeed * 60;

                return TimeSpan.FromMinutes(calc).ToString();
            }
        }
    }

    public interface ICar
    {
        float CalcDistanceByFuel();
        float CalcMaxDistanceByFuel();
        string CalcTimeCar(float distance);
    }

    public enum CarType
    {
        Car = 1,
        SportCar = 2,
        Cargo = 3
    }
}
