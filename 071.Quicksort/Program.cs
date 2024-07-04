using _071.Quicksort;

var array = new int[] { 1, 55, 33, 45345, 5445, 23, 5, 65 };

Console.WriteLine($"Array: {string.Join(", ", array)}");

QuickSorter.QuickSort(array, 0, array.Length - 1);

Console.WriteLine($"Sorted array: {string.Join(", ", array)}");