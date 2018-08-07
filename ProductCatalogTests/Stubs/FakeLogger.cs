using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCatalog.Interfaces;

namespace ProductCatalog.Tests.Stubs
{
    class FakeLogger : ILogger
    {
        private string _message;
        public string LogFilePath { get;}

        public bool Log(string message)
        {
            _message = message;
            return true;
        }

        public string getMessage()
        {
            return _message;
        }
        public void Close()
        {
            return;
        }
    }
}
