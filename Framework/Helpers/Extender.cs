using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web
{
    public static class Extender
    {
        public static int ToInteger(this string s)
        {
            int result;
            int.TryParse(s, out result);
               
            return result;
        }

        public static int? ToNullableInteger(this string s)
        {
            if (String.IsNullOrEmpty((s ?? "").Trim()))
                return null;

            int result;
            if (int.TryParse(s, out result))
                return result;

            return null;
        }

        public static Decimal ToDecimal(this string s)
        {
            Decimal result;
            Decimal.TryParse(s, out result);

            return result;
        }

        public static DateTime? ToNullableDate(this String dateString)
        {
            if (String.IsNullOrEmpty((dateString ?? "").Trim()))
                return null;

            DateTime resultDate;
            if (DateTime.TryParse(dateString, out resultDate))
                return resultDate;

            return null;
        }

        public static DateTime ToDate(this String dateString)
        {
            DateTime resultDate;
            DateTime.TryParse(dateString, out resultDate);
            
            return resultDate;           
        }
       
    }
}
