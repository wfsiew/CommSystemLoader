﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ConsoleApplication2;
using NLog;

namespace ConsoleApplication2.Models
{
    public class E1Internal
    {
        public double Rate { get; set; }
        public double Commission { get; set; }
        public double Tier1 { get; set; }
        public double Tier2 { get; set; }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static Dictionary<double, E1Internal> LoadList(string path)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNodeList x = doc.SelectNodes("RateList/Rate");
                Dictionary<double, E1Internal> l = new Dictionary<double, E1Internal>();

                foreach (XmlNode n in x)
                {
                    E1Internal o = E1Internal.Load(n);
                    l.Add(o.Rate, o);
                }

                return l;
            }

            catch (Exception e)
            {
                logger.Debug("", e);
                throw e;
            }
        }

        private static E1Internal Load(XmlNode n)
        {
            try
            {
                string value = n.Attributes["value"].Value;
                string comm = n.Attributes["comm"].Value;
                string tier1 = n.Attributes["tier1"].Value;
                string tier2 = n.Attributes["tier2"].Value;

                E1Internal o = new E1Internal();
                o.Rate = Utils.GetValue<double>(value);
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

    public class E1External
    {
        public double Rate { get; set; }
        public double Commission { get; set; }
        public double Tier1 { get; set; }
        public double Tier2 { get; set; }
        public double Tier3 { get; set; }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static Dictionary<double, E1External> LoadList(string path)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNodeList x = doc.SelectNodes("RateList/Rate");
                Dictionary<double, E1External> l = new Dictionary<double, E1External>();

                foreach (XmlNode n in x)
                {
                    E1External o = E1External.Load(n);
                    l.Add(o.Rate, o);
                }

                return l;
            }

            catch (Exception e)
            {
                logger.Debug("", e);
                throw e;
            }
        }

        private static E1External Load(XmlNode n)
        {
            try
            {
                string value = n.Attributes["value"].Value;
                string comm = n.Attributes["comm"].Value;
                string tier1 = n.Attributes["tier1"].Value;
                string tier2 = n.Attributes["tier2"].Value;
                string tier3 = n.Attributes["tier3"].Value;

                E1External o = new E1External();
                o.Rate = Utils.GetValue<double>(value);
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
