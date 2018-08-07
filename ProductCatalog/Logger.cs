using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProductCatalog.Interfaces;

namespace ProductCatalog
{
    public class Logger : ILogger
    {
        public string LogFilePath { get; }
        private StreamWriter File;
        private string _message;

        public Logger(string filePath = "")
        {
            LogFilePath = filePath;
            File = new StreamWriter(LogFilePath, true);
        }

        public bool Log(string message)
        {
            try
            {
                _message = message;
                File.WriteLine(message);
                File.Flush();
                return true;
            } 
            catch(Exception ex)
            {
                return false;
            }            
        }

        public string getMessage()
        {
            return _message;
        }

        public void Close()
        {
            File.Close();
        }

    }
}
