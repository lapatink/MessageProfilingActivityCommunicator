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

          public Message()
          {

          }

          public Message(byte version_major, byte version_minor, byte id_high, byte id_low, byte[] data)
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
          }

          public override String ToString()
          {
               String str = "Version: " + version_major + "." + version_minor + "\t\tMessage ID: 0x" + id_high + id_low;

               if (data != null)
               {
                    str += "\t\tData:";

                    foreach (byte b in data)
                    {
                         str += " " + Convert.ToString(b, 16).PadLeft(2, '0').ToUpper();
                    }
               }

               return str;
          }
     }
}
