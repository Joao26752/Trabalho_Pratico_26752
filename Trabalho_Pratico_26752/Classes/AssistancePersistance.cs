using System.IO;
using System.Collections.Generic;
using System;
using Trabalho_Pratico_26752.Classes;

public static class FileManager
{
    #region Fields
    private static string _filePath;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the file path.
    /// </summary>
    public static string FilePath
    {
        get => _filePath;
        set => _filePath = value;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Saves a list of assistances to a file.
    /// </summary>
    /// <param name="assistances">The list of assistances to save.</param>
    public static void SaveAssistancesToFile(List<Assistance> assistances)
    {
        // Create a StreamWriter to write to the file
        using (StreamWriter writer = new StreamWriter(FilePath))
        {
            // Iterate over each assistance in the list
            foreach (var assistance in assistances)
            {
                // Write each assistance to the file in a simple format
                writer.WriteLine($"{assistance.ID}|{assistance.Description}|{assistance.Status}|{assistance.Customer.Name}|{assistance.Operator?.Name ?? "N/A"}|{assistance.Rating}");
            }
        }

        // Print a success message to the console
        Console.WriteLine("Assistances saved successfully!");
    }
    #endregion
}