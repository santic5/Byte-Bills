using Byte_BillsSolution.Orders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_BillsSolution.Reservation.Files
{
    public class HashFile
    {
        private static readonly string attRute = "Reservations.csv";

        public HashFile()
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
        public bool IsEmpty()
        {
            FileInfo attFileInfo = new FileInfo(attRute);
            if (attFileInfo.Length == 0)
            {
                return true;
            }
            return false;
        }

        public void Write(int prmHash)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(attRute, append: true);
                FileInfo attFileInfo = new FileInfo(attRute);
                if (IsEmpty())
                {
                    writer.Write(prmHash);
                }
                else
                {
                    writer.Write("," + prmHash);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving: {ex.Message}");
            }
        }

        public void Write(string[] prmReservations)
        {
            using StreamWriter writer = new(attRute, append: true);
            foreach (var prmReservation in prmReservations)
            {
                writer.Write(prmReservation + ",");
            }
        }

        public string Read()
        {
            using (StreamReader reader = new StreamReader(attRute))
            {
                return reader.ReadToEnd();
            }
        }

        public bool Search(int prmHash)
        {
            try
            {
                using (StreamReader reader = new StreamReader(attRute))
                {
                    string attFile = reader.ReadToEnd();
                    string[] attReservations = attFile.Split(",");

                    foreach (var attReservation in attReservations)
                    {
                        if (int.TryParse(attReservation.Trim(), out int parsedReservation))
                        {
                            if (parsedReservation == prmHash)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: (" + ex.Message + ")");
                return false;
            }
        }   

        public bool Delete(int prmHash)
        {
            try
            {
                string newContent;
                using (StreamReader reader = new StreamReader(attRute))
                {
                    string content = reader.ReadToEnd();
                    string[] items = content.Split(',');
                    string prmHashString = prmHash.ToString();
                    string[] newItems = items
                        .Where(e => !e.Trim().Equals(prmHashString, StringComparison.OrdinalIgnoreCase))
                        .ToArray();
                    newContent = string.Join(",", newItems);
                }
                using (StreamWriter writer = new(attRute, append: false))
                {
                    writer.Write(newContent);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: (" + ex.Message + ")");
                return false;
            }
        }
        public int GetLength()
        {
            try
            {
                using (StreamReader reader = new StreamReader(attRute))
                {
                    string attFile = reader.ReadToEnd();
                    string[] attReservations = attFile.Split(',');
                    return attReservations.Length;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: ("+ex.Message + ")");
                return 0;
            }
        }

        public void Purge()
        {
            File.Delete(attRute);
        }
    }
}
