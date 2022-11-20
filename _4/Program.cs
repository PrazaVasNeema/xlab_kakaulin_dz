class Program
{
    public static void Main(string[] args)
    {
        LinkedList<int> testTrue = new LinkedList<int>();
        MyLinkedList<int> testMine = new MyLinkedList<int>();
        testMine.Push(1);
        testMine.Push(2);
        foreach(int i in testMine)
        {
            Console.WriteLine(i);
        }

        Console.ReadKey();
    }
}