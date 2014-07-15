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
            string path = "..\\..\\vsat\\external.xml";
            var d = VSATExternal.Load(path);

            Console.WriteLine(d.Commission);
            Console.WriteLine(d.Tier1);
            Console.WriteLine(d.Tier2);
            Console.WriteLine(d.Tier3);

            Console.ReadKey();
        }
    }
}
