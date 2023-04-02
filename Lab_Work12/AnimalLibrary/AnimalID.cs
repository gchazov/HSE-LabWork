using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    //класс-id животного в зоопарке
    public class AnimalId
    {
        public int number;
        public AnimalId(int num)
        {
            number = num;
        }
        public override bool Equals(object? obj)
        {
            if (obj is AnimalId num)
                return this.number == num.number;
            else
                return false;
        }

        public override string ToString()
        {
            return number.ToString();
        }

    }
}
