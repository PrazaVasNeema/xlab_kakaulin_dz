using System.Collections;
public class MyList<TItem> : IEnumerable<TItem>
{

    private TItem[] m_array = new TItem[0];

    public int Count {get; private set;}

    public TItem this[int index]
    {
        get
        {
            return m_array[index];
        }
        set
        {
            m_array[index] = value;
        }
    }    

    public void Add(TItem item)
    {
        Array.Copy(m_array, m_array = new TItem[++Count], Count - 1);
        m_array[Count - 1] = item;
    }

        public void Remove(TItem item)
    {
        for(int i = 0; i < Count; i++)
        {
            if(Comparer<TItem>.Default.Compare(m_array[i], item) == 0)
                {
                    TItem[] arrayAssembler = new TItem[--Count];
                    Array.Copy(m_array, arrayAssembler, i);
                    Array.Copy(m_array, i + 1, arrayAssembler, i, Count - i);
                    m_array = arrayAssembler;
                    return;
                }
        }
    }
        public void RemoveAt(int index)
    {

    }

        public void Clear()
    {

    }

    public IEnumerator<TItem> GetEnumerator()
    {
        for (int i = 0; i< m_array.Length; i++)
        {
            yield return m_array[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator(); 
    }
}