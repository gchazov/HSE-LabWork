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
    public class BinaryTree<Animal>
        where Animal : IComparable, IInit<Animal>, new()
    {
        public Animal? Data { get; set; }    //информационное поле
        public BinaryTree<Animal>? Left { get; private set; }  //адресное поле левого потомка 
        public BinaryTree<Animal>? Right { get; private set; }   //адресное поле правого потомка 

        public int Count { get; private set; }  //кол-во элементов в дереве

        public BinaryTree() //конструктор без параметров
        {
            Data = default(Animal);  //используем значение по умолчанию для типа
            Left = null;    //левый и правый потомки отсутствуют
            Right = null;
            Count = 0;
        }

        public BinaryTree(Animal? data) //конструктор с параметром для типа Animal
        {

            Data = data;
            Left = null;    //левый и правый потомки отсутствуют
            Right = null;
            Count = 1;
        }


        public override string? ToString()  //для вывода
        {
            return Data.ToString();
        }

        private BinaryTree<Animal> SetFirst(Animal data) //установка первого элемента дерева
        {
            BinaryTree<Animal> tree = new BinaryTree<Animal>(data);
            return tree;
        }

        public BinaryTree<Animal> Add(BinaryTree<Animal> root, Animal data) //добавление элемента в дерево поиска
        {
            if (Count == 0)
            {
                SetFirst(data);
                Count++;
                return this;
            }
            BinaryTree<Animal> treeRoot = root; //корень дерева
            BinaryTree<Animal> r = null;
            bool isInside = false; //проверка на существование элемента
            while (treeRoot != null && !isInside)
            {
                r = treeRoot;
                if (data.Equals(treeRoot.Data)) isInside = true; //если элемент уже существует
                else
                {
                    if (treeRoot.Data.CompareTo(data) < 0) treeRoot = treeRoot.Left; //пойти в левое поддерево
                    else treeRoot = treeRoot.Right; //пойти в правое поддерево
                }
            }

            if (isInside) return treeRoot;//найдено, не добавляем

            BinaryTree<Animal>  newNode = new BinaryTree<Animal>(data);//создаём узел

            if (r.Data.CompareTo(data) > 0) r.Right = newNode;

            else r.Right = newNode;
            Count++; //увеличиваем счётчик
            return newNode;
        }

        public static BinaryTree<Animal> IdealTreeRnd(int size, BinaryTree<Animal> tree)    //идеально сбалансированное дерево
        {
            BinaryTree<Animal> root;
            int newLeft, newRight;
            if (size == 0) { tree = null; return tree; }
            newLeft = size / 2;
            newRight = size - newLeft - 1;

            Animal? data = new Animal();
            
            root = new BinaryTree<Animal>(data.RandomInit());
            root.Left = IdealTreeRnd(newLeft, root.Left);
            root.Right = IdealTreeRnd(newRight, root.Right);
            
            return root;
        }


    }
}
