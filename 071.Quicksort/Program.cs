using _071.Quicksort;
using System.Diagnostics;

//var array = new int[] { 1, 55, 33, 45345, 5445, 23, 5, 65 };

//Console.WriteLine($"Array: {string.Join(", ", array)}");

//QuickSorter.QuickSort(array, 0, array.Length - 1);

//Console.WriteLine($"Sorted array: {string.Join(", ", array)}");

int n = 100_000;
Random random = new Random();
int[] arr = new int[n];
for (int i = 0; i < n; i++)
{
    arr[i] = random.Next();
}

Measure(QuickSorter.QuickSort, arr, "Quick Sort", 0, arr.Length - 1);

static void Measure(Action<int[], int, int> action, int[] arr, string name, int start, int end)
{
    Stopwatch watch = new Stopwatch();
    watch.Start();
    action(arr, start, end);
    watch.Stop();
    Console.WriteLine($"{name} N={arr.Length} --> {watch.ElapsedMilliseconds}");
}
