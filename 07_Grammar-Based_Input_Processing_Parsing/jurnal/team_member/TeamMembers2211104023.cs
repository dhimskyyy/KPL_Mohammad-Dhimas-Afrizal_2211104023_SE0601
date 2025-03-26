using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace tp7
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string NIM { get; set; }
    }

    public class Team
    {
        [JsonProperty("members")]
        public List<Member> Members { get; set; }
    }

    public class TeamMembers2211104023
    {
        public static Team ReadJSON(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<Team>(jsonData);
                }
                else
                {
                    Console.WriteLine("File JSON tidak ditemukan!");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error membaca file JSON: {ex.Message}");
                return null;
            }
        }

        public static void DisplayTeamData(string filePath)
        {
            Team team = ReadJSON(filePath);

            if (team != null && team.Members != null)
            {
                Console.WriteLine("Daftar Anggota Tim:");
                foreach (var member in team.Members)
                {
                    Console.WriteLine($"{member.NIM} - {member.FirstName} {member.LastName} ({member.Age} tahun, {member.Gender})");
                }
            }
            else
            {
                Console.WriteLine("Data anggota tim tidak ditemukan atau file JSON tidak valid.");
            }
        }
    }
}