using SensorEvaluator;
using System;
using System.IO;

namespace SensorConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //Visual Studio      
            //var path = @"../../../sample.txt"; 
            //VSCode
            var path = @"sample.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                //This allows you to do one Read operation.
                string  logFileContents = sr.ReadToEnd();
                var output =  DeviceEvaluator.EvaluateLogFile(logFileContents);
                Console.WriteLine(output);
            }

            Console.ReadLine();
        }
    }
}
