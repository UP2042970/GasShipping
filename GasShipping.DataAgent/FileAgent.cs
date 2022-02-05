using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasShipping.DataAgent
{
    public class FileAgent
    {
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

        public string FileName { get; set; }
        public string DirectoryName { get; set; }
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
