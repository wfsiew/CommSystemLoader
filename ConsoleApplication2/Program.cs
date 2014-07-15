using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using ConsoleApplication2.Models;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            SettingFactory o = SettingFactory.Instance;
            double v = o.ADSLInternalSetting.GetCommission(1000, 0);
            Console.WriteLine(v);

            Console.ReadKey();
        }
    }
}
