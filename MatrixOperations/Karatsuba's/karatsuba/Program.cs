using System;

namespace KaratsubaInt
{
    class Program
    {
        // Karatsuba multiplication function using int
        static int Karatsuba(int x, int y)
        {
            // Base case: if x or y is small enough, perform normal multiplication
            if (x < 10 || y < 10)
                return x * y;

            // Determine the size of the numbers
            int n = Math.Max(x.ToString().Length, y.ToString().Length);
            int half = n / 2;

            // Split x and y into high and low parts
            int high1 = x / (int)Math.Pow(10, half);
            int low1 = x % (int)Math.Pow(10, half);
            int high2 = y / (int)Math.Pow(10, half);
            int low2 = y % (int)Math.Pow(10, half);

            // Recursive calls for three products
            int z0 = Karatsuba(low1, low2);
            int z1 = Karatsuba(low1 + high1, low2 + high2);
            int z2 = Karatsuba(high1, high2);

            // Combine the results using the Karatsuba formula
            return (z2 * (int)Math.Pow(10, 2 * half)) + ((z1 - z2 - z0) * (int)Math.Pow(10, half)) + z0;
        }

        static void Main(string[] args)
        {
            // Example usage
            int num1 = 12345; // Ensure the values are within int's range
            int num2 = 67890;

            int result = Karatsuba(num1, num2);

            Console.WriteLine("Result of Karatsuba Multiplication:");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
