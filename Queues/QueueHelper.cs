using Microsoft.VisualBasic.FileIO;
using Queues.Models;
using System;

//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class QueueHelper
    {
        /// <summary>
        /// פעולת ספירת כמות איברים בתור 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="q"></param>
        /// <returns></returns>
        public static int Count<T>(Queue<T> q)
        {
            int counter = 0;
            //ניצור עותק נוסף של התור
            Queue<T> temp = Copy(q);
            //נרוקן את העותק
            while (!temp.IsEmpty())
            {
                counter++;
                temp.Remove();
            }
            //נחזיר את הכמות
            return counter;
        }
        /// <summary>
        /// פעולה הסופרת כמות איברים בתור ללא שימוש בפעולת עזר
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="q"></param>
        /// <returns></returns>

        public static int Count2<T>(Queue<T> q)
        {
            int counter = 0;
            Queue<T> temp = new Queue<T>();
            //נעתיק את הערכים לתור חדש
            while (!q.IsEmpty())
            {
                temp.Insert(q.Remove());
                counter++;
            }
            //נחזיר את הערכים חזרה לתור המקורי
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
            //נחזיר את הכמות
            return counter;
        }
        /// <summary>
        /// פעולה היוצרת עותק של התור
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original"></param>
        /// <returns></returns>
        public static Queue<T> Copy<T>(Queue<T> original)
        {
            Queue<T> copy = new Queue<T>();
            Queue<T> temp = new Queue<T>();
            while (!original.IsEmpty())
            {
                temp.Insert(original.Remove());

            }
            while (!temp.IsEmpty())
            {
                copy.Insert(temp.Head());
                original.Insert(temp.Remove());
            }
            return copy;

        }
        public static bool isUp(Queue<int> queue)
        {
            int previous = int.MinValue;
            Queue<int> q = Copy(queue);
            while(!q.IsEmpty())
            {
                if (q.Head() > previous)
                { previous = q.Remove(); }
                else { return false; }
            }
            return true;
            
        }
        public static int Biggest(Queue<int> queue)
        {
            int biggest = int.MinValue;
            Queue<int> q = Copy(queue);
            while(!q.IsEmpty())
            {
                if(q.Head() > biggest)
                    biggest = q.Head();
                q.Remove();
            }
            return biggest;
        }
        public static void RemoveBiggest(Queue<int> queue)
        {
            int biggest = Biggest(queue);
            Queue<int> temp = new Queue<int>();

            while(!queue.IsEmpty())
            {
              if(queue.Head() != biggest)
                {
                    temp.Insert(queue.Head());
                }
              queue.Remove();

            }
            while (!temp.IsEmpty())
            {
                queue.Insert(temp.Remove());
            }

        }
        public static Queue<int> ReOrderDESC(Queue<int> queue)
        {
            Queue<int> q = Copy(queue);
            Queue<int> newQ = new Queue<int>();
            while (q.IsEmpty())
            {
                newQ.Insert(Biggest(q));
                 RemoveBiggest(q);
            }
            return newQ;
        }
        public static int PlaceInQueue(Queue<int> queue, int num)
        {
            int counter = 0;
            int place = 0;
           Queue<int> temp = Copy(queue);
            while (!temp.IsEmpty())
            {
                counter++;
                if(temp.Remove() == num)
                {
                    place = counter; 
                }
            }
            return place;
        }
        public static int ValueInQueue(Queue<int> queue, int k) 
        {
            int counter = 0;
            
            Queue<int> temp = Copy(queue);
            while (!temp.IsEmpty())
            {
                counter++;
                if(counter== k)
                {
                    return temp.Head();
                }
                temp.Remove();
            }
            return -1;
        }
        public static int LongestRezef(Queue<int> queue)
        {
            int longestRezef = -1;
            int currentRezef = 1;
            Queue<int> temp = Copy(queue);
            int previous = temp.Remove();
            while (!temp.IsEmpty())
            {
                if(previous== temp.Head()) 
                {
                    currentRezef++;
                }
                if (currentRezef >= longestRezef)
                    longestRezef = currentRezef;
                if(previous != temp.Head())
                    currentRezef= 1;
                previous = temp.Remove() ;
            }
            return longestRezef;
        }
        public static bool isExistRec(Queue<int> queue, int num)
        {
            if(queue.IsEmpty())
                return false;
            if (queue.Head() == num)
                return true;
            queue.Remove();
            return isExistRec(queue, num);
        }
        public static Queue<int> Serial(Queue<int> q)
        {

            if (!IsHeshbonit(q))
            {
                return null;
            }
            Queue<int> queue = new Queue<int>();
            queue.Insert(q.Head());
            Queue<int> c= Copy(q);
            queue.Insert((c.Remove() - c.Head())*-1);
            queue.Insert(Count(q));
            return queue;
        }
        public static void clean(Queue<char> q)
        {
            Queue<char> temp = new Queue<char>();
            Queue<char> future = Copy(q);
            future.Remove();
            
            while(!future.IsEmpty())
            {
                if(q.Head() == '#'|| future.Head() == '#')
                {
                    q.Remove();
                    
                }
                else
                {
                    temp.Insert(q.Remove());
                }
                future.Remove();
            }
            if (q.Head() == '#')
                q.Remove();
            else
                temp.Insert(q.Remove());
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
        }
        public static bool IsHeshbonit(Queue<int> q)
        {
            
            Queue<int> copy = Copy(q);
            Queue<int> copy2 = Copy(q);
            copy.Remove();
            int hefresh = copy.Remove() - copy2.Remove();
            while (!copy.IsEmpty())
            {
                if((copy.Remove() - copy2.Remove() != hefresh))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
