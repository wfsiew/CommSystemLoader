using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Utils
    {
        public static T GetValue<T>(string p, T k = default(T)) where T : struct
        {
            T x = k;

            if (string.IsNullOrEmpty(p))
                return x;

            try
            {
                object o = Convert.ChangeType(p, typeof(T));
                x = (T)o;
            }

            catch
            {
                x = k;
            }

            return x;
        }
    }
}
