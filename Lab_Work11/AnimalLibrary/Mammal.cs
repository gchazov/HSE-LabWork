using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    public class Mammal : Animal
    {
        protected bool isWoolen;
        string[] mammalArray = { "Броненосец", "Слон", "Коала", "Ёж", "Бурый медведь",
            "Муравьед", "Панда", "Заяц-русак", "Носорог", "Амурский тигр", "Капибара" };

       
        public bool IsWoolen
        {
            get { return isWoolen; }
            set { isWoolen = value; }
        }

        //добавление поля "наличие шерсти"
        public Mammal() : base()
        {
            isWoolen = true;
        }

        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="name">название животного</param>
        /// <param name="age">возраст животного</param>
        /// <param name="habitat">естественное место обитания</param>
        /// <param name="isWoolen">покрытие шерстью</param>
        public Mammal(string name, int age, string habitat, bool isWoolen, int num)
            : base(name, age, habitat, num)
        {
            IsWoolen = isWoolen;
        }

        public override void Init()
        {
            base.Init();
            IsWoolen = Dialog.EnterBool("Покрыто ли животное шерстью?");
        }

        public override void RandomInit()
        {
            Name = mammalArray[random.Next(mammalArray.Length)];
            Age = random.Next(1, 21);
            Habitat = habitatArray[random.Next(habitatArray.Length)];
            IsWoolen = Convert.ToBoolean(random.Next(0, 2));
            id.number = random.Next(1, 5001);
        }


        public override bool Equals(object obj)
        {
            if (obj is Mammal mammal)
            {
                return (this.Age == mammal.Age && this.IsWoolen == mammal.IsWoolen
                    && String.Compare(this.Name, mammal.Name) == 0
                    && String.Compare(this.Habitat, mammal.Habitat) == 0);
            }
            else
                return false;
        }

        public new void Print()
        {
            Console.WriteLine($"Млекопитающее: {Name}; Возраст: {Age}; Ареал обитания: {Habitat}; Покрыто шерстью: {isWoolen}; ID в зоопарке: {id}");
        }
        public override void Show()
        {
            Console.WriteLine($"Млекопитающее: {Name}; Возраст: {Age}; Ареал обитания: {Habitat}; Покрыто шерстью: {isWoolen}; ID в зоопарке: {id}");
        }

        //метод поверхностного копирования
        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        //метод глубокого копирования
        public override object Clone()
        {
            return new Mammal(Name, Age, Habitat, IsWoolen, id.number);
        }
    }
}
