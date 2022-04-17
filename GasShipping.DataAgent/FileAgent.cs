using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasShipping.DataAgent
{/// <summary>
/// This class will be used to read/write to files
/// </summary>
    public class FileAgent
    {
        /// <summary>
        /// Public constructor for the FileAgent class
        /// </summary>
        /// <param name="fileName">string</param>
        /// <param name="directoryName">string</param>
        /// <exception cref="ArgumentException"></exception>
        public FileAgent(string fileName, string directoryName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException($"'{nameof(fileName)}' cannot be null or empty.", nameof(fileName));
            }

            if (string.IsNullOrEmpty(directoryName))
            {

                directoryName = Constants.PATH;
            }

            FileName = fileName;
            DirectoryName = directoryName;
        }
        /// <summary>
        ///  <value>Property <c>FileName</c> string of the file name.</value>
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// <value>Property <c>DirectoryName</c> string of the path to the file.</value>
        /// </summary>
        public string DirectoryName { get; set; }
        /// <summary>
        /// This method reads file and returns a string for the whole file
        /// </summary>
        /// <returns>string</returns>
        public string ReadFile()
        {
            string fullFilePath = DirectoryName + FileName;
            string output = "";
            using(StreamReader reader = new StreamReader(fullFilePath,Encoding.UTF8))
            {
                output = reader.ReadToEnd();
            }
            return output;
        }
        /// <summary>
        /// This method writes a string to a file
        /// </summary>
        /// <param name="input"></param>
        /// <returns>bool</returns>
        public bool WriteFile(string input)
        {
            string fullFilePath = DirectoryName + FileName;
            var output = false;
            using (StreamWriter writer = new StreamWriter(fullFilePath))
            {
                writer.Write(input);
                output = true;
            }
                return output;
        } 

    }
}
