    // Сам лист

    // Заполнение нового массива сначала было написано с применением Array.Copy
    // Время данной реализации оказалось дольше времени работы реализации через for
    // Но заменену произвел только в методах Remove и RemoveAt

    // Реализованы методы: ToArray, Add, Insert, InsertRange, Remove, RemoveAt, Clear, Contains, Sort

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
            if (Count == m_array.Length)
			{
				Array.Resize(ref m_array, 1 + m_array.Length * 2);
			}
			m_array[Count++] = item;
    }

    public void Insert(Int32 index, TItem item)
    {
        if(index < 0 || index > Count)
        {
            Console.WriteLine("Индекс за границами промежутка");
            return;
        }
        if (Count == m_array.Length)
		{
			Array.Resize(ref m_array, 1 + m_array.Length * 2);
		}
        for(int i = Count; i > index; i--)
        {
            m_array[i] = m_array[i - 1];
        }
        m_array[index] = item;
        Count++;
    }

    public void InsertRange(Int32 index, TItem[] arrayData)
    {
        if(index < 0 || index > Count)
        {
            Console.WriteLine("Индекс за границами промежутка");
            return;
        }

        int arrayDataLenght = arrayData.Length;

        if (Count + arrayDataLenght >= m_array.Length)
		{
			Array.Resize(ref m_array, m_array.Length + arrayDataLenght);
		}
        
        for(int i = Count + arrayDataLenght - 1, j = Count - 1; i >= index + arrayDataLenght; i--, j--)
        {
            m_array[i] = m_array[j];
        }
        for(int i = index, j = 0; j < arrayDataLenght; i++, j++)
        {
            m_array[i] = arrayData[j];
        }
        Count += arrayDataLenght;
    }

    public void Remove(TItem item)
    {
        for(int i = 0; i < Count; i++)
        {
            if(Comparer<TItem>.Default.Compare(m_array[i], item) == 0)
                {
                    for(int j = i; j < Count; j++)
                    {
                        m_array[j] = m_array[j + 1];
                    }
                    Count--;
                    return;
                }
        }
    }

    public void RemoveAt(int index)
    {
        if(index < 0 || index >= Count)
        {
            Console.WriteLine("Индекс за границами промежутка");
            return;
        }
		for (int i = index; i < Count; i++)
		{
			m_array[i] = m_array[i + 1];
		}
        Count--;
    }

    public void Clear()
    {
            Count = 0;
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
        for (int i = 0; i< Count; i++)
        {
            yield return m_array[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator(); 
    }
}