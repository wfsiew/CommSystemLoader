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
    public class RecurringContractInternal
    {
        public int Type { get; set; }
        public double Commission { get; set; }
        public double Tier1 { get; set; }
        public double Tier2 { get; set; }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public double GetCommission(double amt, int level)
        {
            double a = 0;

            switch (level)
            {
                case 1:
                    a = Tier1;
                    break;

                case 2:
                    a = Tier2;
                    break;

                default:
                    a = Commission;
                    break;
            }

            double x = a * amt;
            return x;
        }

        public static Dictionary<int, RecurringContractInternal> LoadList(string path)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNodeList x = doc.SelectNodes("CommList/Comm");
                Dictionary<int, RecurringContractInternal> l = new Dictionary<int, RecurringContractInternal>();

                foreach (XmlNode n in x)
                {
                    RecurringContractInternal o = RecurringContractInternal.Load(n);
                    l.Add(o.Type, o);
                }

                return l;
            }

            catch (Exception e)
            {
                logger.Debug("", e);
                throw e;
            }
        }

        private static RecurringContractInternal Load(XmlNode n)
        {
            try
            {
                string type = n.Attributes["type"].Value;
                string value = n.Attributes["value"].Value;
                string tier1 = n.Attributes["tier1"].Value;
                string tier2 = n.Attributes["tier2"].Value;

                RecurringContractInternal o = new RecurringContractInternal();
                o.Type = Utils.GetValue<int>(type);
                o.Commission = Utils.GetValue<double>(value);
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

    public class RecurringContractExternal
    {
        public int Type { get; set; }
        public double Commission { get; set; }
        public double Tier1 { get; set; }
        public double Tier2 { get; set; }
        public double Tier3 { get; set; }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public double GetCommission(double amt, int level)
        {
            double a = 0;

            switch (level)
            {
                case 1:
                    a = Tier1;
                    break;

                case 2:
                    a = Tier2;
                    break;

                case 3:
                    a = Tier3;
                    break;

                default:
                    a = Commission;
                    break;
            }

            double x = a * amt;
            return x;
        }

        public static Dictionary<int, RecurringContractExternal> LoadList(string path)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNodeList x = doc.SelectNodes("CommList/Comm");
                Dictionary<int, RecurringContractExternal> l = new Dictionary<int, RecurringContractExternal>();

                foreach (XmlNode n in x)
                {
                    RecurringContractExternal o = RecurringContractExternal.Load(n);
                    l.Add(o.Type, o);
                }

                return l;
            }

            catch (Exception e)
            {
                logger.Debug("", e);
                throw e;
            }
        }

        private static RecurringContractExternal Load(XmlNode n)
        {
            try
            {
                string type = n.Attributes["type"].Value;
                string value = n.Attributes["value"].Value;
                string tier1 = n.Attributes["tier1"].Value;
                string tier2 = n.Attributes["tier2"].Value;
                string tier3 = n.Attributes["tier3"].Value;

                RecurringContractExternal o = new RecurringContractExternal();
                o.Type = Utils.GetValue<int>(type);
                o.Commission = Utils.GetValue<double>(value);
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
