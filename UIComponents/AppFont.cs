using System;
using System.Collections.Generic;
using MonoTouch.UIKit;

namespace UIComponents
{
    public partial class AppFont
    {
        private const string BOLD_KEYWORD = "Bold";
        private const string ITALIC_KEYWORD = "Italic";
        private string __completeFontDescription;

        public string FamilyName { get; private set; }

        public bool IsBold { get; private set; }

        public bool IsItalic { get; private set; }

        public float FontSize { get; private set; }

        public AppFont(string familyName, bool isBold, bool isItalic, float fontSize)
        {
            if (!__allFonts.ContainsKey(familyName))
                throw new ArgumentException("This family name doesn't exists");

            List<string> familyFonts = __allFonts[familyName];
            familyFonts.Sort(delegate(string x, string y)
            {
                return (x.Length - y.Length);
            });

            this.FamilyName = familyName;
            this.FontSize = fontSize;

            this.IsBold = false;
            this.IsItalic = false;
            __completeFontDescription = familyFonts[0];

            if (!isBold && !isItalic)
                return;

            List<string> boldAndItalicFonts = familyFonts.FindAll((font) =>
            {
                return font.Contains(BOLD_KEYWORD) && font.Contains(ITALIC_KEYWORD);
            });
            List<string> boldFonts = familyFonts.FindAll((font) => font.Contains(BOLD_KEYWORD));
            List<string> italicFonts = familyFonts.FindAll((font) => font.Contains(ITALIC_KEYWORD));

            if (boldFonts.Count == 0 && italicFonts.Count == 0)
                return;

            if (isBold && isItalic && boldAndItalicFonts.Count > 0)
            {
                __completeFontDescription = boldAndItalicFonts[0];
            }
            else
            {
                isBold = (isBold && boldFonts.Count > 0);
                isItalic = (isItalic && !isBold && italicFonts.Count > 0);
            }

            if (isBold && !isItalic)
                __completeFontDescription = boldFonts[0];
            else if (!isBold && isItalic)
                __completeFontDescription = italicFonts[0];
            else if (!isBold && !isItalic)
                __completeFontDescription = familyFonts[0];

            this.IsBold = isBold;
            this.IsItalic = isItalic;
        }

        public UIFont CreateUIFont()
        {
            UIFont font = UIFont.FromName(__completeFontDescription, this.FontSize);
            return font;
        }
    }
}

