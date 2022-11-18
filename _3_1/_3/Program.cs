using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        MyList<int> myList = new MyList<int>();
        MyList<int> myList2 = new MyList<int>();


        var time = new Stopwatch();
        time.Start();
        time.Stop();
        Console.WriteLine(time.Elapsed);

        Random rnd = new Random();
        for(int i = 0; i < 100000; i++)
        {
            myList.Add(rnd.Next(100));
        }

        foreach (int item in myList)
        {
            myList2.Add(item);
        }


        time.Start();
        myList.Remove(10);
        time.Stop();
        Console.WriteLine(time.Elapsed);

        // time.Start();
        // myList2.RemoveTestForLoop(10);
        // time.Stop();
        // Console.WriteLine(time.Elapsed);

        // foreach (int item in myList)
        // {
        //     Console.WriteLine(item);
        // }

        Console.ReadKey();
    }
}