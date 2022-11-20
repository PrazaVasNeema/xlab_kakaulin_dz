using System.Collections;

public class MyLinkedList<TItem> : IEnumerable<TItem>
{
    private class Node
    {
        public TItem value;
        public Node prev;
        public Node next;
    }
    public int Count {get; private set;}
    private Node nodeFirst;
    private Node nodeLast;
    public TItem first
    {
        get
        {
            return nodeFirst.value;
        }
        private set{}
    }
    public TItem last
    {
        get
        {
            return nodeLast.value;
        }
        private set{}
    }
    public MyLinkedList(TItem value)
    {
        AddOnly(value);

    }
    public MyLinkedList()
    {
        nodeFirst = null;
        nodeLast = null;
        Count = 0;
    }

    private void AddOnly(TItem value)
    {
        Node temp = new Node();
        temp.value = value;
        temp.prev = null;
        temp.next = null;
        nodeFirst = temp;
        nodeLast = temp;
        Count = 1;
    }

    public void Push(TItem value)
    {
        if(nodeFirst == null)
        {
            AddOnly(value);
            return;
        }
        Node temp = new Node();
        temp.value = value;
        temp.prev = null;
        temp.next = nodeFirst;
        nodeFirst.prev = temp;
        nodeFirst = temp;
        Count++;
    }

    public TItem Pop() // возвращает и удалаяет последний элемент из листа
    {
        if(nodeFirst == null)
        {
            return default(TItem);
        }
        Node temp = nodeFirst;
        TItem returnValue = nodeFirst.value;

        if(nodeFirst == nodeLast)
        {
            nodeFirst = null;
            nodeLast = null;
        }
        else
        {
            nodeFirst = nodeFirst.next;
            nodeFirst.prev = null;
            temp = null;
        }
        Count--;
        return returnValue;
    }

    public TItem Peek()
    {
        if(nodeFirst == null)
        {
            return default;
        }
        return nodeFirst.value;
    }

    public void Clear()
    {  
        Node temp;
        while(nodeFirst != null && nodeFirst.next != null)
        {
            temp = nodeFirst;
            nodeFirst = nodeFirst.next;
            temp = null;
        }
        nodeFirst = null;
        Count = 0;
    }

    public void AddLast(TItem value)
    {
        if(nodeLast == null)
        {
            AddOnly(value);
            return;
        }
        Node temp = new Node();
        temp.value = value;
        temp.prev = nodeLast;
        temp.next = null;
        nodeLast.next = temp;
        nodeLast = temp;
        Count++;
    }

    public TItem RemoveLast()
    {
        if(nodeLast == null)
        {
            return default;
        }
        Node temp = nodeLast;
        TItem returnValue = nodeLast.value;

        if(nodeFirst == nodeLast)
        {
            nodeFirst = null;
            nodeLast = null;
        }
        else
        {
            nodeLast = nodeLast.prev;
            nodeLast.next = null;
            temp = null;
        }

        Count--;
        return returnValue;
    }

    public void Remove(TItem value)
    {
        Node current = nodeFirst;
        while(current != null)
        {
            if(Comparer<TItem>.Default.Compare(current.value, value) == 0)
            {
                if(current.prev == null)
                {
                    nodeFirst = nodeFirst.next;
                    nodeFirst.prev = null;
                    return;
                }
                else if (current.next == null)
                {
                    nodeLast = nodeLast.prev;
                    nodeLast.next = null;
                    return;
                }
                else
                {
                    Node temp = current.next;
                    current.next = temp.next;
                    temp.next.prev = current;
                    temp = null;
                    return;
                }
            }
            current = current.next;
        }
        Count--;
    }

    public bool Contains(TItem value) // возвращает и удалаяет последний элемент из листа
    {
        Node current = nodeFirst;
        while(current != null)
        {
            if(Comparer<TItem>.Default.Compare(current.value, value) == 0)
            {
                return true;
                
            }
            current = current.next;
        }
        return false;
    }

    public IEnumerator<TItem> GetEnumerator()
    {
        Node current = nodeFirst;
        while(current != null)
        {
            yield return current.value;
            current = current.next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator(); 
    }
}


// больше методов = больше плюсов
// мини тест наших листов, сравнить по скорости ( в форе проинициализировать ( по 1000 элементов))

//что такое yield return current.value
//что такое default(TItem)