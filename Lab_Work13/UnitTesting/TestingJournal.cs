using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCollections;
using System.Threading.Tasks;
using AnimalLibrary;

namespace UnitTesting
{
    [TestClass]
    public class TestingJournal
    {
        ConsoleRedirector cr = new ConsoleRedirector();
        [TestMethod]
        public void TestCtorAndCountChanged() //здесь JE - Journal Entry
        {
            CollectionHandlerEventArgs<Animal> args = new("example", "change", new Animal());
            Journal<Animal> journal = new Journal<Animal>();
            journal.CollectionCountChanged(new object(), args);
            Assert.IsTrue(!journal.IsEmpty);
        }

        [TestMethod]
        public void TestCtorAndReferenceChange() //здесь JE - Journal Entry
        {
            CollectionHandlerEventArgs<Animal> args = new("example", "change", new Animal());
            Journal<Animal> journal = new Journal<Animal>();
            journal.CollectionReferenceChanged(new object(), args);
            Assert.IsTrue(!journal.IsEmpty);
        }

        [TestMethod]
        public void TestShow()
        {
            MyNewCollection<Animal> animals = new(1);
            Journal<Animal> journal = new();
            animals.CollectionCountChanged += journal.CollectionCountChanged;
            animals.Add(new Animal());
            journal.ShowJournal();
            Assert.IsTrue(!journal.IsEmpty && !cr.ToString().Contains(journal.ToString()));
        }
    }
}
