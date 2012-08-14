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
          public byte[] Data
          {
              get { return _data; }
              set { _data = value; }
          }

          public Message()
          {

          }

          public Message(byte version_major, byte version_minor, byte id_high, byte id_low, byte[] data, DateTime timestamp)
          {
               this.VersionMajor = version_major;
               this.VersionMinor = version_minor;
               this.IdHigh = id_high;
               this.IdLow = id_low;
               if (data != null)
               {
                    this.Length = (byte)data.Length;
                    this.Data = data;
               }
               this.timestamp = timestamp;
          }

          public String GetTimestamp()
          {
               return String.Format("{0:MM/dd/yyyy HH:mm:ss.fff tt}     ", timestamp);
          }

          public override String ToString()
          {
               String str = String.Format("{0:MM/dd/yyyy HH:mm:ss.fff tt}     ", timestamp) + "Message ID: 0x" + Format.AsHex(IdHigh) + Format.AsHex(IdLow) + " - Length: " + Length;

               if (Data != null && Data.Length > 0)
               {
                    str += "     Data:";

                    foreach (byte b in Data)
                    {
                         str += " " + Format.AsHex(b);
                    }
               }

               return str;
          }
     }
}
