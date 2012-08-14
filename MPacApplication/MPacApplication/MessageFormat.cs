using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPacApplication
{
    public class MessageFormat
    {
        private int _id = -1;
        private byte _version_major;
        private byte _version_minor;
        private byte _id_high;
        private byte _id_low;
        private byte _length;
        private string _name = "";
        private string _format = "";

        public int Id
        {
            get { return _id; }
        }
        public byte VersionMajor
        {
            get { return _version_major; }
            set { _version_major = value; }
        }
        public byte VersionMinor
        {
            get { return _version_minor; }
            set { _version_minor = value; }
        }
        public byte IdHigh
        {
            get { return _id_high; }
            set { _id_high = value; }
        }
        public byte IdLow
        {
            get { return _id_low; }
            set { _id_low = value; }
        }
        public byte Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string FormatString
        {
            get { return _format; }
            set { _format = value; }
        }

        public MessageFormat()
        {
        }

        public MessageFormat(byte version_major, byte version_minor, byte id_high, byte id_low, byte length, string name, string format)
        {
            this.VersionMajor = version_major;
            this.VersionMinor = version_minor;
            this.IdHigh = id_high;
            this.IdLow = id_low;
            this.Length = length;
            this.Name = name;
            this.FormatString = format;
        }

        public MessageFormat(string csvString)
        {
            FromCSVString(csvString);
        }

        public override string ToString()
        {
            return 
                "0x" + Format.AsHex(IdHigh) + Format.AsHex(IdLow) +
                "     " + Name.ToString() + 
                " - Length: " + Length.ToString() +
                " - Format: " + FormatString.ToString();
        }

        /// <summary>
        /// Converts the message object into a string with its values separated by commas. No newline is added at the end of the string.
        /// </summary>
        /// <returns></returns>
        public string ToCSVString()
        {

            return VersionMajor.ToString() + "," +
                VersionMinor.ToString() + "," +
                Name.ToString() + "," +
                IdHigh.ToString() + "," +
                IdLow.ToString() + "," +
                Length.ToString() + "," +
                FormatString.ToString();
        }

        /// <summary>
        /// Sets the data values of this object based on a csv string.
        /// </summary>
        /// <param name="csvString">The csv string to parse. Newline at the end of the string is ignored.</param>
        /// <returns>Returns true if all parses were successful.</returns>
        public bool FromCSVString(string csvString)
        {
            string[] values = csvString.Split(',');
            bool flag = true;

            try { _id = int.Parse(values[0]); }
            catch { flag = false; }
            try { VersionMajor = byte.Parse(values[1]); }
            catch { flag = false; }
            try { VersionMinor = byte.Parse(values[2]); }
            catch { flag = false; }
            try { Name = values[3]; }
            catch { flag = false; }
            try { IdHigh = byte.Parse(values[4]); }
            catch { flag = false; }
            try { IdLow = byte.Parse(values[5]); }
            catch { flag = false; }
            try { Length = byte.Parse(values[6]); }
            catch { flag = false; }
            try { FormatString = values[7]; }
            catch { flag = false; }

            return flag;

        }

    }
}
