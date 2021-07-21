using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedETS2Packer.Languages
{
    /// <summary>
    /// This class is used for generating culture for translations
    /// </summary>
    public class CultureGenerator
    {
        /// <summary>
        /// This method set culture for thread by language, which is set in properties
        /// </summary>
        // method, that set CultureInfo from properties (selected language)
        public static void SetCultureFromProperties()
        {
            string language = "en-US";

            // that switch may be here for no reason, but in the future, when there will be more languages, it will come in handy
            switch (Properties.Settings.Default.Language)
            {
                case 1:
                    language = "cs-CZ";
                    break;
            }

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
        }
    }
}
