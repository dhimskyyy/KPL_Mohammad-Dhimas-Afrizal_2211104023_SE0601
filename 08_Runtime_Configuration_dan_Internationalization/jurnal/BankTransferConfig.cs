using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class BankTransferConfig
{
    public string lang { get; set; }
    public Transfer transfer { get; set; }
    public List<string> methods { get; set; }
    public Confirmation confirmation { get; set; }

    public BankTransferConfig()
    {
        if (!File.Exists("bank_transfer_config.json"))
        {
            CreateDefaultConfigFile();
        }

        string configJson = File.ReadAllText("bank_transfer_config.json");

        // ⛔ Ganti ini biar gak panggil constructor ini lagi:
        var config = JsonSerializer.Deserialize<BankTransferConfigData>(configJson);

        lang = config.lang;
        transfer = config.transfer;
        methods = config.methods;
        confirmation = config.confirmation;
    }

    private void CreateDefaultConfigFile()
    {
        var defaultConfig = new BankTransferConfigData
        {
            lang = "en",
            transfer = new Transfer { threshold = 25000000, low_fee = 6500, high_fee = 15000 },
            methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" },
            confirmation = new Confirmation { en = "yes", id = "ya" }
        };

        string json = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("bank_transfer_config.json", json);
    }
}

// ✅ Kelas ini *tidak punya constructor*, aman untuk deserialization
public class BankTransferConfigData
{
    public string lang { get; set; }
    public Transfer transfer { get; set; }
    public List<string> methods { get; set; }
    public Confirmation confirmation { get; set; }
}

public class Transfer
{
    public int threshold { get; set; }
    public int low_fee { get; set; }
    public int high_fee { get; set; }
}

public class Confirmation
{
    public string en { get; set; }
    public string id { get; set; }
}
