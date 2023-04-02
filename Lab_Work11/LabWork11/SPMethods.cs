using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LabWork11
{
    //методы и запросы для 2 части работы
    public class SPMethods
    {
        //добавляем случайную пару ключ-значение в словарь
        public static void AddRandomToDict(ref SortedDictionary<int, Animal> animalDict, int amount)
        {
            
            //amount - количество добавляемых элементов
            for (int i = 0; i < amount; i++)
            {
                bool isAdded = false;
                switch (Program.random.Next(1, 5))
                {   //рандомизация случайного метода
                    case 1:
                        do
                        {
                            //использование блока трай-кетч
                            try
                            {
                                var animal = new Animal();
                                animal.RandomInit();
                                //пытаемся добавить рандомизированный объект в словарик
                                animalDict.Add(animal.id.number, animal);

                                //если успех, то выходим из цикла
                                isAdded = true;
                            }
                            catch (ArgumentException)
                            {
                                //если ловим исключением,заходим в цикл заново
                            }
                        } while (!isAdded);
                        break;

                    case 2:
                        do
                        {
                            //здесь и далее то же самое, что и в кейсе 1
                            try
                            {
                                var animal = new Bird();
                                animal.RandomInit();
                                animalDict.Add(animal.id.number, animal);
                                isAdded = true;
                            }
                            catch (ArgumentException)
                            { }
                        } while (!isAdded);
                        break;
                    case 3:
                        do
                        {
                            try
                            {
                                var animal = new Mammal();
                                animal.RandomInit();
                                animalDict.Add(animal.id.number, animal);
                                isAdded = true;
                            }
                            catch (ArgumentException)
                            { }
                        } while (!isAdded);
                        break;

                    case 4:
                        do
                        {
                            try
                            {
                                var animal = new Artiodactyl();
                                animal.RandomInit();
                                animalDict.Add(animal.id.number, animal);
                                isAdded = true;
                            }
                            catch (ArgumentException)
                            { }
                        } while (!isAdded);
                        break;
                }
            }
        }

        //очистка словаря
        public static void ClearDict(ref SortedDictionary<int, Animal> animalDict)
        {
            animalDict.Clear();
        }

        //запрос на самое молодое животное словаря
        public static Animal YoungestAnimal (SortedDictionary<int, Animal> animalDict)
        {
            int minAge = 21; //недостижимый возраст для иерархии Animal
            var animalYoungest = new Animal();
            foreach (KeyValuePair<int, Animal> animal in animalDict)
            {
                if (animal.Value.Age < minAge)
                {
                    minAge = animal.Value.Age;
                    animalYoungest = animal.Value;
                }
            }
            return animalYoungest;
        }
        
        //3 запроса на определённый тип животных (как в очереди почти)
        public static List<Animal> GetTypeRequest(int choice, SortedDictionary<int, Animal> animalDict)
        {
            //для choice
            //1 - млекопитающие
            //2 - птицы
            //3 - парнокопытные
            Animal animalEx = new(); //успрощённое создание объекта
            Animal[] animals1 = { new Mammal(), new Bird(), new Artiodactyl() };

            //по умолчанию пусть тип будет Animal (его всё равно нет в меню поиска)
            Type typeName = animalEx.GetType();
            switch (choice)
            {
                case 1:
                    typeName = animals1[0].GetType();
                    break;
                case 2:
                    typeName = animals1[1].GetType();
                    break;
                case 3:
                    typeName = animals1[2].GetType();
                    break;
            }
            //создание списка для подходящих объектов
            List<Animal> result = new List<Animal>();
            foreach (KeyValuePair<int, Animal> animal in animalDict)
            {
                //создаём переменную для определения типа
                var animal1 = animal;
                if (animal1.Value.GetType() == typeName)
                    result.Add(animal1.Value);
            }
            return result;
        }

        //клонирование сортированного словаря
        public static SortedDictionary<int, Animal> CloneDict(SortedDictionary<int, Animal> animalDict)
        {
            //используем ToDictionary() для создания клона
            var cloneDict = new Dictionary<int, Animal>();
            foreach (KeyValuePair<int, Animal> animal in animalDict)
            {
                cloneDict.Add(animal.Key, (Animal)animal.Value.Clone());
            }
            SortedDictionary<int, Animal> cloneSortDict = new(cloneDict);
            return cloneSortDict;
        }
    }
}
