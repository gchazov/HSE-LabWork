using AnimalLibrary;
using MyCollections;
using System.IO.Pipes;

namespace Functionality
{
    public static class ExtensionsAndRequests
    {
        #region Requests
        //запрос на количество животных из определённого ареала обитания
        public static int HabitatCount(Dictionary<string, Queue<Animal>> animalSections,
            string animalHabitat)
        {
            return (from section in animalSections
             from animal in section.Value
             where animal.Habitat == animalHabitat
             select animal).Count();
        }

        //запрос на животных, которые меньше определённого возраста
        public static IEnumerable<Animal> AnimalsYoungerThan(Dictionary<string, Queue<Animal>> animalSections,
            int ageCompare)
        {
            return animalSections.SelectMany(section => section.Value).Where(animal => animal.Age < ageCompare);
        }


        //запрос на средний возраст животных одного типа
        public static int AverageAgeOfType(Dictionary<string, Queue<Animal>> animalSections,
            string animalType)   //тип здесь не в смысле Animal или Bird, а Пеликан или Медведь
        {
            var sequence = from section in animalSections
                           from animal in section.Value
                           where animal.Name == animalType
                           select animal;
            return sequence.Count() != 0 ? (int)sequence.Average(x => x.Age): 0;
        }

        //запрос на группировку по ареалу обитания
        public static IEnumerable<IGrouping<string, Animal>> GroupByHabitat(Dictionary<string, Queue<Animal>> animalSections)
        {
            return (from queue in animalSections
                    from animal in queue.Value
                    select animal).GroupBy(x => x.Habitat);
        }

        //запрос на количество животных определённого вида
        public static int NameCount(MyCollection<Animal> animals,
            string animalType)
        {
            return (from animal in animals
                    where animal.Name == animalType
                    select animal).Count();
        }

        //запрос на группировку по типу
        public static IEnumerable<IGrouping<string, Animal>> GroupByType(MyCollection<Animal> animals)
        {
            return (from animal in animals
                    select animal).GroupBy(x => x.GetType().Name);
        }
        #endregion

        #region Extensions

        //запрос на количество животных из определённого ареала обитания
        public static int HabitatCountExtension(Dictionary<string, Queue<Animal>> animalSections,
            string animalHabitat)
        {
            return animalSections.SelectMany(section => section.Value).Count(animal => animal.Habitat == animalHabitat);
        }

        //запрос на пересечение множеств (животные одного вида в двух секциях)
        public static IEnumerable<Animal> QueueIntersection(Dictionary<string, Queue<Animal>> animalSections)
        {
            return animalSections.First().Value
                .IntersectBy(animalSections.Last().Value
                .Select(x => x.Name), y => y.Name);
        }

        //запрос на пересечение двух коллекций типа MyColleciton
        public static IEnumerable<Animal> MyCollectionIntersection(MyCollection<Animal> myCollection,
            MyCollection<Animal> myCollectionAddition)
        {
            return myCollection.IntersectBy(myCollectionAddition.Select(x => x.Name), x => x.Name);
        }

        //запрос выбор объектов которые старше заданного значения
        public static IEnumerable<Animal> OlderThan(MyCollection<Animal> myCollection,
            int ageToCompare)
        {
            return myCollection.Where(animal => animal.Age > ageToCompare);
        }

        //отбор животных по условию для словаря (через расширение)
        public static IEnumerable<Animal> WhereCustomDictionary<Animal>(this Dictionary<string, Queue<Animal>> dict, Func<Animal, bool> predicate)
        {
            foreach (var keyValuePair in dict)  //перебираем каждую
            {
                foreach(var animal in keyValuePair.Value)
                {
                    if (predicate(animal))
                        yield return animal;
                }
            }
        }

        //отбор животных по условию для хеш-таблицы (через расширение)
        public static IEnumerable<Animal> WhereCustom<Animal>(this IEnumerable<Animal> source, Func<Animal, bool> predicate)
        {
            foreach (var animal in source)
            {
                if (predicate(animal))
                    yield return animal;
            }
        }

        //расширение для нахождения элемента с минимальным айди в коллекции
        public static TSource? MinByCustom<TSource, TKey>(this IEnumerable<TSource> source,
           Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            //создание нового листа
            List<TSource> sourceList = new();
            foreach (var sourceItem in source)
            {
                if (sourceItem != null) //неnullовые элементы добавляем в лист
                    sourceList.Add(sourceItem);
            }
            //выбираем первый элемент (чтоб было с чем сравнивать) и удаляем его тут же
            TSource result = sourceList[0];
            sourceList.RemoveAt(0);

            foreach (var element in sourceList)
            {
                if (element != null
                    //если поле перебираемого < поле сравниваемого, то присваиваем
                    && comparer.Compare(keySelector(element), keySelector(result)) < 0)
                    result = element;
            }
            return result;
        }

        //расширение для нахождения элемента с максимальным айди в коллекции
        public static TSource? MaxByCustom<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            //логика та же, что и при минимуме, тоьлко наобороот
            List<TSource> sourceList = new();
            foreach (var sourceItem in source)
            {
                if (sourceItem != null)
                    sourceList.Add(sourceItem);
            }
            TSource result = sourceList[0];
            sourceList.RemoveAt(0);

            foreach (var element in sourceList)
            {
                if (element != null
                    && comparer.Compare(keySelector(element), keySelector(result)) > 0)
                    result = element;
            }
            return result;
        }

        //расширение для нахождения среднего возраста животных в коллекции
        public static int AverageAge(this MyCollection<Animal> source) //здесь не придумал как обобщить, да и смысл...
        {
            int result = 0;
            foreach (var animal in source)
            {
                result += animal.Age;
            }
            return result / source.Count;
        }

        //кастомный сортировщик по выбранному полю
        public static IEnumerable<TSource> OrderCustom<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            List<TSource> result = new();
            foreach (var sourceItem in source)
            {
                if (sourceItem != null)
                    result.Add(sourceItem);
            }
            
            while (result.Count > 0)
            {
                TSource minimal = result.First();
                int minimalIndex = 0;
                for (int i = 1; i < result.Count; i++)
                {
                    var key1 = keySelector(result[i]);
                    var key2 = keySelector(minimal);

                    if (comparer.Compare(key1, key2) < 0)
                    {
                        minimal = result[i];
                        minimalIndex = i;
                    }
                }
                result.RemoveAt(minimalIndex);
                yield return minimal;
            }
        }

        //кастомный сортировщик по выбранному полю
        public static IEnumerable<TSource> OrderByDescendingCustom<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            List<TSource> result = new();
            foreach (var sourceItem in source)
            {
                if (sourceItem != null)
                    result.Add(sourceItem);
            }

            while (result.Count > 0)
            {
                TSource maximal = result.First();
                int maximalIndex = 0;
                for (int i = 1; i < result.Count; i++)
                {
                    var key1 = keySelector(result[i]);
                    var key2 = keySelector(maximal);

                    if (comparer.Compare(key1, key2) > 0)
                    {
                        maximal = result[i];
                        maximalIndex = i;
                    }
                }
                result.RemoveAt(maximalIndex);
                yield return maximal;
            }
        #endregion
        }

    }
}
