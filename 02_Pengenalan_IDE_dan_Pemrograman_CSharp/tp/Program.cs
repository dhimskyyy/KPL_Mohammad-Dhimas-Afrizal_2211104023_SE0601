using System;

class Program
{
    static void Main()
    {
        // Menerima input satu karakter
        Console.Write("Masukkan satu huruf: ");
        char huruf = Char.ToUpper(Console.ReadKey().KeyChar); // Mengambil input dan mengubah ke huruf besar
        Console.WriteLine(); // Pindah baris

        // Cek apakah huruf adalah vokal atau konsonan
        if (huruf == 'A' || huruf == 'I' || huruf == 'U' || huruf == 'E' || huruf == 'O')
        {
            Console.WriteLine($"Huruf {huruf} merupakan huruf vokal");
        }
        else
        {
            Console.WriteLine($"Huruf {huruf} merupakan huruf konsonan");
        }

        // Membuat array bilangan genap
        int[] bilanganGenap = { 2, 4, 6, 8, 10 };

        // Iterasi dan menampilkan angka genap
        for (int i = 0; i < bilanganGenap.Length; i++)
        {
            Console.WriteLine($"Angka genap {i + 1} : {bilanganGenap[i]}");
        }
    }
}
