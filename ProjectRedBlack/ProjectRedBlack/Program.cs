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
            RedddBlackkk tree = new RedddBlackkk();
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
        }
    }
    enum Color
    {
        Red,
        Black
    }
    class RedddBlackkk
    {
        public class Node
        {
            public Color colour;
            public Node Lefttt;
            public Node Righttt;
            public int dataaa;
            public Node Parentsss;

            public Node(int data)
            {
                this.dataaa = data;
            }
            public Node(Color colour)
            {
                this.colour = colour;
            }
            public Node(int data, Color colour)
            {
                this.dataaa = data; this.colour = colour;
            }
        }
            public Node root;

            public RedddBlackkk()
            {}

            public void LRotate(Node X)
            {
                Node Y = X.Righttt;
                X.Righttt = Y.Lefttt;
                if (Y.Lefttt != null)
                {
                    Y.Lefttt.Parentsss = X;
                }
                if (Y != null)
                {
                    Y.Parentsss = X.Parentsss;
                }
                if (X.Parentsss == null)
                {
                    root = Y;
                }
                if (X == X.Parentsss.Lefttt)
                {
                    X.Parentsss.Lefttt = Y;
                }
                else
                {
                    X.Parentsss.Righttt = Y;
                }
                Y.Lefttt = X; 
                if (X != null)
                {
                    X.Parentsss = Y;
                }

            }

        
            public void RRotate(Node Y)
            {
               
                Node X = Y.Lefttt;
                Y.Lefttt = X.Righttt;
                if (X.Righttt != null)
                {
                    X.Righttt.Parentsss = Y;
                }
                if (X != null)
                {
                    X.Parentsss = Y.Parentsss;
                }
                if (Y.Parentsss == null)
                {
                    root = X;
                }
                if (Y == Y.Parentsss.Righttt)
                {
                    Y.Parentsss.Righttt = X;
                }
                if (Y == Y.Parentsss.Lefttt)
                {
                    Y.Parentsss.Lefttt = X;
                }

                X.Righttt = Y;
                if (Y != null)
                {
                    Y.Parentsss = X;
                }
            }
        




            public void DisplayTree()
            {
                if (root == null)
                {
                    Console.WriteLine("Nothing in the tree!");
                    return;
                }
                if (root != null)
                {
                    InOrderPrint(root);    
                }
            }
       





            public void InOrderPrint(Node n)
            {
                if (n != null)
                {
                    InOrderPrint(n.Lefttt);
                    Console.Write("{0} ", n.dataaa);
                    InOrderPrint(n.Righttt);
                }
            }
          





            public Node FindMethod(int n)
            {
                bool isFound = false;
                Node t = root;
                Node item = null;
                while (!isFound)
                {
                    if (t == null)
                    {
                        break;
                    }
                    if (n < t.dataaa)
                    {
                        t = t.Lefttt;
                    }
                    if (n > t.dataaa)
                    {
                        t= t.Righttt;
                    }
                    if (n == t.dataaa)
                    {
                        isFound = true;
                        item = t;
                    }
                }
                if (isFound)
                {
                    Console.WriteLine("{0} was found",n);
                    return t;
                }
                else
                {
                    Console.WriteLine("{0} not found",n);
                    return null;
                }
            }











          


            public void Insert(int n
                )
            {
                Node newN = new Node(n);
                if (root == null)
                {
                    root = newN;
                    root.colour = Color.Black;
                    return;
                }
                Node Y = null;
                Node X = root;
                while (X != null)
                {
                    Y = X;
                    if (newN.dataaa < X.dataaa)
                    {
                        X = X.Lefttt;
                    }
                    else
                    {
                        X = X.Righttt;
                    }
                }
                newN.Parentsss = Y;
                if (Y == null)
                {
                    root = newN;
                }
                else if (newN.dataaa < Y.dataaa)
                {
                    Y.Lefttt = newN;
                }
                else
                {
                    Y.Righttt = newN;
                }
                newN.Lefttt = null;
                newN.Righttt = null;
                newN.colour = Color.Red;   //colour the new node red
                InsertFix(newN);          //Fixed Up Method
            }
        //Insert Fix Up Method


            public void InsertFix(Node item)
            {
                //Checks Red-Black Tree properties


                while (item != root && item.Parentsss.colour == Color.Red)
                {
                   
                    if (item.Parentsss == item.Parentsss.Parentsss.Lefttt)
                    {
                        Node Y = item.Parentsss.Parentsss.Righttt;
                        if (Y != null && Y.colour == Color.Red)
                            
                            
                        {
                            item.Parentsss.colour = Color.Black;
                            Y.colour = Color.Black;
                            item.Parentsss.Parentsss.colour = Color.Red;
                            item = item.Parentsss.Parentsss;
                        }
                        else
                            
                        {
                            if (item == item.Parentsss.Righttt)
                            {
                                item = item.Parentsss;
                                LRotate(item);
                            }
                            
                            
                            
                            item.Parentsss.colour = Color.Black;
                            item.Parentsss.Parentsss.colour = Color.Red;
                            RRotate(item.Parentsss.Parentsss);
                        }

                    }
                    else
                    {
                        //mirror image of code above
                        Node X = null;

                        X = item.Parentsss.Parentsss.Lefttt;
                        if (X != null && X.colour == Color.Black)
                            
                            //Case 1
                        {
                            item.Parentsss.colour = Color.Red;
                            X.colour = Color.Red;
                            item.Parentsss.Parentsss.colour = Color.Black;
                            item = item.Parentsss.Parentsss;
                        }
                        else 
                            
                            //Case 2
                        {
                            if (item == item.Parentsss.Lefttt)
                            {
                                item = item.Parentsss;
                                RRotate(item);
                            }
                            
                            
                            
                            item.Parentsss.colour = Color.Black;
                            item.Parentsss.Parentsss.colour = Color.Red;
                            LRotate(item.Parentsss.Parentsss);

                        }

                    }
                    root.colour = Color.Black;
                }
            }


       

            public void Deletee(int n)
            {
                
                Node item = FindMethod(n);
                Node X = null;
                Node Y = null;

                if (item == null)
                {
                    Console.WriteLine("Nothing to delete!");
                    return;
                }
                if (item.Lefttt == null || item.Righttt == null)
                {
                    Y = item;
                }
                else
                {
                    Y = Successor(item);
                }
                if (Y.Lefttt != null)
                {
                    X = Y.Lefttt;
                }
                else
                {
                    X = Y.Righttt;
                }
                if (X != null)
                {
                    X.Parentsss = Y;
                }
                if (Y.Parentsss == null)
                {
                    root = X;
                }
                else if (Y == Y.Parentsss.Lefttt)
                {
                    Y.Parentsss.Lefttt = X;
                }
                else
                {
                    Y.Parentsss.Lefttt = X;
                }
                if (Y != item)
                {
                    item.dataaa = Y.dataaa;
                }
                if (Y.colour == Color.Black)
                {
                    DeleteFix(X);
                }

            }

        





          public void DeleteFix(Node X)
            {

                while (X != null && X != root && X.colour == Color.Black)
                {
                    if (X == X.Parentsss.Lefttt)
                    {
                        Node W = X.Parentsss.Righttt;
                        if (W.colour == Color.Red)
                        {

        
                            W.colour = Color.Black; 
                            X.Parentsss.colour = Color.Red; 
                            LRotate(X.Parentsss); 
                            W = X.Parentsss.Righttt; 
                        }
                        if (W.Lefttt.colour == Color.Black && W.Righttt.colour == Color.Black)
                        {

                            
                            W.colour = Color.Red; 
                            X = X.Parentsss; 
                        }
                        else if (W.Righttt.colour == Color.Black)
                        {

                            
                            W.Lefttt.colour = Color.Black; 
                            W.colour = Color.Red; 
                            RRotate(W);
                            W = X.Parentsss.Righttt;
                        }

                       
                        W.colour = X.Parentsss.colour; 
                        X.Parentsss.colour = Color.Black; 
                        W.Righttt.colour = Color.Black;                  
                        LRotate(X.Parentsss); 
                        X = root; 
                    }
                    else 
                    {
                        Node W = X.Parentsss.Lefttt;
                        if (W.colour == Color.Red)
                        {
                            W.colour = Color.Black;
                            X.Parentsss.colour = Color.Red;
                            RRotate(X.Parentsss);
                            W = X.Parentsss.Lefttt;
                        }
                        if (W.Righttt.colour == Color.Black && W.Lefttt.colour == Color.Black)
                        {
                            W.colour = Color.Black;
                            X = X.Parentsss;
                        }
                        else if (W.Lefttt.colour == Color.Black)
                        {
                            W.Righttt.colour = Color.Black;
                            W.colour = Color.Red;
                            LRotate(W);
                            W = X.Parentsss.Lefttt;
                        }
                        W.colour = X.Parentsss.colour;
                        X.Parentsss.colour = Color.Black;
                        W.Lefttt.colour = Color.Black;
                        RRotate(X.Parentsss);
                        X = root;
                    }
                }
                if (X != null)
                    X.colour = Color.Black;
            }


        
            public Node Min(Node X)
            {
                while (X.Lefttt.Lefttt != null)
                {
                    X = X.Lefttt;
                }
                if (X.Lefttt.Righttt != null)
                {
                    X = X.Lefttt.Righttt;
                }
                return X;
            }

        
            public Node Successor(Node X)
            {
                if (X.Lefttt!= null)
                {
                    return Min(X);
                }
                else
                {
                    Node Y = X.Parentsss;
                    while (Y != null && X == Y.Righttt)
                    {
                        X = Y;
                        Y = Y.Parentsss;
                    }
                    return Y;
                }
            }
        }
            

            
        }
    