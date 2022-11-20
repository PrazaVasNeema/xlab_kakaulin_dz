
public static class TestingChamber <T>{

    private static void PrintMyList(MyLinkedList<T> myList)
    {
        foreach (T item in myList)
        {
            Console.WriteLine(item);
        }
    }
    public static void TestMyList(MyLinkedList<T> myLinkedList){
        
        T TestingValue = (T)Convert.ChangeType(Constants.TESTING_VALUE, typeof(T));

        Console.WriteLine($"{Constants.NEW_TEST}");

        Console.WriteLine($"{Constants.OUTPUT}<{typeof(T).ToString().Split('.')[1]}>:\n");
        PrintMyList(myLinkedList);
        
        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.POP}:\n");   
        Console.WriteLine($"Первое значение: {myLinkedList.Pop()}\n");
        PrintMyList(myLinkedList);

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.PEEK}: {myLinkedList.Peek()}\n");   

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.ADD_LAST}:\n");   
        myLinkedList.AddLast(TestingValue);
        PrintMyList(myLinkedList);

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.REMOVE_LAST}: {myLinkedList.RemoveLast()}\n");   
        PrintMyList(myLinkedList);

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.CONTAINS}: {myLinkedList.Contains(TestingValue)}");   

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.CLEAR}\n");
        myLinkedList.Clear();
        PrintMyList(myLinkedList);
    }
}


//https://stackoverflow.com/questions/8625/generic-type-conversion-from-string - (T)Convert.ChangeType(Constants.TESTING_INT_VALUE,typeof(T));