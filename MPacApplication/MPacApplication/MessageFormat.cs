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

        public int id
        {
            get { return _id; }
        }
        public byte version_major
        {
            get { return _version_major; }
            set { _version_major = value; }
        }
        public byte version_minor
        {
            get { return _version_minor; }
            set { _version_minor = value; }
        }
        public byte id_high
        {
            get { return _id_high; }
            set { _id_high = value; }
        }
        public byte id_low
        {
            get { return _id_low; }
            set { _id_low = value; }
        }
        public byte length
        {
            get { return _length; }
            set { _length = value; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string format
        {
            get { return _format; }
            set { _format = value; }
        }

        public MessageFormat()
        {
        }

        public MessageFormat(byte version_major, byte version_minor, byte id_high, byte id_low, byte length, string name, string format)
        {
            this.version_major = version_major;
            this.version_minor = version_minor;
            this.id_high = id_high;
            this.id_low = id_low;
            this.length = length;
            this.name = name;
            this.format = format;
        }

        public MessageFormat(string csvString)
        {
            FromCSVString(csvString);
        }

        public override string ToString()
        {
            return 
                "0x" + Format.AsHex(id_high) + Format.AsHex(id_low) +
                "     " + name.ToString() + 
                " - Length: " + length.ToString() +
                " - Format: " + format.ToString();
        }

        /// <summary>
        /// Converts the message object into a string with its values separated by commas. No newline is added at the end of the string.
        /// </summary>
        /// <returns></returns>
        public string ToCSVString()
        {

            return version_major.ToString() + "," +
                version_minor.ToString() + "," +
                name.ToString() + "," +
                id_high.ToString() + "," +
                id_low.ToString() + "," +
                length.ToString() + "," +
                format.ToString();
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
            try { version_major = byte.Parse(values[1]); }
            catch { flag = false; }
            try { version_minor = byte.Parse(values[2]); }
            catch { flag = false; }
            try { name = values[3]; }
            catch { flag = false; }
            try { id_high = byte.Parse(values[4]); }
            catch { flag = false; }
            try { id_low = byte.Parse(values[5]); }
            catch { flag = false; }
            try { length = byte.Parse(values[6]); }
            catch { flag = false; }
            try { format = values[7]; }
            catch { flag = false; }

            return flag;

        }

    }
}
