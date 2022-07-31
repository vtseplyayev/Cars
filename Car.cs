using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
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
}
