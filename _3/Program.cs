    // Класс с наличием Main, здесь заполняются листы, вызывается их проверка в TestingChamber
    // и производится сравнение по времени работы метода Remove() с таковым во встроенном List 

using System.Diagnostics;
class Program
{


    static void Main(string[] args)
    {
        MyList<int> myListInt = new MyList<int>();
        MyList<string> myListString = new MyList<string>();
        MyList<int> myListForComparison = new MyList<int>();
        List<int> ListForComparison = new List<int>();
        var time = new Stopwatch();
        int numberOfValues;
        Random rnd = new Random();

        Console.WriteLine($"Введите количество чисел:");
        while(!int.TryParse(Console.ReadLine(), out numberOfValues) || numberOfValues < 1)
        {
            Console.WriteLine($"Неверный ввод");
        }

        for(int i = 0; i < numberOfValues; i++)
        {
            myListInt.Add(rnd.Next(100));
        }      

        TestingChamber<int>.TestMyList(myListInt);

        foreach(string item in Constants.LOREM_IPSUM.Split(' '))
        {
            myListString.Add(item);
        }

        TestingChamber<string>.TestMyList(myListString);
        

        for(int i = 0, temp; i < numberOfValues; i++)
        {
            temp = rnd.Next(100);
            myListForComparison.Add(temp);
            ListForComparison.Add(temp);
        }

        Console.WriteLine("\nСравнение метода Remove в MyList и List\n");

        time.Start();
        myListForComparison.Remove(10);
        time.Stop();
        Console.WriteLine($"Remove(10) в MyList: {time.Elapsed}");

        time.Reset();

        time.Start();
        ListForComparison.Remove(10);
        time.Stop();
        Console.WriteLine($"Remove(10) в List: {time.Elapsed}");

        Console.ReadKey();
    }
}