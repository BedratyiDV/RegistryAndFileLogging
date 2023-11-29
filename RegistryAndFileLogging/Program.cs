using Microsoft.Win32;
using System;
using System.IO;

namespace RegistryAndFileLogging
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //New instance of ReadWrightClass class
            ReadWrightClass readWrightClass = new ReadWrightClass();

            //Path to file containing number of starts of the program
            string filePath = "C:\\Users\\denis\\source\\Hillel\\Pro\\RegistryAndFileLogging\\number_of_starts.txt";
            //Path to log file 
            string logFilePath = "C:\\Users\\denis\\source\\Hillel\\Pro\\RegistryAndFileLogging\\log.txt";

            int startsNumber = readWrightClass.ReadFromFile(filePath);

            //The brench of code execuring while first run of the program
            if (startsNumber == 0)
            {
                RegistryKey regKey = Registry.CurrentUser;
                var subKey = regKey.CreateSubKey("Registry_And_File_Logging_Application");
                subKey.SetValue("Start_Number", 1);
                subKey.SetValue("Start_DateTime", DateTime.Now);
                subKey.Close();
            }
            //Increasing the number of starts of the program   
            startsNumber++;

            //Writing to the file the new number of starts of the program
            readWrightClass.WriteToFile(filePath, startsNumber);

            //Appending info regarding the new start of the program into the log file
            readWrightClass.WriteToLogFile(logFilePath, startsNumber);
                      

            //Reading of log file content and it's console output
            readWrightClass.ReadFromLogFile(logFilePath);
                   
        }
    }
}
    
