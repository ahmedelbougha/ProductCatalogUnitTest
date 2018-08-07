using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCatalog;
using System.Diagnostics;
using System.IO;

namespace ProductCatalog.Tests
{
    [TestClass]
    public class AssemblyInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Debug.WriteLine("Initilizing Unit Test");
            
            //Debug.WriteLine("DataDirectory"+ Path.GetFullPath(dataDirectory));
            //Debug.WriteLine(AppDomain.CurrentDomain.GetData("DataDirectory"));

            //AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory.ToString() + "Data\\");
        }

        [AssemblyCleanup]
        public static void AssemblyDone()
        {
            Debug.WriteLine("Cleaning up Unit Test");
        }
    }
}
