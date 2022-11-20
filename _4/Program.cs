// TO DO
// AddLast, Clear, Remove, RemoveLast, Contains
// Constants, TestChamber
// Сравнение по скорости с List
using System.Diagnostics;
class Program
{
    public static void Main(string[] args)
    {
        MyLinkedList<int> myLinkedListInt = new MyLinkedList<int>();
        MyLinkedList<string> myLinkedListString = new MyLinkedList<string>();
        List<int> ListForComparison = new List<int>();
        var time = new Stopwatch();
        int numberOfValues;
        Random rnd = new Random();

        // Тест на int
        Console.WriteLine($"Введите количество чисел:");
        while(!int.TryParse(Console.ReadLine(), out numberOfValues) || numberOfValues < 1)
        {
            Console.WriteLine($"Неверный ввод");
        }

        for(int i = 0; i < numberOfValues; i++)
        {
            myLinkedListInt.Push(rnd.Next(100));
        }

        TestingChamber<int>.TestMyList(myLinkedListInt);

        // Тест на string
        foreach(string str in Constants.LOREM_IPSUM.Split(' '))
        {
            myLinkedListString.Push(str);
        }

        TestingChamber<string>.TestMyList(myLinkedListString);

        // Сравнение скорости прохода
        for(int i = 0, temp; i < numberOfValues; i++)
        {
            temp = rnd.Next(100);
            myLinkedListInt.Push(temp);
            ListForComparison.Add(temp);
        }

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"/nВремя полного прохода/n");

        time.Start();
        foreach (int item in myLinkedListInt)
        {
        }
        time.Stop();
        Console.WriteLine($"MyLinkedList: {time.Elapsed}");

        time.Reset();

        time.Start();
        foreach (int item in ListForComparison)
        {
        }
        time.Stop();
        Console.WriteLine($"List: {time.Elapsed}");

        Console.ReadKey();
    }
}