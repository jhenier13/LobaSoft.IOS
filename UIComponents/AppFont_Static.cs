using System;
using System.Collections.Generic;
using MonoTouch.UIKit;

namespace UIComponents
{
    public partial class AppFont
    {
        private static Dictionary<string, List<string>> __allFonts;

        public static string [] FontFamilies { get; private set; }

        static AppFont()
        {
            __allFonts = new Dictionary<string, List<string>>();
            LoadAllFonts();
        }

        private static void LoadAllFonts()
        {
            FontFamilies = UIFont.FamilyNames; 

            foreach (string familyName in FontFamilies)
            {
                List<string> familyFonts = new List<string>();

                foreach (string fontName in UIFont.FontNamesForFamilyName(familyName))
                    familyFonts.Add(fontName);

                __allFonts.Add(familyName, familyFonts);
            }
        }
    }
}

