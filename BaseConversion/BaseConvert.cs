using System;
using System.Linq;

namespace BaseConversion
{
    public static class BaseConvert
    {
        public static string From10Unsigned(int toConvert, int toBase) {
            if(toConvert < 0 || toBase < 2 || toBase > 36) throw new ArgumentException("Base or input was in invalid range!");
            if (toConvert < toBase) return Validate(toConvert).ToString();

            int maxBase = 1;
            while (maxBase <= toConvert) maxBase *= toBase;  //Get max base
            maxBase /= toBase;

            string output = string.Empty;

            while (maxBase >= 1) {
                int number = toConvert / maxBase;
                output += Validate(number);
                toConvert = toConvert % maxBase;
                maxBase /= toBase;
            }

            return output;
        }

        public static int To10Unsigned(string toConvert, int toBase) {
            
            //Validation
            for (char i = 'A'; i <= 'Z'; i++) {
                if (!toConvert.Contains((char)(i + 32))) continue; 

                toConvert = toConvert.Replace(i, (char) (i + 32));      //Set literals to it's lower equivalents (A -> a, B -> b....)

                int currentStand = i - 55;
                if(toBase <= currentStand) 
                    throw new ArgumentException("Input string contained out-of-base characters!");   //String contains stand-off characters that don't suit the base (eg. there is no g in hexadecimal base)
            }

            //Conversion
            toConvert = toConvert.ReverseString();
            int curBase = 1;
            int result = 0;
            foreach (var c in toConvert) {
                var value = Devalidate(c);
                result += value * curBase;
                curBase *= toBase;
            }

            return result;
        }

        private static char Validate(int i) {
            if (i < 10) return (char)(i + 48);
            i -= 10;
            if (i < 26) return (char) (i + 97);
            throw new ArgumentException("Current number is out of valid scope!");
        }

        private static int Devalidate(char c) {
            if (c >= '0' && c <= '9') return (c - 48);
            if (c >= 'a' && c <= 'z') return (c - 87);
            throw new ArgumentException("Current number is out of valid scope!");
        }

        private static string ReverseString(this string s) {
            var arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        

    }
}
