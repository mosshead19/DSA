using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue_practice_implementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class customQueue
    {
        private int rear;//tail or back 
        private int max;
        private int[] ele;

        //enqueue is similar to push in stack
        public void enqueue(int item)
        {
            if (rear == max - 1)
            {
                Console.WriteLine("queue overflow");
                return;
            }

            else
            {
                ele[++rear]=item;
            }

        }


        public void dequeue()
        {



        }

        public int front()
        {

        }

        public int Rear()
        {

        }

        public bool isEmpty()
        {

        }

        public int isfull()
        {

        }

        public void size()
        {

        }
    }
}
