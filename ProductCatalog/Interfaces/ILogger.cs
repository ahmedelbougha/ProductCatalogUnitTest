using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Interfaces
{
    public interface ILogger
    {
        bool Log(string message);
        string getMessage();
        void Close();
    }
}
