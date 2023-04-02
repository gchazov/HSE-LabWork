using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//помещён в namespace для демонстрации класса на диаграмме классов
namespace AnimalLibrary
{
    //класс, не относящийся к иерархии Library, но реализующий IInit
    public class Car:IInit, IShow
    {
        string name;
        int maxSpeed;
        Random random = new Random();
        string[] carArray = {"ВАЗ 2114", "BMW M5 e60", "Toyota Camry XV70",
        "Audi RS6 C7", "Mercedes-Benz S-Klasse w223", "Volkswagen Toureg",
        "Honda Civic Type-R", "Toyota Mark II", "ВАЗ 2105", "Toyota GT86"};

        //свойство для марки машины
        public string Name
        {
            get { return name; }
            set
            {
                if (String.Compare(value.ToString(), "") == 0)
                {
                    Dialog.ColorText("Полю name не может быть пустым," +
                        " ему присвоено значение NoName");
                    name = "NoName";
                }
                else { name = value; }
            }
        }

        //свойство для максимальной скорости авто
        public int MaxSpeed
        {
            get { return maxSpeed; }
            set
            {
                if (value > 500)
                {
                    Dialog.ColorText("Не придумали пока таких быстрых машин!" +
                        " Полю maxSpeed присвоено значение 500");
                    maxSpeed = 500;
                }
                else if (value < 0)
                {
                    Dialog.ColorText("Автомобиль не может иметь отрицательную скорость! " +
                        "Полю maxSpeed присвоено значение 0");
                    maxSpeed = 0;
                }
                else { maxSpeed = value; }
            }
        }

        //конструктор с параметрами по умолчанию
        public Car(string name = "NoName", int maxSpeed = 0)
        {
            Name = name;
            MaxSpeed = maxSpeed;   
        }

        public void Init()
        {
            Name = Dialog.EnterString("Введите название автомобиля:", true);
            MaxSpeed = Dialog.EnterNumber("Введите максимальную скорость авто:", 0, 500);
        }

        public void RandomInit()
        {
            Name = carArray[random.Next(carArray.Length)];
            MaxSpeed = random.Next(120, 300);
        }

        public void Show()
        {
            Console.WriteLine($"Автомобиль: {Name}; Максимальная скорость: {MaxSpeed}");
        }

        public override bool Equals(object? obj)
        {
            if (obj is Car car)
            {
                return (this.MaxSpeed == car.MaxSpeed
                    && String.Compare(this.Name, car.Name) == 0);
            }
            else
                return false;
        }
    }
}
