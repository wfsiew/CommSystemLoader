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
    public class CorporateInternetPremiumInternal
    {
        public double Commission { get; set; }
        public double Tier1 { get; set; }
        public double Tier2 { get; set; }
        public double Tier3 { get; set; }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static CorporateInternetPremiumInternal Load(string path)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode n = doc.SelectSingleNode("Comm");
                CorporateInternetPremiumInternal o = CorporateInternetPremiumInternal.Load(n);

                return o;
            }

            catch (Exception e)
            {
                logger.Debug("", e);
                throw e;
            }
        }

        private static CorporateInternetPremiumInternal Load(XmlNode n)
        {
            try
            {
                string value = n.Attributes["value"].Value;
                string tier1 = n.Attributes["tier1"].Value;
                string tier2 = n.Attributes["tier2"].Value;
                string tier3 = n.Attributes["tier3"].Value;

                CorporateInternetPremiumInternal o = new CorporateInternetPremiumInternal();
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

    public class CorporateInternetPremiumExternal : CorporateInternetPremiumInternal
    {
    }
}
