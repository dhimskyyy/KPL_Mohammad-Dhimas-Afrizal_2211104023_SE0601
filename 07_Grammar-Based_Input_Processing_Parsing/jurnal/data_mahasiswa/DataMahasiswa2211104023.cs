using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace tpmodul7_kelompok_5
{
    class Nama
    {
        [JsonPropertyName("depan")]
        public string Depan { get; set; }

        [JsonPropertyName("belakang")]
        public string Belakang { get; set; }
    }
    class DataMahasiswa2211104023
    {
        [JsonPropertyName("nama")]
        public Nama Nama { get; set; }

        [JsonPropertyName("nim")]
        public string Nim { get; set; }

        [JsonPropertyName("fakultas")]
        public string Fakultas { get; set; }

        public static void ReadJSON()
        {
            string pathFile = Path.Combine(Directory.GetCurrentDirectory(), "tp7_1_2211104023.json");
            if (File.Exists(pathFile))
            {
                string jsonData = File.ReadAllText(pathFile);
                DataMahasiswa2211104023 mahasiswa = JsonSerializer.Deserialize<DataMahasiswa2211104023>(jsonData);

                Console.WriteLine($"Nama {mahasiswa.Nama.Depan} {mahasiswa.Nama.Belakang} dengan nim {mahasiswa.Nim} dari fakultas {mahasiswa.Fakultas}");
            }
            else
            {
                Console.WriteLine("File tidak ditemukan");
            }
        }
    }
}