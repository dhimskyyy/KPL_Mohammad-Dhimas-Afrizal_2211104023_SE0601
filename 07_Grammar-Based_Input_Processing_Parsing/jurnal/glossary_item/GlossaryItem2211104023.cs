using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace tp7_kelompok_5
{
    public class GlossDef
    {
        public string Para { get; set; }
        public List<string> GlossSeeAlso { get; set; }
    }

    public class GlossEntry
    {
        public string ID { get; set; }
        public string SortAs { get; set; }
        public string GlossTerm { get; set; }
        public string Acronym { get; set; }
        public string Abbrev { get; set; }
        public GlossDef GlossDef { get; set; }
        public string GlossSee { get; set; }
    }

    public class GlossList
    {
        public GlossEntry GlossEntry { get; set; }
    }

    public class GlossDiv
    {
        public string Title { get; set; }
        public GlossList GlossList { get; set; }
    }

    public class Glossary
    {
        public string Title { get; set; }
        public GlossDiv GlossDiv { get; set; }
    }

    public class Root
    {
        public Glossary Glossary { get; set; }
    }

    public class GlossaryItem
    {
        public static void ReadJSON(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    Root data = JsonConvert.DeserializeObject<Root>(jsonData);

                    if (data != null && data.Glossary?.GlossDiv?.GlossList?.GlossEntry != null)
                    {
                        var entry = data.Glossary.GlossDiv.GlossList.GlossEntry;

                        Console.WriteLine("\n--- Glossary Entry ---");
                        Console.WriteLine($"ID: {entry.ID}");
                        Console.WriteLine($"Sort As: {entry.SortAs}");
                        Console.WriteLine($"Gloss Term: {entry.GlossTerm}");
                        Console.WriteLine($"Acronym: {entry.Acronym}");
                        Console.WriteLine($"Abbreviation: {entry.Abbrev}");
                        Console.WriteLine($"Definition: {entry.GlossDef.Para}");
                        Console.WriteLine("GlossSeeAlso: " + string.Join(", ", entry.GlossDef.GlossSeeAlso));
                        Console.WriteLine($"GlossSee: {entry.GlossSee}");
                    }
                    else
                    {
                        Console.WriteLine("GlossEntry data not found.");
                    }
                }
                else
                {
                    Console.WriteLine("File JSON tidak ditemukan!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
            }
        }
    }
}