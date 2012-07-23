using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPacApplication
{
     public class Message
     {
          private byte _version_major;
          private byte _version_minor;
          private byte _id_high;
          private byte _id_low;
          private byte _length;
          private byte[] _data;
          private DateTime timestamp;

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
          public byte[] data
          {
              get { return _data; }
              set { _data = value; }
          }

          public Message()
          {

          }

          public Message(byte version_major, byte version_minor, byte id_high, byte id_low, byte[] data, DateTime timestamp)
          {
               this.version_major = version_major;
               this.version_minor = version_minor;
               this.id_high = id_high;
               this.id_low = id_low;
               if (data != null)
               {
                    this.length = (byte)data.Length;
                    this.data = data;
               }
               this.timestamp = timestamp;
          }

          public String GetTimestamp()
          {
               return String.Format("{0:MM/dd/yyyy HH:mm:ss.fff tt}     ", timestamp);
          }

          public override String ToString()
          {
               String str = String.Format("{0:MM/dd/yyyy HH:mm:ss.fff tt}     ", timestamp) + "Message ID: 0x" + Format.AsHex(id_high) + Format.AsHex(id_low) + " - Length: " + length;

               if (data != null && data.Length > 0)
               {
                    str += "     Data:";

                    foreach (byte b in data)
                    {
                         str += " " + Format.AsHex(b);
                    }
               }

               return str;
          }
     }
}
