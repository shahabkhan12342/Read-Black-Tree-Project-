using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRedBlack
{
    class Program
    {
        static void Main(string[] args)
        {
            RedBlack tree = new RedBlack();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(3);
            
            tree.Insert(6);
            tree.DisplayTree();
            
            //tree.Insert(5);
            //tree.Insert(3);
            //tree.Insert(7);
            //tree.Insert(1);
            //tree.Insert(9);
            //tree.Insert(-1);
            //tree.Insert(11);
            //tree.Insert(6);
            //tree.DisplayTree();
            //tree.Delete(-1);
            //tree.DisplayTree();
            //tree.Delete(9);
            //tree.DisplayTree();
            //tree.Delete(5);
            //tree.DisplayTree();
            //Console.ReadLine();
        }
    }
    enum Color
    {
        Red,
        Black
    }
    class RedBlack
    {
        public class Node
        {
            public Color colour;
            public Node Left;
            public Node Right;
            public int data;
            public Node Parents;

            public Node(int data)
            {
                this.data = data;
            }
            public Node(Color colour)
            {
                this.colour = colour;
            }
            public Node(int data, Color colour)
            {
                this.data = data; this.colour = colour;
            }
        }
            public Node root;

            public RedBlack()
            {}


              //Method for LeftRotate
            public void LeftRotate(Node X)
            {
                Node Y = X.Right;
                X.Right = Y.Left;
                if (Y.Left != null)
                {
                    Y.Left.Parents = X;
                }
                if (Y != null)
                {
                    Y.Parents = X.Parents;//link X's parent to Y
                }
                if (X.Parents == null)
                {
                    root = Y;
                }
                if (X == X.Parents.Left)
                {
                    X.Parents.Left = Y;
                }
                else
                {
                    X.Parents.Right = Y;
                }
                Y.Left = X; //put X on Y's left
                if (X != null)
                {
                    X.Parents = Y;
                }

            }

        //Method For RightRotate
            public void RightRotate(Node Y)
            {
                // right rotate is simply mirror code from left rotate
                Node X = Y.Left;
                Y.Left = X.Right;
                if (X.Right != null)
                {
                    X.Right.Parents = Y;
                }
                if (X != null)
                {
                    X.Parents = Y.Parents;
                }
                if (Y.Parents == null)
                {
                    root = X;
                }
                if (Y == Y.Parents.Right)
                {
                    Y.Parents.Right = X;
                }
                if (Y == Y.Parents.Left)
                {
                    Y.Parents.Left = X;
                }

                X.Right = Y;//put Y on X's right
                if (Y != null)
                {
                    Y.Parents = X;
                }
            }
        //Display Method
            public void DisplayTree()
            {
                if (root == null)
                {
                    Console.WriteLine("Nothing in the tree!");
                    return;
                }
                if (root != null)
                {
                    InOrderDisplay(root);    //From In Order Display method
                }
            }
        // InOrder Display Method
            public void InOrderDisplay(Node current)
            {
                if (current != null)
                {
                    InOrderDisplay(current.Left);
                    Console.Write("({0}) ", current.data);
                    InOrderDisplay(current.Right);
                }
            }
            // Find Method
            public Node Find(int key)
            {
                bool isFound = false;
                Node temp = root;
                Node item = null;
                while (!isFound)
                {
                    if (temp == null)
                    {
                        break;
                    }
                    if (key < temp.data)
                    {
                        temp = temp.Left;
                    }
                    if (key > temp.data)
                    {
                        temp = temp.Right;
                    }
                    if (key == temp.data)
                    {
                        isFound = true;
                        item = temp;
                    }
                }
                if (isFound)
                {
                    Console.WriteLine("{0} was found", key);
                    return temp;
                }
                else
                {
                    Console.WriteLine("{0} not found", key);
                    return null;
                }
            }


        // Insert Method  


            public void Insert(int item)
            {
                Node newItem = new Node(item);
                if (root == null)
                {
                    root = newItem;
                    root.colour = Color.Black;
                    return;
                }
                Node Y = null;
                Node X = root;
                while (X != null)
                {
                    Y = X;
                    if (newItem.data < X.data)
                    {
                        X = X.Left;
                    }
                    else
                    {
                        X = X.Right;
                    }
                }
                newItem.Parents = Y;
                if (Y == null)
                {
                    root = newItem;
                }
                else if (newItem.data < Y.data)
                {
                    Y.Left = newItem;
                }
                else
                {
                    Y.Right = newItem;
                }
                newItem.Left = null;
                newItem.Right = null;
                newItem.colour = Color.Red;   //colour the new node red
                InsertFixUp(newItem);          //Fixed Up Method
            }
        //Insert Fix Up Method


            public void InsertFixUp(Node item)
            {
                //Checks Red-Black Tree properties


                while (item != root && item.Parents.colour == Color.Red)
                {
                   
                    if (item.Parents == item.Parents.Parents.Left)
                    {
                        Node Y = item.Parents.Parents.Right;
                        if (Y != null && Y.colour == Color.Red)
                            
                            //Case 1: uncle is red
                        {
                            item.Parents.colour = Color.Black;
                            Y.colour = Color.Black;
                            item.Parents.Parents.colour = Color.Red;
                            item = item.Parents.Parents;
                        }
                        else
                            //Case 2: uncle is black
                        {
                            if (item == item.Parents.Right)
                            {
                                item = item.Parents;
                                LeftRotate(item);
                            }
                            
                            
                            //Case 3: recolour & rotate
                            item.Parents.colour = Color.Black;
                            item.Parents.Parents.colour = Color.Red;
                            RightRotate(item.Parents.Parents);
                        }

                    }
                    else
                    {
                        //mirror image of code above
                        Node X = null;

                        X = item.Parents.Parents.Left;
                        if (X != null && X.colour == Color.Black)
                            
                            //Case 1
                        {
                            item.Parents.colour = Color.Red;
                            X.colour = Color.Red;
                            item.Parents.Parents.colour = Color.Black;
                            item = item.Parents.Parents;
                        }
                        else 
                            
                            //Case 2
                        {
                            if (item == item.Parents.Left)
                            {
                                item = item.Parents;
                                RightRotate(item);
                            }
                            
                            
                            //Case 3: recolour & rotate
                            item.Parents.colour = Color.Black;
                            item.Parents.Parents.colour = Color.Red;
                            LeftRotate(item.Parents.Parents);

                        }

                    }
                    root.colour = Color.Black;
                }
            }


        //Delete Method

            public void Delete(int key)
            {
                
                Node item = Find(key);
                Node X = null;
                Node Y = null;

                if (item == null)
                {
                    Console.WriteLine("Nothing to delete!");
                    return;
                }
                if (item.Left == null || item.Right == null)
                {
                    Y = item;
                }
                else
                {
                    Y = TreeSuccessor(item);
                }
                if (Y.Left != null)
                {
                    X = Y.Left;
                }
                else
                {
                    X = Y.Right;
                }
                if (X != null)
                {
                    X.Parents = Y;
                }
                if (Y.Parents == null)
                {
                    root = X;
                }
                else if (Y == Y.Parents.Left)
                {
                    Y.Parents.Left = X;
                }
                else
                {
                    Y.Parents.Left = X;
                }
                if (Y != item)
                {
                    item.data = Y.data;
                }
                if (Y.colour == Color.Black)
                {
                    DeleteFixUp(X);
                }

            }

        //Delete Fixed Up Method

          public void DeleteFixUp(Node X)
            {

                while (X != null && X != root && X.colour == Color.Black)
                {
                    if (X == X.Parents.Left)
                    {
                        Node W = X.Parents.Right;
                        if (W.colour == Color.Red)
                        {

                            //case1
                            W.colour = Color.Black; 
                            X.Parents.colour = Color.Red; 
                            LeftRotate(X.Parents); 
                            W = X.Parents.Right; 
                        }
                        if (W.Left.colour == Color.Black && W.Right.colour == Color.Black)
                        {

                            //case 2
                            W.colour = Color.Red; 
                            X = X.Parents; 
                        }
                        else if (W.Right.colour == Color.Black)
                        {

                            //case 3
                            W.Left.colour = Color.Black; 
                            W.colour = Color.Red; 
                            RightRotate(W);
                            W = X.Parents.Right;
                        }

                        //case 4
                        W.colour = X.Parents.colour; 
                        X.Parents.colour = Color.Black; 
                        W.Right.colour = Color.Black;                  
                        LeftRotate(X.Parents); 
                        X = root; 
                    }
                    else 
                    {
                        Node W = X.Parents.Left;
                        if (W.colour == Color.Red)
                        {
                            W.colour = Color.Black;
                            X.Parents.colour = Color.Red;
                            RightRotate(X.Parents);
                            W = X.Parents.Left;
                        }
                        if (W.Right.colour == Color.Black && W.Left.colour == Color.Black)
                        {
                            W.colour = Color.Black;
                            X = X.Parents;
                        }
                        else if (W.Left.colour == Color.Black)
                        {
                            W.Right.colour = Color.Black;
                            W.colour = Color.Red;
                            LeftRotate(W);
                            W = X.Parents.Left;
                        }
                        W.colour = X.Parents.colour;
                        X.Parents.colour = Color.Black;
                        W.Left.colour = Color.Black;
                        RightRotate(X.Parents);
                        X = root;
                    }
                }
                if (X != null)
                    X.colour = Color.Black;
            }


        //Minimum Method
            public Node Minimum(Node X)
            {
                while (X.Left.Left != null)
                {
                    X = X.Left;
                }
                if (X.Left.Right != null)
                {
                    X = X.Left.Right;
                }
                return X;
            }

        //Sussessor Method
            public Node TreeSuccessor(Node X)
            {
                if (X.Left != null)
                {
                    return Minimum(X);
                }
                else
                {
                    Node Y = X.Parents;
                    while (Y != null && X == Y.Right)
                    {
                        X = Y;
                        Y = Y.Parents;
                    }
                    return Y;
                }
            }
        }
            

            
        }
    