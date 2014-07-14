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
            string path = "..\\..\\fibre+\\external.xml";
            var d = FibrePlusExternal.LoadList(path);

            foreach (KeyValuePair<int, FibrePlusExternal> k in d)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", k.Value.Type, k.Value.Commission, k.Value.Tier1, k.Value.Tier2, k.Value.Tier3);
            }

            Console.ReadKey();
        }
    }
}
