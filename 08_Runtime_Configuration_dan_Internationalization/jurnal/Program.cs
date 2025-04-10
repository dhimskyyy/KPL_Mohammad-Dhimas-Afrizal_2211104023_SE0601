using System;

class Program
{
    static void Main(string[] args)
    {
        var config = new BankTransferConfig();

        string lang = config.lang;
        string prompt = lang == "en" ?
            "Please insert the amount of money to transfer: " :
            "Masukkan jumlah uang yang akan di-transfer: ";
        Console.WriteLine(prompt);

        int amount = int.Parse(Console.ReadLine());
        int fee = amount <= config.transfer.threshold ? config.transfer.low_fee : config.transfer.high_fee;
        int total = amount + fee;

        // Menampilkan ringkasan awal transfer
        Console.WriteLine("\n" + (lang == "en" ? "Transfer Summary" : "Ringkasan Transfer"));
        Console.WriteLine("------------------------------");
        Console.WriteLine((lang == "en" ? "Amount       :" : "Jumlah       :") + $" {amount}");
        Console.WriteLine((lang == "en" ? "Transfer fee :" : "Biaya        :") + $" {fee}");
        Console.WriteLine((lang == "en" ? "Total amount :" : "Total        :") + $" {total}");

        // Menampilkan pilihan metode transfer
        Console.WriteLine("\n" + (lang == "en" ? "Select transfer method:" : "Pilih metode transfer:"));
        for (int i = 0; i < config.methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {config.methods[i]}");
        }

        int methodInput = int.Parse(Console.ReadLine());
        string selectedMethod = config.methods[methodInput - 1];
        Console.WriteLine((lang == "en" ? "You have chosen: " : "Metode yang dipilih: ") + selectedMethod);

        // Konfirmasi transfer
        string confirmPrompt = lang == "en" ?
            $"Please type \"{config.confirmation.en}\" to confirm the transaction:" :
            $"Ketik \"{config.confirmation.id}\" untuk mengkonfirmasi transaksi:";
        Console.WriteLine(confirmPrompt);

        string confirmationInput = Console.ReadLine();
        bool isConfirmed = (lang == "en" && confirmationInput.ToLower() == config.confirmation.en.ToLower()) ||
                           (lang != "en" && confirmationInput.ToLower() == config.confirmation.id.ToLower());

        string result = isConfirmed ?
            (lang == "en" ? "The transfer is completed" : "Proses transfer berhasil") :
            (lang == "en" ? "Transfer is cancelled" : "Transfer dibatalkan");
        Console.WriteLine(result);
    }
}
