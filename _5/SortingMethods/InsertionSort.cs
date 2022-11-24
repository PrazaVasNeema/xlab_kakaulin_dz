public static class InsertionSort<T>
{
    public static MyList<T> Sort(ref MyList<T> array)
    {
        T x;
        for (int i = 1; i < array.Count; i++) {
            x = array[i];
            int j;
            for(j = i; j > 0 && Comparer<T>.Default.Compare(array[j - 1], x) >= 0; j--)
            {
                array[j] = array[j - 1];
            }
            array[j] = x;
        }
        return array;
    }
}