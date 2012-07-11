using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MPacApplication
{
    static class FormatParser
    {
        private static string delim = " ";
        private static string def_type = "b";
        private static string def_form = "h";
        private static string external = "";
        private static int index = 0;

        public static string Parse(string format, byte[] data)
        {
            index = 0;
            string[] tokens = format.ToLower().Split(' ');
            string output = "";

            for (int i = 0; i < tokens.Length; i++)
            {
                int num = 0;
                int grp = 0;
                string form = "";
                string type = "";

                if (external != "")
                    break;
                switch (tokens[i])
                {
                    case "df":
                        def_form = tokens[++i];
                        def_type = tokens[++i];
                        break;
                    case "dl":
                        delim = tokens[++i].Replace(@"\s", " ").Replace(@"\c", ",");
                        break;
                    case "call":
                        external = format.Substring("call ".Length);
                        break;
                    case "g":
                        grp = int.Parse(tokens[++i]);
                        num = int.Parse(tokens[++i]);
                        form = tokens[++i];
                        type = tokens[++i];
                        for (int j = 0; j < num * grp; j++)
                            output += parse(type, form, data, true) + ((j % grp != 0) ? delim : "");
                        break;
                    case "":
                        break;
                    default:
                        num = int.Parse(tokens[i]);
                        form = tokens[++i];
                        type = tokens[++i];
                        for (int j = 0; j < num; j++)
                            output += parse(type, form, data);
                        break;
                }


            }

            if (external != "")
            {
                string input = "";

                foreach (byte b in data)
                    input += b.ToString() + " ";

                Process p = new Process();
                p.StartInfo.FileName = external;
                p.StartInfo.Arguments = input;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();

                output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                return output;
            }

            int size = 0;
            switch (def_type)
            {
                case "b":
                    size = sizeof(byte);
                    break;
                case "s":
                    size = sizeof(short);
                    break;
                case "i":
                    size = sizeof(int);
                    break;
                case "l":
                    size = sizeof(long);
                    break;

            }
            while (index < data.Length)
            {
                if ((data.Length - index) < size)
                    break;
                output += parse(def_type, def_form, data);
            }

            return output.Substring(0, output.Length - delim.Length);
        }

        private static string parse(string type, string form, byte[] data, bool group = false)
        {
            string ret = "";
            byte[] bytes;
            string mydelim = delim;
            if (group)
                mydelim = "";

            switch (type)
            {
                case "i":
                    if ((sizeof(Int32) + index) > data.Length)
                        return "";
                    bytes = new byte[sizeof(Int32)];
                    Array.Copy(data, index, bytes, 0, sizeof(Int32));
                    index += sizeof(Int32);
                    if (form == "d")
                        ret += BitConverter.ToInt32(bytes, 0).ToString() + mydelim;
                    else if (form == "h")
                        ret += Format.AsHex(BitConverter.ToInt32(bytes, 0)) + mydelim;
                    else if (form == "b")
                        ret += Format.AsBinary(BitConverter.ToInt32(bytes, 0)) + mydelim;
                    else if (form == "o")
                        ret += Format.AsOctal(BitConverter.ToInt32(bytes, 0)) + mydelim;
                    break;
                case "s":
                    if ((sizeof(Int16) + index) > data.Length)
                        return "";
                    bytes = new byte[sizeof(Int16)];
                    Array.Copy(data, index, bytes, 0, sizeof(Int16));
                    index += sizeof(Int16);
                    if (form == "d")
                        ret += BitConverter.ToInt16(bytes, 0).ToString() + mydelim;
                    else if (form == "h")
                        ret += Format.AsHex(BitConverter.ToInt16(bytes, 0)) + mydelim;
                    else if (form == "b")
                        ret += Format.AsBinary(BitConverter.ToInt16(bytes, 0)) + mydelim;
                    else if (form == "o")
                        ret += Format.AsOctal(BitConverter.ToInt16(bytes, 0)) + mydelim;
                    break;
                case "b":
                    if ((sizeof(byte) + index) > data.Length)
                        return "";
                    bytes = new byte[sizeof(byte)];
                    Array.Copy(data, index, bytes, 0, sizeof(byte));
                    index += sizeof(byte);
                    if (form == "d")
                        ret += bytes[0].ToString() + mydelim;
                    else if (form == "h")
                        ret += Format.AsHex(bytes[0]) + mydelim;
                    else if (form == "b")
                        ret += Format.AsBinary(bytes[0]) + mydelim;
                    else if (form == "o")
                        ret += Format.AsOctal(bytes[0]) + mydelim;
                    break;
                case "l":
                    if ((sizeof(Int64) + index) > data.Length)
                        return "";
                    bytes = new byte[sizeof(Int64)];
                    Array.Copy(data, index, bytes, 0, sizeof(Int64));
                    index += sizeof(Int64);
                    if (form == "d")
                        ret += BitConverter.ToInt64(bytes, 0).ToString() + mydelim;
                    else if (form == "h")
                        ret += Format.AsHex(BitConverter.ToInt64(bytes, 0)) + mydelim;
                    else if (form == "b")
                        ret += Format.AsBinary(BitConverter.ToInt64(bytes, 0)) + mydelim;
                    else if (form == "o")
                        ret += Format.AsOctal(BitConverter.ToInt64(bytes, 0)) + mydelim;
                    break;
            }
            return ret;
        }
    }
}
