using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2.Models;

namespace ConsoleApplication2
{
    public class SettingFactory
    {
        private static volatile SettingFactory instance;
        private static object syncRoot = new Object();

        private SettingFactory()
        {
            Load();
        }

        public static SettingFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SettingFactory();
                    }
                }

                return instance;
            }
        }

        private void Load()
        {
            ADSLInternalSetting = ADSLInternal.Load("..\\..\\adsl\\internal.xml");
            ADSLExternalSetting = ADSLExternal.Load("..\\..\\adsl\\external.xml");
            CorporateInternetPremiumInternalSetting = CorporateInternetPremiumInternal.Load("");
            CorporateInternetPremiumExternalSetting = CorporateInternetPremiumInternal.Load("");
            DiscountedCallServiceInternalSetting = DiscountedCallServiceInternal.LoadList("..\\..\\discountedcallservice\\internal.xml");
            DiscountedCallServiceExternalSetting = DiscountedCallServiceExternal.LoadList("..\\..\\discountedcallservice\\external.xml");
        }

        public ADSLInternal ADSLInternalSetting { get; set; }
        public ADSLExternal ADSLExternalSetting { get; set; }
        public CorporateInternetPremiumInternal CorporateInternetPremiumInternalSetting { get; set; }
        public CorporateInternetPremiumInternal CorporateInternetPremiumExternalSetting { get; set; }
        public Dictionary<double, DiscountedCallServiceInternal> DiscountedCallServiceInternalSetting { get; set; }
        public Dictionary<double, DiscountedCallServiceExternal> DiscountedCallServiceExternalSetting { get; set; }
    }
}
