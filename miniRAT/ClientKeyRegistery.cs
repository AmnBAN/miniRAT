using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniRAT
{
    public class ClientKeyRegistery
    {
        static readonly string fileName = Path.Combine(Path.GetTempPath(), "miniRat_Client.tmp");

        private static string GetOrCreateTmpFile()
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    File.AppendAllText(fileName, "");
                    FileInfo fileInfo = new FileInfo(fileName);
                    fileInfo.Attributes = FileAttributes.Temporary;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to create TEMP file or set its attributes: " + ex.Message);
            }

            return fileName;
        }
        public static void UpdateGuid(string txt)
        {
            try
            {
                File.WriteAllText(fileName, txt);
                Console.WriteLine("TEMP file updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to TEMP file: " + ex.Message);
            }
        }
        public static Guid ReadGuid()
        {
            string fileContent = string.Empty;
            GetOrCreateTmpFile();
            try
            {
                fileContent = File.ReadAllText(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading TEMP file: " + ex.Message);
            }
            return string.IsNullOrEmpty(fileContent) ? Guid.Empty : Guid.Parse(fileContent);

        }
        public static void DeleteTmpFile(string tmpFile)
        {
            try
            {
                if (File.Exists(tmpFile))
                {
                    File.Delete(tmpFile);
                    Console.WriteLine("TEMP file deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleteing TEMP file: " + ex.Message);
            }
        }
    }
}
