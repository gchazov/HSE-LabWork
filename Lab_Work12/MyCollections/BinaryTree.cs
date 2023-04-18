using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyCollections
{
    //определение бинарного дерева
    public class BinaryTree<T> : IComparable
        where T : IComparable, IInit<T>, new() //для правильной реализации
    {
        public T? Data { get; private set; } //информационное поле
        public BinaryTree<T>? Left { get; private set; } //левый потомок
        public BinaryTree<T>? Right { get; private set; } //правый потомок

        public BinaryTree(T data = default) //параметр по умолчанию
        {
            Data = data;
            Left = null;
            Right = null;
        }


        //префиксный обход
        public static List<T> PrefixWalk(BinaryTree<T> tree)
        {
            var list = new List<T>();
            if (tree != null)
            {
                list.Add(tree.Data);
                if (tree.Left != null)
                {
                    list.AddRange(PrefixWalk(tree.Left));
                }
                if (tree.Right != null)
                {
                    list.AddRange(PrefixWalk(tree.Right));
                }
            }
            return list;
        }


        //создание первого элемента
        public static BinaryTree<T> AddFirst()
        {
            return new(new T().RandomInit());
        }

        //получение корня
        public BinaryTree<T> GetFirst()
        {
            return new BinaryTree<T>(Data);
        }

        //добавление элемента в дерево (для пребразования в дерево поиска)
        public static BinaryTree<T>? Add(BinaryTree<T>? root, T? data)
        {
            BinaryTree<T>? point = root; //корень
            BinaryTree<T>? temp = null;

            bool isAdded = false; //наличие элемента в дереве
            while (point != null && !isAdded)
            {
                temp = point;
                if (data.Equals(point.Data))
                    isAdded = true;
                else
                {
                    if (data.CompareTo(point.Data) < 0)
                        point = point.Left;
                    else point = point.Right;
                }
            }

            if (isAdded) return point;

            BinaryTree<T> newNode = new BinaryTree<T>(data);

            if (data.CompareTo(temp.Data) < 0)
                temp.Left = newNode;
            else temp.Right = newNode;

            return newNode;
        }

        //построение идеально сбалансированного дерева
        public static BinaryTree<T> IdealTree(int size, BinaryTree<T>? newNode)
        {
            BinaryTree<T> tree;
            int nodeLeft, nodeRight;

            if (size == 0)
            {
                newNode = null;
                return newNode;
            }
            
            nodeLeft = size / 2;
            nodeRight = size - nodeLeft - 1;
            tree = new BinaryTree<T>(new T().RandomInit());
            tree.Left = IdealTree(nodeLeft, tree.Left);
            tree.Right = IdealTree(nodeRight, tree.Right);

            return tree;
        }

        // проверка пустоты
        public bool IsEmpty()
        {
            return Data == null ? true : false;
        }

        //получение минимума дерева ПОИСКА
        public static T? GetMinimalBST(BinaryTree<T>? tree)
        {
            T? result = tree.Data;
            while (tree.Left != null)
            {
                result = tree.Left.Data;
                tree = tree.Left;
            }
            return result;
        }

        //печать дерева
        public static void ShowTree(BinaryTree<T>? node, int spaceSize)
        {
            if (node != null)
            {
                ShowTree(node.Right, spaceSize + 5);//к правому поддереву
                for (int i = 0; i < spaceSize; i++)
                {
                    char symbol = (i + 1) % spaceSize == 0 ? '|' : '-';
                    Console.Write(symbol);
                }
                Console.WriteLine(node.Data);
                ShowTree(node.Left, spaceSize + 5); //к левому поддереву
            }
        }

        //преобразование в дерево поиска (root - новое дерево)
        public static void Transform(BinaryTree<T> root, BinaryTree<T>? idtree)
        {
            if (idtree != null)
            {
                Add(root, idtree.Data);
                Transform(root, idtree.Left);
                Transform(root, idtree.Right);
            }
        }

        //для вывода узла на экран
        public override string ToString()
        {
            return Data.ToString();
        }

        //компаратор для узла
        public int CompareTo(object? obj)
        {
            if (obj is BinaryTree<T> item) return Data.CompareTo(item);
            else throw new ArgumentException();
        }


    }
}