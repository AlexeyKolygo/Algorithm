using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS
{
    public class TreeNode
    {
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public TreeNode Parent { get; set; }
        public int Value { get; set; }

    }

    public interface ITree
    {
        TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }

    class Tree : ITree
    {
        private TreeNode root = null;

        public TreeNode GetRoot()
        {
            return root;
        }

        public void AddArrayToTree(int[]data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                AddItem(data[i]);
            }
        }
        public void AddItem(int value)
        {
            TreeNode newNode = new TreeNode() {Value = value};
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                TreeNode temp = root;
                while (true)
                {

                    if (value <= temp.Value)
                    {
                        if (temp.LeftChild == null)
                        {
                            temp.LeftChild = newNode;
                            newNode.Parent = temp;
                            break;
                        }
                        else
                        {
                            temp = temp.LeftChild;
                        }
                    }
                    else
                    {
                        if (temp.RightChild == null)
                        {
                            temp.RightChild = newNode;
                            newNode.Parent = temp;
                            break;
                        }
                        else
                        {
                            temp = temp.RightChild;
                        }
                    }
                }
            }
        }

        public void PrintTree()=> Order(root);
        //Это было круто! Благодаря этому заданию я наконец-то до конца разобрался, как работает рекурсия. Это вот ловушка методички, когда тебе дают готовый кусок кода для сортировки дерева
        //и ты (ну, не ты, а вот я лично) копипастишь его. Для себя выводы сделал, так делать нельзя.
        // Очень круто, что теперь я умею обходить какой-то набор данных стеком и очередью. Этот урок помог мне выяснить, какие есть коллекции для хранения данных.
        //Конечно, я не все посмотрел, осталось очень много неизведанного, но что-то мне подсказывает, что так будет всегда xDDD
        
        //ПРОСЬБЫ К ПРЕПОДАВАТЕЛЮ:

        //1. Я знаю, что цель курса не в том, чтоб учить нас культуре кода, но я был бы благодарен за обратную связь в т.ч. по этому аспекту. Мне интересно, что можно было бы улучшить, чтоб было красиво :)
        //2. Не совсем по теме, но я также был бы благодарен за обратную связь по гиту. в прошлый раз ругались, что у нас у всех там бардак и хаос. У меня тоже?Надо что-то улучшить?

        //P.S. Вопросов пока нет. Вроде, получилось все...
        public void DFS(int searchValue)
        {
            Console.WriteLine("DFS:");
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            DFSHelper(stack, root);
            while (stack.Count != 0)
            {
                var current = stack.Pop().Value;
                if (current == root.Value) Console.Write($"Root:");
                if (current == searchValue) Console.Write($"Found it! ");
                Console.WriteLine(current);
            }

        }
        public void DFSHelper(Stack<TreeNode> stack, TreeNode root)//тут сначала лево, потом право.
        {
            if (root == null) return;

            if (root.RightChild != null) stack.Push(root.RightChild);
            DFSHelper(stack, root.RightChild);

            if (root.LeftChild != null) stack.Push(root.LeftChild);
            DFSHelper(stack, root.LeftChild);
        }

        public void BFS(int searchValue)
        {
            Console.WriteLine("BFS:");
            var queue = new Queue<TreeNode>();
            
            BFSHelper(queue, root);
            queue.Enqueue(root);//для однообразия решил корень добавить в самый низ.
            while (queue.Count != 0)//тут еще можно было какую=то проверку добавить, что если мол искомое значение не найдено, то выведи что-нибудь в консоль. но я не стал, зато я много всего нового открыл для себя.
            {
                var current = queue.Dequeue().Value;
                if (current == root.Value) Console.Write($"Root:");
                if (current == searchValue) Console.Write($"Found it! ");
                
                Console.WriteLine(current);
            }

        }

        public void BFSHelper(Queue<TreeNode> queue, TreeNode root)//точно такая же логика работает наоборот: сначала право, потом лево. Прикольно!
        {
            if (root == null) return;

            if (root.RightChild != null) queue.Enqueue(root.RightChild);
            BFSHelper(queue, root.RightChild);

            if (root.LeftChild != null) queue.Enqueue(root.LeftChild);
            BFSHelper(queue, root.LeftChild);
        }

        private void Order(TreeNode root)
        {
            if (root == null) return;

            Order(root.LeftChild);
            if (root == this.root)
            {
                Console.Write(root.Value + "(root) ");
            }
            else
            {
                Console.Write(root.Value + " ");
            }
            Order(root.RightChild);
        }

        public void RemoveItem(int value) //в предыдущей домашке было. убрал, для компактности
        {
            throw new NotImplementedException();
        }

        public TreeNode GetNodeByValue(int value)//в предыдущей домашке было. убрал, для компактности
        {
            throw new NotImplementedException();
        }
    }

}

