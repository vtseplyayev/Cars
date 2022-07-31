using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        public float CalcDistanceByFuel();
        public float CalcMaxDistanceByFuel();
        public string CalcTimeCar(float distance);
    }
}
