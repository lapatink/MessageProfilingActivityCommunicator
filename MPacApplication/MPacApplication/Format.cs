using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPacApplication
{
    static class Format
    {
        public static string AsHex(byte value)
        {
            return value.ToString("X").PadLeft(2, '0');
        }
        public static string AsHex(short value)
        {
            return value.ToString("X").PadLeft(4, '0');
        }
        public static string AsHex(int value)
        {
            return value.ToString("X").PadLeft(8, '0');
        }
        public static string AsHex(long value)
        {
            return value.ToString("X").PadLeft(16, '0');
        }
        public static string AsHex(ushort value)
        {
            return value.ToString("X").PadLeft(4, '0');
        }
        public static string AsHex(uint value)
        {
            return value.ToString("X").PadLeft(8, '0');
        }
        public static string AsHex(ulong value)
        {
            return value.ToString("X").PadLeft(16, '0');
        }

        public static string AsBinary(byte value)
        {
            return Convert.ToString(value, 2).PadLeft(8, '0');
        }
        public static string AsBinary(short value)
        {
            return Convert.ToString(value, 2).PadLeft(16,'0');
        }
        public static string AsBinary(int value)
        {
            return Convert.ToString(value, 2).PadLeft(32,'0');
        }
        public static string AsBinary(long value)
        {
            return Convert.ToString(value, 2).PadLeft(64,'0');
        }
        public static string AsBinary(ushort value)
        {
            return Convert.ToString(value, 2).PadLeft(16,'0');
        }
        public static string AsBinary(uint value)
        {
            return Convert.ToString(value, 2).PadLeft(32, '0'); ;
        }
        public static string AsBinary(ulong value)
        {
            return Convert.ToString((long)value, 2).PadLeft(64, '0'); //there is no distinction in binary
        }

        public static string getTokenString(string s)
        {
            s = s.ToLower();
            switch (s)
            {
                case "b":
                case "byte":
                case "bytes":
                case "binary":
                case "bin":
                    return "b";
                case "s":
                case "short":
                    return "s";
                case "i":
                case "int":
                case "integer":
                    return "i";
                case "l":
                case "long":
                    return "l";
                case "o":
                case "oct":
                case "octal":
                    return "o";
                case "h":
                case "hex":
                case "hexidecimal":
                    return "h";
                case "d":
                case "dec":
                case "decimal":
                    return "d";
                default:
                    return "";
            }
        }

    }
}

