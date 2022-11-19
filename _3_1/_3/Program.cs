using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        MyList<int> myList = new MyList<int>();
        MyList<int> myList2 = new MyList<int>();
        var time = new Stopwatch();


        Random rnd = new Random();
        for(int i = 0; i < 5; i++)
        {
            myList.Add(rnd.Next(100));
        }


        // time.Start();

        // time.Stop();
        // Console.WriteLine(time.Elapsed);

        foreach (int item in myList)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("____________________________");
        time.Start();
        myList.Sort();

        foreach (int item in myList)
        {
            Console.WriteLine(item);
        }
        time.Stop();
        Console.WriteLine(time.Elapsed);

        Console.WriteLine("____________________________");

        int[] testtt = {666, 666};
        myList.InsertRange(myList.Count, testtt);
        foreach (int item in myList)
        {
            Console.WriteLine(item);
        }
        time.Stop();
        Console.WriteLine(time.Elapsed);
        
        Console.ReadKey();
    }
}