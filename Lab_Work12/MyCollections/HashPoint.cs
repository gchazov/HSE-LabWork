using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    //класс-описание элемента хеш-таблицы
    public class HashPoint<T>
    {
        public int Key { get; set; } //ключ элемента
        public T? Value { get; set; } //информационное поле элемента

        public HashPoint<T>? Next { get; set; } //следующий элемент (в цепочке)

        public HashPoint(T? data = default) //конструктор с эл. по умолчанию
        {
            Value = data;
            Next = null;
            Key = GetHashCode();
        }

        public override string ToString() //для вывода через cw()
        {
            return Key.ToString() + ":" + Value.ToString();
        }

        public override int GetHashCode() //получение хеш-кода элемента
        {
            int hcode = 0;
            foreach (char letter in Value.ToString())
            {
                hcode += (int)letter;
            }
            return hcode;
        }

        public override bool Equals(object? obj) //переопределение Equals
        {
            return String.Compare(this.ToString(), obj.ToString()) == 0;
        }
    }
}
