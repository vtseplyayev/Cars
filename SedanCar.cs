using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
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
}
