using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace MPacApplication
{

     public partial class MainForm : Form
     {
          public static ushort SOFTWARE_VERSION = 0x0100;

          private List<MessageFormat> localMessages = new List<MessageFormat>();
          private List<MessageFormat> companyMessages = new List<MessageFormat>();

          public const int MAX_BAUD_RATE = 1000000;
          public const int DEFAULT_BAUD_RATE = 9600;
          public const Parity DEFAULT_PARITY = Parity.None;
          public const int DEFAULT_DATA_BITS = 8;
          public const StopBits DEFAULT_STOP_BITS = StopBits.One;
          public const Handshake DEFAULT_HANDSHAKE = Handshake.None;
          public const bool DEFAULT_RTS = false;
          public const bool DEFAULT_DTR = false;

          private ComPortConfigForm comPortConfigForm;
          private AddMessageForm AddMessageForm;
          private AddMessageForm AddCompanyForm;

          private SerialPort listeningPort;
          private bool comPortClosed;

          private List<String> availablePortNames;

          private DataProcessor dataProcessor;
          private int numberOfStatusEntries;
          private int numberOfEntries;
          private int numberOfLinesOfBytesEntries;
          private int totalNumberOfMessages;

          private bool initialized;

          private bool isAdministrator = false;
          public bool IsAdministrator
          {
              get
              {
                  return isAdministrator;
              }
          }
          private String comPortName;
          public String ComPortName
          {
               get
               {
                    return comPortName;
               }
          }
          private int baudRate;
          public int BaudRate
          {
               get
               {
                    return baudRate;
               }
          }
          private Parity parity;
          public Parity ParityValue
          {
               get
               {
                    return parity;
               }
          }
          private int dataBits;
          public int DataBits
          {
               get
               {
                    return dataBits;
               }
          }
          private StopBits stopBits;
          public StopBits StopBitsvalue
          {
               get
               {
                    return stopBits;
               }
          }
          private Handshake handshake;
          public Handshake Handshake
          {
               get
               {
                    return handshake;
               }
          }
          private bool dtrEnable;
          public bool DtrEnable
          {
               get
               {
                    return dtrEnable;
               }
          }
          private bool rtsEnable;
          public bool RtsEnable
          {
               get
               {
                    return rtsEnable;
               }
          }

          public MainForm()
          {
               InitializeComponent();

               comPortConfigForm = null;
               dataProcessor = new DataProcessor(this);
               numberOfStatusEntries = 0;
               numberOfEntries = 0;
               numberOfLinesOfBytesEntries = 0;
               totalNumberOfMessages = 0;
               lstMessageSummary.Sorted = true;
               cmbViews.SelectedIndex = 0;

               PrintStatusMessage("Start Initialization");
               initialized = false;

               availablePortNames = new List<String>();
               String[] portNames = SerialPort.GetPortNames();
               foreach (String name in portNames)
               {
                    if (name.StartsWith("COM"))
                    {
                         PrintStatusMessage("Add Com Port " + name);
                         availablePortNames.Add(name);
                    }
               }
               availablePortNames.Sort();

               OpenComPort(availablePortNames.ElementAt<String>(0), DEFAULT_BAUD_RATE, DEFAULT_PARITY, DEFAULT_DATA_BITS, DEFAULT_STOP_BITS, DEFAULT_HANDSHAKE, DEFAULT_RTS, DEFAULT_DTR);

               PrintStatusMessage("Remaining List");
               foreach (String name in availablePortNames)
               {
                    PrintStatusMessage(name);
               }

               initialized = true;

               PrintStatusMessage("End Initialization");

               PrintStatusMessage("Start Configuration");
               Configuration config = new Configuration();

               string[] connections = config.Read();
              PrintStatusMessage("Configuration read complete. Found " + connections.Length + " connection(s).");

              if (!config.IsAdministrator)
                  btnAddCompanyMessage.Hide();
              else
                  isAdministrator = true;

               PrintStatusMessage("End Configuration");
               PrintStatusMessage("Start SQL Import");

               List<MessageFormat> messages = new List<MessageFormat>();
               foreach (string connection in connections)
                   messages.AddRange(new SqlMessageConnection(connection).GetMessageList());

               foreach (MessageFormat m in messages)
                   AddMessageFormat(m, MessageType.Company);

              PrintStatusMessage("End SQL Import. " + companyMessages.Count + " custom messages loaded.");

              /*
              //Format testing. form is the format string, b is the random data array.
              //Prints raw data and formatted data to console.
              string form = "* 2 h";
              byte[] b = new byte[13];
              (new Random()).NextBytes(b);

              string s = "";
              foreach (byte a in b)
                  s += a.ToString() + " ";
              Console.WriteLine(s);
              Console.WriteLine(FormatParser.Parse(form, b));
              */
             
              //byte[] b = {0,0,0,0,1};
              //Console.WriteLine(Format.AsDecimal(b)); 
          }

          private void SetSerialPortConfig(String comPortName, int baudRate, Parity parity, int dataBits, StopBits stopBits, Handshake handshake, bool rtsEnable, bool dtrEnable)
          {
               PrintStatusMessage("Set Serial Port Config " + comPortName + " " + baudRate + " " + parity + " " + dataBits + " " + stopBits);

               CloseComPort();

               this.comPortName = comPortName;
               this.baudRate = baudRate;
               this.parity = parity;
               this.dataBits = dataBits;
               this.stopBits = stopBits;
               this.handshake = handshake;
               this.rtsEnable = rtsEnable;
               this.dtrEnable = dtrEnable;

               if (listeningPort == null)
               {
                    PrintStatusMessage("Create new SerialPort " + this.comPortName + " " + this.baudRate + " " + this.parity + " " + this.dataBits + " " + this.stopBits);
                    listeningPort = new SerialPort(this.comPortName, this.baudRate, this.parity, this.dataBits, this.stopBits);
                    listeningPort.Handshake = this.handshake;
                    listeningPort.RtsEnable = this.rtsEnable;
                    listeningPort.DtrEnable = this.dtrEnable;
               }
               else
               {
                    listeningPort.PortName = this.comPortName;
                    listeningPort.BaudRate = this.baudRate;
                    listeningPort.Parity = this.parity;
                    listeningPort.DataBits = this.dataBits;
                    listeningPort.StopBits = this.stopBits;
                    listeningPort.Handshake = this.handshake;
                    listeningPort.RtsEnable = this.rtsEnable;
                    listeningPort.DtrEnable = this.dtrEnable;
               }

               lblvPortName.Text = this.comPortName;
               lblvBaudRate.Text = this.baudRate.ToString();
               lblvParity.Text = this.parity.ToString();
               lblvDataBits.Text = this.dataBits.ToString();
               lblvStopBits.Text = this.stopBits.ToString();
               lblvHandshake.Text = this.handshake.ToString();
               lblvRTSEnable.Text = this.rtsEnable.ToString();
               lblvDTREnable.Text = this.dtrEnable.ToString();

               switch (stopBits)
               {
                    case StopBits.One:
                         lblvStopBits.Text = "1";
                         break;
                    case StopBits.OnePointFive:
                         lblvStopBits.Text = "1.5";
                         break;
                    case StopBits.Two:
                         lblvStopBits.Text = "2";
                         break;
                    case StopBits.None:
                         lblvStopBits.Text = "None";
                         break;
                    default:
                         lblvStopBits.Text = "None";
                         break;
               }
          }

          public void OpenComPort(String comPortName, int baudRate, Parity parity, int dataBits, StopBits stopBits, Handshake handshake, bool rtsEnable, bool dtrEnable)
          {
               SetSerialPortConfig(comPortName, baudRate, parity, dataBits, stopBits, handshake, rtsEnable, dtrEnable);
               OpenComPort();
          }

          private void OpenComPort()
          {
               try
               {
                    PrintStatusMessage("Opening Serial Port " + this.comPortName);
                    tmrCheckForData.Enabled = true;
                    this.listeningPort.Open();
               }
               catch (Exception)
               {
                    PrintStatusMessage("Unable to open serial port " + this.comPortName);
                    PrintStatusMessage("Removing " + this.comPortName + " from available port list");
                    availablePortNames.Remove(this.comPortName);
                    if(initialized)
                         MessageBox.Show(this.comPortName + " does not seem to be a valid port, selecting port " + availablePortNames.ElementAt<String>(0));
                    OpenComPort(availablePortNames.ElementAt<String>(0), this.baudRate, this.parity, this.dataBits, this.stopBits, this.handshake, this.rtsEnable, this.dtrEnable);
               }

               comPortClosed = false;
               btnOpenAndClose.BackColor = Color.Green;
               btnOpenAndClose.Text = "Opened";
          }

          private void CloseComPort()
          {
               if (listeningPort != null && listeningPort.IsOpen)
               {
                    PrintStatusMessage("Closing serial port");
                    listeningPort.Close();
                    tmrCheckForData.Enabled = false;
               }

               btnOpenAndClose.BackColor = Color.Red;
               btnOpenAndClose.Text = "Closed";
               comPortClosed = true;
          }

          //TODO - these four functions could be wrapped up into a "CanThisMessageBeAdded(MessageFormat messageFormat) type of function
          public int GetMessagesCount(MessageType type)
          {
               if (type == MessageType.Company)
                    return companyMessages.Count;
               else
                    return localMessages.Count;
          }

          public byte GetMessageHighByte(int index, MessageType type)
          {
               if (type == MessageType.Company)
                    return companyMessages[index].id_high;
               else
                    return localMessages[index].id_high;
          }

          public byte GetMessageLowByte(int index, MessageType type)
          {
               if (type == MessageType.Company)
                    return companyMessages[index].id_low;
               else
                    return localMessages[index].id_low;
          }

          public string GetMessageName(int index, MessageType type)
          {
               if (type == MessageType.Company)
                    return companyMessages[index].name;
               else
                    return localMessages[index].name;
          }

          private MessageFormat GetMessageFormat(byte highByte, byte lowByte)
          {
               foreach (MessageFormat mf in localMessages)
               {
                    if (mf.id_high == highByte && mf.id_low == lowByte)
                    {
                         return mf;
                    }
               }

               foreach (MessageFormat mf in companyMessages)
               {
                    if (mf.id_high == highByte && mf.id_low == lowByte)
                    {
                         return mf;
                    }
               }

               return null;
          }

          public void LogData(Message completedMessage)
          {
               String message;
               
               MessageFormat format = GetMessageFormat(completedMessage.id_high, completedMessage.id_low);

               if (format == null)
               {
                    message = completedMessage.ToString();
               }
               else
               {
                    message = completedMessage.GetTimestamp() + format.name;
                    if (completedMessage.data == null || completedMessage.data.Length == format.length)
                    {
                         String formattedString = FormatParser.Parse(format.format, completedMessage.data); // if data length == 0, this can still return string via external program

                         if (formattedString != null && formattedString.Length != 0)
                         {
                              message += ":  " + formattedString;
                         }
                    }
                    else
                    {
                         message += ":  Message Format Does Not Match Data Length";
                    }
               }

               lstDisplayWindow.Items.Add(message);
               lstDisplayWindow.SelectedIndex = numberOfEntries++;
          }

          public void RecordTrash(byte[] trashBytes)
          {
               //TODO - this may be used to record all bytes not in messages
          }

          public void PrintComPortMessage(String message)
          {
               lstComPortDisplay.Items.Add(message);
               lstComPortDisplay.SelectedIndex = numberOfLinesOfBytesEntries;
               numberOfLinesOfBytesEntries++;
          }

          public void PrintStatusMessage(String message)
          {
               lstStatusDisplay.Items.Add(message);
               lstStatusDisplay.SelectedIndex = numberOfStatusEntries;
               numberOfStatusEntries++;
          }

          public void AddMessageFormat(MessageFormat messageFormat, MessageType type)
          {
               if (type == MessageType.Company)
                    companyMessages.Add(messageFormat);
               else
                    localMessages.Add(messageFormat);

               lstMessageSummary.Items.Add(messageFormat);
               lstMessageSummary.SelectedIndex = totalNumberOfMessages;
               cmbViews.Items.Add(messageFormat.name);
               totalNumberOfMessages++;
          }

          public bool RemoveMessageFormat(MessageFormat messageFormat)
          {
              bool flag = false;

              if (localMessages.Remove(messageFormat))
                  flag = true;
              else if (IsAdministrator)
                  if (companyMessages.Remove(messageFormat))
                      flag = true;

              if (flag)
              {
                  lstMessageSummary.Items.Remove(messageFormat);
                  totalNumberOfMessages--;
              }


              return flag;
          }
          public bool RemoveMessageFormat(int index)
          {
              return RemoveMessageFormat((MessageFormat)lstMessageSummary.Items[index]);
          }

          private void tmrClockRefresh_Tick(object sender, EventArgs e)
          {
               String time = String.Format("{0:MM/dd/yyyy   HH:mm:ss tt}", DateTime.Now);
               lblCurrentTime.Text = time;
          }

          private void btnConfigureComPort_Click(object sender, EventArgs e)
          {
               CloseComPort();
               try
               {
                    comPortConfigForm.Show();
               }
               catch (Exception)
               {
                    comPortConfigForm = new ComPortConfigForm(this);
                    comPortConfigForm.Show();
               }
               finally
               {
                    comPortConfigForm.SetComboBoxes(this.comPortName, this.baudRate, this.parity, this.dataBits, this.stopBits, this.handshake, this.rtsEnable, this.dtrEnable);
               }
          }

          private void tmrCheckForData_Tick(object sender, EventArgs e)
          {
               if (listeningPort == null || !listeningPort.IsOpen)
                    return;

               int numberOfBytes = listeningPort.BytesToRead;

               if (listeningPort.BytesToRead <= 0 || dataProcessor.IsBusy())
                    return;

               byte[] buffer = new byte[numberOfBytes];
               String byteString = "";

               numberOfBytes = listeningPort.Read(buffer, 0, numberOfBytes);

               if (numberOfBytes > 0)
               {
                    PrintStatusMessage("Milliseconds:" + dataProcessor.ProcessData(buffer) + "\n");
                    foreach (byte b in buffer)
                    {
                         byteString += Convert.ToString(b, 16).PadLeft(2, '0').ToUpper() + " ";
                    }
                    PrintComPortMessage(byteString);
               }
          }

          private void btnOpenAndClose_Click(object sender, EventArgs e)
          {
               if (comPortClosed)
               {
                    OpenComPort();
               }
               else
               {
                    CloseComPort();
               }
          }

          private void btnAddMessage_Click(object sender, EventArgs e)
          {
               try
               {
                    AddMessageForm.Show();
               }
               catch (Exception)
               {
                    AddMessageForm = new AddMessageForm(this, MessageType.Local);
                    AddMessageForm.Show();
               }
          }

          private void btnAddCompanyMessage_Click(object sender, EventArgs e)
          {
               try
               {
                   AddCompanyForm.Show();
               }
               catch (Exception)
               {
                    AddCompanyForm = new AddMessageForm(this, MessageType.Company);
                    AddCompanyForm.Show();
               }
          }

          private void btnSendMessageOne_Click(object sender, EventArgs e)
          {
               SendMessageToParser(txtMessageOne.Text.Trim().Split(' '));
          }

          private void btnSendMessageTwo_Click(object sender, EventArgs e)
          {
               SendMessageToParser(txtMessageTwo.Text.Trim().Split(' '));
          }

          private void btnSendMessageThree_Click(object sender, EventArgs e)
          {
               SendMessageToParser(txtMessageThree.Text.Trim().Split(' '));
          }

          private void SendMessageToParser(String[] parts)
          {
               if (parts == null)
                    return;

               byte[] message = new byte[parts.Length];

               for (int i = 0; i < parts.Length; i++)
               {
                    message[i] = (byte)int.Parse(parts[i], System.Globalization.NumberStyles.HexNumber);
               }

               dataProcessor.ProcessData(message);
          }

          private void exitToolStripMenuItem_Click(object sender, EventArgs e)
          {
              //TODO: Do we need anything else here? Ask if they want to save maybe?
              Close();
          }

          private void importToolStripMenuItem_Click(object sender, EventArgs e)
          {
              OpenFileDialog fileDialog = new OpenFileDialog();
              fileDialog.Filter = "CSV Files|*.csv|All Files|*.*";
              fileDialog.InitialDirectory = "%USERPROFILE%";

              if (localMessages.Count > 0)
              {
                  MessageBox.Show("Please remove all local messages before importing.");
                  return;
              }

              if (fileDialog.ShowDialog() == DialogResult.OK)
              {
                  List<MessageFormat> messages = new List<MessageFormat>();
                  messages.AddRange(localMessages);

                  foreach (MessageFormat m in messages)
                      RemoveMessageFormat(m);

                  messages = new List<MessageFormat>();
                  messages = Import.ToMessages(fileDialog.FileName);
                  foreach (MessageFormat m in messages)
                      AddMessageFormat(m, MessageType.Local);
              }
          }

          private void exportToolStripMenuItem_Click(object sender, EventArgs e)
          {
              SaveFileDialog fileDialog = new SaveFileDialog();
              fileDialog.Filter = "CSV Files|*.csv|All Files|*.*";
              fileDialog.InitialDirectory = "%USERPROFILE%";
              

              if (fileDialog.ShowDialog() == DialogResult.OK)
              {
                  Export.FromMessages(localMessages, fileDialog.FileName);
              }
          }

          private void btnRefresh_Click(object sender, EventArgs e)
          {
              btnRefresh.Enabled = false; //prevent spam

              Configuration config = new Configuration();

              string[] connections = config.Read();

              List<MessageFormat> messages = new List<MessageFormat>();

              messages.AddRange(companyMessages);

              foreach (MessageFormat m in messages)
                  RemoveMessageFormat(m);
              
              messages = new List<MessageFormat>();

              foreach (string connection in connections)
                  messages.AddRange(new SqlMessageConnection(connection).GetMessageList());
              foreach (MessageFormat m in messages)
                  AddMessageFormat(m, MessageType.Company);

              btnRefresh.Enabled = true;
          }

          private void btnRemove_Click(object sender, EventArgs e)
          {
              int index = lstMessageSummary.SelectedIndex;

              if (index < 0)
                  return;


              MessageFormat mf = (MessageFormat)lstMessageSummary.Items[index];

              if (mf.id_high >= 0x80)
              {
                  MessageBox.Show("You cannot remove company messages.");
                  return;
              }
              RemoveMessageFormat(index);
              
          }

          private void btnSave_Click(object sender, EventArgs e)
          {
              SaveFileDialog fileDialog = new SaveFileDialog();
              string textOut = "";
              fileDialog.Filter = "TXT Files|*.txt|All Files|*.*";
              fileDialog.InitialDirectory = "%USERPROFILE%";


              
              if (fileDialog.ShowDialog() == DialogResult.OK)
              {
                  foreach (string listItems in lstDisplayWindow.Items)
                  {
                      textOut = textOut + listItems + Environment.NewLine;
                  }
                  System.IO.File.WriteAllText(fileDialog.FileName, textOut);
              }
          }
     }
}