using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace tpmodul7_kelompok_5
{
    class Course
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

    }

    class KuliahMahasiswa2211104023
    {
        [JsonPropertyName("courses")]
        public List<Course> courses { get; set; }
        public static void ReadJSON()
        {
            string pathFile = Path.Combine(Directory.GetCurrentDirectory(), "tp7_2_2211104023.json");
            if (File.Exists(pathFile))
            {
                string jsonData = File.ReadAllText(pathFile);
                KuliahMahasiswa2211104023 courses = JsonSerializer.Deserialize<KuliahMahasiswa2211104023>(jsonData);
                Console.WriteLine("Daftar mata kuliah yang diambil:");
                int index = 1;
                foreach (var course in courses.courses)
                {
                    Console.WriteLine($"MK {index} {course.Code} - {course.Name}");
                    index++;
                }
            }
            else
            {
                Console.WriteLine("File tidak ditemukan");
            }
        }
    }
}