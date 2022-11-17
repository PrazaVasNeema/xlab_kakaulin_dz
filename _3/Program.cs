class Program
{
    //TO DO
    //Add( T ), Clear(), Insert( Int32, T ), RemoveAt( Int32 ), Sort()
    // Contains(T)

    struct MyList<T>
    {
        T[] array;
        int arraySize;
        public MyList()
        {
            arraySize = 0;
            array = new T[0];
        }

        public void Add(T item)
        {
            T[] tempArray = array;
            arraySize++;
            array = new T[arraySize];
            for (int i = 0; i < arraySize - 1; i++)
            {
                array[i] = tempArray[i];
            }
            array[arraySize-1] = item;
        }

        public void Clear()
        {
            arraySize = 0;
            array = new T[0];
        }

        public void Insert(Int32 index, T item)
        {
            T[] tempArray = array;
            arraySize++;
            array = new T[arraySize];
            
            for (int i = 0, indicesDiff = 0; i < arraySize; i++)
            {
                if(i == index)
                {
                    array[index] = item;
                    indicesDiff++;
                }
                else
                {
                    array[i] = tempArray[i - indicesDiff];
                }
            }
        }

        public void RemoveAt(Int32 index)
        {
            T[] tempArray = array;
            arraySize--;
            array = new T[arraySize];
            
            for (int i = 0, indicesDiff = 0; i < arraySize; i++)
            {
                if(i == index)
                {
                    indicesDiff++;
                }
                else
                {
                    array[i  - indicesDiff] = tempArray[i];
                }
            }
        }

        public void Sort()
        {
            T temp;
            for(int i = 0; i < arraySize; i++)
            {
                for(int j = i + 1; j < arraySize; j++)
                {
                    if (Comparer<T>.Default.Compare(array[i], array[j]) >= 0)
                    {
                        temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
        }

        public bool Contains(T item)
        {
            foreach (T curArrayItem in array)
            {
                if(Comparer<T>.Default.Compare(curArrayItem, item) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public T[] GetArray()
        {
            return array;
        }
    }

    static void Main(string[] args)
    {
        MyList<int> test = new MyList<int>();
        int testVar = 0;
        string exitLooker;
        Console.WriteLine("Для выхода нажмите enter без ввода");
        Console.WriteLine("Введите целые числа:");
        do
        {
            exitLooker = Console.ReadLine();
            try
            {
                testVar = Convert.ToInt32(exitLooker);
                test.Add(testVar);
            }
            catch
            {
                if (exitLooker != "")
                    Console.WriteLine("\nНеправильное значение\n");
            }

        }
        while(exitLooker != "");

        Console.WriteLine("\n_____________\n\nGetArray()\n");

        foreach(int i in test.GetArray()){
            Console.WriteLine(i);
        }
        
        Console.WriteLine("\n_____________\n\nInsert(2, 666)\n");
                    
        test.Insert(2, 666);
        foreach(int i in test.GetArray()){
            Console.WriteLine(i);
        }

        Console.WriteLine("\n_____________\n\nRemoveAt(2)\n");

        test.RemoveAt(2);
        foreach(int i in test.GetArray()){
            Console.WriteLine(i);
        }

        Console.WriteLine("\n_____________\n\nSort()\n");

        test.Sort();
        foreach(int i in test.GetArray()){
            Console.WriteLine(i);
        }

        Console.WriteLine("\n_____________\n\nContains(666)\n");

        Console.WriteLine(test.Contains(666));

//        Console.ReadKey(true);

//------------------------------------

        MyList<string> test2 = new MyList<string>();
        
        string testVar2;

        Console.WriteLine("\nВведите текст:\n");
        do
        {
            testVar2 = Console.ReadLine();
            test2.Add(testVar2);
        }
        while(testVar2 != "");

        Console.WriteLine("\n_____________\n\nGetArray()\n");

        foreach(string i in test2.GetArray()){
            Console.WriteLine(i);
        }
        
        Console.WriteLine("\n_____________\n\nInsert()\n");
                    
        test2.Insert(2, "test2");
        foreach(string i in test2.GetArray()){
            Console.WriteLine(i);
        }

        Console.WriteLine("\n_____________\n\nRemoveAt()\n");

        test2.RemoveAt(2);
        foreach(string i in test2.GetArray()){
            Console.WriteLine(i);
        }

        Console.WriteLine("\n_____________\n\nSort()\n");

        test2.Sort();
        foreach(string i in test2.GetArray()){
            Console.WriteLine(i);
        }

        Console.WriteLine("\n_____________\n\nContains(\"666\")\n");

        Console.WriteLine(test2.Contains("666"));

        Console.ReadKey(true);
    }
}