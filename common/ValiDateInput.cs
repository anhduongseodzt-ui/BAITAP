using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace common
{
    public static class ValiDateInput
    {
        public static bool CheckValueInputNumber(string inputnumber)
        {
            if (string.IsNullOrEmpty(inputnumber))
            {
                return false;
            }
            inputnumber = inputnumber.Trim();
            if (!int.TryParse(inputnumber, out int value))
            { return false; }
            int numberInput = int.Parse(inputnumber);
            if (numberInput > int.MaxValue)
            {
                return false;
            }

            return true;
        }
        public static bool CheckValueInputString(string inputnumber)
        {
            if (string.IsNullOrEmpty(inputnumber))
            {
                return false;
            }
            if (int.TryParse(inputnumber, out int num))
            {
                return false;
            }
            if (inputnumber.Length > 200)
            {
                return false;
            }
            return true;
        }
        public static bool CheckSpecialCharacter(string inputString)
        {
            var regexItem = new Regex(@"^[a-zA-Z0-9 ]+$");
            if (!regexItem.IsMatch(inputString))
            {
                return false ;
            }
            return true; 
            


        }

        public static bool CheckXSSInput(string input)
        {
            try
            {
                var listDangerousString = new List<string>
        {
            "<applet",
            "<body",
            "<embed",
            "<frame",
            "<iframe",
            "<script",
            "<object",
            "<link",
            "<meta",
            "<style",
            "<img",
            "<svg",
            "onerror",
            "onload",
            "onclick",
            "onmouseover",
            "onfocus",
            "onblur",
            "onmouseenter"
        };

                if (string.IsNullOrWhiteSpace(input))
                    return false;

                string lowerInput = input.Trim().ToLower();

                foreach (var dangerous in listDangerousString)
                {
                    if (lowerInput.Contains(dangerous))
                        return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
