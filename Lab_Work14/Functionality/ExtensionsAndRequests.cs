using AnimalLibrary;
using MyCollections;
using System.IO.Pipes;

namespace Functionality
{
    //методы Linq для первой части работы (словарь очередей)
    public static class ExtensionsAndRequests
    {
        //отбор животных по условию для словаря (через расширение)
        public static IEnumerable<Animal> Where<Animal>(this Dictionary<string, Queue<Animal>> dict, Func<Animal, bool> predicate)
        {
            foreach (var keyValuePair in dict)
            {
                foreach(var animal in keyValuePair.Value)
                {
                    if (predicate(animal))
                        yield return animal;
                }
            }
        }

        //отбор животных по условию для хеш-таблицы (через расширение)
        public static IEnumerable<Animal> WhereMyCollection<Animal>(this IEnumerable<Animal> source, Func<Animal, bool> predicate)
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
                    && comparer.Compare(keySelector(element), keySelector(result)) < 0)
                    result = element;
            }
            return result;
        }

        //расширение для нахождения элемента с максимальным айди в коллекции
        public static TSource? MaxByCustom<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
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
        
    }
}
