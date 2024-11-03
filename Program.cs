using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SortingPracticeImplementation
{

    



    internal class Program
    {
        public static void heapSort(int[] array) { 
        //build the heap
        int n = array.Length;
            for (int i = n / 2 - 1; i >= 0; i--) {

                heapify(array, n, i);
            
            }



            // extraction
            for (int i = n - 1; i > 0; i--) { 
            swap(array,0,i);
                heapify(array, i, 0);
            
            
            }
        
        
        
        }


        public static void heapify(int[] array, int length, int node)
        {

            int largest = node;

            int leftChild = 2 * node + 1;
            int rightChild = 2 * node + 2;

            if (leftChild < length && array[leftChild] > array[largest]) {
                largest = leftChild;
            }

            if (rightChild < length && array[rightChild] > array[largest]) {
            
            largest = rightChild;
            
            }

            if (largest != node) { 

                swap(array,largest,node);
                heapify(array, length, largest);
            
            }
        
        
        
        }
        public static void mergeSort(int[] array) { 
        int n = array.Length;
            if (n <= 1) return;

            int mid = n / 2;

            int[] leftArr = new int[mid];
            int[] rightArr = new int[n - mid];
            int i =0,j=0;
            for (; i < n; i++) {

                if (i < mid)
                {

                    leftArr[i] = array[i];
                }

                else {
                    rightArr[j] = array[i];
                    j++;
                }
            
            
            }

            mergeSort(leftArr);
            mergeSort(rightArr);
            merge(leftArr, rightArr, array);

        
        }


        private static void merge(int[] leftArr, int[] rightArr, int[] array) { 
        
            int ls = leftArr.Length;
            int rs= rightArr.Length;
            int i = 0, l = 0, r = 0;
            while (l < ls && r < rs) {
                if (leftArr[l] < rightArr[r])
                {
                    array[i] = leftArr[l];
                    l++;
                    i++;
                }
                else
                {
                    array[i]= rightArr[r];
                    r++;
                    i++;
                }
            
            
            }

            while (l < ls) {

                array[i] = leftArr[l];
                l++;
                i++;
            }
            while (r < rs) {

                array[i] = rightArr[r];
                r++;
                i++;

            }
        
        }

        public static void swap(int[] array, int i, int j) {

            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;


        }

        //quickSort
         public static void quickSort(int[] array, int start, int end)
        {
            if (start >= end) return;

            int pivot = partition(array, start, end);
            
            quickSort(array, start, pivot-1);
            quickSort(array, pivot+1, end);
           


        }
         public static int partition(int[] array, int start, int end) {

            int pivot = array[end];

            int i = start - 1;

            for(int  j = start; j<end;j++)
            {
                if (array[j] < pivot) {
                    i++;
                    swap(array,i, j);

                
                }

            }
            i++;

            swap(array, i, end);

            return i;
        
        }
        //mergeSort
        //HeapSort
        //InsertionSort
        //SelectionSort
        //BubbleSort

        public static int[] generateRandomArray(int n, int bound) {
            Random random = new Random();
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, bound + 1);

            }

            return array;

        }


        public static void displayArray(int[] array)
        {

            for (int i = 0; i < array.Length; i++) {

                Console.Write(array[i] + " ");
            }
        }
        static void Main(string[] args)
        {
            bool tryAgain = true;


            while (tryAgain)
            {
                Console.Write("Enter your preferred array size: ");
                int n = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nEnter preferred bound: ");
                int bound = Convert.ToInt32(Console.ReadLine());


                int[] randomArray = generateRandomArray(n, bound);
                Console.WriteLine();
                Console.WriteLine("Generated random Array: ");
                displayArray(randomArray);

                Console.WriteLine();
                Console.WriteLine("\nSelect sorting algorithm:\n1.QuickSort\n2.MergeSort\n3.InsertionSort\n4.SelectionSort\n.5.HeapSort\n6.BubbleSort ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {

                    case 1:
                        Console.WriteLine("\nSorted array using quickSort: ");
                        quickSort(randomArray, 0, randomArray.Length - 1);
                        displayArray(randomArray);
                        break;

                    case 2:
                        Console.WriteLine("\nSorted using mergeSort: ");
                        mergeSort(randomArray);
                        displayArray(randomArray);
                        break;
                    case 3:
                        Console.WriteLine("\nSorted using heapSort: ");
                        heapSort(randomArray);
                        displayArray(randomArray);
                        break;
                    case 4:
                        break;

                    case 5:
                        break;
                    case 6:
                        break;

                    default:
                        break;


                }

                Console.Write("\nSort again (y/n): ");
                string response = Console.ReadLine();
                if (response.ToLower() == "n") { 
                tryAgain = false;
                }
            }


            Console.ReadLine();

        }
    }
}
