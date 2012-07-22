using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPacApplication
{
     class DataProcessor
     {
          private bool busy;

          private const byte START_OF_HEADER = 0xA5;
          private const byte SYSTEM_ID = 0x00;
          private const byte SUBSYSTEM_ID = 0x00;
          private const byte NODE_ID = 0x00;
          private const byte COMPONENT_ID = 0x00;
          private const byte MAJOR_SOFTWARE_VERSION = 0x01;
          private const byte MINOR_SOFTWARE_VERSION = 0x00;

          private DateTime timestamp;
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

               busy = false;

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
          public bool IsBusy()
          {
               return busy;
          }
          public int ProcessData(byte[] data)
          {
               busy = true;
               //TODO - take these out and turn functions back into void function
               DateTime timestamp1 = DateTime.Now;
               DateTime timestamp2;
               byte dataCrcHighByte, dataCrcLowByte;
               for (int i = 0; i < data.Length; i++)
               {
                    switch (currentState)
                    {
                         case ProcessingState.WAITING_FOR_START_OF_HEADER:
                              if (data[i] == START_OF_HEADER)
                              {
                                   timestamp = DateTime.Now;
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
                                   owner.LogData(new Message(majorSoftwareVersion, minorSoftwareVersion, messageIdHighByte, messageIdLowByte, payload, timestamp));
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
               //TODO - take timestamp comparision out
               timestamp2 = DateTime.Now;
               int time;

               if(timestamp1.Millisecond > timestamp2.Millisecond)
               {
                    time = timestamp2.Millisecond + (1000 - timestamp1.Millisecond);
               }
               else
               {
                    time = timestamp2.Millisecond - timestamp1.Millisecond;
               }
               
               busy = false;

               return time;
          }
     }
}
