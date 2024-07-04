using _07.SortingAlgorithms;
using System.Diagnostics;

//var array = new int[] { 1, 55, 33, 44, 2, 11, 3 };

//Console.WriteLine($"Array: {string.Join(", ", array)}");

//Console.WriteLine($"Sorted Array: {string.Join(", ", MergeSorter.MergeSort(array))}");

int n = 100_000;
Random random = new Random();
int[] arr = new int[n];
for (int i = 0; i < n; i++)
{
    arr[i] = random.Next();
}

Measure(MergeSorter.MergeSort, arr, "Merge Sort");

static void Measure(Func<int[], int[]> action, int[] arr, string name)
{
    Stopwatch watch = new Stopwatch();
    watch.Start();
    action(arr);
    watch.Stop();
    Console.WriteLine($"{name} N={arr.Length} --> {watch.ElapsedMilliseconds}");
}



