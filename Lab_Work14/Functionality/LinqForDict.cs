using AnimalLibrary;

namespace Functionality
{
    //методы Linq для первой части работы (словарь очередей)
    public class LinqForDict
    {
        //животные, которые старше заданного значения
        public static IEnumerable<Animal> AnimalsOlderThan(Dictionary<string, Queue<Animal>> animalSections, int value)
        {
            return from section in animalSections
                         from animal in section.Value
                         where animal.Age > value
                         select animal;
        }

        //животные, которые младше заданного значения
        public static IEnumerable<Animal> AnimalsYoungerThan(Dictionary<string, Queue<Animal>> animalSections, int value)
        {
            return from section in animalSections
                   from animal in section.Value
                   where animal.Age < value
                   select animal;
        }
    }
}
