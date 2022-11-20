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
        MyLinkedList<int> myLinkedListForComparison = new MyLinkedList<int>();
        LinkedList<int> LinkedListForComparison = new LinkedList<int>();
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
            myLinkedListInt.Push(rnd.Next(100));
        }

        TestingChamber<int>.TestMyList(myLinkedListInt);

        foreach(string str in Constants.LOREM_IPSUM.Split(' '))
        {
            myLinkedListString.Push(str);
        }

        TestingChamber<string>.TestMyList(myLinkedListString);

        Console.ReadKey();
    }
}