using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parsingJSON2
{
    class Program
    {
        static void Main()
        {
            string dateStr = "March 20, 2025 13:30:00";
            DateTime tanggal = DateTime.Parse(dateStr);
            Console.WriteLine($"Hasil parsing DateTime dengan waktu: {tanggal}");
        }
    }
}