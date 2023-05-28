global using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollections;
using AnimalLibrary;

namespace UnitTesting
{
    [TestClass]
    public class TestingTree
    {
        ConsoleRedirector cr = new ConsoleRedirector();

        [TestMethod]
        public void TestCtor()  //тест конструкторов
        {
            BinaryTree<Animal> tree1 = new(new Animal());
            var list1 = BinaryTree<Animal>.PrefixWalk(tree1);
            BinaryTree <Animal> tree2 = BinaryTree<Animal>.AddFirst();
            var list2 = BinaryTree<Animal>.PrefixWalk(tree2);
            BinaryTree<Animal> tree3 = new();
            var list3 = BinaryTree<Animal>.PrefixWalk(tree3);
            Assert.IsFalse(list1.SequenceEqual(list3) && list2.SequenceEqual(list1));
        }

        [TestMethod]
        public void TestWalk()  //тест обхода
        {
            BinaryTree<Animal> tree1 = new(new Animal());
            for (int i = 0; i < 10; i++)
                BinaryTree<Animal>.Add(tree1, new Animal().RandomInit());
            Assert.IsTrue(BinaryTree<Animal>.PrefixWalk(tree1).Count == 11
                && tree1.GetFirst().Data.Equals(new Animal()));
        }

        [TestMethod]
        public void TestWalkIdealize()  //тест обхода идеального дерева
        {
            BinaryTree<Animal> tree1 = new(new Animal());
            tree1 = BinaryTree<Animal>.IdealTree(12, tree1);
            Assert.IsTrue(BinaryTree<Animal>.PrefixWalk(tree1).Count == 12
                && !tree1.IsEmpty());
        }

        [TestMethod]
        public void TestPrint1()  //тест вывода одного узла и сравнение узлов
        {
            BinaryTree<Animal> tree = new(new Animal());
            Console.WriteLine(tree);
            BinaryTree<Animal> treeNew = new(new Animal("horse", 1, "field", 9999));
            Assert.IsTrue(cr.ToString().Contains("Животное: NoName; Возраст: 1; Ареал обитания: NoHabitat; ID в зоопарке: 0")
                && tree.CompareTo(treeNew) < 0);
        }

        [TestMethod]
        public void TestTransform()  //тест обхода идеального дерева
        {
            BinaryTree<Animal> tree1 = new(new Animal());
            tree1 = BinaryTree<Animal>.IdealTree(12, tree1);
            BinaryTree<Animal> bst = tree1.GetFirst();
            BinaryTree<Animal>.Transform(bst, tree1);
            BinaryTree<Animal>.Add(bst, new Animal());

            Assert.IsTrue(BinaryTree<Animal>.GetMinimalBST(bst).Equals(new Animal()));
        }

        [TestMethod]
        public void TestShow()  //тест обхода идеального дерева
        {
            BinaryTree<Animal> tree1 = new();
            BinaryTree<Animal>.Add(tree1, new("2", 2, "2", 2));
            BinaryTree<Animal>.Add(tree1, new("1", 1, "1", 1));
            BinaryTree<Animal>.Add(tree1, new("3", 3, "3", 3));
            BinaryTree<Animal>.ShowTree(tree1, 0);
            Assert.IsTrue(cr.ToString().Contains("---------|Животное: 3; Возраст: 3; Ареал обитания: 3; ID в зоопарке: 3\r\n" +
                "----|Животное: 2; Возраст: 2; Ареал обитания: 2; ID в зоопарке: 2\r\n" +
                "---------|Животное: 1; Возраст: 1; Ареал обитания: 1; ID в зоопарке: 1"));
        }
    }
}