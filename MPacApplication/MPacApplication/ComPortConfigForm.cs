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
     public partial class ComPortConfigForm : Form
     {
          private MainForm parentForm;
          private String[] portNames;

          public ComPortConfigForm(MainForm sourceForm)
          {
               InitializeComponent();
               parentForm = sourceForm;
               if (sourceForm.ComPortName == null)
                    PopulatePortNameList("");
               else
                    PopulatePortNameList(sourceForm.ComPortName);
          }

          private void PopulatePortNameList(String currentlySelectedPortName)
          {
               portNames = SerialPort.GetPortNames();
               Array.Sort(portNames);
               cmbComPortName.Items.Clear();
               foreach (String name in portNames)
               {
                    if (name.StartsWith("COM"))
                         cmbComPortName.Items.Add(name);
               }

               cmbComPortName.SelectedIndex = GetIndexOfValue(cmbComPortName.Items, currentlySelectedPortName);
          }

          public void SetComboBoxes(String comPortName, int baudRate, Parity parity, int dataBits, StopBits stopBits, Handshake handshake, bool rtsEnable, bool dtrEnable)
          {
               try
               {
                    cmbComPortName.Text = GetValidPortName(cmbComPortName.Text);
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.ToString());
                    cmbComPortName.Text = "NONE";
               }

               cmbBaudRate.Text = baudRate.ToString();
               cmbParity.SelectedIndex = GetIndexOfValue(cmbParity.Items, parity.ToString());
               cmbDataBits.SelectedIndex = GetIndexOfValue(cmbDataBits.Items, dataBits.ToString());
               switch (stopBits)
               {
                    case StopBits.One:
                         cmbStopBits.SelectedIndex = GetIndexOfValue(cmbStopBits.Items, "1");
                         break;
                    case StopBits.OnePointFive:
                         cmbStopBits.SelectedIndex = GetIndexOfValue(cmbStopBits.Items, "1.5");
                         break;
                    case StopBits.Two:
                         cmbStopBits.SelectedIndex = GetIndexOfValue(cmbStopBits.Items, "2");
                         break;
                    case StopBits.None:
                         cmbStopBits.SelectedIndex = GetIndexOfValue(cmbStopBits.Items, "1");
                         break;
                    default:
                         cmbStopBits.SelectedIndex = GetIndexOfValue(cmbStopBits.Items, "1");
                         break;
               }
               switch (handshake)
               {
                    case Handshake.None:
                         cmbHandshake.SelectedIndex = GetIndexOfValue(cmbHandshake.Items, "None");
                         break;
                    case Handshake.RequestToSend:
                         cmbHandshake.SelectedIndex = GetIndexOfValue(cmbHandshake.Items, "RequestToSend");
                         break;
                    case Handshake.XOnXOff:
                         cmbHandshake.SelectedIndex = GetIndexOfValue(cmbHandshake.Items, "XOnXOff");
                         break;
                    case Handshake.RequestToSendXOnXOff:
                         cmbHandshake.SelectedIndex = GetIndexOfValue(cmbHandshake.Items, "Both");
                         break;
                    default:
                         cmbHandshake.SelectedIndex = GetIndexOfValue(cmbHandshake.Items, "None");
                         break;
               }

               if (rtsEnable)
               {
                    cmbRequestToSend.SelectedIndex = GetIndexOfValue(cmbRequestToSend.Items, "Enable");
               }
               else
               {
                    cmbRequestToSend.SelectedIndex = GetIndexOfValue(cmbRequestToSend.Items, "Disable");
               }

               if (dtrEnable)
               {
                    cmbDataTerminalReady.SelectedIndex = GetIndexOfValue(cmbDataTerminalReady.Items, "Enable");
               }
               else
               {
                    cmbDataTerminalReady.SelectedIndex = GetIndexOfValue(cmbDataTerminalReady.Items, "Disable");
               }
          }

          private int GetIndexOfValue(ComboBox.ObjectCollection items, String value)
          {
               int index = 0;
               foreach (var item in items)
               {
                    if (item.ToString().Trim().Equals(value.Trim()))
                         break;

                    index++;
               }
               if (index < items.Count)
                    return index;
               else
                    return 0;
          }

          public String GetValidPortName(String desiredPortName)
          {
               String[] portNames = SerialPort.GetPortNames();

               if (!portNames.Contains<String>(desiredPortName))
               {
                    foreach (String name in portNames)
                    {
                         if (name.StartsWith("COM"))
                         {
                              return name;
                         }
                    }
                    throw new Exception("No COM ports available");
               }
               else
               {
                    return desiredPortName;
               }
          }

          private void btnOK_Click(object sender, EventArgs e)
          {
               String selectedPortName;
               int selectedBaudRate;
               Parity selectedParity;
               int selectedDataBits;
               StopBits selectedStopBits;
               Handshake selectedHandshake;
               bool selectedRtsEnable;
               bool selectedDtrEnable;

               try
               {
                    selectedPortName = GetValidPortName(cmbComPortName.Text);
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.ToString());
                    selectedPortName = "NONE";
               }

               if (!Int32.TryParse(cmbBaudRate.Text, out selectedBaudRate))
               {
                    MessageBox.Show("Invalid Baud Rate. Reverting to default: " + MainForm.DEFAULT_BAUD_RATE.ToString());
                    selectedBaudRate = MainForm.DEFAULT_BAUD_RATE;
               }
               else if (selectedBaudRate < 1 || selectedBaudRate > MainForm.MAX_BAUD_RATE)
               {
                    MessageBox.Show("Invalid Baud Rate. Reverting to default: " + MainForm.DEFAULT_BAUD_RATE.ToString());
                    selectedBaudRate = MainForm.DEFAULT_BAUD_RATE;
               }

               try
               {
                    selectedParity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text, true);
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.ToString());
                    MessageBox.Show("Invalid Parity. Reverting to default: " + MainForm.DEFAULT_PARITY.ToString());
                    selectedParity = Parity.None;
               }

               if (!Int32.TryParse(cmbDataBits.Text.Trim(), out selectedDataBits))
               {
                    MessageBox.Show("Invalid Number Of Data Bits. Reverting to default: " + MainForm.DEFAULT_DATA_BITS.ToString());
                    selectedDataBits = MainForm.DEFAULT_DATA_BITS;
               }
               else if (selectedBaudRate < 1)
               {
                    MessageBox.Show("Invalid Number Of Data Bits. Reverting to default: " + MainForm.DEFAULT_DATA_BITS.ToString());
                    selectedDataBits = MainForm.DEFAULT_DATA_BITS;
               }

               if (cmbStopBits.Text.Trim().Equals("1"))
               {
                    selectedStopBits = StopBits.One;
               }
               else if (cmbStopBits.Text.Trim().Equals("1.5"))
               {
                    selectedStopBits = StopBits.OnePointFive;
               }
               else if (cmbStopBits.Text.Trim().Equals("2"))
               {
                    selectedStopBits = StopBits.Two;
               }
               else
               {
                    MessageBox.Show("Invalid Stop Bits. Setting to None");
                    selectedStopBits = StopBits.None;
               }

               if (cmbHandshake.Text.Trim().Equals("RequestToSend"))
               {
                    selectedHandshake = Handshake.RequestToSend;
               }
               else if (cmbHandshake.Text.Trim().Equals("XOnXOff"))
               {
                    selectedHandshake = Handshake.XOnXOff;
               }
               else if (cmbHandshake.Text.Trim().Equals("Both"))
               {
                    selectedHandshake = Handshake.RequestToSendXOnXOff;
               }
               else
               {
                    selectedHandshake = Handshake.None;
               }

               if (cmbDataTerminalReady.Text.Trim().Equals("Enable"))
               {
                    selectedDtrEnable = true;
               }
               else
               {
                    selectedDtrEnable = false;
               }

               if (cmbRequestToSend.Text.Trim().Equals("Enable"))
               {
                    selectedRtsEnable = true;
               }
               else
               {
                    selectedRtsEnable = false;
               }

               this.parentForm.OpenComPort(selectedPortName, selectedBaudRate, selectedParity, selectedDataBits, selectedStopBits, selectedHandshake, selectedRtsEnable, selectedDtrEnable);
               this.Visible = false;
          }

          private void btnCancel_Click(object sender, EventArgs e)
          {
               this.Visible = false;
          }
     }
}
