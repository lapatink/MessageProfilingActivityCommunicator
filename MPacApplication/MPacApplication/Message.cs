using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPacApplication
{
    class Message
    {
        public byte version_major;
        public byte version_minor;
        public byte id_high;
        public byte id_low;
        public byte length;
        public byte[] data;

        public Message()
        {

        }

        public Message(byte version_major, byte version_minor, byte id_high, byte id_low, byte length, byte[] data)
        {
            this.version_major = version_major;
            this.version_minor = version_minor;
            this.id_high = id_high;
            this.id_low = id_low;
            this.length = length;
            this.data = data;

            //System.Diagnostics.Debug.Assert(data.Length == length);
        }

    }
}
