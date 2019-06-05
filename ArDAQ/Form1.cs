using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
using System.Threading;
using System.Reflection;

using System.IO;


using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Deployment.Application;

//using ComInterfaces;
//using System.ServiceModel;

namespace ArDAQ
{

    enum FileFormat { csv, bin, xlsx};

    public partial class Form1 : Form
    {


        private bool isAcquiring;

        // Incoming data from the client.  
        TcpListener listenerTCP;
        TcpClient handlerTCP;
        public static string dataTCP = null;

        public Dictionary<String, string[,]> allData;

        private Dictionary<Tuple<String, int, int>, String> calibrationLabel;
        private Dictionary<Tuple<String, int, int>, String> calibrationUnit;
        private Dictionary<Tuple<String, int, int>, double> calibrationAcoef;
        private Dictionary<Tuple<String, int, int>, double> calibrationBcoef;

        private Dictionary<String, bool[]> dictCheck;

        private FileStream fs;
        private BinaryWriter binWriterNETDAQ;
        private bool isWriting;

        private Stopwatch stopWatch;
        private HighResTimer HTimer;
        private Dictionary<String, SerialPort> serialDict;
        private List<String> serialList;

        private int currentSerialSelection;

        private bool serialSelectionChanging;

        private bool getValueWhenWriting;
        private Dictionary<string, int> nbDataPerTCA;
        FileFormat outFileFormat;

        public Form1()
        {
            InitializeComponent();
            updatePortList();

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                this.Text = string.Format("ArduinoDAQ Control & Monitoring v{0}", ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4));
            }


            isAcquiring = false;
            isWriting = false;

            allData = new Dictionary<String, string[,]>();

            dictCheck = new Dictionary<String, bool[]>();
            
            calibrationLabel = new Dictionary<Tuple<String, int, int>, String>();
            calibrationUnit = new Dictionary<Tuple<String, int, int>, String>();
            calibrationAcoef = new Dictionary<Tuple<String, int, int>, double>();
            calibrationBcoef = new Dictionary<Tuple<String, int, int>, double>();

            stopWatch = new Stopwatch();

            HTimer = new HighResTimer();
            HTimer.Elapsed += HTimer_Elapsed;

            serialDict = new Dictionary<String, SerialPort>();
            serialList = new List<String>();
            currentSerialSelection = -1;
            serialSelectionChanging = false;

            getValueWhenWriting = false;
            btS3.Enabled = false;

            /*var host = new ServiceHost(typeof(Form1), new Uri("net.pipe://localhost"));

            host.AddServiceEndpoint(typeof(IComService), new NetNamedPipeBinding(), "ArDAQ");
            host.Open();
            */

            nbDataPerTCA = new Dictionary<string, int>();
            
            //numericUpDown1.Value = nbDataPerTCA;
        }



        private void setAcquiringStatus(bool status)
        {
            this.isAcquiring = status;
        }
        delegate void outputDelegate(string s);
        public void output(string s)
        {
            if (boxOut.InvokeRequired)
            {
                outputDelegate d = new outputDelegate(output);
                boxOut.Invoke(d, new object[] { s});
            }
            else
            {
                boxOut.AppendText(s);
            }
        }
        public void setbtConnect(bool status)
        {
            btStart.Enabled = status;
        }
        public bool isConnected()
        {
            SerialPort serialPort1 = serialDict[(string)dataGridView3.Rows[currentSerialSelection].Cells[0].Value];

            return serialPort1.IsOpen;
        }
        private void btStop_Click(object sender, EventArgs e)
        {
            closeConnection();
        }
        private void closeConnection()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SerialPort serialPort1 = serialDict[(string)dataGridView3.Rows[currentSerialSelection].Cells[0].Value];
                if ((serialPort1.IsOpen))
                {
                    try
                    {
                        string r = string.Format("{0}", 1);
                        serialPort1.Write(r);
                    }
                    catch (Exception Ex)
                    {
                        output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
                    }
                    btStop.Enabled = false;

                    serialPort1.Close();

                    if (serialPort1.IsOpen)
                    {
                        output("serial not properly closed\r\n");
                    }
                    btStop.Enabled = true;
                }
                else
                {
                    output("port not connected yet\r\n");
                }
                setBTConnection();
                updateSerialGrid();
            }
            catch (Exception Ex)
            {

                MessageBox.Show("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
                setBTConnection();
            }
            this.Cursor = Cursors.Default;

        }
        private void updateSerialGrid()
        {
            try
            {
                dataGridView3.Rows.Clear();
                foreach (String str in serialList)
                {
                    int id = dataGridView3.Rows.Add(new string[]{ str});
                    //dataGridView3.Rows[id].Cells[0].Value = str;
                    if (serialDict[str].IsOpen)
                    {
                        dataGridView3.Rows[id].Cells[0].Style.ForeColor = Color.Green;
                        dataGridView3.Rows[id].Cells[0].Style.SelectionBackColor = Color.Green;

                    }
                    else
                    {
                        dataGridView3.Rows[id].Cells[0].Style.ForeColor = Color.Red;
                        dataGridView3.Rows[id].Cells[0].Style.SelectionBackColor = Color.Red;

                    }

                }
                setBTConnection();
            }
            catch (Exception Ex)
            {
                output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }
        private void btStart_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SerialPort serialPort1 ;
                serialPort1 = serialDict[(string)dataGridView3.Rows[currentSerialSelection].Cells[0].Value];
                if ((serialPort1.IsOpen))
                {

                    output("Already connected\r\n");
                }
                else
                {
                    btStart.Enabled = false;
                    
                    

                    serialPort1.Open();
                    
                    
                    System.Threading.Thread.Sleep(3000);
                    string r = string.Empty;
                    for (int j = 0; j < 8; j++)
                    {
                        int status = 0;
                        if (dictCheck[serialList[currentSerialSelection]][j]) { status = 1; }
                        r += string.Format("{0}", status);
                    }
                    r += string.Format("{0}", 0);
                   
                    serialPort1.Write(r);
                    
                   
                    
                    //initializeChannel();
                    btStart.Enabled = true;
                }
                setBTConnection();
                updateSerialGrid();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
                btStart.Enabled = true;
            }
            this.Cursor = Cursors.Default;
        }
        private void setBTConnection()
        {
            try
            {
                if (currentSerialSelection >= 0)
                {
                    string key = serialList[currentSerialSelection];
                    if (serialDict.ContainsKey(key))
                    {
                        SerialPort serialPort1 = serialDict[key];

                        numericUpDown1.Value = nbDataPerTCA[key];
                        for (int i = 0; i < entryList.Items.Count; i++)
                        {
                            entryList.SetItemChecked(i, dictCheck[key][i]);
                        }
                        if (serialPort1.IsOpen)
                        {
                            btStart.Enabled = false;
                            btStop.Enabled = true;
                            gbEntry.Enabled = false;
                        }
                        else
                        {
                            btStart.Enabled = true;
                            btStop.Enabled = false;
                            gbEntry.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");


            }
        }
  

        public void clean()
        {
            closeConnection();
        }
        




        private void btPorts_Click(object sender, EventArgs e)
        {
            updatePortList();
        }
        private void updatePortList()
        {
            try
            {
                string[] ArrayComPortsNames = null;
                int index = -1;
                string ComPortName = null;

                //Com Ports
                ArrayComPortsNames = SerialPort.GetPortNames();
                comboBox1.Items.Clear();
                do
                {
                    index += 1;
                    comboBox1.Items.Add(ArrayComPortsNames[index]);
                } while (!((ArrayComPortsNames[index] == ComPortName) ||
                  (index == ArrayComPortsNames.GetUpperBound(0))));
                Array.Sort(ArrayComPortsNames);

                if (index == ArrayComPortsNames.GetUpperBound(0))
                {
                    ComPortName = ArrayComPortsNames[0];
                }

                //get first item print in text
                comboBox1.Text = ArrayComPortsNames[0];
            }
            catch (Exception Ex)
            {
                output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }

    
        

        public double getSampling()
        {
            return double.Parse(tbSampling.Text);
        }
        

        private void tbIn_TextChanged(object sender, EventArgs e)
        {

        }
        delegate void s_DataReceivedDelegate(object sender, SerialDataReceivedEventArgs e);
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        { 
            try
            {
                SerialPort sp = (SerialPort)sender;
                String spName = sp.PortName;
                //string indata = sp.ReadExisting();
                string indata = sp.ReadLine();// sp.ReadExisting();
                                              //tbIn.Text = indata;

                //output(indata);
                indata = indata.Trim();
                String[] substrings = indata.Split();

                
                try
                {
                    if (!getValueWhenWriting)
                   // if (true)//!isWriting)
                    {
                        int myID = 0;

                        for (int i = 0; i < 8; i++)
                        {
                            if (dictCheck[spName][i])
                            {
                                for (int j = 0; j < nbDataPerTCA[spName]; j++)
                                {
                                    allData[spName][i, j] = substrings[myID];
                                    myID++;
                                }
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + substrings.Count()  + "\r\n");
                    for (int i = 0; i < substrings.Count(); i++)
                    {
                        output(substrings[i] + "\r\n");
                    }
                    output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
                }
                
                if (String.Equals(spName, serialList[currentSerialSelection]))
                {
                    updateMonitoringGrid();
                
                }
                else
                {
                    if (!serialDict[serialList[currentSerialSelection]].IsOpen)
                    {
                        clearMonitoringGrid();
                    }
                    
                }
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btLocation_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "CSV|*.csv|NETDAQ BINARY|*.bin|Excel File|*.xlsx";
            saveFileDialog1.ShowDialog();
            btLocation.Text = saveFileDialog1.FileName;
        }


        private void updateCalibrationGrid()
        {
            try
            {
                if (currentSerialSelection >= 0)
                {
                    String pn = String.Format("{0}", serialList[currentSerialSelection]);
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dictCheck[serialList[currentSerialSelection]].Count(); i++)
                    {
                        if (dictCheck[serialList[currentSerialSelection]][i])
                        {
                            for (int j = 0; j < nbDataPerTCA[pn]; j++)
                            {
                                int index = dataGridView1.Rows.Add();
                                //output("index : " + index + "\r\n");
                                if ((index % 2) == 0)
                                {
                                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Gray;
                                    dataGridView1.Rows[index].DefaultCellStyle.ForeColor = Color.White;
                                }
                                else
                                {
                                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                                }
                                dataGridView1.Rows[index].Cells[0].Value = String.Format("{0}/{1}-{2}",pn, i, j);

                                dataGridView1.Rows[index].Cells[1].Value = calibrationLabel[new Tuple<String, int, int>(pn, i, j)];
                                dataGridView1.Rows[index].Cells[2].Value = calibrationAcoef[new Tuple<String, int, int>(pn, i, j)];
                                dataGridView1.Rows[index].Cells[3].Value = calibrationBcoef[new Tuple<String, int, int>(pn, i, j)];
                                dataGridView1.Rows[index].Cells[4].Value = calibrationUnit[new Tuple<String, int, int>(pn, i, j)];
                            }
                        }
                    }
                    createMonitoringGrid();
                }
            }
            catch (Exception Ex)
            {
                //output(currentSerialSelection + "\rn");
                //output(serialList[currentSerialSelection] + "\rn");
                output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }
        private void createMonitoringGrid()
        {
            try
            {
                if (currentSerialSelection >= 0)
                {
                    String pn = String.Format("{0}", serialList[currentSerialSelection]);
                    dataGridView2.Rows.Clear();
                    for (int i = 0; i < dictCheck[pn].Count(); i++)
                    {
                        if (dictCheck[pn][i])
                        {
                            for (int j = 0; j < nbDataPerTCA[pn]; j++)
                            {
                                int index = dataGridView2.Rows.Add();
                                if ((index % 2) == 0)
                                {
                                    dataGridView2.Rows[index].DefaultCellStyle.BackColor = Color.Gray;
                                    dataGridView2.Rows[index].DefaultCellStyle.ForeColor = Color.White;
                                }
                                else
                                {
                                    dataGridView2.Rows[index].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                                }

                                dataGridView2.Rows[index].Cells[0].Value = String.Format("{0}/{1}-{2}", pn,i, j);
                                dataGridView2.Rows[index].Cells[1].Value = calibrationLabel[new Tuple<String, int, int>(pn, i, j)];
                                dataGridView2.Rows[index].Cells[2].Value = 0.0;
                                dataGridView2.Rows[index].Cells[3].Value = calibrationUnit[new Tuple<String, int, int>(pn, i, j)];
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }
        private void clearMonitoringGrid()
        {
            try
            {
                dataGridView2.Rows.Clear();
                
            }
            catch (Exception Ex)
            {
                output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }
        private void updateMonitoringGrid()
        {
            try
            {
                if (dataGridView2.Rows.Count ==0)
                {
                    createMonitoringGrid();
                }
                String pn = String.Format("{0}", serialList[currentSerialSelection]);
                int myID = 0;

                for (int i = 0; i < dictCheck[pn].Count(); i++)
                {
                    if (dictCheck[pn][i])
                    {
                        for (int j = 0; j < nbDataPerTCA[pn]; j++)
                        {

                            dataGridView2.Rows[myID].Cells[1].Value = calibrationLabel[new Tuple<String, int, int>(pn, i, j)];
                            double A = calibrationAcoef[new Tuple<String, int, int>(pn, i, j)];
                            double B = calibrationBcoef[new Tuple<String, int, int>(pn, i, j)];

                            dataGridView2.Rows[myID].Cells[2].Value = double.Parse(allData[pn][i, j]) * A + B;
                            dataGridView2.Rows[myID].Cells[3].Value = calibrationUnit[new Tuple<String, int, int>(pn, i, j)];
                            myID++;
                        }
                    }
                }
                
            }
            catch (Exception Ex)
            {
                output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    String pn = String.Format("{0}", serialList[currentSerialSelection]);
                    String myStr = String.Format("{0}", dataGridView1.Rows[e.RowIndex].Cells[0].Value);

                    string pnn = myStr.Split('/')[0];
                    myStr = myStr.Split('/')[1];
                    char delim = '-';
                    int i = int.Parse(myStr.Split(delim)[0]);
                    int j = int.Parse(myStr.Split(delim)[1]);

                    String strVal = String.Format("{0}", dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                    if (e.ColumnIndex == 1)
                    {
                        calibrationLabel[new Tuple<String, int, int>(pn, i, j)] = strVal;
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        calibrationAcoef[new Tuple<String, int, int>(pn, i, j)] = double.Parse(strVal);
                    }
                    else if (e.ColumnIndex == 3)
                    {
                        calibrationBcoef[new Tuple<String, int, int>(pn, i, j)] = double.Parse(strVal);
                    }
                    else if (e.ColumnIndex == 4)
                    {
                        calibrationUnit[new Tuple<String, int, int>(pn, i, j)] = strVal;
                    }
                    updateCalibrationGrid();
                }
            }
            catch (Exception Ex)
            {
                updateCalibrationGrid();
                output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }

        private void entryList_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (!serialSelectionChanging)
                {
                    String pn = String.Format("{0}", serialList[currentSerialSelection]);
                    for (int i = 0; i < entryList.Items.Count; i++)
                    {
                        dictCheck[pn][i] = entryList.GetItemChecked(i);

                        if (i == e.Index)
                        {
                            if (e.NewValue == CheckState.Checked)
                            {
                                dictCheck[pn][i] = true;
                            }
                            else
                            {
                                dictCheck[pn][i] = false;
                            }
                        }

                        if (dictCheck[pn][i])
                        {
                            for (int j = 0; j < nbDataPerTCA[pn]; j++)
                            {
                                if (!calibrationLabel.ContainsKey(new Tuple<String, int, int>(pn, i, j)))
                                {
                                    calibrationLabel[new Tuple<String, int, int>(pn, i, j)] = String.Format("{0}/{1}-{2}", pn, i, j);
                                    calibrationUnit[new Tuple<String, int, int>(pn, i, j)] = String.Format("[-]");
                                    calibrationAcoef[new Tuple<String, int, int>(pn, i, j)] = 1.0;
                                    calibrationBcoef[new Tuple<String, int, int>(pn, i, j)] = 0.0;
                                }
                            }
                        }
                        
                    }
                    updateCalibrationGrid();
                }
            }
            catch (Exception Ex)
            {
                updateCalibrationGrid();
                output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }

        private void entryList_SelectedValueChanged(object sender, EventArgs e)
        {

        }



        private void HTimer_Elapsed(object sender, HighResTimerElapsedEventArgs e)
        {
            getValueWhenWriting = true;
            writingData();
            getValueWhenWriting = false;
        }

        private void writingData()
        {
            try
            {

                //
                Byte[] Textinfo;
                

                string tmpStr = string.Empty;

                Dictionary<string, string[,]> tmpAllData = new Dictionary<string, string[,]>();

                for (int k = 0; k < serialList.Count; k++)
                {
                    String pn = String.Format("{0}", serialList[k]);
                    tmpAllData[pn] = new string[8, nbDataPerTCA[pn]];

                    for (int i = 0; i < dictCheck[pn].Count(); i++)
                    {
                        if (dictCheck[pn][i])
                        {

                            int j;
                            for (j = 0; j < nbDataPerTCA[pn]; j++)
                            {
                                tmpAllData[pn][i, j] = string.Format("{0}", (allData[pn][i, j]));
                            }
                        }
                    }
                }

                if (outFileFormat == FileFormat.csv)
                {
                    DateTime dt = DateTime.Now;
                    Textinfo = new UTF8Encoding(true).GetBytes(string.Format("{0}/{1:00}/{2} {3}:{4}:{5:0.000}\t", dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute, dt.Second + (double)dt.Millisecond / 1000.0));

                    fs.Write(Textinfo, 0, Textinfo.Length);

                    for (int k = 0; k < serialList.Count; k++)
                    {
                        String pn = String.Format("{0}", serialList[k]);
                        for (int i = 0; i < dictCheck[pn].Count(); i++)
                        {
                            if (dictCheck[pn][i])
                            {

                                int j;
                                double A, B;
                                for (j = 0; j < nbDataPerTCA[pn]; j++)
                                {
                                    A = calibrationAcoef[new Tuple<String, int, int>(pn, i, j)];
                                    B = calibrationBcoef[new Tuple<String, int, int>(pn, i, j)];
                                    double val;
                                    try
                                    {
                                        val = double.Parse(tmpAllData[pn][i, j]) * A + B;
                                    }
                                    catch (Exception Ex)
                                    {
                                        val = 0.0;
                                    }
                                    tmpStr += string.Format("{0}\t", val);

                                }

                            }
                        }

                    }
                    tmpStr += "\n";
                    Textinfo = new UTF8Encoding(true).GetBytes(tmpStr);
                    fs.Write(Textinfo, 0, Textinfo.Length);
                    fs.Flush();

                }
                else if (outFileFormat == FileFormat.bin)
                {
                    
                    //using (BinaryWriter binWriter = new BinaryWriter(fs))
                    //{

                    UInt32 alignement = 1;
                    binWriterNETDAQ.Write(alignement);

                    DateTime dt = DateTime.Now;
                    Byte bVal = (Byte)dt.Hour;
                    binWriterNETDAQ.Write(bVal);

                    bVal = (Byte)dt.Minute;
                    binWriterNETDAQ.Write(bVal);

                    bVal = (Byte)dt.Second;
                    binWriterNETDAQ.Write(bVal);

                    bVal = (Byte)dt.Month;
                    binWriterNETDAQ.Write(bVal);

                    bVal = (Byte)dt.DayOfWeek;
                    binWriterNETDAQ.Write(bVal);

                    bVal = (Byte)dt.Day;
                    binWriterNETDAQ.Write(bVal);

                    bVal = (Byte)(dt.Year-2000);
                    binWriterNETDAQ.Write(bVal);

                    bVal = (Byte)1; //unused
                    binWriterNETDAQ.Write(bVal);

                    UInt16 u16Val = (UInt16)dt.Millisecond;
                    binWriterNETDAQ.Write(u16Val);

                    //dio
                    
                    for (int i = 0; i < 1; i++)
                    {
                        u16Val = (UInt16)255;
                        binWriterNETDAQ.Write(u16Val);
                    }

                    UInt32 uintVal = 0; //alarm 1
                    binWriterNETDAQ.Write(uintVal);

                    // alarm2
                    binWriterNETDAQ.Write(uintVal);
                    //total
                    binWriterNETDAQ.Write(uintVal);

                    for (int k = 0; k < serialList.Count; k++)
                    {
                        String pn = String.Format("{0}", serialList[k]);
                        for (int i = 0; i < dictCheck[pn].Count(); i++)
                        {
                            if (dictCheck[pn][i])
                            {

                                int j;
                                double A, B;
                                for (j = 0; j < nbDataPerTCA[pn]; j++)
                                {
                                    A = calibrationAcoef[new Tuple<String, int, int>(pn, i, j)];
                                    B = calibrationBcoef[new Tuple<String, int, int>(pn, i, j)];
                                    float val;
                                    try
                                    {
                                        val = float.Parse(tmpAllData[pn][i, j]) * (float)A + (float)B;
                                    }
                                    catch (Exception Ex)
                                    {
                                        val = 0.0F;
                                    }
                                    binWriterNETDAQ.Write(val);

                                }

                            }
                        }

                        //}


                    }
                    //binWriter.Close();
                }

                if (ckReccording.BackColor == Color.Red)
                {
                    ckReccording.BackColor = Color.White;

                }
                else
                {
                    ckReccording.BackColor = Color.Red;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }

        private void serialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            output(e.ToString());
        }




        private void ckReccording_Click(object sender, EventArgs e)
        {
            Recoording_click();
        }

        private void Recoording_click() { 
            try
            {
                

                if (isWriting == false)
                {
                    if (btLocation.Text.Split('.').Last().Equals("csv"))
                    {
                        outFileFormat = FileFormat.csv;
                    }
                    else if (btLocation.Text.Split('.').Last().Equals("bin"))
                    {
                        outFileFormat = FileFormat.bin;
                    }
                    else if (btLocation.Text.Split('.').Last().Equals("xlsx"))
                    {
                        outFileFormat = FileFormat.xlsx;
                    }
                    else
                    {
                        output("ERROR : unknown file format" + btLocation.Text + "\r\n" );
                    }


                    Byte[] Textinfo;

                    output("open file :" + btLocation.Text + "\r\n");

                    if (File.Exists(btLocation.Text))
                    {
                        if (MessageBox.Show(string.Format("The file : \"{0}\" already exist. Do you want to overwrite it?", btLocation.Text), "Warning : file exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    if (checkBoxAppend.Checked)
                    {
                        fs = File.Open(btLocation.Text, FileMode.Append, FileAccess.Write, FileShare.Read);
                        
                    }
                    else
                    {
                        fs = File.Open(btLocation.Text, FileMode.Create, FileAccess.Write, FileShare.Read);
                    }

                    isWriting = true;

                    
                   

                    String pathConfig = btLocation.Text.Split('.')[0]+".ardaq";
                    SaveConfig(pathConfig);

                    stopWatch.Restart();

                    try
                    {


                        if (!ckReccording.Checked)
                        {
                            ckReccording.BackColor = Color.White;
                        }


                        HTimer.Interval = (int)Math.Round(double.Parse(tbSampling.Text) * 1000);
                        HTimer.Start();

                    }
                    catch (Exception Ex)
                    {
                        output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
                    }


                    if (checkBoxHeader.Checked)
                    {
                        if (outFileFormat == FileFormat.csv)
                        {
                            //Writing Label
                            Textinfo = new UTF8Encoding(true).GetBytes("Time\t");
                            fs.Write(Textinfo, 0, Textinfo.Length);

                            for (int k = 0; k < serialList.Count; k++)
                            {
                                String pn = String.Format("{0}", serialList[k]);

                                for (int i = 0; i < dictCheck[pn].Count(); i++)
                                {
                                    if (dictCheck[pn][i])
                                    {
                                        for (int j = 0; j < nbDataPerTCA[pn]; j++)
                                        {
                                            Textinfo = new UTF8Encoding(true).GetBytes(string.Format("{0}\t", calibrationLabel[new Tuple<String, int, int>(pn, i, j)]));
                                            fs.Write(Textinfo, 0, Textinfo.Length);

                                        }


                                    }
                                }
                            }
                            Textinfo = new UTF8Encoding(true).GetBytes("\n");
                            fs.Write(Textinfo, 0, Textinfo.Length);

                            //Writing Units

                            Textinfo = new UTF8Encoding(true).GetBytes("dd/mm/yyyy hh:mm:ss.000\t");
                            fs.Write(Textinfo, 0, Textinfo.Length);
                            for (int k = 0; k < serialList.Count; k++)
                            {
                                String pn = String.Format("{0}", serialList[k]);

                                for (int i = 0; i < dictCheck[pn].Count(); i++)
                                {
                                    if (dictCheck[pn][i])
                                    {
                                        for (int j = 0; j < nbDataPerTCA[pn]; j++)
                                        {
                                            Textinfo = new UTF8Encoding(true).GetBytes(string.Format("{0}\t", calibrationUnit[new Tuple<String, int, int>(pn, i, j)]));
                                            fs.Write(Textinfo, 0, Textinfo.Length);

                                        }
                                    }
                                }
                            }
                            Textinfo = new UTF8Encoding(true).GetBytes("\n");
                            fs.Write(Textinfo, 0, Textinfo.Length);
                        }
                        else if (outFileFormat == FileFormat.bin)
                        {
                            //Writing Label
                            Textinfo = new UTF8Encoding(true).GetBytes("\"ARDAQ\"\r\n");
                            fs.Write(Textinfo, 0, Textinfo.Length);

                            string str = String.Format("\"{0}\"\r\n", btLocation.Text);
                            Textinfo = new UTF8Encoding(true).GetBytes(str);
                            fs.Write(Textinfo, 0, Textinfo.Length);

                            DateTime dt = DateTime.Now;
                            Textinfo = new UTF8Encoding(true).GetBytes(string.Format("\"{0}/{1:00}/{2} {3}:{4}:{5:0.000}\"\r\n", dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute, dt.Second + (double)dt.Millisecond / 1000.0));
                            fs.Write(Textinfo, 0, Textinfo.Length);


                            Textinfo = new UTF8Encoding(true).GetBytes("\"\"\r\n");
                            fs.Write(Textinfo, 0, Textinfo.Length);


                            //counting number of data
                            int nbData = 0;
                            for (int k = 0; k < serialList.Count; k++)
                            {
                                String pn = String.Format("{0}", serialList[k]);

                                for (int i = 0; i < dictCheck[pn].Count(); i++)
                                {
                                    if (dictCheck[pn][i])
                                    {
                                        for (int j = 0; j < nbDataPerTCA[pn]; j++)
                                        {
                                            nbData++;
                                        }
                                    }
                                }
                            }

                            str = String.Format("{0}\r\n", nbData + 5);
                            Textinfo = new UTF8Encoding(true).GetBytes(str);
                            fs.Write(Textinfo, 0, Textinfo.Length);


                            //Writing Units
                            Textinfo = new UTF8Encoding(true).GetBytes("\"dd/mm/yyyy hh:mm:ss.000\", ");
                            fs.Write(Textinfo, 0, Textinfo.Length);
                            for (int k = 0; k < serialList.Count; k++)
                            {
                                String pn = String.Format("{0}", serialList[k]);

                                for (int i = 0; i < dictCheck[pn].Count(); i++)
                                {
                                    if (dictCheck[pn][i])
                                    {
                                        int j;
                                        for ( j= 0; j < nbDataPerTCA[pn]; j++)
                                        {
                                            Textinfo = new UTF8Encoding(true).GetBytes(string.Format("\"{0}\", ", calibrationUnit[new Tuple<String, int, int>(pn, i, j)]));
                                            fs.Write(Textinfo, 0, Textinfo.Length);

                                        }
                                    }
                                }
                            }
                            Textinfo = new UTF8Encoding(true).GetBytes("\"DIO\", \"TOTAL\", \"ALARM1\", \"ALARM2\"\n");
                            fs.Write(Textinfo, 0, Textinfo.Length);

                            //writing Labels
                            Textinfo = new UTF8Encoding(true).GetBytes("\"TIME\", ");
                            fs.Write(Textinfo, 0, Textinfo.Length);


                            for (int k = 0; k < serialList.Count; k++)
                            {
                                String pn = String.Format("{0}", serialList[k]);

                                for (int i = 0; i < dictCheck[pn].Count(); i++)
                                {
                                    if (dictCheck[pn][i])
                                    {
                                        int j;
                                        for (j = 0; j < nbDataPerTCA[pn]; j++)
                                        {
                                            Textinfo = new UTF8Encoding(true).GetBytes(string.Format("\"{0}\", ", calibrationLabel[new Tuple<String, int, int>(pn, i, j)]));
                                            fs.Write(Textinfo, 0, Textinfo.Length);

                                        }


                                    }
                                }
                            }
                            
                            Textinfo = new UTF8Encoding(true).GetBytes("\"01DIO\", \"01TOTAL\", \"01ALARM1\", \"01ALARM2\"\n");
                            fs.Write(Textinfo, 0, Textinfo.Length);

                            fs.Close();
                            binWriterNETDAQ = new BinaryWriter(File.Open(btLocation.Text, FileMode.Append));
                        }
                        
                    }

                    //BinaryWriter binWriter = new BinaryWriter(fs);
                    btS3.Enabled = true;
                }
                else
                {

                    btS3.Enabled = false;
                    fs.Close();
                    if (outFileFormat == FileFormat.bin)
                    {
                        binWriterNETDAQ.Close();
                    }
                    isWriting = false;
                    stopWatch.Stop();

                    HTimer.Stop();

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }

        private void checkBoxAppend_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxAppend.Checked)
            {
                checkBoxHeader.CheckState = CheckState.Unchecked;
            }
            else
            {
                checkBoxHeader.CheckState = CheckState.Checked;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog2.Filter = "ArDAQ Configuration file|*.ardaq";
                saveFileDialog2.ShowDialog();
                SaveConfig(saveFileDialog2.FileName);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }

        private void SaveConfig(String path)
        {
            try { 

                using (BinaryWriter binWriter = new BinaryWriter(File.Open(path, FileMode.Create)))
                {
                    binWriter.Write(serialList.Count());

                    for (int j = 0; j < serialList.Count(); j++)
                    {
                        currentSerialSelection = j;
                        binWriter.Write(serialList[j]);

                        binWriter.Write(dictCheck[serialList[j]].Count());
                        for (int i = 0; i < dictCheck[serialList[j]].Count(); i++)
                        {
                            binWriter.Write(dictCheck[serialList[j]][i]);
                        }
                        binWriter.Write(nbDataPerTCA[serialList[j]]);
                    }
                    binWriter.Write(calibrationLabel.Count);
                    foreach (Tuple<String, int, int> key in calibrationLabel.Keys)
                    {
                        binWriter.Write(key.Item1);
                        binWriter.Write(key.Item2);
                        binWriter.Write(key.Item3);
                        binWriter.Write(calibrationLabel[key]);
                    }
                    binWriter.Write(calibrationUnit.Count);
                    foreach (Tuple<String, int, int> key in calibrationUnit.Keys)
                    {
                        binWriter.Write(key.Item1);
                        binWriter.Write(key.Item2);
                        binWriter.Write(key.Item3);
                        binWriter.Write(calibrationUnit[key]);
                    }
                    binWriter.Write(calibrationAcoef.Count);
                    foreach (Tuple<String, int, int> key in calibrationAcoef.Keys)
                    {
                        binWriter.Write(key.Item1);
                        binWriter.Write(key.Item2);
                        binWriter.Write(key.Item3);
                        binWriter.Write(calibrationAcoef[key]);
                    }
                    binWriter.Write(calibrationBcoef.Count);
                    foreach (Tuple<String, int, int> key in calibrationBcoef.Keys)
                    {
                        binWriter.Write(key.Item1);
                        binWriter.Write(key.Item2);
                        binWriter.Write(key.Item3);
                        binWriter.Write(calibrationBcoef[key]);
                    }
                    binWriter.Write(tbSampling.Text);
                    binWriter.Write(btLocation.Text);
                    binWriter.Flush();
                    binWriter.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }

        private void ckReccording_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "ArDAQ Configuration file|*.ardaq";
                openFileDialog1.ShowDialog();
                var fi = new System.IO.FileInfo(openFileDialog1.FileName);


                using (BinaryReader binReader = new BinaryReader(File.Open(openFileDialog1.FileName, FileMode.Open)))
                {
                    int nbSerial = binReader.ReadInt32();
                    for (int j = 0; j < nbSerial; j++)
                    {
                        String pn = binReader.ReadString();
                        addSerial(pn);
                        int nbListCheck = binReader.ReadInt32();
                        for (int i = 0; i < nbListCheck; i++)
                        {
                            dictCheck[pn][i] = binReader.ReadBoolean();
                            entryList.SetItemChecked(i, dictCheck[pn][i]);
                        }
                        nbDataPerTCA[pn] = binReader.ReadInt32();
                        numericUpDown1.Value = nbDataPerTCA[pn];

                    }

                    int nb = binReader.ReadInt32();
                    for (int i = 0; i < nb; i++)
                    {
                        String key1 = binReader.ReadString();
                        int key2 = binReader.ReadInt32();
                        int key3 = binReader.ReadInt32();
                        calibrationLabel[new Tuple<String, int, int>(key1, key2, key3)] = binReader.ReadString();
                    }
                    nb = binReader.ReadInt32();
                    for (int i = 0; i < nb; i++)
                    {
                        String key1 = binReader.ReadString();
                        int key2 = binReader.ReadInt32();
                        int key3 = binReader.ReadInt32();
                        calibrationUnit[new Tuple<String, int, int>(key1, key2, key3)] = binReader.ReadString();
                    }
                    nb = binReader.ReadInt32();
                    for (int i = 0; i < nb; i++)
                    {
                        String key1 = binReader.ReadString();
                        int key2 = binReader.ReadInt32();
                        int key3 = binReader.ReadInt32();
                        calibrationAcoef[new Tuple<String, int, int>(key1, key2, key3)] = binReader.ReadDouble();
                    }
                    nb = binReader.ReadInt32();
                    for (int i = 0; i < nb; i++)
                    {
                        String key1 = binReader.ReadString();
                        int key2 = binReader.ReadInt32();
                        int key3 = binReader.ReadInt32();
                        calibrationBcoef[new Tuple<String, int, int>(key1, key2, key3)] = binReader.ReadDouble();
                    }
                    tbSampling.Text =  binReader.ReadString();
                    btLocation.Text = binReader.ReadString();
                    binReader.Close();
                }
                updateCalibrationGrid();
                createMonitoringGrid();
            }

            catch (Exception Ex)
            {
                MessageBox.Show("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            addSerial(comboBox1.Text);
        }

        private void addSerial(String pn)
        {
            try
            {
                if (!serialDict.ContainsKey(pn))
                {
                    SerialPort serialPort1 = new SerialPort(pn);

                    serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort1_DataReceived);
                    serialPort1.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(serialPort1_ErrorReceived);

                    serialPort1.PortName = pn;

                    // Allow the user to set the appropriate properties.
                    serialPort1.BaudRate = 115200;
                    serialPort1.DtrEnable = true;


                    // Set the read/write timeouts
                    //serialPort1.ReadTimeout = 3000;// 3000;
                    serialPort1.WriteTimeout = 7000;
                    serialDict[pn] = serialPort1;
                    serialList.Add(pn);
                    nbDataPerTCA[pn] = 16;
                    if (!dictCheck.ContainsKey(pn))
                    {
                        dictCheck[pn] = new bool[8];
                    }
                    if (!allData.ContainsKey(pn))
                    {
                        allData[pn] = new string[8, nbDataPerTCA[pn]];
                    }
                    updateSerialGrid();
                } 
            }

            catch (Exception Ex)
            {
                MessageBox.Show("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            serialSelectionChanging = true;
            if (dataGridView3.Rows.Count > 0)
            {
                currentSerialSelection = dataGridView3.CurrentCell.RowIndex;
            }
            else
            {
                currentSerialSelection = -1;
            }
            
            updateCalibrationGrid();
            createMonitoringGrid();
            
            setBTConnection();

            serialSelectionChanging = false;

        }

        private void entryList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            String pn = (string)e.Row.Cells[0].Value;
            serialList.Remove(pn);
            serialDict.Remove(pn);


        }

        private void btUp_Click(object sender, EventArgs e)
        {
            try
            {
                
                int oldIndex = currentSerialSelection;
                int newIndex = currentSerialSelection - 1;

                if (newIndex < 0) newIndex = 0;

                string pn = serialList[oldIndex];
                serialList.RemoveAt(oldIndex);

                
                serialList.Insert(newIndex, pn);
                updateSerialGrid();

                dataGridView3.CurrentCell = dataGridView3.Rows[newIndex].Cells[0];
                currentSerialSelection = newIndex;


            }

            catch (Exception Ex)
            {
                output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            try
            {
                int oldIndex = currentSerialSelection;
                int newIndex = currentSerialSelection + 1;

                if (newIndex > serialList.Count-1) newIndex = serialList.Count - 1;
                String pn = serialList[oldIndex];
                serialList.RemoveAt(oldIndex);

                serialList.Insert(newIndex, pn);
                updateSerialGrid();
                dataGridView3.CurrentCell = dataGridView3.Rows[newIndex].Cells[0];
                currentSerialSelection = newIndex;


            }

            catch (Exception Ex)
            {
                output("ERROR in " + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
            }
        }

        private void btTCPServerStart_Click(object sender, EventArgs e)
        {
            btTCPServerStart.Enabled = false;
            btTCPServerStop.Enabled = true;
            backgroundWorkerTCP.RunWorkerAsync();

        }

        private void backgroundWorkerTCP_DoWork(object sender, DoWorkEventArgs e)
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];



            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the   
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0]; 
            IPEndPoint ep = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            listenerTCP = new TcpListener(ep);
            handlerTCP = new TcpClient();
            String dataStr = null;

            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            try
            {
                // Start listening for client requests.

                new Thread(new ThreadStart(delegate
                {
                    new infoForm("Waiting for a connection...", 2000);
                }
                )).Start();


                listenerTCP.Start();



                handlerTCP =  listenerTCP.AcceptTcpClient();

                new Thread(new ThreadStart(delegate
                {
                    new infoForm("connection accepted from..", 10000);
                    //MessageBox.Show("kljm");
                })).Start();
                


                // Get a stream object for reading and writing
                NetworkStream stream = handlerTCP.GetStream();
                // Start listening for connections.  


              

                int i;
                while (true)
                {
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {

                        try
                        {
                            
                            // Translate data bytes to a ASCII string.
                            dataStr = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            //MessageBox.Show(string.Format("Received: {0}\r\n", dataStr));
                            if (dataStr.Equals("GET_LIST_VALUES"))
                            {
                                dataStr = string.Format("GETLISTVAL {0,2:00}", 8);
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(dataStr);
                                stream.Write(msg, 0, msg.Length);
                            }
                            else if (dataStr.Equals("GET_NB_VALUES"))
                            {
                                //int[] nb = new int[1] { 10 };
                                //byte[] msg = Array.ConvertAll<int, byte>(nb, Convert.ToByte);
                                dataStr = string.Format("GETNBVAL {0,2:00}", 8);
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(dataStr);
                                stream.Write(msg, 0, msg.Length);
                            }
                            else if (dataStr.Equals("GET_LIST_NAMES"))
                            {
                                dataStr = string.Format("GETLISTNAMES{0,2:00}", 8);
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(dataStr);
                                stream.Write(msg, 0, msg.Length);
                            }
                            



                        }
                        catch (FormatException Ex)
                        {
                            MessageBox.Show("ERROR in " + this.GetType().Name + ":" + MethodBase.GetCurrentMethod().Name + " :\r\n" + Ex.Message + "\r\n");
                            backgroundWorkerTCP.CancelAsync();
                            listenerTCP.Stop();
                            handlerTCP.Close();
                        }
                    }
                }


            }
            catch (Exception excp)
            {
                //MessageBox.Show(string.Format(excp.ToString()));
                listenerTCP.Stop();
                handlerTCP.Close();
            }
        }

        private void btTCPServerStop_Click(object sender, EventArgs e)
        {
            try
            {
                listenerTCP.Stop();
                handlerTCP.Close();
                backgroundWorkerTCP.CancelAsync();
            }
            catch (Exception excp)
            {
                output(excp.ToString());
            }
            
        }
        private void statusBtTCP()
        {
            if ((handlerTCP.Client == null) ||(!handlerTCP.Connected))
            {
                btTCPServerStart.Enabled = true;
                btTCPServerStop.Enabled = false;
            }
            else
            {
                btTCPServerStart.Enabled = false;
                btTCPServerStop.Enabled = true;
            }
        }
        private void backgroundWorkerTCP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusBtTCP();
        }

        private void tbSampling_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseCancel() == false)
            {
                e.Cancel = true;
            }
        }
        private bool CloseCancel()
        {
            const string message = "Are you sure that you would like to close the acquisition tool?";
            const string caption = "Quit";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            try
            {
                CopyToClipboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy/paste operation failed. " + ex.Message, "Copy/Paste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void CopyToClipboard()
        {
            //Copy to clipboard
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void PasteClipboard()
        {
            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');


                int iRow = dataGridView1.CurrentCell.RowIndex;
                int iCol = dataGridView1.CurrentCell.ColumnIndex;
                DataGridViewCell oCell, entryCell;
                if (iRow + lines.Length > dataGridView1.Rows.Count - 1)
                {
                    bool bFlag = false;
                    foreach (string sEmpty in lines)
                    {
                        if (sEmpty == "")
                        {
                            bFlag = true;
                        }
                    }

                    int iNewRows = iRow + lines.Length - dataGridView1.Rows.Count;
                    
                }
                foreach (string line in lines)
                {
                    if (iRow < dataGridView1.RowCount && line.Length > 0)
                    {
                        string[] sCells = line.Split('\t');
                        for (int i = 0; i < sCells.GetLength(0); ++i)
                        {
                            if (iCol + i < this.dataGridView1.ColumnCount)
                            {
                                if ((iCol + i) > 0)
                                {
                                    entryCell = dataGridView1[0, iRow];
                                    string entry = entryCell.Value.ToString();
                                    string pn = entry.Split('/')[0];
                                    int ii = int.Parse((entry.Split('/')[1]).Split('-')[0]);
                                    int jj = int.Parse((entry.Split('/')[1]).Split('-')[1]);
                                    oCell = dataGridView1[iCol + i, iRow];
                                    oCell.Value = Convert.ChangeType(sCells[i].Replace("\r", ""), oCell.ValueType);
                                    if ((iCol + i) == 1)
                                    {
                                        calibrationLabel[new Tuple<String, int, int>(pn, ii, jj)] = string.Format("{0}", oCell.Value);
                                    }
                                    else if ((iCol + i) == 2)
                                    {
                                        calibrationAcoef[new Tuple<String, int, int>(pn, ii, jj)] = double.Parse(string.Format("{0}", oCell.Value));
                                    }
                                    else if ((iCol + i) == 3)
                                    {
                                        calibrationBcoef[new Tuple<String, int, int>(pn, ii, jj)] = double.Parse(string.Format("{0}", oCell.Value));
                                    }
                                    else if ((iCol + i) == 4)
                                    {
                                        calibrationUnit[new Tuple<String, int, int>(pn, ii, jj)] = string.Format("{0}", oCell.Value);
                                    }

                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        iRow++;
                    }
                    else
                    {
                        break;
                    }
                }
                Clipboard.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("The data you pasted is in the wrong format for the cell");
                return;
            }
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.C:
                            CopyToClipboard();
                            break;

                        case Keys.V:
                            PasteClipboard();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy/paste operation failed. " + ex.Message, "Copy/Paste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btPaste_Click(object sender, EventArgs e)
        {
            try
            {
                PasteClipboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy/paste operation failed. " + ex.Message, "Copy/Paste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isWriting)
            {
                Recoording_click();

                string FileName = btLocation.Text;
                string extension = FileName.Split('.').Last();
                string baseName = FileName.TrimEnd(extension.ToCharArray()).TrimEnd('.');



                string tbr = string.Empty;

                if (baseName.Split('_').Count() > 1)
                {
                    tbr = baseName.Split('_').Last();
                }
                string newName = baseName.TrimEnd(tbr.ToCharArray()).TrimEnd('_');
                DateTime dt = DateTime.Now;
                //Textinfo = new UTF8Encoding(true).GetBytes(string.Format("{0}/{1:00}/{2} {3}:{4}:{5:0.000}\t", dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute, dt.Second + (double)dt.Millisecond / 1000.0));
                string tba = string.Format("{0:0000}{1:00}{2:00}{3:00}{4:00}{5:00}",dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second );

                newName = string.Format("{0}_{1}.{2}", newName, tba, extension);
                btLocation.Text = newName;

                Recoording_click();
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!serialSelectionChanging)
                {
                    String pn = String.Format("{0}", serialList[currentSerialSelection]);

                    nbDataPerTCA[pn] = Convert.ToInt32(numericUpDown1.Value);
                    updateCalibrationGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR Exception: " + ex.Message, "ERROR Exception:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
    }
}
