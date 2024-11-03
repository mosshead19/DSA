using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingImplementationPractice
{
    internal class Program
    {


        public static void swap(int[] array, int i, int j)
        {

            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;


        }
        public static int partition(int[] array, int start, int end)
        {

            int pivot = array[end];

            int i = start - 1;

            for (int j = start; j < end; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    swap(array, i, j);


                }

            }
            i++;

            swap(array, i, end);

            return i;

        }

        public static int quickSelect(int[] array, int start, int end,int target) {

            if (start <= end) { 
            int pivot = partition(array, start, end);

                if (pivot == target-1) {
                    return array[pivot];
                }

                if (pivot > target - 1) {
                    return quickSelect(array, start, pivot - 1, target);

                }

                if(pivot < target - 1)
                {
                    return quickSelect(array, pivot + 1, end,target);
                }
            
            
            
            }
            return -1;
        }

        //BinarySearch
        public static int binarySearch(int[] array, int target) {
            int l = 0;
            int r = array.Length - 1;

            while (l <= r) { 
            int mid = l+ (r - l) / 2;

                if (array[mid] == target)
                {
                    return mid;
                }
                else if (array[mid] > target) {

                    r = mid - 1;
                
                }
                else
                {
                    l = mid + 1;
                }
            
            }

            return -1;
        
        
        
        }


        //interpolationSearch

        public static int interSearch(int[] array,int lo, int hi, int target) {

            int pos;

            while (lo <= hi && target >= array[lo] && target <= array[hi]) {

                pos = lo + (int)((double)(hi - lo) / (array[hi] - array[lo]) * (target - array[lo]));


                if (array[pos] == target) {

                    return pos;
                }

                if (array[pos] > target) {

                    return interSearch(array, lo, pos - 1, target);
                }

                if (array[pos] < target) {
                    return interSearch(array, pos + 1, hi, target);
                }
            }


            return -1;
        
        }
        static void Main(string[] args)
        {

            int[] unsortedArray = { 29, 10, 14, 37, 14 };
            int[] sortedArray = { 10, 14, 14, 29, 37 };

            // Randomly select k for QuickSelect
            Random random = new Random();
            int targetPosition = random.Next(1, unsortedArray.Length + 1); // Random k between 1 and array length
            int quickSelectResult = quickSelect((int[])unsortedArray.Clone(), 0, unsortedArray.Length - 1, targetPosition);
            Console.WriteLine($"QuickSelect: The {targetPosition}-th smallest element is {quickSelectResult}");

            // Binary Search Test: Search for element 29
            int binarySearchTarget = 29;
            int binarySearchResult = binarySearch(sortedArray, binarySearchTarget);
            Console.WriteLine($"BinarySearch: Element {binarySearchTarget} is at index {binarySearchResult}");

            // Interpolation Search Test: Search for element 14
            int interSearchTarget = 14;
            int interSearchResult = interSearch(sortedArray, 0, sortedArray.Length - 1, interSearchTarget);
            Console.WriteLine($"InterpolationSearch: Element {interSearchTarget} is at index {interSearchResult}");


            Console.ReadLine();
        }
    }
}
