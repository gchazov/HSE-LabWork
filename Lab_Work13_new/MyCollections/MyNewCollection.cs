using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{

    public class MyNewCollection<T> : MyCollection<T>
        where T : class, IInit<T>, ICloneable, new()
    {
        public delegate void CollectionHandler(object source, CollectionHandlerEventArgs<T> args);

        public event CollectionHandler? CollectionCountChanged; //событие при добавления/удаления элемента
        public event CollectionHandler? CollectionReferenceChanged; //событие при изменении ссылки

        public string CollectionName { get; set; } = "NoNameCollection";   //название кроллекции
        public MyNewCollection(string name) //конструктор для создания нвоой коллекции
        {
            CollectionName = name;
            Table = Array.Empty<HashPoint<T>>();
        }

        public MyNewCollection(int capacity):base(capacity)
        { }

        public MyNewCollection():base() { }



        //обработчик события CollectionCountChanged
        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs<T> args)
        {
            CollectionCountChanged?.Invoke(source, args);
        }

        //обработчик события CollectionReferenceChanged
        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs<T> args)
        {
            CollectionReferenceChanged?.Invoke(source, args);
        }


        public override void Add(T item) //добавление и вызов обработчика события
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(CollectionName, "Добавление", item));
            base.Add(item);
        }

        public void AddDefault()    //добавление псевдослучайного объекта в коллекцию
        {
            var randomObject = new T().RandomInit();
            if (!this.Contains(randomObject))
            {
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(CollectionName, "Добавление", randomObject));
                base.Add(randomObject);
            }
        }

        public override bool Remove(T item)  //удаление элемента и вызов обработчика события
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(CollectionName, "Удаление", item));
            return base.Remove(item);
        }

        public override T? this[T key]
        {
            get => base[key];
            set
            {
                base[key] = value;
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs<T>(CollectionName, "Изменение элемента", base[key]));
            }
        }
    }
}
