using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int height = 15;  // You can adjust the height here
            int[,] triangle = PascalTriangle(height);
            DisplayPascalTriangle(triangle, height);
          
            Console.ReadLine();

        }



        



        






        public static  int[,] PascalTriangle(int height)
        {
            
            int[,] triangle = new int[height, height];
            
            
            for(int i =0; i < height; i++) {

                //initialize the beginning and end of the current row as 1
                triangle[i, 0] = 1;
                triangle[i, i] = 1;

                // iterates over the elements in the current row
                // (excluding the first and last elements)
                // to compute their values based on the values from the previous row

                for (int j = 1; j < i; j++) {
                    triangle[i,j] = triangle[i-1,j-1]+ triangle[i-1,j];

                }
            
            }

            return triangle;

        }

        public static void DisplayPascalTriangle(int[,] triangle, int height)
        {
            // Find the width of the largest number in the last row
            int maxWidth = triangle[height - 1, height / 2].ToString().Length;

            for (int i = 0; i < height; i++)
            {
                // Print leading spaces to center the numbers
                Console.Write(new string(' ', height - i));

                // Print each element in the current row with padding for alignment
                for (int j = 0; j <= i; j++)
                {
                    // Pad each number to ensure the triangle is aligned properly
                    Console.Write(triangle[i, j].ToString().PadLeft(maxWidth) + " ");
                }

                // Move to the next line after each row
                Console.WriteLine();
            }
        }

        public static void DisplayT(int[,] triangle, int height) {

            // Calculate the maximum width needed for the largest number in the triangle
            int maxNumberWidth = triangle[height - 1, height / 2]; // Largest number in the last row
            int maxWidth = maxNumberWidth.ToString().Length; // Find width of the largest number

            // Print the triangle centered
            for (int i = 0; i < height; i++)
            {
                // Print leading spaces for alignment
                Console.Write(new string(' ', (height - i) * maxWidth / 2));

                // Print each element in the current row with padding for alignment
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(triangle[i, j].ToString().PadLeft(maxWidth) + " ");
                }

                Console.WriteLine();
            }

        }
    }
}

