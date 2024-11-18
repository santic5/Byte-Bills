using Byte_BillsSolution.Orders.Interfaces;
using System;
using System.IO;

namespace Byte_BillsSolution.Orders.Files
{
    public class OrdersFile
    {
        private static readonly string attRute = "Orders.txt";

        /// <summary>
        /// Constructor of the file. This method creates the file "Orders.txt" for their future use.
        /// </summary>
        public OrdersFile()
        {
            try
            {
                if (!File.Exists(attRute))
                {
                    using FileStream fs = File.Create(attRute);
                }
            }
            catch (Exception ex) when (ex is FileNotFoundException || ex is OutOfMemoryException || ex is IOException)
            {
                Console.WriteLine("Error: Missing file. (" + ex.Message + ")");
            }
        }

        /// <summary>
        /// Save a string text in the archive "Orders.txt".
        /// </summary>
        /// <param name="prmOrder">String to save.</param>
        public void Write(string prmOrder)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(attRute, append: true);
                writer.WriteLine(prmOrder);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Save an array of string in the archive "Orders.txt".
        /// </summary>
        /// <param name="prmOrders">String array to save</param>
        public void Write(string[] prmOrders)
        {
            using StreamWriter writer = new(attRute, append: true);
            foreach (var order in prmOrders)
            {
                writer.WriteLine(order);
            }
        }

        /// <summary>
        /// A string value with every text saved in the archive.
        /// </summary>
        /// <returns>String text</returns>
        public string Read()
        {
            using (StreamReader reader = new StreamReader(attRute))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// The counter is equals to the id of the orders that was be saved sequentially in the orders saved.
        /// The number has to be readed for the next order to save.
        /// </summary>
        /// <returns>Value of the las order id</returns>
        /// <exception cref="FormatException">Ex caused by a incorrect format in the string</exception>
        public int GetLastCounter()
        {
            try
            {
                var lines = File.ReadAllLines(attRute);
                if (lines.Length == 0)
                {
                    return 0;
                }
                string lastLine = lines[^1];
                string[] parts = lastLine.Split(" - ");
                if (parts.Length > 0 && int.TryParse(parts[0], out int lastCounter))
                {
                    return lastCounter;
                }
                else
                {
                    throw new FormatException("Error: Invalid format");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error: Fail to read file: {ex.Message}");
                return 0;
            }
        }

    }
}
