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
    public TItem[] ToArray()
    {
        return m_array;
    }

    public MyList(TItem[] array)
    {
        this.m_array = array;
    }
    public MyList()
    {
    }

    public void Add(TItem item)
    {
        Array.Copy(m_array, m_array = new TItem[++Count], Count - 1);
        m_array[Count - 1] = item;
    }

    public void Insert(Int32 index, TItem item)
    {
            if(index < 0 || index > Count)
            {
                Console.WriteLine("Индекс за границами промежутка");
                return;
            }
            TItem[] arrayAssembler = new TItem[++Count];
            Array.Copy(m_array, arrayAssembler, index);
            arrayAssembler[index] = item;
            Array.Copy(m_array, index, arrayAssembler, index + 1, Count - index - 1);
            m_array = arrayAssembler;
            return;
    }

    public void InsertRange(Int32 index, System.Collections.Generic.IEnumerable<TItem> arrayData)
    {
        if(index < 0 || index > Count)
        {
            Console.WriteLine("Индекс за границами промежутка");
            return;
        }
        TItem[] DataArray = arrayData.ToArray<TItem>();
        Count += DataArray.Length;
        TItem[] arrayAssembler = new TItem[Count];
        Array.Copy(m_array, arrayAssembler, index);
        Array.Copy(DataArray, 0, arrayAssembler, index, DataArray.Length);
        Array.Copy(m_array, index, arrayAssembler, index + DataArray.Length, Count - index - DataArray.Length);
        m_array = arrayAssembler;
        return;
    }

    public void RemoveTestForLoop(TItem item)
    {
        for(int i = 0; i < Count; i++)
        {
            if(Comparer<TItem>.Default.Compare(m_array[i], item) == 0)
                {
                    TItem[] arrayAssembler = new TItem[--Count];
                    for (int j = 0; j < Count; j++)
                    {
                        if(j < i)
                        {
                            arrayAssembler[j] = m_array[j];
                        }
                        else
                        {
                            arrayAssembler[j] = m_array[j - 1];
                        }

                    }
                    m_array = arrayAssembler;
                    return;
                }
        }
    }

    public void RemoveTestForLoop2(TItem item)
    {
        for(int i = 0; i < Count; i++)
        {
            if(Comparer<TItem>.Default.Compare(m_array[i], item) == 0)
                {
                    TItem[] arrayAssembler = new TItem[--Count];
                    for (int j = 0; j < i; j++)
                    {
                        arrayAssembler[j] = m_array[j];
                    }
                    for (int j = i; j < Count; j++)
                    {
                        arrayAssembler[j] = m_array[j - 1];
                    }

                    
                    m_array = arrayAssembler;
                    return;
                }
        }
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
        if(index < 0 || index > Count)
        {
            Console.WriteLine("Индекс за границами промежутка");
            return;
        }
        TItem[] arrayAssembler = new TItem[--Count];
        Array.Copy(m_array, arrayAssembler, index);
        Array.Copy(m_array, index + 1, arrayAssembler, index, Count - index);
        m_array = arrayAssembler;
        return;
    }

    public void Clear()
    {
            Count = 0;
            m_array = new TItem[Count];
    }

    public bool Contains(TItem item)
    {
        for(int i = 0; i < Count; i++)
        {
            if(Comparer<TItem>.Default.Compare(m_array[i], item) == 0)
                {
                    return true;
                }
        }
        return false;
    }

    public void Sort()
    {
        TItem temp;
        for(int i = 0; i < Count - 1; i++)
            for(int j = i + 1; j < Count; j++)
            {
                if(Comparer<TItem>.Default.Compare(m_array[i], m_array[j]) >= 0 )
                {
                    temp = m_array[i];
                    m_array[i] = m_array[j];
                    m_array[j] = temp;
                }
            }
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