using OLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var x = new OLogger("log.log");
            x.LogToConsoleEnabled = true;

            x.Warn("This is a warning");

            x.Info("This is an info");
            x.Error("This is an Error");
        }
    }
}
