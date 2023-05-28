global using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollections;
using AnimalLibrary;

namespace UnitTesting
{
    [TestClass]
    public class TestingDList
    {
        ConsoleRedirector cr = new ConsoleRedirector();

        [TestMethod]
        public void TestCtor()  //���� ������������� � ������ � �������
        {
            DoublyLinkedList<Animal> list1 = new();
            DoublyLinkedList<Animal> list2 = new();
            list1.AddFirst(new Animal().RandomInit());
            list2.AddLast(new Animal().RandomInit());
            list2.Insert(new Animal(), 1);
            DuplexItem<Animal> item1 = new DuplexItem<Animal>();
            DuplexItem<Animal> item2 = new(new Animal(), item1);

            list1 = new(new Animal());
            Console.WriteLine(item2);

            Assert.IsTrue(list2.Count > list1.Count 
                && cr.ToString().Contains("��������: NoName; �������: 1; " +
                "����� ��������: NoHabitat; ID � ��������: 0"));
        }

        [TestMethod]
        public void TestNumeration() //���� ����� �� ������ � ���������� �� �������
        {
            DoublyLinkedList<Animal> list = new();
            Animal item = new();
            Animal itemNew = new("��������", 12, "������", 12);
            list.AddFirst(item);
            list.AddLast(itemNew);
            Animal first = list[0];
            list[1] = new();
            var last = list[1];

            try
            {
                first = list[10];
            }
            catch (ArgumentOutOfRangeException) { };

            try
            {
                list[10] = new Animal();
            }
            catch (IndexOutOfRangeException) { };
            list.Reverse();
            list.Clear();
            Assert.IsTrue(last.Equals(first) & list.isEmpty);
        }

        [TestMethod]
        public void TestInsert()    //���� �� ������� �� ������ �������
        {
            DoublyLinkedList<Animal> list = new();
            for (int i = 0; i < 10; i++) list.AddLast(new Animal().RandomInit());
            list.Insert(new Animal(), 10);
            list.Insert(new Animal(), 1);
            list.Insert(new Animal().RandomInit(), 4);

            try
            {
                list.Insert(new Animal(), 20);
            }
            catch (InvalidOperationException) { };

            var last = list.Pop();
            Assert.AreNotEqual(last.Data, new Animal());
        }

        [TestMethod]
        public void TestShow1()    //���� �� ������ � ������� � �.�. foreach
        {
            DoublyLinkedList<Animal> list = new();
            for (int i = 0; i < 1; i++) list.AddLast(new Animal());
            list.Show();
            Assert.IsTrue(cr.ToString().Contains("��������: NoName; �������: 1; ����� ��������: NoHabitat; ID � ��������: 0"));

        }

        [TestMethod]
        public void TestShow2()    //���� �� ������ � �������
        {
            DoublyLinkedList<Animal> list = new();
            for (int i = 0; i < 1; i++) list.AddLast(new Animal());
            Console.WriteLine(list);
            Assert.IsTrue(cr.ToString().Contains("��������: NoName; �������: 1; ����� ��������: NoHabitat; ID � ��������: 0"));

        }

        [TestMethod]
        public void Clone()    //���� �� ������������
        {
            DoublyLinkedList<Animal> list1 = new();
            for (int i = 0; i < 3; i++) list1.AddLast(new Animal());
            DoublyLinkedList<Animal> list2 = list1.Clone();
            list1.Pop();
            Assert.IsTrue(list1.Count < list2.Count);
        }
    }
}