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
          private const String ALL_MESSAGES = " All";

          private ComPortConfigForm comPortConfigForm;
          private AddMessageForm addLocalMessageForm;
          private AddMessageForm addCompanyMessageForm;

          private SerialPort listeningPort;
          private bool comPortClosed;

          private List<String> availableComPortNames;

          private DataProcessor dataProcessor;
          private bool initialized;
          private bool listBoxOneSelected;
          private bool stopReceiving;

          private List<String> recordedMessages;

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

               lstDisplayWindowTwo.Visible = false;
               listBoxOneSelected = true;
               comPortConfigForm = null;
               dataProcessor = new DataProcessor(this);
               lstMessageSummary.Sorted = true;
               cmbViews.Items.Add(ALL_MESSAGES);
               cmbViews.Sorted = true;
               cmbViews.SelectedIndex = 0;
               recordedMessages = new List<String>();

               initialized = false;
               stopReceiving = false;
               this.comPortName = "--";
               this.baudRate = DEFAULT_BAUD_RATE;
               this.parity = DEFAULT_PARITY;
               this.dataBits = DEFAULT_DATA_BITS;
               this.stopBits = DEFAULT_STOP_BITS;
               this.handshake = DEFAULT_HANDSHAKE;
               this.rtsEnable = DEFAULT_RTS;
               this.dtrEnable = DEFAULT_DTR;

               lblvPortName.Text = this.comPortName;
               lblvBaudRate.Text = this.baudRate.ToString();
               lblvParity.Text = this.parity.ToString();
               lblvDataBits.Text = this.dataBits.ToString();
               lblvStopBits.Text = this.stopBits.ToString();
               lblvHandshake.Text = this.handshake.ToString();
               lblvRTSEnable.Text = this.rtsEnable.ToString();
               lblvDTREnable.Text = this.dtrEnable.ToString();

               btnOpenAndClose.BackColor = Color.Red;
               btnOpenAndClose.Text = "Closed";
               comPortClosed = true;

               availableComPortNames = FindAvailableComPorts();

               if(availableComPortNames.Count > 0)
                    OpenComPort(availableComPortNames.ElementAt<String>(0), DEFAULT_BAUD_RATE, DEFAULT_PARITY, DEFAULT_DATA_BITS, DEFAULT_STOP_BITS, DEFAULT_HANDSHAKE, DEFAULT_RTS, DEFAULT_DTR);
               
               Configuration config = new Configuration();

               string[] connections = config.Read();

              if (!config.IsAdministrator)
                  btnAddCompanyMessage.Enabled = false;
              else
                  isAdministrator = true;

               string errors = "";
               List<MessageFormat> messages = new List<MessageFormat>();
               foreach (string connection in connections)
               {
                   SqlMessageConnection sql = new SqlMessageConnection(connection);

                   if (sql.isConnected())
                       messages.AddRange(sql.GetMessageList());
                   else
                   {
                       try
                       {
                           errors += connection.Split(';')[0] + ';' + connection.Split(';')[1] + ';' + connection.Split(';')[2] + ";Table=" + connection.Split(';')[4] + '\n';
                       }
                       catch { }
                   }
               }

               if (errors != "")
                   MessageBox.Show("The following SQL connections could not be opened:\n\n" + errors);

               foreach (MessageFormat m in messages)
                   AddMessageFormat(m, MessageType.Company);

              initialized = true;
          }

          private List<String> FindAvailableComPorts()
          {
               String[] allComPorts = SerialPort.GetPortNames();
               List<String>  availableComPorts = new List<String>();
               foreach (String name in allComPorts)
               {
                    if (name.StartsWith("COM") && OpenComPortCheck(name))
                    {
                         availableComPorts.Add(name);
                    }
               }
               availableComPorts.Sort();

               return availableComPorts;
          }
          private bool OpenComPortCheck(String comPortName)
          {
               SerialPort testingPort = new SerialPort(comPortName);
               try
               {
                    testingPort.Open();
                    testingPort.Close();
               }
               catch (Exception)
               {
                    return false;
               }

               return true;
          }

          private void SetSerialPortConfig(String comPortName, int baudRate, Parity parity, int dataBits, StopBits stopBits, Handshake handshake, bool rtsEnable, bool dtrEnable)
          {
               try
               {
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
               catch (Exception ex)
               {
                    ex.ToString();
                    Application.Exit();
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
                    tmrCheckForData.Enabled = true;
                    this.listeningPort.Open();
               }
               catch (Exception)
               {
                    availableComPortNames.Remove(this.comPortName);
                    try
                    {
                         if (initialized)
                              MessageBox.Show(this.comPortName + " does not seem to be a valid port, selecting port " + availableComPortNames.ElementAt<String>(0));
                         OpenComPort(availableComPortNames.ElementAt<String>(0), this.baudRate, this.parity, this.dataBits, this.stopBits, this.handshake, this.rtsEnable, this.dtrEnable);
                    }
                    catch (Exception)
                    {
                         MessageBox.Show("Unable to open com port and no other com ports available, closing application");
                         Application.Exit();
                    }
               }

               comPortClosed = false;
               btnOpenAndClose.BackColor = Color.Green;
               btnOpenAndClose.Text = "Opened";
          }

          private void CloseComPort()
          {
               if (listeningPort != null && listeningPort.IsOpen)
               {
                    try
                    {
                         listeningPort.Close();
                    }
                    catch (Exception)
                    {
                         //do nothing
                    }
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
                    return companyMessages[index].IdHigh;
               else
                    return localMessages[index].IdHigh;
          }

          public byte GetMessageLowByte(int index, MessageType type)
          {
               if (type == MessageType.Company)
                    return companyMessages[index].IdLow;
               else
                    return localMessages[index].IdLow;
          }

          public string GetMessageName(int index, MessageType type)
          {
               if (type == MessageType.Company)
                    return companyMessages[index].Name;
               else
                    return localMessages[index].Name;
          }
          public MessageFormat GetMessageFormat(int index)
          {
              if (index < 0 || index >= lstMessageSummary.Items.Count)
                  return null;
              else
                  return (MessageFormat)lstMessageSummary.Items[index];
          }
          private MessageFormat GetMessageFormat(byte highByte, byte lowByte)
          {
               foreach (MessageFormat mf in localMessages)
               {
                    if (mf.IdHigh == highByte && mf.IdLow == lowByte)
                    {
                         return mf;
                    }
               }

               foreach (MessageFormat mf in companyMessages)
               {
                    if (mf.IdHigh == highByte && mf.IdLow == lowByte)
                    {
                         return mf;
                    }
               }

               return null;
          }

          public void LogData(Message completedMessage)
          {
               String message;
               
               MessageFormat format = GetMessageFormat(completedMessage.IdHigh, completedMessage.IdLow);

               if (format == null)
               {
                    message = completedMessage.ToString();
               }
               else
               {
                    message = completedMessage.GetTimestamp() + format.Name;
                    if (completedMessage.Data == null || completedMessage.Data.Length == format.Length)
                    {
                         String formattedString = FormatParser.Parse(format.FormatString, completedMessage.Data); // if data length == 0, this can still return string via external program

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

               recordedMessages.Add(message);

               if (cmbViews.SelectedItem.ToString().Equals(ALL_MESSAGES) || message.Contains(cmbViews.SelectedItem.ToString()))
               {
                    if (listBoxOneSelected)
                    {
                         lstDisplayWindowOne.Items.Add(message);
                         lstDisplayWindowOne.SelectedIndex = lstDisplayWindowOne.Items.Count - 1;
                    }
                    else
                    {
                         lstDisplayWindowTwo.Items.Add(message);
                         lstDisplayWindowTwo.SelectedIndex = lstDisplayWindowTwo.Items.Count - 1;
                    }
               }
          }

          public void AddMessageFormat(MessageFormat messageFormat, MessageType type)
          {
               if (type == MessageType.Company)
                    companyMessages.Add(messageFormat);
               else
                    localMessages.Add(messageFormat);

               lstMessageSummary.Items.Add(messageFormat);
               lstMessageSummary.SelectedIndex = lstMessageSummary.Items.Count-1;
               cmbViews.Items.Add(messageFormat.Name);
               //bool allSelected = cmbViews.SelectedItem.ToString().Equals(ALL_MESSAGES);
               //cmbViews.Items.Remove(ALL_MESSAGES);
               //cmbViews.Items.Insert(0,ALL_MESSAGES);
               //if (allSelected)
               //     cmbViews.SelectedItem = ALL_MESSAGES;
          }

          public bool RemoveMessageFormat(MessageFormat messageFormat)
          {
               bool flag = false;

               if (cmbViews.SelectedItem.ToString().Equals(messageFormat.Name))
               {
                    cmbViews.SelectedItem = ALL_MESSAGES;
               }

               if (localMessages.Remove(messageFormat))
               {
                    flag = true;
               }
               else if (IsAdministrator)
               {
                    if (companyMessages.Remove(messageFormat))
                         flag = true;
               }

               if (flag)
               {
                    lstMessageSummary.Items.Remove(messageFormat);
                    cmbViews.Items.Remove(messageFormat.Name);
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
               if (comPortConfigForm != null && comPortConfigForm.Visible)
                    return;

               CloseComPort();
               availableComPortNames = FindAvailableComPorts();

               try
               {
                    comPortConfigForm.SetComboBoxes(this.availableComPortNames, this.comPortName, this.baudRate, this.parity, this.dataBits, this.stopBits, this.handshake, this.rtsEnable, this.dtrEnable);
                    comPortConfigForm.ShowDialog();
               }
               catch (Exception)
               {
                    comPortConfigForm = new ComPortConfigForm(this);
                    comPortConfigForm.SetComboBoxes(this.availableComPortNames, this.comPortName, this.baudRate, this.parity, this.dataBits, this.stopBits, this.handshake, this.rtsEnable, this.dtrEnable);
                    comPortConfigForm.ShowDialog();
               }
          }

          private void tmrCheckForData_Tick(object sender, EventArgs e)
          {
               try
               {
                    if (listeningPort == null || !listeningPort.IsOpen || stopReceiving)
                         return;

                    int numberOfBytes = listeningPort.BytesToRead;

                    if (listeningPort.BytesToRead <= 0 || dataProcessor.IsBusy())
                         return;

                    byte[] buffer = new byte[numberOfBytes];

                    numberOfBytes = listeningPort.Read(buffer, 0, numberOfBytes);

                    if (numberOfBytes > 0)
                    {
                         dataProcessor.ProcessData(buffer);
                    }
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.ToString());
                    Application.Exit();
               }
          }

          private void cmbViews_SelectedIndexChanged(object sender, EventArgs e)
          {
               if (!initialized)
                    return;

               stopReceiving = true;

               if (listBoxOneSelected)
               {
                    lstDisplayWindowTwo.Items.Clear();

                    if (cmbViews.SelectedItem.ToString().Equals(ALL_MESSAGES))//ALL_MESSAGES was selected
                    {
                         foreach (String str in recordedMessages)
                         {
                              lstDisplayWindowTwo.Items.Add(str);
                         }
                    }
                    else
                    {
                         foreach (String str in recordedMessages)
                         {
                              if (str.Contains(cmbViews.SelectedItem.ToString()))
                                   lstDisplayWindowTwo.Items.Add(str);
                         }
                    }
                    if (lstDisplayWindowTwo.Items.Count > 0)
                         lstDisplayWindowTwo.SelectedIndex = lstDisplayWindowTwo.Items.Count - 1;

                    lstDisplayWindowTwo.Visible = true;
                    lstDisplayWindowOne.Visible = false;
                    listBoxOneSelected = false;
               }
               else
               {
                    lstDisplayWindowOne.Items.Clear();

                    if (cmbViews.SelectedItem.ToString().Equals(ALL_MESSAGES))//ALL_MESSAGES was selected
                    {
                         foreach (String str in recordedMessages)
                         {
                              lstDisplayWindowOne.Items.Add(str);
                         }
                    }
                    else
                    {
                         foreach (String str in recordedMessages)
                         {
                              if (str.Contains(cmbViews.SelectedItem.ToString()))
                                   lstDisplayWindowOne.Items.Add(str);
                         }
                    }
                    if (lstDisplayWindowOne.Items.Count > 0)
                         lstDisplayWindowOne.SelectedIndex = lstDisplayWindowOne.Items.Count - 1;

                    lstDisplayWindowOne.Visible = true;
                    lstDisplayWindowTwo.Visible = false;
                    listBoxOneSelected = true;
               }
               
               stopReceiving = false;
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
                   addLocalMessageForm = new AddMessageForm(this, MessageType.Local, -1);
                   addLocalMessageForm.ShowDialog();
          }

          private void btnAddCompanyMessage_Click(object sender, EventArgs e)
          {
                    addCompanyMessageForm = new AddMessageForm(this, MessageType.Company, -1);
                    addCompanyMessageForm.ShowDialog();
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
                  string errors = "";

                  messages = new List<MessageFormat>();
                  messages = Import.ToMessages(fileDialog.FileName);

                  List<string> companyNames = new List<string>();
                  List<ushort> ids = new List<ushort>();


                  foreach (MessageFormat m in companyMessages)
                      companyNames.Add(m.Name);

                  foreach (MessageFormat m in messages)
                      if (!companyNames.Contains(m.Name) && !ids.Contains((ushort)(m.IdHigh << 8 | m.IdLow)))
                      {
                          AddMessageFormat(m, MessageType.Local);
                          companyNames.Add(m.Name); //prevent name conflicts within the file
                          ids.Add((ushort)(m.IdHigh << 8 | m.IdLow)); //prevent id conflicts within the file
                      }
                      else
                          errors += m.ToString() + '\n';

                  if (errors != "")
                      MessageBox.Show("The following messages were not imported because they have conflicting names or ids with existing messages.\n\n" + errors);
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

              string error = "";

              List<MessageFormat> messages = new List<MessageFormat>();
              List<string> localNames = new List<string>();

              foreach (MessageFormat m in localMessages)
                  localNames.Add(m.Name);

              messages.AddRange(companyMessages);

              foreach (MessageFormat m in messages)
                  RemoveMessageFormat(m);
              
              messages = new List<MessageFormat>();

              foreach (string connection in connections)
                  messages.AddRange(new SqlMessageConnection(connection).GetMessageList());
              foreach (MessageFormat m in messages)
              {
                  AddMessageFormat(m, MessageType.Company);
                  if (localNames.Contains(m.Name))
                  {
                      MessageFormat dupe = localMessages.Find(d => d.Name == m.Name);
                      error += dupe.ToString() + '\n';
                      RemoveMessageFormat(dupe);
                  }
              }

              if (error != "")
                  MessageBox.Show("The following local messages were removed because they share a name with a company message:\n\n" + error);

              btnRefresh.Enabled = true;
          }

          private void btnRemove_Click(object sender, EventArgs e)
          {
              int index = lstMessageSummary.SelectedIndex;

              if (index < 0)
                  return;


              MessageFormat mf = (MessageFormat)lstMessageSummary.Items[index];

              if (mf.IdHigh >= 0x80)
              {
                  MessageBox.Show("You cannot remove company messages.");
                  return;
              }
              RemoveMessageFormat(index);
          }
          private void btnEdit_Click(object sender, EventArgs e)
          {
              int index = lstMessageSummary.SelectedIndex;

              if (index < 0)
                  return;

              MessageFormat mf = (MessageFormat)lstMessageSummary.Items[index];

              if (companyMessages.Contains(mf))
                  return;

              addLocalMessageForm = new AddMessageForm(this, MessageType.Local, index);
              addLocalMessageForm.ShowDialog();
          }

          private void btnClear_Click(object sender, EventArgs e)
          {
              recordedMessages.Clear();
              if (listBoxOneSelected)
                lstDisplayWindowOne.Items.Clear();
              else
                lstDisplayWindowTwo.Items.Clear();    
          }

          private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
          {
              SaveFileDialog fileDialog = new SaveFileDialog();
              string textOut = "";
              fileDialog.Filter = "TXT Files|*.txt|All Files|*.*";
              fileDialog.InitialDirectory = "%USERPROFILE%";

              if (fileDialog.ShowDialog() == DialogResult.OK)
              {
                  foreach (string listItems in recordedMessages)
                  {
                      textOut = textOut + listItems + Environment.NewLine;
                  }
                  System.IO.File.WriteAllText(fileDialog.FileName, textOut);
              }
          }
     }
}