using _07.SortingAlgorithms;

var array = new int[] { 1, 55, 33, 44, 2, 11, 3 };

Console.WriteLine($"Array: {string.Join(", ", array)}");

Console.WriteLine($"Sorted Array: {string.Join(", ", MergeSorter.MergeSort(array))}");







