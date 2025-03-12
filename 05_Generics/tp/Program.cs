using System;

public class HaloGeneric
{
    public static void SapaUser<T>(T user)
    {
        Console.WriteLine($"Halo Bray {user}");
    }
}

public class DataGeneric<T>
{
    private T data;
    public DataGeneric(T data)
    {
        this.data = data;
    }
    public void PrintData()
    {
        Console.WriteLine($"Data yang tersimpan adalah: {data}");
    }
}

class Program
{
    static void Main()
    {
        HaloGeneric.SapaUser("Mohammad Dhimas Afrizal");
        DataGeneric<string> data = new DataGeneric<string>("2211104023");
        data.PrintData();
    }
}