
using System.Diagnostics;
class Program
{
    private static void PrintMyList(MyList<int> myList)
    {
        foreach (int item in myList)
        {
            Console.WriteLine(item);
        }
    }

    static void Main(string[] args)
    {
        MyList<int> myList = new MyList<int>();
        MyList<int> myList2 = new MyList<int>();
        var time = new Stopwatch();
        int numberOfValues;
        Random rnd = new Random();

        Console.WriteLine($"Введите количество чисел");
        while(!int.TryParse(Console.ReadLine(), out numberOfValues) || numberOfValues < 1)
        {
            Console.WriteLine($"Неверный ввод");
        }

        for(int i = 0; i < numberOfValues; i++)
        {
            myList.Add(rnd.Next(100));
        }


        // time.Start();

        // time.Stop();
        // Console.WriteLine(time.Elapsed);

        Console.WriteLine($"{Constants.OUTPUT}<int>:");
        PrintMyList(myList);
        
        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.SORT}:");
        myList.Sort();
        PrintMyList(myList);

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.INSERT}:");   
        myList.Insert(Constants.TESTING_INDEX, Constants.TESTING_INT_VALUE);
        PrintMyList(myList);

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.INSERT_RANGE}:");   
        myList.InsertRange(Constants.TESTING_INDEX, new int[]{Constants.TESTING_INT_VALUE, Constants.TESTING_INT_VALUE});
        PrintMyList(myList);

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.REMOVE}:");   
        myList.Remove(Constants.TESTING_INT_VALUE);
        PrintMyList(myList);

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.REMOVE_AT}:");   
        myList.RemoveAt(2);
        PrintMyList(myList);

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.CONTAINS}: {myList.Contains(Constants.TESTING_INT_VALUE)}");   

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine(Constants.CLEAR);
        myList.Clear();
        PrintMyList(myList);


        Console.ReadKey();
    }
}