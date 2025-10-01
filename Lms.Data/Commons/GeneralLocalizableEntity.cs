using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Commons
{
    public class GeneralLocalizableEntity
    {
        
        public string localize(string texrAr ,string textEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if(culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return texrAr;
            return textEn;
        }
    }
}
