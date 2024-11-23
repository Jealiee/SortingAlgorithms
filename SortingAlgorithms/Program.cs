using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace sort_AaDS
{
    class Sort
    {
        // To have a visual of each result for checkin purposes.
        public static void PrintArray(int[] an_array)
        {
            foreach (int i in an_array)
            {
                Console.WriteLine(i + " ");
            }

        }

        // To not rewrite it 20 000 times.
        public static void Swap(int[] an_array, int i, int j)
        {
            int temp = an_array[i];
            an_array[i] = an_array[j];
            an_array[j] = temp;

        }

        public static void SelectionSort(int[] an_array)
        {
         //TODO implemment here
        }


        public static void BubbleSort(int[] an_array)
        {
            bool swapped;
            int temp;

            for (int i = 0;i < an_array.Length;i++)
            {
                swapped = false;

                 for (int j = 0;j < an_array.Length - 1; j++)
                 {
                    if (an_array[j]<an_array[j+1])
                    {
                        Swap(an_array, i,j);
                        swapped = true;
                    }
                    if (swapped == false)
                        break;
                 }
            }
        }


        public static void InsertionSort(int[] an_array)
        {
            for (int i = 0; i < an_array.Length;i++)
            {
               
                int j = i - 1;
                while (j >= 0 && an_array[j] > an_array[i])
                {
                    an_array[j+1] = an_array[j];
                    j = j - 1;

                }
                an_array[j+1] = an_array [i];
            }

        }

        //  Here chosen as the  pivot is the last element.
        public static int Partition (int[] an_array, int l, int u)
        {
            int pivot = an_array[u];
            int i = l - 1;

            for (int j = l; j < u; j++)
            {
                if(an_array[j] < pivot)
                {
                    i++;
                    Swap (an_array, i, j);        
                }

            }
            Swap (an_array,i+1, u);
            return i+1;
        }
        public static int PartitionRandom(int[] an_array, int l, int u)
        {
            Random r = new Random();
            int pivotRandom = r.Next (l, u + 1);
            int i = l - 1;

            Swap(an_array, pivotRandom, u);

            int pivot = an_array[u];

            for (int j = l; j < u; j++)
            {
                if (an_array[j] < pivot)
                {
                    i++;
                    Swap(an_array, i, j);
                }

            }
            Swap(an_array, i + 1, u);
            return i + 1;
        }

        public static void QuickSort(int[] an_array, int l, int u)
        {
            if (l<u)
            {
                int pIndex= Partition (an_array, l, u);
                QuickSort(an_array, l, pIndex - 1);
                QuickSort(an_array, pIndex + 1, u);
                
            }
        }

      
        public static void QuickSortModified(int[] an_array, int l, int u)
        {
            if (l < u)
            {
                int pIndex = PartitionRandom(an_array, l, u);
                QuickSortModified(an_array, l, pIndex - 1);
                QuickSortModified(an_array, pIndex + 1, u);

            }
        }


        /// <summary>
        /// Example of testing the methods
        /// </summary>
        /// 
        static void Exercise_0()
        {
            int TABLE_SIZE = 10;
            Stopwatch counter = new Stopwatch();
            Random generator = new Random(1-10);

            int[] a_table = new int[TABLE_SIZE];

            for (int i = 0; i < a_table.Length; i++)
            {
                a_table[i] = generator.Next();
            }

            // Print original array
            Console.WriteLine("Unsorted arrray:");
            PrintArray(a_table);

            int[] a_table_selection = new int[TABLE_SIZE];
            int[] a_table_bubble = new int[TABLE_SIZE];
            int[] a_table_insertion = new int[TABLE_SIZE];
            int[] a_table_quick = new int[TABLE_SIZE];
            int[] a_table_standard = new int[TABLE_SIZE];

            Array.Copy(a_table, a_table_selection, TABLE_SIZE);
            Array.Copy(a_table, a_table_bubble, TABLE_SIZE);
            Array.Copy(a_table, a_table_insertion, TABLE_SIZE);
            Array.Copy(a_table, a_table_quick, TABLE_SIZE);
            Array.Copy(a_table, a_table_standard, TABLE_SIZE);


            counter.Start();
            SelectionSort(a_table_selection);
            counter.Stop();
            TimeSpan time_selection = counter.Elapsed;

            counter.Restart();  // or: counter.Reset(); counter.Start();
            BubbleSort(a_table_bubble);
            counter.Stop();
            TimeSpan time_bubble = counter.Elapsed;

            counter.Restart();
            InsertionSort(a_table_insertion);
            counter.Stop();
            TimeSpan time_insertion = counter.Elapsed;

            counter.Restart();
            QuickSort(a_table_quick, 0, a_table_quick.Length - 1);
            counter.Stop();
            TimeSpan time_quick = counter.Elapsed;

            counter.Restart();
            Array.Sort(a_table_standard);
            counter.Stop();
            TimeSpan time_standard = counter.Elapsed;

            //Make sure if sorting is implemented
            SortingTests.Assert(SortingTests.isSortedAscending(a_table_selection), "Selection sort implemented wrongly!");
            SortingTests.Assert(SortingTests.isSortedAscending(a_table_bubble), "Bubble sort implemented wrongly!");
            SortingTests.Assert(SortingTests.isSortedAscending(a_table_insertion), "Insertion sort implemented wrongly!");
            SortingTests.Assert(SortingTests.isSortedAscending(a_table_quick), "Quick sort implemented wrongly!");
            SortingTests.Assert(SortingTests.isSortedAscending(a_table_standard), "Standard method Array.Sort implemented wrongly!");

            //If all the assertion have passed, print out the results and arrrays
            Console.WriteLine("Selection:  {0}", time_selection);
            PrintArray(a_table_selection);
            Console.WriteLine("Bubble:     {0}", time_bubble);
            PrintArray(a_table_bubble);
            Console.WriteLine("Insertion:  {0}", time_insertion);
            PrintArray(a_table_insertion);
            Console.WriteLine("Quick :     {0}", time_quick);
            PrintArray(a_table_quick);
            Console.WriteLine("Array.Sort: {0}", time_standard);
            PrintArray(a_table_standard);


        }

        static void Main(string[] args)
        {
            Exercise_0();
            //TODO Create, implement and lauch other exercises

        }
    }
    /// <summary>
    /// Additional class for testing purpose 
    /// </summary>
    class SortingTests
    {
        /// <summary>
        /// Check if sorted ascending
        /// </summary>
        /// <returns>true if sorted ascending, false otherwise</returns>
        public static bool isSortedAscending(int[] an_array)
        {
            for (int i = 1; i < an_array.Length; i++)
            {
                if (an_array[i - 1] > an_array[i])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Check if sorted dsescending
        /// </summary>
        /// <returns>true if sorted descending, false otherwise</returns>
        public static bool isSortedDescending(int[] an_array)
        {
            for (int i = 1; i < an_array.Length; i++)
            {
                if (an_array[i - 1] < an_array[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static void Assert(bool condition, String message)
        {
            if (!condition)
            {
                throw new ArgumentException(message);
            }
        }
    }
}

