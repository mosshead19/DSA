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
            Console.WriteLine("Enter string to reverse: ");
            string A = Console.ReadLine();


        //temp to store the stack elements 
            customStack2 stack = new customStack2(A.Length);


            Console.WriteLine("pushing elements to the stack: ");
            //operation to move the given element to the stack
            for (int i = 0; i < A.Length; i++)
            {
               
                stack.push(A[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Popping elements from the stack: ");
            string B = string.Empty;
            while(!stack.isEmpty())
            {
                B += stack.pop();

            }
            
               
            


            Console.WriteLine("reversed string : "+ B);




            Console.ReadLine();
        }

    }

    


    class customStack2
    {
        private char[] ele;
        private int top;
        private int max;

        public customStack2(int size) 
        {
            ele = new char[size];
            top = -1;
            max = size;
        
        }

        public bool isEmpty()
        {
            return top == -1;
        }

        public bool isFull()
        {
            return top == max - 1;
        }

        public void push(char item)
        {
            if (isFull())
            {
                Console.WriteLine("Stack overflow"); return;
            }
            else
            {
                Console.WriteLine($"{item} pushed int the stack");
                ele[++top] = item;
            }
        }

        public char pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack empty");
                return '\0';
            }
            else
            {
                Console.WriteLine("{0} popped from the stack", ele[top]);
                
            }

            return ele[top--];
        }

        public char peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("Empty");
                return'\0';
            }
            else
            {
                Console.WriteLine("{0} is the top of the stack", ele[top]);
            }
            return ele[top];
        }
        
        public void printSTACK()
        {
            if (isEmpty())
            {
                Console.WriteLine("STACK EMPTY");return;
            }

            for (int i = 0; i <= top; i++)
            {
                Console.WriteLine($"{i} pushed into the stack");
            }
        }
    }

}