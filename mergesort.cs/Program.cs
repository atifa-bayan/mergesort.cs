using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Input array
        int[] data = { 3, 7, 8, 5, 4, 2, 6, 1 };

        // Display input array
        Console.WriteLine("Input: " + string.Join(", ", data));

        // Sort the array using MergeSort
        MergeSort(data, 0, data.Length - 1);

        // Display sorted array
        Console.WriteLine("Sorted: " + string.Join(", ", data));

        // Accept user input for sorting
        Console.WriteLine("Test your merge sort, Enter numbers separated by spaces:");
        string userInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(userInput))
        {
            List<int> userArray = new List<int>();
            string[] userNumbers = userInput.Split(' ');
            foreach (string num in userNumbers)
            {
                if (int.TryParse(num, out int number))
                {
                    userArray.Add(number);
                }
            }

            // Sort the user array
            int[] userArrayToSort = userArray.ToArray();
            MergeSort(userArrayToSort, 0, userArrayToSort.Length - 1);

            // Display sorted user array
            Console.WriteLine("Sorted User Input according to merge Sort: " + string.Join(", ", userArrayToSort));
        }
        else
        {
            Console.WriteLine("No input provided.");
        }
    }

    static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            // Find the middle point
            int middle = (left + right) / 2;

            // Recursively sort first and second halves
            MergeSort(array, left, middle);
            MergeSort(array, middle + 1, right);

            // Merge the sorted halves
            Merge(array, left, middle, right);
        }
    }

    static void Merge(int[] array, int left, int middle, int right)
    {
        // Sizes of two subarrays to be merged
        int n1 = middle - left + 1;
        int n2 = right - middle;

        // Temporary arrays
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        // Copy data to temporary arrays
        for (int i = 0; i < n1; i++)
            leftArray[i] = array[left + i];
        for (int j = 0; j < n2; j++)
            rightArray[j] = array[middle + 1 + j];

        // Initial indices of subarrays and merged array
        int iIndex = 0, jIndex = 0, kIndex = left;

        // Merge the arrays
        while (iIndex < n1 && jIndex < n2)
        {
            if (leftArray[iIndex] <= rightArray[jIndex])
            {
                array[kIndex] = leftArray[iIndex];
                iIndex++;
            }
            else
            {
                array[kIndex] = rightArray[jIndex];
                jIndex++;
            }
            kIndex++;
        }

        // Copy remaining elements of leftArray[]
        while (iIndex < n1)
        {
            array[kIndex] = leftArray[iIndex];
            iIndex++;
            kIndex++;
        }

        // Copy remaining elements of rightArray[]
        while (jIndex < n2)
        {
            array[kIndex] = rightArray[jIndex];
            jIndex++;
            kIndex++;
        }
    }
}
