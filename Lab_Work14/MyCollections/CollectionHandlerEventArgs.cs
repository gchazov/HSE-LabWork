using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    //класс-контейнер для хранения информации о событии
    public class CollectionHandlerEventArgs<T> : EventArgs
        where T: class, ICloneable, IInit<T>, new()
    {
        public string CollectionName { get; set; } = "";
        public string ChangeType { get; set; } = "";
        public T? Object { get; set; }

        public CollectionHandlerEventArgs(string collectionName ,string changeType, T @object)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            Object = @object;
        }
    }
}
