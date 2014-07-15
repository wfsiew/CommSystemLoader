using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ConsoleApplication2;
using NLog;

namespace ConsoleApplication2.Models
{
    public class IDDInternal
    {
        public int IDD { get; set; }
        public double Commission { get; set; }
        public double Tier1 { get; set; }
        public double Tier2 { get; set; }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static Dictionary<int, IDDInternal> LoadList(string path)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNodeList x = doc.SelectNodes("IDDList/IDD");
                Dictionary<int, IDDInternal> l = new Dictionary<int, IDDInternal>();

                foreach (XmlNode n in x)
                {
                    IDDInternal o = IDDInternal.Load(n);
                    l.Add(o.IDD, o);
                }

                return l;
            }

            catch (Exception e)
            {
                logger.Debug("", e);
                throw e;
            }
        }

        private static IDDInternal Load(XmlNode n)
        {
            try
            {
                string value = n.Attributes["value"].Value;
                string comm = n.Attributes["comm"].Value;
                string tier1 = n.Attributes["tier1"].Value;
                string tier2 = n.Attributes["tier2"].Value;

                IDDInternal o = new IDDInternal();
                o.IDD = Utils.GetValue<int>(value);
                o.Commission = Utils.GetValue<double>(comm);
                o.Tier1 = Utils.GetValue<double>(tier1);
                o.Tier2 = Utils.GetValue<double>(tier2);

                return o;
            }

            catch (Exception e)
            {
                logger.Debug("", e);
                throw e;
            }
        }
    }

    public class IDDExternal
    {
        public int IDD { get; set; }
        public double Commission { get; set; }
        public double Tier1 { get; set; }
        public double Tier2 { get; set; }
        public double Tier3 { get; set; }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static Dictionary<int, IDDExternal> LoadList(string path)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNodeList x = doc.SelectNodes("IDDList/IDD");
                Dictionary<int, IDDExternal> l = new Dictionary<int, IDDExternal>();

                foreach (XmlNode n in x)
                {
                    IDDExternal o = IDDExternal.Load(n);
                    l.Add(o.IDD, o);
                }

                return l;
            }

            catch (Exception e)
            {
                logger.Debug("", e);
                throw e;
            }
        }

        private static IDDExternal Load(XmlNode n)
        {
            try
            {
                string value = n.Attributes["value"].Value;
                string comm = n.Attributes["comm"].Value;
                string tier1 = n.Attributes["tier1"].Value;
                string tier2 = n.Attributes["tier2"].Value;
                string tier3 = n.Attributes["tier3"].Value;

                IDDExternal o = new IDDExternal();
                o.IDD = Utils.GetValue<int>(value);
                o.Commission = Utils.GetValue<double>(comm);
                o.Tier1 = Utils.GetValue<double>(tier1);
                o.Tier2 = Utils.GetValue<double>(tier2);
                o.Tier3 = Utils.GetValue<double>(tier3);

                return o;
            }

            catch (Exception e)
            {
                logger.Debug("", e);
                throw e;
            }
        }
    }
}
