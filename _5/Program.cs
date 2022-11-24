    // Класс с наличием Main, здесь заполняются листы, вызывается их проверка в TestingChamber
    // и производится сравнение по времени работы метода Remove() с таковым во встроенном List 

using System.Diagnostics;
class Program
{

    private static void PrintArray(MyList<int> array)
    {
        foreach (int item in array)
        {
            Console.WriteLine(item);
        }
    }

    static void Main(string[] args)
    {
        MyList<int> myListIntBubbleSort = new MyList<int>();
        MyList<int> myListIntShakerSort = new MyList<int>();
        MyList<int> myListIntInsertionSort = new MyList<int>();
        MyList<int> myListIntQuickSort = new MyList<int>();

        var time = new Stopwatch();
        int numberOfValues;
        string bubbleTime, shakerTime, insertionTime, quickTime;
        Random rnd = new Random();
        bool outputFlag = true;

        Console.WriteLine($"Введите количество чисел:");
        while(!int.TryParse(Console.ReadLine(), out numberOfValues) || numberOfValues < 1)
        {
            Console.WriteLine($"Неверный ввод");
        }

        for(int i = 0, temp; i < numberOfValues; i++)
        {
            temp = rnd.Next(100);
            myListIntBubbleSort.Add(temp);
            myListIntShakerSort.Add(temp);
            myListIntInsertionSort.Add(temp);
            myListIntQuickSort.Add(temp);
        }

        Console.WriteLine($"\n{Constants.ORIGINAL_ARRAY}:\n");
        PrintArray(myListIntBubbleSort);

        Console.WriteLine(Constants.BORDER);

        // Сортировка пузырьком

        Console.WriteLine($"\n{Constants.BUBBLE_SORT}:\n");

        time.Start();
        BubbleSort<int>.Sort(ref myListIntBubbleSort);
        time.Stop();
        
        PrintArray(myListIntBubbleSort);
        Console.WriteLine($"\n{Constants.TIME_STATS}: {time.Elapsed}");
        bubbleTime = time.Elapsed.ToString();

        time.Reset();
        Console.WriteLine(Constants.BORDER);

        // Шейкерная сортировка

        Console.WriteLine($"\n{Constants.SHAKER_SORT}:\n");

        time.Start();
        ShakerSort<int>.Sort(ref myListIntShakerSort);
        time.Stop();
        
        PrintArray(myListIntShakerSort);
        Console.WriteLine($"\n{Constants.TIME_STATS}: {time.Elapsed}");
        shakerTime = time.Elapsed.ToString();

        time.Reset();
        Console.WriteLine(Constants.BORDER);

        // Сортировка вставками

        Console.WriteLine($"\n{Constants.INSERTION_SORT}:\n");

        time.Start();
        InsertionSort<int>.Sort(ref myListIntInsertionSort);
        time.Stop();
        
        PrintArray(myListIntInsertionSort);
        Console.WriteLine($"\n{Constants.TIME_STATS}: {time.Elapsed}");
        insertionTime = time.Elapsed.ToString();

        time.Reset();
        Console.WriteLine(Constants.BORDER);

        // Быстрая сортировка

        Console.WriteLine($"\n{Constants.QUICK_SORT}:\n");

        time.Start();
        QuickSort<int>.Sort(ref myListIntQuickSort);
        time.Stop();
        
        PrintArray(myListIntQuickSort);
        Console.WriteLine($"\n{Constants.TIME_STATS}: {time.Elapsed}");
        quickTime = time.Elapsed.ToString();

        time.Reset();
        Console.WriteLine(Constants.BORDER);

        // Итоговое сравнение сортировок по времени

        Console.WriteLine($"Итоговое сравнение сортировок по времени\n\n{Constants.BUBBLE_SORT}: {bubbleTime}\n{Constants.SHAKER_SORT}: {shakerTime}\n{Constants.INSERTION_SORT}: {insertionTime}\n{Constants.QUICK_SORT}: {quickTime}\n");

        Console.ReadKey();
    }
}