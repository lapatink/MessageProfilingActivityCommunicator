using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPacApplication
{
     public class Message
     {
          public byte version_major;
          public byte version_minor;
          public byte id_high;
          public byte id_low;
          public byte length;
          public byte[] data;
          private DateTime timestamp;

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
