using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MPacApplication
{
    static class FormatParser
    {
        private const string delim = "  ";
        private static byte[] data = null;
        private static int index = 0;

        /// <summary>
        /// Parses a set of byte data based on a format string.
        /// </summary>
        /// <param name="format">The format string.</param>
        /// <param name="bytes">The set of byte data to parse.</param>
        /// <returns>Returns a formatted string of the data.</returns>
        public static string Parse(string format, byte[] bytes)
        {
            index = 0;

            if (bytes == null)
                return "";
            if (format.Length < 1)
                return "";

            data = bytes;

            string[] tokens = format.Split(' ');
            string output = "";

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "call")
                {
                    //format the argument string
                    string args = FormatParser.Parse("%", data).Replace(delim, " ");

                    string filename = format.Substring(5, format.Length - 5);

                    Process p = new Process();
                    p.StartInfo.FileName = filename;
                    p.StartInfo.Arguments = args;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();

                    output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();

                    return output;
                }
                else if (tokens[i] != "" && tokens[i] != "%")
                {
                    output += group(tokens[i], tokens[++i], tokens[++i]);
                }
            }

            //format remaining data
            while (index < data.Length)
            {
                output += Format.AsHex(data[index]) + delim;
                index++;
            }

            output = output.Substring(0, Math.Max(output.Length - delim.Length, 0));
            return output;

        }

        /// <summary>
        /// Format a string with uniform grouping.
        /// </summary>
        /// <param name="scount">String representing the integer number of times to repeat, or * for "infinite."</param>
        /// <param name="sgroupsize">String representing the number of bytes to group.</param>
        /// <param name="type">h for hex and b for binary.</param>
        /// <returns>Returns a formatted string, or "" if a failure occured.</returns>
        private static string group(string scount, string sgroupsize, string type)
        {
            int count = safeParse(scount);
            int groupsize = safeParse(sgroupsize);
            string output = "";

            if (groupsize < 1)
                return "";

            if (count == -1)
            {
                int space = 0;

                for (int i = index; i < data.Length - (data.Length % groupsize); i++)
                {
                    space++;
                    if (type == "h")
                        output += Format.AsHex(data[i]);
                    else if (type == "b")
                        output += Format.AsBinary(data[i]);
                    else if (type == "d")
                    {
                        byte[] dec = new byte[groupsize];
                        for (int j = 0; j < groupsize; j++)
                        {
                            dec[j] = data[i + j];
                        }
                        i += groupsize - 1;
                        output += Format.AsDecimal(dec) + delim;
                        continue;
                    }

                    if (space % groupsize == 0)
                        output += delim;

                }

                index = data.Length - (data.Length % groupsize);
                return output;
            }
            else
            {
                int size = count * groupsize;
                int space = 0;

                if (size > data.Length - index)
                {
                    size = data.Length - index;
                    size = size - (size % groupsize);
                }

                for (int i = index; i < index+size; i++)
                {
                    space++;

                    if (type == "h")
                        output += Format.AsHex(data[i]);
                    else if (type == "b")
                        output += Format.AsBinary(data[i]);
                    else if (type == "d")
                    {
                        byte[] dec = new byte[groupsize];
                        for (int j = 0; j < groupsize; j++)
                        {
                            dec[j] = data[i + j];
                        }
                        i += groupsize - 1;
                        output += Format.AsDecimal(dec) + delim;
                        continue;
                    }

                    if (space % groupsize == 0)
                        output += delim;
                }
                index += size;
                return output;
            }
        }

        /// <summary>
        /// Format a string based on a format and data type, with a set number of repeats.
        /// </summary>
        /// <param name="scount">Number of times to repeat.</param>
        /// <param name="format">Format style</param>
        /// <param name="type">Data type.</param>
        /// <returns>Returns a formatted string, or "" if failure occured.</returns>
        private static string set(string scount, string format, string type)
        {
            int count = safeParse(scount);
            int size = sizeOf(type);

            string ret = "";

            if (count == -1)
                count = (data.Length - index) - ((data.Length - index) % size);

            while ((count * size) > (data.Length - index))
                count--;

            if (count < 1)
                return "";

            byte[] bytes;
            object value = null;

            for (int i = 0; i < count; i++)
            {
                value = null;

                switch (type)
                {
                    case "b":
                        bytes = new byte[sizeof(byte)];
                        Array.Copy(data, index, bytes, 0, sizeof(byte));
                        index += sizeof(byte);

                        value = (byte)bytes[0];

                        if (format == "b")
                            ret += Format.AsBinary((byte)value) + delim;
                        else if (format == "h")
                            ret += Format.AsHex((byte)value) + delim;
                        else if (format == "d")
                            ret += ((byte)value).ToString() + delim;
                        break;
                    case "s":
                        bytes = new byte[sizeof(short)];
                        Array.Copy(data, index, bytes, 0, sizeof(short));
                        index += sizeof(short);

                        value = (short)BitConverter.ToInt16(bytes, 0);

                        if (format == "b")
                            ret += Format.AsBinary((short)value) + delim;
                        else if (format == "h")
                            ret += Format.AsHex((short)value) + delim;
                        else if (format == "d")
                            ret += ((short)value).ToString() + delim;
                        break;
                    case "us":
                        bytes = new byte[sizeof(ushort)];
                        Array.Copy(data, index, bytes, 0, sizeof(ushort));
                        index += sizeof(ushort);

                        value = (ushort)BitConverter.ToUInt16(bytes, 0);

                        if (format == "b")
                            ret += Format.AsBinary((ushort)value) + delim;
                        else if (format == "h")
                            ret += Format.AsHex((ushort)value) + delim;
                        else if (format == "d")
                            ret += ((ushort)value).ToString() + delim;
                        break;
                    case "i":
                        bytes = new byte[sizeof(int)];
                        Array.Copy(data, index, bytes, 0, sizeof(int));
                        index += sizeof(int);

                        value = (int)BitConverter.ToInt32(bytes, 0);

                        if (format == "b")
                            ret += Format.AsBinary((int)value) + delim;
                        else if (format == "h")
                            ret += Format.AsHex((int)value) + delim;
                        else if (format == "d")
                            ret += ((int)value).ToString() + delim;
                        break;
                    case "ui":
                        bytes = new byte[sizeof(uint)];
                        Array.Copy(data, index, bytes, 0, sizeof(uint));
                        index += sizeof(uint);

                        value = (uint)BitConverter.ToUInt32(bytes, 0);

                        if (format == "b")
                            ret += Format.AsBinary((uint)value) + delim;
                        else if (format == "h")
                            ret += Format.AsHex((uint)value) + delim;
                        else if (format == "d")
                            ret += ((uint)value).ToString() + delim;
                        break;
                    case "l":
                        bytes = new byte[sizeof(long)];
                        Array.Copy(data, index, bytes, 0, sizeof(long));
                        index += sizeof(long);

                        value = (long)BitConverter.ToInt64(bytes, 0);

                        if (format == "b")
                            ret += Format.AsBinary((long)value) + delim;
                        else if (format == "h")
                            ret += Format.AsHex((long)value) + delim;
                        else if (format == "d")
                            ret += ((long)value).ToString() + delim;
                        break;
                    case "ul":
                        bytes = new byte[sizeof(ulong)];
                        Array.Copy(data, index, bytes, 0, sizeof(ulong));
                        index += sizeof(ulong);

                        value = (ulong)BitConverter.ToUInt64(bytes, 0);

                        if (format == "b")
                            ret += Format.AsBinary((ulong)value) + delim;
                        else if (format == "h")
                            ret += Format.AsHex((ulong)value) + delim;
                        else if (format == "d")
                            ret += ((ulong)value).ToString() + delim;
                        break;
                    default:
                        break;
                }

            }

            return ret;

        }

        /// <summary>
        /// Safely parse a string value to an int. 
        /// </summary>
        /// <param name="value">String value to parse.</param>
        /// <returns>Returns 0 on failure and -1 for *</returns>
        private static int safeParse(string value)
        {
            int ret = 0;
            if (value == "*")
                return -1;
            try { ret = int.Parse(value); }
            catch { }
            return ret;
        }

        /// <summary>
        /// Get the integer size of a type token.
        /// </summary>
        /// <param name="s">The token to parse.</param>
        /// <returns>Returns an integer size, or 0 by default.</returns>
        public static int sizeOf(string s)
        {
            s = s.ToLower();

            switch (s)
            {
                case "b":
                case "byte":
                    return 1;
                case "s":
                case "us":
                case "short":
                case "ushort":
                    return 2;
                case "i":
                case "ui":
                case "int":
                case "uint":
                    return 4;
                case "l":
                case "ul":
                case "long":
                case "ulong":
                    return 8;
                default:
                    return 0;
            }

        }
    }
}
