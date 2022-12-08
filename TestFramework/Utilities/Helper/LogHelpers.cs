//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace TestFramework.Utilities.Helper
//{
//    public static class LogHelpers
//    {
//        public static StreamWriter stream = null;
//        public static string filePath = @"C:\Users\Gokul Anil\source\repos\TestFramework\TestProject\Log\Logger.log";

//        /// <summary>
//        /// Method that can write the information into the log file
//        /// </summary>
//        /// <param name="testName"></param>
//        /// <param name="status"></param>
//        /// <param name="message"></param>
//        public static void WriteToFile(string testName, string status, string message)
//        {
//            if (File.Exists(filePath))
//            {
//                File.AppendAllText(filePath,
//                   DateTime.Now.ToString() + " " + testName + " " + status + " " + message + Environment.NewLine);
//            }
//        }

//        /// <summary>
//        /// Read through each line from the log file
//        /// </summary>
//        /// <param name="filePath"></param>
//        /// <returns></returns>
//        public static List<string> Log(string filePath)
//        {
//            var lines = File.ReadAllLines(filePath);
//            List<string> line = new List<string>();
//            for (var i = 0; i < lines.Length; i += 1)
//            {
//                line.Add(lines[i]); // Process line
//            }
//            return line;
//        }
//    }
//}