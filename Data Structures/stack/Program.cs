using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initial arrays
            int[] A = { 1, 2, 3, 4, 5, 6 };
            int[] B = { 7, 8, 9, 10, 11, 12, 13, 14 };

            // Stack to hold elements temporarily
            customStack2 stack = new customStack2(2);

            // Push 1 and 2 from A into the stack
            stack.push(A[1]);
            stack.push(A[0]); // Push 1
                              // Push 2

            // Prepare a list to modify Array B
            List<int> modifiedB = new List<int>();

            // Pop elements from the stack and add to modifiedB
            while (!stack.isEmpty())
            {
                modifiedB.Add(stack.pop());
            }

            // Add all elements of Array B
            modifiedB.AddRange(B);

            // Convert modified list back to an array
            int[] result = modifiedB.ToArray();

            // Print the result
            Console.WriteLine("Modified Array B:");
            foreach (int num in result)
            {
                Console.Write(num + " ");
            }
            Console.ReadLine();
        }

    }

    


    class customStack2
    {

        private int[] ele;
        private int top;
        private int max;


        public customStack2(int size)
        {
            ele = new int[size];
            top = -1;//keeps track of the top element
            max = size;
        }

        public void push(int item)
        {
            if (top == max - 1)
            {
                Console.WriteLine("Stack overflow");
                return;
            }

            else
            {
                Console.WriteLine("{0} push on the stack",item);
                ele[++top] = item;

            }
        }


        public int pop()
        {
            if (top == -1)
            {
                Console.WriteLine("stack is empty");
                return -1;
            }
            else
            {
                Console.WriteLine("{0} popped from the stack", ele[top]);
                return ele[top--];
            }
        }

        public int peek()
        {
            if (top == -1)
            {
                Console.WriteLine("stack is empty");
                return -1;
            }
            else
            {
                Console.WriteLine("{0} is at the top of the stack", ele[top]);
                return ele[top];
            }
        }
        public bool isEmpty()
        {
            return top == -1;
        }
        public void printStack()
        {
            if (top == -1)
            {
                Console.WriteLine("stack is empty");

            }
            else
                for (int i = 0; i <=top; i++)
            {
                    Console.WriteLine("current stack elements: ");
                    Console.WriteLine(ele[i]);
            }
        }
    }

}