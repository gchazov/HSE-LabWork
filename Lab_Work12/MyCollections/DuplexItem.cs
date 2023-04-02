using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary;

namespace MyCollections
{
    //определение элемента двунаправленного списка
    public class DuplexItem<T>
    {
        public T? Data { get; set; } //информационное поле
        public DuplexItem<T>? Next { get; set; } //последующий элемент (ссылка)
        public DuplexItem<T>? Prev { get; set; } //предшествующий элемент (ссылка)

        public DuplexItem() //конструктор без параметров
        { }

        public DuplexItem(T data) //к-тор с параметром
        {
            Data = data; 
        }

        public DuplexItem(T data, DuplexItem<T> prev)
        {
            Data = data;
            Prev = prev;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
