using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        float CalcDistanceByFuel();
        float CalcMaxDistanceByFuel();
        string CalcTimeCar(float distance);
    }
}
