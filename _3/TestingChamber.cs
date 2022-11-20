
public static class TestingChamber <T>{

    private static void PrintMyList(MyList<T> myList)
    {
        foreach (T item in myList)
        {
            Console.WriteLine(item);
        }
    }
    public static void TestMyList(MyList<T> myList){
        
        T TestingValue = (T)Convert.ChangeType(Constants.TESTING_VALUE,typeof(T));

        Console.WriteLine($"{Constants.NEW_TEST}");

        Console.WriteLine($"{Constants.OUTPUT}<{typeof(T).ToString().Split('.')[1]}>:\n");
        PrintMyList(myList);
        
        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.SORT}:\n");
        myList.Sort();
        PrintMyList(myList);

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.INSERT}:\n");   
        myList.Insert(Constants.TESTING_INDEX, TestingValue);
        PrintMyList(myList);

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.INSERT_RANGE}:\n");   
        myList.InsertRange(Constants.TESTING_INDEX, new T[]{TestingValue, TestingValue});
        PrintMyList(myList);

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.REMOVE}:\n");   
        myList.Remove(TestingValue);
        PrintMyList(myList);

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.REMOVE_AT}:\n");   
        myList.RemoveAt(2);
        PrintMyList(myList);

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.CONTAINS}: {myList.Contains(TestingValue)}");   

        Console.WriteLine(Constants.BORDER);

        Console.WriteLine($"{Constants.CLEAR}\n");
        myList.Clear();
        PrintMyList(myList);
    }
}


//https://stackoverflow.com/questions/8625/generic-type-conversion-from-string - (T)Convert.ChangeType(Constants.TESTING_INT_VALUE,typeof(T));