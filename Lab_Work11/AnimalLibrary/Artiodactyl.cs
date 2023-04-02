using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    public class Artiodactyl : Mammal
    {

        protected string hornStyle;
        protected string[] artiArray = { "Баран", "Антилопа", "Газель", "Горный козёл", 
            "Лань", "Карликовая свинья", "Зубр", "Олень", "Косуля", "Лось" };

        protected string[] hornStyles = { "Карликовые", "Ветвистые", "Развесистые", "Клинообразные", "Винтообразные"};
        public string HornStyle
        {
            get { return hornStyle; }
            set { hornStyle = value; }
        }

        //конструктор, наследуемый от базового класса
        public Artiodactyl()
            : base()
        {
            hornStyle = "NoStyle";
        }

        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="name">название животного</param>
        /// <param name="age">возраст</param>
        /// <param name="habitat">естественное место обитания</param>
        /// <param name="isWoolen">покрытие шерстью</param>
        /// <param name="hornStyle">вид рогов</param>
        public Artiodactyl(string name, int age, string habitat,
            bool isWoolen, string hornStyle, int num)
            : base(name, age, habitat, isWoolen, num)
        {
            HornStyle = hornStyle;
        }

        public override void Init()
        {
            base.Init();
            HornStyle = Dialog.EnterString("Какой вид рогов у парнокопытного?", true);

        }

        public override void RandomInit()
        {
            Name = artiArray[random.Next(artiArray.Length)];
            Age = random.Next(1, 21);
            Habitat = habitatArray[random.Next(habitatArray.Length)];
            IsWoolen = Convert.ToBoolean(random.Next(0, 2));
            HornStyle = hornStyles[random.Next(hornStyles.Length)];
            id.number = random.Next(1, 5001);
        }

        public override bool Equals(object obj)
        {
            if (obj is Artiodactyl art)
            {
                return (this.Age == art.Age && this.IsWoolen == art.IsWoolen
                    && String.Compare(this.Name, art.Name) == 0
                    && String.Compare(this.Habitat, art.Habitat) == 0
                    && String.Compare(this.HornStyle, art.HornStyle) == 0);
            }
            else
                return false;
        }
        
        public new void Print()
        {
            Console.WriteLine($"Парнокопытное: {Name}; Возраст: {Age}; " +
                $"Ареал обитания: {Habitat}; Покрыто шерстью: {isWoolen}; Вид рогов: {HornStyle}; ID в зоопарке: {id}");
        }

        public override void Show()
        {
            Console.WriteLine($"Парнокопытное: {Name}; Возраст: {Age}; " +
                $"Ареал обитания: {Habitat}; Покрыто шерстью: {isWoolen}; Вид рогов: {HornStyle}; ID в зоопарке: {id}");
        }

        //метод поверхностного копирования
        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        //метод глубокого копирования
        public override object Clone()
        {
            return new Artiodactyl(Name, Age, Habitat, IsWoolen, HornStyle, id.number);
        }
    }
}
