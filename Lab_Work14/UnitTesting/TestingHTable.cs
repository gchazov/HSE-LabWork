global using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollections;
using AnimalLibrary;

namespace UnitTesting
{
    [TestClass] //������������ ���-������� (3 �����)
    public class TestingHTable
    {
        ConsoleRedirector cr = new ConsoleRedirector();

        [TestMethod]
        public void TestCtor() //������������ ������������ � ������
        {
            HTable<Animal> hTable = new(1);
            hTable.Add(new Animal("1", 2, "3", 4));
            Console.WriteLine(hTable);
            Assert.IsTrue(hTable.Size == 1 
                && cr.ToString().Contains("������� 1:\n\t��������: 1; �������: 2; ����� ��������: 3; ID � ��������: 4 => ��������: 1; �������: 2; ����� ��������: 3; ID � ��������: 4\n"));
        }

        [TestMethod]
        public void TestAdd() //������������ ���������� � ���-������� ���������
        {
            HTable<Animal> hTable = new(1);
            hTable.Add(new Animal("1", 2, "3", 4));
            hTable.Add(new Animal("2", 2, "3", 4));
            hTable.Add(new Animal("3", 2, "3", 4));
            Assert.IsFalse(hTable.Add(new Animal("2", 2, "3", 4)));
        }

        [TestMethod]
        public void TestFindElement() //������������ ������ ��������
        {
            HTable<Animal> hTable = new(1);
            hTable.Add(new Animal("1", 2, "3", 4));
            hTable.Add(new Animal("2", 2, "3", 4));
            hTable.Add(new Animal("3", 2, "3", 4));
            Assert.IsTrue(hTable.FindElementData(new Animal("2", 2, "3", 4))
                && !hTable.FindElementData(new Animal("222", 2, "3", 4)));
        }

        [TestMethod]
        public void TestDeleteELement1() //������������ �������� ��������
        {
            HTable<Animal> hTable = new(1);
            hTable.Add(new Animal("1", 2, "3", 4));
            hTable.Add(new Animal("2", 2, "3", 4));
            hTable.Add(new Animal("3", 2, "3", 4));
            Assert.IsNull(hTable.DeleteElement(new Animal("222", 2, "3", 4)));
        }

        [TestMethod]
        public void TestDeleteELement2() //������������ �������� ��������
        {
            HTable<Animal> hTable = new(1);
            hTable.Add(new Animal("1", 2, "3", 4));
            hTable.Add(new Animal("2", 2, "3", 4));
            hTable.Add(new Animal("3", 2, "3", 4));
            Assert.IsNotNull(hTable.DeleteElement(new Animal("2", 2, "3", 4)));
        }

        [TestMethod]
        public void TestDeleteELement3() //������������ �������� ��������
        {
            HTable<Animal> hTable = new(1);
            hTable.Add(new Animal("1", 2, "3", 4));
            hTable.Add(new Animal("2", 2, "3", 4));
            hTable.Add(new Animal("3", 2, "3", 4));
            Assert.IsNotNull(hTable.DeleteElement(new Animal("1", 2, "3", 4)));
        }
    }
}