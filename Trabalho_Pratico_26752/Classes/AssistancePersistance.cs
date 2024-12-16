using System.IO;
using System.Collections.Generic;
using System;
using Trabalho_Pratico_26752.Classes;

public static class FileManager
{
    public static void SaveAssistancesToFile(string filePath, List<Assistance> assistances)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var assistance in assistances)
            {
                // Gravando cada assistência no arquivo em formato simples
                writer.WriteLine($"{assistance.ID}|{assistance.Description}|{assistance.Status}|{assistance.Customer.Name}|{assistance.Operator?.Name ?? "N/A"}|{assistance.Rating}");
            }
        }

        Console.WriteLine("Assistances saved successfully!");
    }
}