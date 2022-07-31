using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
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
}
