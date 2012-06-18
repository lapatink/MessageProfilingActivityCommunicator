using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPacApplication
{
    class Message
    {
        private int id = -1;
        public byte version_major;
        public byte version_minor;
        public byte id_high;
        public byte id_low;
        public byte length;
        public string name = "";
        public string format = "";

        public Message()
        {

        }

        public Message(byte version_major, byte version_minor, byte id_high, byte id_low, byte length, string name, string format)
        {
            this.version_major = version_major;
            this.version_minor = version_minor;
            this.id_high = id_high;
            this.id_low = id_low;
            this.length = length;
            this.name = name;
            this.format = format;
        }

        public Message(string csvString)
        {
            FromCSVString(csvString);
        }

        public override string ToString()
        {
            return "id: " + id.ToString() +
                " version_major: " + version_major.ToString() +
                " version_minor: " + version_minor.ToString() +
                " name: " + name.ToString() +
                " id_high: " + id_high.ToString() +
                " id_low: " + id_low.ToString() +
                " length: " + length.ToString() +
                " format: " + format.ToString();
        }

        /// <summary>
        /// Converts the message object into a string with its values separated by commas. No newline is added at the end of the string.
        /// </summary>
        /// <returns></returns>
        public string ToCSVString()
        {

            return id.ToString() + "," +
                version_major.ToString() + "," +
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

            try { id = int.Parse(values[0]); }
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
