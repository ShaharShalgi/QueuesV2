using System;

using Queues.Models;
namespace Queues
{
    internal class Program
    {
        public static int CountNodes<T>(Node<T> head)
        {
            int counter = 0;
            while (head != null)
            {
                counter++;
                head = head.GetNext();
            }
            return counter;
        }
        public static Node<T> Split<T>(Node<T> node)
        {
            int counter = CountNodes(node);
            for (int i = 0; i < counter/2; i++)
            {
                node = node.GetNext();
            }
            return node;
        }

        public static bool IsArranged(Node<int> node)
        {
            int counter = CountNodes(node);
            Node<int> tail = node;
            Node<int> secondHalf = Split<int>(node);
            Node<int> secondHead = secondHalf;
            for (int i = 0; i < counter/2; i++)
            {
                while (secondHalf != null)
                {
                    if (tail.GetValue() >= secondHalf.GetValue() || counter % 2 != 0)
                    {
                        return false;
                    }
                    secondHalf = secondHalf.GetNext();
                }
                secondHalf = secondHead;
                tail = tail.GetNext();
                
            }
            return true;

        }
        public static bool IsPrefix(Node<int> lst1, Node<int> lst2)
        {
            Node<int> tail1 = lst1;
            Node<int> tail2 = lst2;
            if (CountNodes(lst1) > CountNodes(lst2))
                return false;
            while (tail1 != null)
            {
                if(tail1.GetValue() != tail2.GetValue())
                    return false;
                tail1= tail1.GetNext();
                tail2= tail2.GetNext();
            }
            return true;
        }
        public static bool IsSubChain(Node<int> lst1, Node<int> lst2)
        {
            Node<int> tail2 = lst2;
            while(tail2 != null)
            {
                if (IsPrefix(lst1, tail2))
                    return true;
                tail2= tail2.GetNext();
            }
            return false;
        }
       


        static void Main(string[] args)
        {
            //Queue<int> q1= new Queue<int>();    
            //q1.Insert(3);
            //q1.Insert(6);
            //q1.Insert(7);
            //q1.Insert(9);
            //q1.Insert(12);
            //Console.WriteLine(q1);
            //Console.WriteLine(QueueHelper.Count(q1));
            //Console.WriteLine(QueueHelper.Biggest(q1));
            //QueueHelper.RemoveBiggest(q1);
            //Console.WriteLine(q1);
            //Console.WriteLine(QueueHelper.isExistRec(q1, 9));
            //Console.WriteLine(q1);
            //Node<int> node = new Node<int>(3);
            //node.SetNext(new Node<int>(-4));
            //node.GetNext().SetNext(new Node<int>(4));
            //node.GetNext().GetNext().SetNext(new Node<int>(41));
            //node.GetNext().GetNext().GetNext().SetNext(new Node<int>(15));
            //node.GetNext().GetNext().GetNext().GetNext().SetNext(new Node<int>(2));
            ////Console.WriteLine(IsArranged(node));
            //Node<int> node1 = new Node<int>(-4);
            //node1.SetNext(new Node<int>(4));
            //Console.WriteLine(IsSubChain(node1, node));
            //Console.WriteLine(node);
            //Queue<int> q2 = new Queue<int>();
            //q2.Insert(2);
            //q2.Insert(5);
            //q2.Insert(8);
            //q2.Insert(11);
            //if (QueueHelper.Serial(q2) == null)
            //    Console.WriteLine("null");
            //else
            //{
            //    Console.WriteLine( QueueHelper.Serial(q2).ToString() ); 
            //}
            //Console.WriteLine(q2.ToString());
           


        }
    }
}