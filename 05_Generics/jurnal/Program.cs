using System;

class Penjumlahan
{
    public static T JumlahTigaAngka<T>(T angka1, T angka2, T angka3) where T : struct
    {
        dynamic a = angka1;
        dynamic b = angka2;
        dynamic c = angka3;
        return (T)(a + b + c);
    }
}

class Program
{
    static void Main()
    {
        // Sesuai dengan NIM 2211104026, gunakan tipe data int
        int angka1 = 22;
        int angka2 = 11;
        int angka3 = 10;

        int hasil = Penjumlahan.JumlahTigaAngka(angka1, angka2, angka3);
        Console.WriteLine("NIM saya 2211104023");
        Console.WriteLine("Penjumlahan tiga input angka dari 2-digit NIM saya");
        Console.WriteLine($"Hasil penjumlahan: {hasil}");
    }
}
