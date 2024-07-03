namespace _07.SortingAlgorithms
{
    public class MergeSorter
    {
        public static int[] MergeSort(int[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }

            int middle = array.Length / 2;
            int[] leftArray = PopulateArray(array, 0, middle);
            int[] rightArray = PopulateArray(array, middle, array.Length);

            Console.WriteLine
                ($"Left: {string.Join(", ", leftArray)} --- Right: {string.Join(", ", rightArray)}");

            return MergeArrays(MergeSort(leftArray), MergeSort(rightArray));
        }

        static int[] MergeArrays(int[] left, int[] right)
        {
            int index = 0;
            int[] merged = new int[left.Length + right.Length];

            int leftIndex = 0;
            int rightIndex = 0;

            while (true)
            {
                if (leftIndex < left.Length && rightIndex < right.Length)
                {
                    if (left[leftIndex] < right[rightIndex])
                    {
                        merged[index++] = left[leftIndex++];
                    }
                    else
                    {
                        merged[index++] = right[rightIndex++];
                    }
                }
                else if (leftIndex < left.Length)
                {
                    merged[index++] = left[leftIndex++];
                }
                else if (rightIndex < right.Length)
                {
                    merged[index++] = right[rightIndex++];
                }
                else
                {
                    return merged;
                }
            }
        }

        public static int[] PopulateArray(int[] array, int start, int end)
        {
            int[] newArray = new int[end - start];

            for (int i = 0; i <= newArray.Length - 1; i++)
            {
                newArray[i] = array[start + i];
            }

            return newArray;
        }
    }
}
