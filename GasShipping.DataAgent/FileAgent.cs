using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasShipping.DataAgent
{
    /// <summary>This class will be used to read/write to files</summary>
    public class FileAgent
    {

        /// <summary>Initializes a new instance of the <see cref="FileAgent" /> class.</summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="directoryName">Name of the directory.</param>
        /// <exception cref="System.ArgumentException">'{nameof(fileName)}' cannot be null or empty. - fileName</exception>
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

        /// <summary>Gets or sets the name of the file.</summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; }

        /// <summary>Gets or sets the name of the directory.</summary>
        /// <value>The name of the directory.</value>
        public string DirectoryName { get; set; }
        /// <summary>This method reads file and returns a string for the whole file</summary>
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
        /// <summary>This method writes a string to a file</summary>
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
