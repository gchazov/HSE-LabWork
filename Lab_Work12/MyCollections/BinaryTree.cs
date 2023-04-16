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
        public T? Data { get; set; } //информационное поле
        public BinaryTree<T>? Left { get; set; } //левый потомок
        public BinaryTree<T>? Right { get; set; } //правый потомок

        public BinaryTree(T data = default) //параметр по умолчанию
        {
            Data = data;
            Left = null;
            Right = null;
        }

        //создание первого элемента
        public BinaryTree<T> AddFirst()
        {
            return new(new T().RandomInit());
        }

        //добавление элемента в дерево
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
        public static BinaryTree<T> IdealTree(int heigth, BinaryTree<T>? newNode)
        {
            BinaryTree<T> tree;
            int nodeLeft, nodeRight;

            if (heigth == 0)
            {
                newNode = null;
                return newNode;
            }
            
            nodeLeft = heigth / 2;
            nodeRight = heigth - nodeLeft - 1;
            tree = new BinaryTree<T>(new T().RandomInit());
            tree.Left = IdealTree(nodeLeft, tree.Left);
            tree.Right = IdealTree(nodeRight, tree.Right);

            return tree;
        }

        // проверка пустоты
        public bool IsEmpty()
        {
            return this.Data == null ? true : false;
        }

        //подсчет
        public int Recount(BinaryTree<T> tree)
        {
            int count = 0;

            if (tree.Left != null)
                count += Recount(tree.Left);

            count++;
            return count;
        }

        //получение минимума дерева
        public BinaryTree<T>? GetMinimal(BinaryTree<T>? tree)
        {
            if (tree != null)
            {
                GetMinimal(tree.Left);
            }
            return tree;
        }


        //печать дерева
        public static void ShowTree(BinaryTree<T>? node, int spaceSize)
        {
            if (node != null)
            {
                ShowTree(node.Left, spaceSize + 5); //к левому поддереву
                for (int i = 0; i < spaceSize; i++)
                {
                    char symbol = (i + 1) % spaceSize == 0 ? '|' : ' ';
                    Console.Write(symbol);
                }
                Console.WriteLine(node.Data);
                ShowTree(node.Right, spaceSize + 5);//к правому поддереву
            }
        }

        //преобразование в дерево поиска
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