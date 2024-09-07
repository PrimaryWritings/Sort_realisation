using System;

public class Sort
{
    public static void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Item swap
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    public static void Bubble2Sort(int[,] array)
    {
        int n = array.GetLength(0);
        int m = array.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                for (int a = 0; a < n; a++)
                {
                    for (int b = 0; b < m; b++)
                    {
                        if (array[a, b] > array[i, j])
                        {
                            int temp = array[a, b];
                            array[a, b] = array[i, j];
                            array[i, j] = temp;
                        }
                    }
                }
            }
        }
    }


    public static void ShakerSort(int[] array)
    {
        int n = array.Length;
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < n - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    // Item swap
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped)
                break;

            swapped = false;
            for (int i = n - 2; i >= 0; i--)
            {
                if (array[i] > array[i + 1])
                {
                    // Item swap
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);
    }


    public static void SelectionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            // Item swap
            int temp = array[i];
            array[i] = array[minIndex];
            array[minIndex] = temp;
        }
    }


    public static void InsertionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 1; i < n; i++)
        {
            int key = array[i];
            int j = i - 1;

            // Shift elements bigger than key
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }

            // Inserting the key in the correct place
            array[j + 1] = key;
        }
    }


    public static void BinaryInsertionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 1; i < n; i++)
        {
            int key = array[i];
            int left = 0, right = i - 1;

            // Binary search to determine the insertion location
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] > key)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            // Element shift and key insertion
            for (int j = i - 1; j >= left; j--)
            {
                array[j + 1] = array[j];
            }
            array[left] = key;
        }
    }
  

    public static void ShellSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 5; i++)
        {
            int minIndex = i;
            for (int j = i + 4; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            // Item swap
            int temp = array[i];
            array[i] = array[minIndex];
            array[minIndex] = temp;
        }
        for (int i = 0; i < n - 3; i++)
        {
            int minIndex = i;
            for (int j = i + 2; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            int temp = array[i];
            array[i] = array[minIndex];
            array[minIndex] = temp;
        }
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
 
            int temp = array[i];
            array[i] = array[minIndex];
            array[minIndex] = temp;
        }

    }


    public static void HeapSort(int[] array)
    {
        int n = array.Length;
        for (int i = n / 2 - 1; i >= 0; i--)
            Heap(array, n, i);

        for (int i = n - 1; i >= 0; i--)
        {
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp;

            Heap(array, i, 0);
        }


    }
    public static void Heap(int[] array, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && array[left] > array[largest])
            largest = left;
        if (right < n && array[right] > array[largest])
            largest = right;

        if (largest != i)
        {
            int swap = array[i];
            array[i] = array[largest];
            array[largest] = swap;

            Heap(array, n, largest);
        }


    }


    public static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int baseIndex = Partition(arr, low, high);
            QuickSort(arr, low, baseIndex - 1);
            QuickSort(arr, baseIndex + 1, high);
        }
    }
    private static int Partition(int[] arr, int low, int high)
    {
        int median = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < median)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int temp2 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp2;

        return i + 1;
    }

}

