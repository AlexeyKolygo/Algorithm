using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
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

    class Tree:ITree
    {
        private TreeNode root = null; 

        public TreeNode GetRoot()
        {
            return root;
        }

        public void AddItem(int value)
        {
            TreeNode newNode = new TreeNode(){Value = value};
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

        public void RemoveItem(int value)//сам не смог придумать. сдул из интернета
        {
            TreeNode temp = root;
            while (true)
            {
                if (temp == null) break;
                else if (temp.Value == value) Delete(temp);
                else if (value > temp.Value)
                    temp = temp.RightChild;
                else
                    temp = temp.LeftChild;
            }
        }

        

        public TreeNode GetNodeByValue(int value)
        {
            TreeNode temp = root;
            TreeNode nilNode = new TreeNode() { Value = 0 };
            while (true)
            {
                if (temp == null) return nilNode;
                else if (temp.Value == value) return temp;
                else if (value > temp.Value)
                    temp = temp.RightChild;
                else
                    temp = temp.LeftChild;
            }

        }

        public void PrintTree()
        {
            Order(root);
        }

        private void Order(TreeNode root)
        {

            if (root == null)
            {
                return;
            }
            Order(root.LeftChild);
            if(root == this.root)
            {
                Console.Write(root.Value + "(root) ");
            }
            else
            {
                Console.Write(root.Value + " ");
            }
            
            Order(root.RightChild);
        }


        private void Delete(TreeNode node) //сам не смог придумать. сдул из интернета
        {
            if (node.LeftChild == null && node.RightChild == null)
            {
                if (node.Parent == null)
                {
                    root = null;
                }
                else if (node.Parent.LeftChild == node)
                {
                    node.Parent.LeftChild = null;
                }
                else if (node.Parent.RightChild == node)
                {
                    node.Parent.RightChild = null;
                }
                return;
            }
            else if (node.LeftChild == null && node.RightChild != null)
            {
                node.Value = node.RightChild.Value;
                node.RightChild = null;
                return;
            }
            else if (node.RightChild == null && node.LeftChild != null)
            {
                node.Value = node.LeftChild.Value;
                node.LeftChild = null;
                return;
            }
            else
            {
                TreeNode temp = node.RightChild;
                while (true)
                {
                    if (temp.LeftChild != null)
                    {
                        temp = temp.LeftChild;
                    }
                    else
                    {
                        break;
                    }
                }
                node.Value = temp.Value;
                Delete(temp);
            }
        }
    }

}

