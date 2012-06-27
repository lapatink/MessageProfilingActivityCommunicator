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
          public static List<MessageFormat> messages = new List<MessageFormat>();

          public const int DEFAULT_BAUD_RATE = 240;
          public const Parity DEFAULT_PARITY = Parity.None;
          public const int DEFAULT_DATA_BITS = 8;
          public const StopBits DEFAULT_STOP_BITS = StopBits.One;

          private ComPortConfigForm comPortConfigForm;
          private AddMessageForm AddMessageForm;
          private AddMessageForm AddCompanyForm;

          private SerialPort listeningPort;
          private bool closeComPort;

          private DataProcessor dataProcessor;
          private int numberOfEntries;

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

          public MainForm()
          {
               InitializeComponent();
               comPortConfigForm = null;
               closeComPort = false;

               dataProcessor = new DataProcessor(this);
               numberOfEntries = 0;

               String[] portNames = SerialPort.GetPortNames();
               foreach (String name in portNames)
               {
                    if (name.StartsWith("COM") && !name.StartsWith("COM1"))
                    {
                         OpenComPort(name, DEFAULT_BAUD_RATE, DEFAULT_PARITY, DEFAULT_DATA_BITS, DEFAULT_STOP_BITS);
                         break;
                    }
               }
          }

          private void SetSerialPortConfig(String comPortName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
          {
               this.comPortName = comPortName;
               this.baudRate = baudRate;
               this.parity = parity;
               this.dataBits = dataBits;
               this.stopBits = stopBits;

               lblvPortName.Text = this.comPortName;
               lblvBaudRate.Text = this.baudRate.ToString();
               lblvParity.Text = this.parity.ToString();
               lblvDataBits.Text = this.dataBits.ToString();
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

          private void OpenComPort()
          {
               try
               {
                    listeningPort = new SerialPort(this.comPortName, this.baudRate, this.parity, this.dataBits, this.stopBits);
               }
               catch (Exception e)
               {
                    MessageBox.Show(e.ToString());
                    return;
               }

               btnCloseComPort.Enabled = true;
               btnCloseComPort.BackColor = Color.Red;
               btnOpenComPort.Enabled = false;
               btnOpenComPort.BackColor = Button.DefaultBackColor;
          }

          public void OpenComPort(String comPortName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
          {
               try
               {
                    listeningPort = new SerialPort(comPortName, baudRate, parity, dataBits, stopBits);
               }
               catch (Exception e)
               {
                    MessageBox.Show(e.ToString());
                    return;
               }

               btnCloseComPort.Enabled = true;
               btnCloseComPort.BackColor = Color.Red;
               btnOpenComPort.Enabled = false;
               btnOpenComPort.BackColor = Button.DefaultBackColor;

               SetSerialPortConfig(comPortName, baudRate, parity, dataBits, stopBits);
               try
               {
                    this.listeningPort.Open();
               }
               catch (Exception)
               {
                    String[] portNames = SerialPort.GetPortNames();
                    foreach (String name in portNames)
                    {
                         if (name.StartsWith("COM") && !name.StartsWith("COM1"))
                         {
                              MessageBox.Show(comPortName + " does not seem to be a valid port, selecting port " + name);
                              OpenComPort(name, this.baudRate, this.parity, this.dataBits, this.stopBits);
                              break;
                         }
                    }
               }
          }

          private void CloseComPort()
          {
               btnCloseComPort.Enabled = false;
               btnCloseComPort.BackColor = Button.DefaultBackColor;
               btnOpenComPort.Enabled = true;
               btnOpenComPort.BackColor = Color.Green;

               if (listeningPort != null)
               {
                    listeningPort.Close();
                    listeningPort.Dispose();
                    listeningPort = null;
               }
          }

          public void LogData(Message completedMessage)
          {
               String message = String.Format("{0:MM/dd/yyyy HH:mm:ss.fff tt}\t\t", DateTime.Now) + completedMessage.ToString();

               lstDisplayWindow.Items.Add(message);
               lstDisplayWindow.SelectedIndex = numberOfEntries++;
          }

          public void RecordTrash(byte[] trashBytes)
          {
          }

          private void tmrClockRefresh_Tick(object sender, EventArgs e)
          {
               String time = String.Format("{0:MM/dd/yyyy   HH:mm:ss tt}", DateTime.Now);
               lblCurrentTime.Text = time;
          }

          private void btnCloseComPort_Click(object sender, EventArgs e)
          {
               CloseComPort();
               closeComPort = true;
          }

          private void btnOpenComPort_Click(object sender, EventArgs e)
          {
               OpenComPort();
               closeComPort = false;
          }

          private void btnConfiureComPort_Click(object sender, EventArgs e)
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
                    comPortConfigForm.SetComboBoxes(this.comPortName, this.baudRate, this.parity, this.dataBits, this.stopBits);
               }
          }

          private void tmrCloseComPortCheck_Tick(object sender, EventArgs e)
          {
               if (!closeComPort && listeningPort != null && !listeningPort.IsOpen && !comPortConfigForm.Visible)
                    OpenComPort();
          }

          private void tmrCheckForData_Tick(object sender, EventArgs e)
          {
               if (listeningPort == null || !listeningPort.IsOpen)
                    return;

               int numberOfBytes = listeningPort.BytesToRead;

               if (listeningPort.BytesToRead <= 0)
                    return;

               byte[] buffer = new byte[numberOfBytes];

               numberOfBytes = listeningPort.Read(buffer, 0, numberOfBytes);

               if (numberOfBytes > 0)
                    dataProcessor.ProcessData(buffer);
          }

          private void btnAddMessage_Click(object sender, EventArgs e)
          {
              try
              {
                  AddMessageForm.Show();
              }
              catch (Exception)
              {
                  AddMessageForm = new AddMessageForm(this, AddMessageForm.messageType.local);
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
                  AddCompanyForm = new AddMessageForm(this, AddMessageForm.messageType.local);
                  AddCompanyForm.Show();
              }
          }

          private void btnSendMessageOne_Click(object sender, EventArgs e)
          {
               String[] parts = txtMessageOne.Text.Trim().Split(' ');
               byte[] message = new byte[parts.Length];

               for (int i = 0; i < parts.Length; i++)
               {
                    message[i] = (byte)int.Parse(parts[i], System.Globalization.NumberStyles.HexNumber);
               }

               dataProcessor.ProcessData(message);
          }

          private void btnSendMessageTwo_Click(object sender, EventArgs e)
          {
               String[] parts = txtMessageTwo.Text.Split(' ');
               byte[] message = new byte[parts.Length];

               for (int i = 0; i < parts.Length; i++)
               {
                    message[i] = (byte)int.Parse(parts[i], System.Globalization.NumberStyles.HexNumber);
               }

               dataProcessor.ProcessData(message);
          }

          private void btnSendMessageThree_Click(object sender, EventArgs e)
          {
               String[] parts = txtMessageThree.Text.Split(' ');
               byte[] message = new byte[parts.Length];

               for (int i = 0; i < parts.Length; i++)
               {
                    message[i] = (byte)int.Parse(parts[i], System.Globalization.NumberStyles.HexNumber);
               }

               dataProcessor.ProcessData(message);
          }
     }
}