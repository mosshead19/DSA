using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strassen_S
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


        static int[] MultiplyMatrixByVector(int[,] A, int[] r) {

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

        // Method to multiply matrix A by vector r
        static int[] MultiplyMatrixByVector1(int[,] A, int[] r)
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


        static bool CheckMatrixProduct(int[,] A, int[,] B, int[,] C) {
            int n = A.GetLength(1);


            int[] r = GenerateRandomBitVector(n);

            int[] b = MultiplyMatrixByVector(B, r);
            int[] x = MultiplyMatrixByVector(A, b);
            int[] y = MultiplyMatrixByVector(C, r);

            for (int i = 0; i < x.Length; i++) {

                if (x[i] != y[i])
                {
                    Console.WriteLine("AB != C");
                    return false;

                }
           
            }


            Console.WriteLine("AB = C");
            return true;


        }









        // Method to check if the products AB and C are identical
        static bool CheckMatrixProduct1(int[,] A, int[,] B, int[,] C)
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


        public static int[,] add(int[,] A, int[,] B)
        {
            int n = A.GetLength(0);
            int[,] result = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = A[i, j] + B[i, j];
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
        public static int[,] strassen(int[,] A, int[,] B)
        {

            int n = A.GetLength(0);
            if (n == 1)
            {

                return new int[,] { { A[0, 0] * B[0, 0] } };
            }

            int newSize = n / 2;
            int[,] a11 = new int[newSize, newSize];
            int[,] a12 = new int[newSize, newSize];
            int[,] a21 = new int[newSize, newSize];
            int[,] a22 = new int[newSize, newSize];

            int[,] b11 = new int[newSize, newSize];
            int[,] b12 = new int[newSize, newSize];
            int[,] b21 = new int[newSize, newSize];
            int[,] b22 = new int[newSize, newSize];


            for (int i = 0; i < newSize; i++)
            {
                for (int j = 0; j < newSize; j++)
                {
                    a11[i, j] = A[i, j];
                    a12[i, j] = A[i, j + newSize];
                    a21[i, j] = A[i + newSize, j];
                    a22[i, j] = A[i + newSize, j + newSize];

                    b11[i, j] = B[i, j];
                    b12[i, j] = B[i, j + newSize];
                    b21[i, j] = B[i + newSize, j];
                    b22[i, j] = B[i + newSize, j + newSize];


                }

            }

            //STRASSEN MULTIPLIER
            int[,] P = strassen(add(a11,a22), add(b11,b22));
            int[,] Q = strassen(add(a21,a22),b11);
            int[,] R = strassen(a11,subtract(b12,b22));
            int[,] S = strassen(a22,subtract(b21,b11));
            int[,] T = strassen(add(a11, a12), b22);
            int[,] U = strassen(subtract(a21, a11), add(b11, b12));
            int[,] V = strassen(subtract(a12, a22), add(b21, b22));

            //PQRSTUV




            //DISTRIBUTE PRODUCT AND COMPILE 
            //int C
            int[,] C = new int[n,n];

            for (int i = 0; i < newSize; i++) {
                for (int j = 0; j < newSize; j++)
                {
                    C[i,j] = P[i, j] + S[i, j] - T[i, j] + V[i,j];
                    C[i,j+newSize] = R[i,j] + T[i,j];
                    C[i+newSize,j] = Q[i,j] + S[i,j];
                    C[i + newSize, j+newSize] = P[i, j] + R[i, j] - Q[i, j] + U[i,j];




                }
            
            
            }
            //


            return C;

        }


        public static void printMatrix(int[,] matrix) { 
        
        int n = matrix.GetLength(0);    
            for(int i =0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i,j]+ " ");


                }
                Console.WriteLine();
            }
        
        
        }


        static void Main(string[] args)
        {

            int[,] A =  {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16}
        };

            int[,] B =  {
                {16, 15, 14, 13},
                {12, 11, 10, 9},
                {8, 7, 6, 5},
                {4, 3, 2, 1}
        };



            int[,] result = strassen(A, B);
            printMatrix(result);

            int[,] C = result; // Assuming result is the expected output of AB.
            if (CheckMatrixProduct(A, B, C))
            {
                Console.WriteLine("The computed result matches the expected matrix.");
            }
            else
            {
                Console.WriteLine("The computed result does not match the expected matrix.");
            }
            Console.ReadLine();

           


        }
    }
}
