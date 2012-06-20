using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPacApplication
{
     class DataProcessor
     {
          private const byte START_OF_HEADER = 0xA5;
          private const byte SYSTEM_ID = 0x00;
          private const byte SUBSYSTEM_ID = 0x00;
          private const byte NODE_ID = 0x00;
          private const byte COMPONENT_ID = 0x00;
          private const byte MAJOR_SOFTWARE_VERSION = 0x01;
          private const byte MINOR_SOFTWARE_VERSION = 0x00;

          private byte majorSoftwareVersion;
          private byte minorSoftwareVersion;
          private byte messageIdHighByte;
          private byte messageIdLowByte;
          private byte payloadLength;
          private byte[] payload;
          private byte payloadPosition;
          private byte CRC_BYTE_0;
          private byte CRC_BYTE_1;

          private MainForm owner;

          private ProcessingState currentState;
          private ushort currentCRC;

          private int crcCheckFails;

          private enum ProcessingState
          {
               WAITING_FOR_START_OF_HEADER = 0,
               WAITING_FOR_SYSTEM_ID,
               WAITING_FOR_SUBSYSTEM_ID,
               WAITING_FOR_NODE_ID,
               WAITING_FOR_COMPONENT_ID,
               WAITING_FOR_MAJOR_SOFTWARE_VERSION,
               WAITING_FOR_MINOR_SOFTWARE_VERSION,
               WAITING_FOR_MESSAGE_ID_0,
               WAITING_FOR_MESSAGE_ID_1,
               WAITING_FOR_PAYLOAD_LENGTH,
               PROCESSING_PAYLOAD,
               WAITING_FOR_CRC_BYTE_0,
               WAITING_FOR_CRC_BYTE_1
          };

          public DataProcessor(MainForm parent)
          {
               owner = parent;

               majorSoftwareVersion = 0x00;
               minorSoftwareVersion = 0x00;
               messageIdHighByte = 0x00;
               messageIdLowByte = 0x00;
               payloadLength = 0x00;
               payloadPosition = 0x00;
               CRC_BYTE_0 = 0x00;
               CRC_BYTE_1 = 0x00;

               currentState = (int)ProcessingState.WAITING_FOR_START_OF_HEADER;
               currentCRC = 0;

               crcCheckFails = 0;
          }
          public void ProcessData(byte[] data)
          {
               byte dataCrcHighByte, dataCrcLowByte;
               for (int i = 0; i < data.Length; i++)
               {
                    switch (currentState)
                    {
                         case ProcessingState.WAITING_FOR_START_OF_HEADER:
                              if (data[i] == START_OF_HEADER)
                              {
                                   currentCRC = XModemCRC.CalculateCRC(data[i], 0);
                                   currentState = ProcessingState.WAITING_FOR_SYSTEM_ID;
                              }
                              break;
                         case ProcessingState.WAITING_FOR_SYSTEM_ID:
                              if (data[i] == SYSTEM_ID)
                              {
                                   currentCRC = XModemCRC.CalculateCRC(data[i], currentCRC);
                                   currentState = ProcessingState.WAITING_FOR_SUBSYSTEM_ID;
                              }
                              else
                              {
                                   currentState = ProcessingState.WAITING_FOR_START_OF_HEADER;
                                   goto case ProcessingState.WAITING_FOR_START_OF_HEADER;
                              }
                              break;
                         case ProcessingState.WAITING_FOR_SUBSYSTEM_ID:
                              if (data[i] == SUBSYSTEM_ID)
                              {
                                   currentCRC = XModemCRC.CalculateCRC(data[i], currentCRC);
                                   currentState = ProcessingState.WAITING_FOR_NODE_ID;
                              }
                              else
                              {
                                   currentState = ProcessingState.WAITING_FOR_START_OF_HEADER;
                                   goto case ProcessingState.WAITING_FOR_START_OF_HEADER;
                              }
                              break;
                         case ProcessingState.WAITING_FOR_NODE_ID:
                              if (data[i] == NODE_ID)
                              {
                                   currentCRC = XModemCRC.CalculateCRC(data[i], currentCRC);
                                   currentState = ProcessingState.WAITING_FOR_COMPONENT_ID;
                              }
                              else
                              {
                                   currentState = ProcessingState.WAITING_FOR_START_OF_HEADER;
                                   goto case ProcessingState.WAITING_FOR_START_OF_HEADER;
                              }
                              break;
                         case ProcessingState.WAITING_FOR_COMPONENT_ID:
                              if (data[i] == COMPONENT_ID)
                              {
                                   currentCRC = XModemCRC.CalculateCRC(data[i], currentCRC);
                                   currentState = ProcessingState.WAITING_FOR_MAJOR_SOFTWARE_VERSION;
                              }
                              else
                              {
                                   currentState = ProcessingState.WAITING_FOR_START_OF_HEADER;
                                   goto case ProcessingState.WAITING_FOR_START_OF_HEADER;
                              }
                              break;
                         case ProcessingState.WAITING_FOR_MAJOR_SOFTWARE_VERSION:
                              if (data[i] <= MAJOR_SOFTWARE_VERSION)
                              {
                                   majorSoftwareVersion = data[i];
                                   currentCRC = XModemCRC.CalculateCRC(data[i], currentCRC);
                                   currentState = ProcessingState.WAITING_FOR_MINOR_SOFTWARE_VERSION;
                              }
                              else
                              {
                                   currentState = ProcessingState.WAITING_FOR_START_OF_HEADER;
                                   goto case ProcessingState.WAITING_FOR_START_OF_HEADER;
                              }
                              break;
                         case ProcessingState.WAITING_FOR_MINOR_SOFTWARE_VERSION:
                              if ((majorSoftwareVersion == MAJOR_SOFTWARE_VERSION && data[i] <= MINOR_SOFTWARE_VERSION) || (majorSoftwareVersion < MAJOR_SOFTWARE_VERSION))
                              {
                                   minorSoftwareVersion = data[i];
                                   currentCRC = XModemCRC.CalculateCRC(data[i], currentCRC);
                                   currentState = ProcessingState.WAITING_FOR_MESSAGE_ID_0;
                              }
                              else//if majorSoftwareVersion == MAJOR_SOFTWARE_VERSION && minorSoftwareVersion > MINOR_SOFTWARE_VERSION
                              {
                                   currentState = ProcessingState.WAITING_FOR_START_OF_HEADER;
                                   goto case ProcessingState.WAITING_FOR_START_OF_HEADER;
                              }
                              break;
                         case ProcessingState.WAITING_FOR_MESSAGE_ID_0:
                              messageIdHighByte = data[i];
                              currentCRC = XModemCRC.CalculateCRC(data[i], currentCRC);
                              currentState = ProcessingState.WAITING_FOR_MESSAGE_ID_1;
                              break;
                         case ProcessingState.WAITING_FOR_MESSAGE_ID_1:
                              messageIdLowByte = data[i];
                              currentCRC = XModemCRC.CalculateCRC(data[i], currentCRC);
                              currentState = ProcessingState.WAITING_FOR_PAYLOAD_LENGTH;
                              break;
                         case ProcessingState.WAITING_FOR_PAYLOAD_LENGTH:
                              payloadLength = data[i];
                              currentCRC = XModemCRC.CalculateCRC(data[i], currentCRC);
                              if(payloadLength > 0)
                              {
                                   payload = new byte[payloadLength];
                                   payloadPosition = 0;
                                   currentState = ProcessingState.PROCESSING_PAYLOAD;
                              }
                              else //payloadLength == 0
                              {
                                   payload = null;
                                   currentState = ProcessingState.WAITING_FOR_CRC_BYTE_0;
                              }
                              break;
                         case ProcessingState.PROCESSING_PAYLOAD:
                              payload[payloadPosition++] = data[i];
                              currentCRC = XModemCRC.CalculateCRC(data[i], currentCRC);
                              if(payloadPosition >= payloadLength)
                              {
                                   currentState = ProcessingState.WAITING_FOR_CRC_BYTE_0;
                              }
                              break;
                         case ProcessingState.WAITING_FOR_CRC_BYTE_0:
                              CRC_BYTE_0 = data[i];
                              currentState = ProcessingState.WAITING_FOR_CRC_BYTE_1;
                              break;
                         case ProcessingState.WAITING_FOR_CRC_BYTE_1:
                              CRC_BYTE_1 = data[i];

                              dataCrcHighByte = (byte)(currentCRC >> 8);
                              dataCrcLowByte = (byte)(currentCRC & 0x00FF);

                              if((dataCrcHighByte == CRC_BYTE_0) && (dataCrcLowByte == CRC_BYTE_1))
                              {
                                   owner.LogData(new Message(majorSoftwareVersion, minorSoftwareVersion, messageIdHighByte, messageIdLowByte, payload));
                              }
                              else //Failed CRC Check
                              {
                                   crcCheckFails++;
                              }

                              currentState = ProcessingState.WAITING_FOR_START_OF_HEADER;
                              break;
                         default:
                              MessageBox.Show("Unexpected Default Case in Process Data");
                              break;
                    }
               }
          }
          /*
           *         private void UpdateAndDisplay()
        {
            String str = "";
            str = "Command Code - " + Convert.ToString(commandCode, 16).PadLeft(2, '0').ToUpper() + "     ";
            str += "Battery Number - " + Convert.ToString(payload[0], 16).PadLeft(2, '0').ToUpper() + "     ";
            //str += "Request Number - " + cmbRequestedItem.SelectedItem.ToString() + "     ";
            str += "Data - ";
            for (int i = 1; i < payload.Length; i++)
            {
                if (item >= 0x22 && item <= 0x25)
                {
                    if (i == 1)
                        continue;
                    str += char.ConvertFromUtf32(payload[i]);
                }
                else
                {
                    str += Convert.ToString(payload[i], 16).PadLeft(2, '0').ToUpper() + " ";
                }
            }
            lstDisplay.Items.Add(str);
            lstDisplay.SelectedIndex = numberOfEntries;
            numberOfEntries++;
        }
        private bool[] ByteToBits(byte b)
        {
            bool[] bit = new bool[8];
            bit[0] = (1 == (0x01 & b)) ? true : false;  //00000001 LSB
            bit[1] = (2 == (0x02 & b)) ? true : false;  //00000010
            bit[2] = (4 == (0x04 & b)) ? true : false;  //00000100
            bit[3] = (8 == (0x08 & b)) ? true : false;  //00001000
            bit[4] = (16 == (0x10 & b)) ? true : false; //00010000
            bit[5] = (32 == (0x20 & b)) ? true : false; //00100000
            bit[6] = (64 == (0x40 & b)) ? true : false; //01000000
            bit[7] = (128 == (0x80 & b)) ? true : false;//10000000 MSB

            return bit;
        }
        private bool[] ByteToBits(byte[] b)
        {
            bool[] bit = new bool[b.Length * 8];
            for (int i = 0; i < b.Length; i++)
            {
                bit[0 + (8 * i)] = (1 == (0x01 & b[i])) ? true : false;  //00000001 LSB
                bit[1 + (8 * i)] = (2 == (0x02 & b[i])) ? true : false;  //00000010
                bit[2 + (8 * i)] = (4 == (0x04 & b[i])) ? true : false;  //00000100
                bit[3 + (8 * i)] = (8 == (0x08 & b[i])) ? true : false;  //00001000
                bit[4 + (8 * i)] = (16 == (0x10 & b[i])) ? true : false; //00010000
                bit[5 + (8 * i)] = (32 == (0x20 & b[i])) ? true : false; //00100000
                bit[6 + (8 * i)] = (64 == (0x40 & b[i])) ? true : false; //01000000
                bit[7 + (8 * i)] = (128 == (0x80 & b[i])) ? true : false;//10000000 MSB
            }
            return bit;
        }
        private bool[] ByteToBits(byte MSB, byte LSB)
        {
            bool[] bit = new bool[16];
            //byte 1
            bit[0] = (1 == (0x01 & LSB)) ? true : false;  //00000001 LSB
            bit[1] = (2 == (0x02 & LSB)) ? true : false;  //00000010
            bit[2] = (4 == (0x04 & LSB)) ? true : false;  //00000100
            bit[3] = (8 == (0x08 & LSB)) ? true : false;  //00001000
            bit[4] = (16 == (0x10 & LSB)) ? true : false; //00010000
            bit[5] = (32 == (0x20 & LSB)) ? true : false; //00100000
            bit[6] = (64 == (0x40 & LSB)) ? true : false; //01000000
            bit[7] = (128 == (0x80 & LSB)) ? true : false;//10000000 MSB
            //byte 2
            bit[8] = (1 == (0x01 & MSB)) ? true : false;  //00000001 LSB
            bit[9] = (2 == (0x02 & MSB)) ? true : false;  //00000010
            bit[10] = (4 == (0x04 & MSB)) ? true : false;  //00000100
            bit[11] = (8 == (0x08 & MSB)) ? true : false;  //00001000
            bit[12] = (16 == (0x10 & MSB)) ? true : false; //00010000
            bit[13] = (32 == (0x20 & MSB)) ? true : false; //00100000
            bit[14] = (64 == (0x40 & MSB)) ? true : false; //01000000
            bit[15] = (128 == (0x80 & MSB)) ? true : false;//10000000 MSB

            return bit;
        }
        private bool[] ByteToBits(byte MSB, byte middleByte, byte LSB)
        {
            bool[] bit = new bool[24];
            //byte 1
            bit[0] = (1 == (0x01 & LSB)) ? true : false;  //00000001 LSB
            bit[1] = (2 == (0x02 & LSB)) ? true : false;  //00000010
            bit[2] = (4 == (0x04 & LSB)) ? true : false;  //00000100
            bit[3] = (8 == (0x08 & LSB)) ? true : false;  //00001000
            bit[4] = (16 == (0x10 & LSB)) ? true : false; //00010000
            bit[5] = (32 == (0x20 & LSB)) ? true : false; //00100000
            bit[6] = (64 == (0x40 & LSB)) ? true : false; //01000000
            bit[7] = (128 == (0x80 & LSB)) ? true : false;//10000000 MSB
            //byte 2
            bit[8] = (1 == (0x01 & middleByte)) ? true : false;   //00000001 LSB
            bit[9] = (2 == (0x02 & middleByte)) ? true : false;   //00000010
            bit[10] = (4 == (0x04 & middleByte)) ? true : false;  //00000100
            bit[11] = (8 == (0x08 & middleByte)) ? true : false;  //00001000
            bit[12] = (16 == (0x10 & middleByte)) ? true : false; //00010000
            bit[13] = (32 == (0x20 & middleByte)) ? true : false; //00100000
            bit[14] = (64 == (0x40 & middleByte)) ? true : false; //01000000
            bit[15] = (128 == (0x80 & middleByte)) ? true : false;//10000000 MSB
            //byte 3
            bit[16] = (1 == (0x01 & MSB)) ? true : false;  //00000001 LSB
            bit[17] = (2 == (0x02 & MSB)) ? true : false;  //00000010
            bit[18] = (4 == (0x04 & MSB)) ? true : false;  //00000100
            bit[19] = (8 == (0x08 & MSB)) ? true : false;  //00001000
            bit[20] = (16 == (0x10 & MSB)) ? true : false; //00010000
            bit[21] = (32 == (0x20 & MSB)) ? true : false; //00100000
            bit[22] = (64 == (0x40 & MSB)) ? true : false; //01000000
            bit[23] = (128 == (0x80 & MSB)) ? true : false;//10000000 MSB

            return bit;
        }
        private int combineBytes(byte b1, byte b2)
        {//b1 is MSB
            int combined = b1 << 8 | b2;
            return combined;
        }
        private int combineBytes(byte b1, byte b2, byte b3)
        {//b1 is MSB
            int combined = b1 << 8 | b2;
            combined = combined << 8 | b3;
            return combined;
        }
        private void CheckForData()
        {
            try
            {
                //load all serial port data to buffer
                int numberOfBytes = receivingSerialPort.BytesToRead;

                if (numberOfBytes > 0)
                {
                    inBuffer = new byte[numberOfBytes];
                    receivingSerialPort.Read(inBuffer, 0, numberOfBytes);

                    ringBuffer.putBytes(inBuffer);
                }
            }
            catch (Exception)
            {
                Application.Exit();
            }
        }
           */
     }
}
