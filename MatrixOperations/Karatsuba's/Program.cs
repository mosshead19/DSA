using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karatsuba_s
{


    internal class Program
    {
        //generate random vector
        // Method to generate a random n x 1 bit vector
        static int[] GenerateRandomBitVector(int n)
        {
            Random rand = new Random();
            int[] r = new int[n];
            for (int i = 0; i < n; i++)
            {
                r[i] = rand.Next(2); // Generates 0 or 1
            }
            return r;
        }

        // Method to multiply matrix A by vector r
        static int[] MultiplyMatrixByVector(int[,] A, int[] r)
        {
            int rows = A.GetLength(0);
            int cols = A.GetLength(1);
            int[] result = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                result[i] = 0;
                for (int j = 0; j < cols; j++)
                {
                    result[i] += A[i, j] * r[j];
                }
            }
            return result;
        }

        // Method to check if the products AB and C are identical
        static bool CheckMatrixProduct(int[,] A, int[,] B, int[,] C)
        {
            int n = A.GetLength(1); // Assuming A is m x n
            int m = A.GetLength(0); // Number of rows in A
            int p = B.GetLength(1); // Number of columns in B

            // Generate random bit vector r
            int[] r = GenerateRandomBitVector(n);

            // Compute b = B * r
            int[] b = MultiplyMatrixByVector(B, r);

            // Compute x = A * b
            int[] x = MultiplyMatrixByVector(A, b);

            // Compute y = C * r
            int[] y = MultiplyMatrixByVector(C, r);

            // Check if x is identical to y
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    Console.WriteLine("AB ≠ C");
                    return false; // AB is definitely not equal to C
                }
            }

            Console.WriteLine("AB might be equal to C");
            return true; // AB might be equal to C
        }


        public static int[,] add(int[,] A, int[,] B) {
        int n = A.GetLength(0);
        int[,] result = new int[n,n];

        for(int i=0; i<n;i++){
            for(int j =0;j<n;j++){
                result[i,j]= A[i,j]+B[i,j];
            }

        }
        return result;

        
        }

        public static int[,] subtract(int[,] A, int[,] B)
        {
            int n = A.GetLength(0);
            int[,] result = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = A[i, j] - B[i, j];
                }

            }
            return result;


        }
        public static int[,] karatsuba(int[,] A, int[,] B) { 
        
            int n = A.GetLength(0);
            if (n == 1) {

                return new int[,] { { A[0, 0] * B[0, 0] } };
            }

            int newSize = n / 2;
            int[,] a11 = new int[newSize, newSize];
            int[,] a12 = new int[newSize, newSize];
            int[,] a21 = new int[newSize, newSize];
            int[,] a22 = new int[newSize,newSize];

            int[,] b11 = new int[newSize, newSize];
            int[,] b12 = new int[newSize, newSize];
            int[,] b21 = new int[newSize, newSize];
            int[,] b22 = new int[newSize, newSize];


            for (int i = 0; i < newSize; i++) { 
            for(int j =0; j < newSize; j++)
                {
                    a11[i, j] = A[i, j];
                    a12[i,j] = A[i, j+newSize];
                    a21[i,j] = A[i+newSize, j];
                    a22[i, j] = A[i + newSize, j + newSize];

                    b11[i, j] = B[i, j];
                    b12[i, j] = B[i, j + newSize];
                    b21[i, j] = B[i + newSize, j];
                    b22[i, j] = B[i + newSize, j + newSize];


                }
            
            }

            //STRASSEN MULTIPLIER
            int[,] P = strassen()
            
            //PQRSTUV




            //DISTRIBUTE PRODUCT AND COMPILE 
            //int C
            int[,] C = new 
            //


            return C;

        }



        static void Main(string[] args)
        {
        }
    }
}
