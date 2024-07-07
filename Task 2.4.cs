using System;

class Program
{
    public static void Main(string[] args)
    {
        int[] array = { 12, 34, 54, 2, 3, 1, 45, 67, 23 };

        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        MergeSort(array, 0, array.Length - 1);

        Console.WriteLine("\n Отсортированный массив:");
        PrintArray(array);

        Console.WriteLine("\n Введите новые элементы массива через запятую:");
        string input = Console.ReadLine();
        string[] inputArray = input.Split(',');
        int[] newArray = Array.ConvertAll(inputArray, int.Parse);

        Console.WriteLine(" Массив после добавления новых элементов:");
        PrintArray(newArray);
    }

    static void MergeSort(int[] arr, int l, int r)
    {
        if (l < r)
        {
            int m = l + (r - l) / 2;

            MergeSort(arr, l, m);
            MergeSort(arr, m + 1, r);

            Merge(arr, l, m, r);
        }
    }

    static void Merge(int[] arr, int l, int m, int r)
    {
        int n1 = m - l + 1;
        int n2 = r - m;

        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(arr, l, L, 0, n1);
        Array.Copy(arr, m + 1, R, 0, n2);

        int i = 0, j = 0;
        int k = l;

        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
