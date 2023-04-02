using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWork11;
using AnimalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionTesting
{
    //тестирование всего, что связано с TestCollections
    [TestClass]
    public class CollectionsTesting
    {
        [TestMethod]
        public void TestSizeChanges() //тест конструктора, свойств и методов
        {
            TestCollections testCollections = new TestCollections();
            testCollections.RandomInit(500);
            testCollections.AddElements(500);
            testCollections.DeleteElements(3);
            testCollections.DeleteElements(2);
            int size = testCollections.GetSize();

            Assert.AreEqual(995, size);
        }

        [TestMethod]
        public void TestCollectionValues() //тест установки 1, серединного и посл. значений
        {
            //тест  новых свойств
            TestCollections tc = new();
            var col1 = tc.Collection1;
            var col2 = tc.Collection2;
            var col3 = tc.Collection3;
            var col4 = tc.Collection4;

            tc.RandomInit(10);
            tc.AddElements(5);
            tc.SetValues();
            Bird el1 = tc.GetElement("first");
            Bird el2 = tc.GetElement("middle");
            Bird el3 = tc.GetElement("last");
            var el4 = tc.GetElement("notFound");
            var el5 = tc.GetElement("idkWhatTOWRITEHERE"); //по умолчанию свитч

            tc.AddElements(10);
            Bird newEl = tc.GetElement("last");
            //значения не были установлены, поэтому не произойдут изменения

            Assert.AreEqual(el3, newEl);
        }


        //почему бы не проверить время поиска элементов? (сравнить, правильнее) для 3 части
        [TestMethod]
        public void TestSearchingTime1() //тест времени поиска в 1 и 3 коллекциях
        {
            TestCollections testCollections = new();
            testCollections.RandomInit(1000);
            testCollections.SetValues();
            Bird first = testCollections.GetElement("first");
            var objToFindFirst = first;

            var tick1 = TPMethods.TimeCollection1(testCollections, objToFindFirst);
            var tick2 = TPMethods.TimeCollection3(testCollections, objToFindFirst);
            Assert.IsTrue(tick1 <= tick2);
        }

        [TestMethod]
        public void TestSearchingTime2() //тест времени поиска во 2 и 4 коллекциях
        {
            TestCollections testCollections = new();
            testCollections.RandomInit(1000);
            testCollections.SetValues();
            Bird middle = testCollections.GetElement("middle");
            var objToFindFirst = middle;

            
            var tick1 = TPMethods.TimeCollection2(testCollections, objToFindFirst);
            var tick2 = TPMethods.TimeCollection4(testCollections, objToFindFirst);

            //бинарный поиск словаря куда эффективнее линейного поиска очереди
            Assert.IsTrue(tick1 >= tick2);
        }

        [TestMethod]
        public void TestSearchingTime3() //тест поиска несуществующего элемента
        {
            TestCollections testCollections = new();
            testCollections.RandomInit(1000);
            testCollections.SetValues();
            Bird notFound = testCollections.GetElement("notFound");
            var objToFindFirst = notFound;


            var tick1 = TPMethods.TimeCollection1(testCollections, objToFindFirst);
            var tick2 = TPMethods.TimeCollection2(testCollections, objToFindFirst);
            var tick3 = TPMethods.TimeCollection3(testCollections, objToFindFirst);
            var tick4 = TPMethods.TimeCollection4(testCollections, objToFindFirst);

            //бинарный поиск словаря куда эффективнее линейного поиска очереди (x2)
            Assert.IsTrue(tick3 <= tick1 && tick4 <= tick2);
            //с последним элементом результат будет почти таким же
        }
    }
}
