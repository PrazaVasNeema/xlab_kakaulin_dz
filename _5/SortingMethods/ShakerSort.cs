public static class ShakerSort<T>
{
    public static MyList<T> Sort(ref MyList<T> array)
    {
        T temp;
        int count = array.Count;
        int left = 0;
        int right = array.Count - 1;
        while (left <= right) {
            for (int i = right; i > left; --i) {
              if (Comparer<T>.Default.Compare(array[i - 1], array[i]) >= 0) {
                  temp = array[i];
                  array[i] = array[i - 1];
                  array[i - 1] = temp;
              }
            }
            ++left;
            for (int i = left; i < right; ++i) {
              if (Comparer<T>.Default.Compare(array[i], array[i + 1]) >= 0) {
                  temp = array[i];
                  array[i] = array[i + 1];
                  array[i + 1] = temp;
              }
            }
            --right;
        }
        return array;
    }
}