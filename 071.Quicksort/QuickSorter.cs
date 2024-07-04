using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _071.Quicksort
{
    public class QuickSorter
    {
        public static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end || start < 0)
            {
                return;
            }

            int pivotIndex = Partitioner(array, start, end);

            QuickSort(array, start, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, end);
        }

        private static int Partitioner(int[] array, int start, int end)
        {
            int pivot = array[end];
            int pivotIndex = start - 1;
            for (int i = start; i <= end -1; i++)
            {
                if (array[i] <= pivot)
                {
                    pivotIndex++;
                    Swap(array, i, pivotIndex);
                }
            }

            pivotIndex++;
            Swap(array, pivotIndex, end);

            return pivotIndex;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
