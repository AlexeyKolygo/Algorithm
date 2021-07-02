using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2_algorhitms
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public class NodeItem : ILinkedList, IEnumerable
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        private int count;

        public int GetCount()
        {
            return count;
        }

        public void AddNode(int value)
        {
            var node = new Node() { Value = value };

            if (Head == null)
                Head = node;
            else
            {
                Tail.NextNode = node;
                node.PrevNode = Tail;
            }
            Tail = node;
            count++;

        }

        public void AddNodeAfter(Node node, int value)
        {

            var findNode = FindNode(value);
            if (findNode == null)
            {
                Console.WriteLine("No such element in the list.Your node HAS NOT been added");
                return;
            }
            var nextItem = findNode.NextNode;
            findNode.NextNode = node;
            node.NextNode = nextItem;
            count++;
        }

        public void RemoveNode(int index)
        {
            if (index == 0)
            {
                var newStartNode = Head.NextNode;
                Head.NextNode = null;

            }

            int currentIndex = 0;
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentIndex == index - 1)
                {
                    RemoveNode(currentNode);

                }

                currentNode = currentNode.NextNode;
                currentIndex++;
            }

        }

        public void RemoveNode(Node node)
        {
            var searchNode = FindNode(node.Value);
            if (searchNode == Head)
            {
                Head = Head.NextNode;
                count--;
                return;
            }
            if (searchNode.NextNode == null)
            {
                Tail = searchNode.PrevNode;
                count--;
                return;
            }
            var nextItem = searchNode.NextNode;
            var prevItem = searchNode.PrevNode;
            prevItem.NextNode = nextItem;
            count--;
        }

        public Node FindNode(int searchValue)
        {
            Node result = Head;
            while (result != null)
            {
                if (result.Value == searchValue)
                    return result;
                result = result.NextNode;
            }
            return null;
        }

        public IEnumerator GetEnumerator()
        {
            Node current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.NextNode;
            }
        }

    }

}
