public static class QuickSort<T>
{
    public static MyList<T> Sort(ref MyList<T> array)
    {
        QuickSortImpl(ref array, 0, array.Count - 1);
        return array;
    }
                 
    private static int Partition(ref MyList<T> array, int l, int r) {
        T temp;
        T x = array[r];
        int less = l;
        for (int i = l; i < r; ++i) {
            if (Comparer<T>.Default.Compare(array[i], x) >= 0 ) 
            {
                temp = array[i];
                array[i] = array[less];
                array[less] = temp;
                less++;
            }
        }
        temp = array[less];
        array[less] = array[r];
        array[r] = temp;
        return less;
    }
    private static void QuickSortImpl(ref MyList<T> array, int l, int r)
    {
        if (l < r) {
          int q = Partition(ref array, l, r);
          QuickSortImpl(ref array, l, q - 1);
          QuickSortImpl(ref array, q + 1, r);
        }
    }
}