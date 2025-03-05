using System;

class Program
{
    static void Main()
    {
        // Implementasi C: Memeriksa bilangan prima
        Console.Write("Masukkan sebuah angka (1-10000): ");
        int nilaiInt = Convert.ToInt32(Console.ReadLine());

        if (IsPrime(nilaiInt))
        {
            Console.WriteLine($"Angka {nilaiInt} merupakan bilangan prima");
        }
        else
        {
            Console.WriteLine($"Angka {nilaiInt} bukan merupakan bilangan prima");
        }
    }

    // Fungsi untuk mengecek bilangan prima
    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}