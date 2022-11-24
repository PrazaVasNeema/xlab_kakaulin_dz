public static class BubbleSort<T>
{
    public static MyList<T> Sort(ref MyList<T> array)
    {
        T temp;
        int count = array.Count;
        for(int i = 0; i < count - 1; i++)
            for(int j = i + 1; j < count; j++)
            {
                if(Comparer<T>.Default.Compare(array[i], array[j]) >= 0)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        return array;
    }
}