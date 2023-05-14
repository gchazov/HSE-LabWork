using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    //класс-описание элемента хеш-таблицы
    //ИСПОЛЬЗУЕТСЯ КАК В 3, ТАК И В 4 ЧАСТИ РАБОТЫ!!!
    public class HashPoint<T>
        where T : IInit<T>, ICloneable
    {
        public T Key { get; internal set; } //ключ элемента
        public T Value { get; internal set; } //информационное поле элемента

        public HashPoint<T>? Next { get; internal set; } //следующий элемент (в цепочке)

        public HashPoint(T? data = default) //конструктор с эл. по умолчанию
        {
            Value = data;
            Next = null;
            Key = Value.GetBase();
        }

        public override string ToString() //для вывода через cw()
        {
            return Key.ToString() + " => " + Value.ToString();
        }

        public override int GetHashCode() //получение хеш-кода элемента
        {
            return Key.GetHashCode();
        }

        public override bool Equals(object? obj) //переопределение Equals для сравнения
        {
            return String.Compare(this.ToString(), obj.ToString()) == 0;
        }
    }
}
