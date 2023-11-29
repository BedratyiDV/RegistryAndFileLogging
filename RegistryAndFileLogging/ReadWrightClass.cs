using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryAndFileLogging
{
    //The class contains methods for readind/writing from/into txt file
   internal class ReadWrightClass
    {
        /// <summary>
        /// Reads number of starts of the program from txt file. Initially the file is filled with 0
        /// </summary>
        ///  <param name="filePath"> </param> 
        public int ReadFromFile(string filePath)
        {
            string countString = File.ReadAllText(filePath);

            if (int.TryParse(countString, out int count))
            {
                return count;
            }

            return 0;
        }
        /// <summary>
        /// Writes number of starts of the program into txt file.
        /// </summary>
        ///  <param name="filePath"> </param> 
        ///  <param name="count"> </param>
        public void WriteToFile(string filePath, int count)
        {
            File.WriteAllText(filePath, count.ToString());
        }
        /// <summary>
        /// Reads content of log txt file and output the received content to console.
        /// </summary>
        ///  <param name="filePath"> </param> 
        public void ReadFromLogFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string logRecords = reader.ReadToEnd();
                Console.WriteLine(logRecords);
                reader.Close();

            }
        }
        /// <summary>
        /// Writes number of starts of the program into txt log file with appending.
        /// </summary>
        ///  <param name="filePath"> </param> 
        ///  <param name="count"> </param>
        public void WriteToLogFile(string filePath, int count)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{DateTime.Now} - Program start {count}");
                writer.Close();

            }
        }
        
    }
}
