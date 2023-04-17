using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    //интерфейс, реализуемый в программе
    public interface IInit<T>: IShow
    {
        T Init();
        T RandomInit();

        T GetMaxID();
    }
}
