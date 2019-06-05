namespace ArDAQ
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btStart = new System.Windows.Forms.Button();
            this.boxOut = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btPorts = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btTCPServerStop = new System.Windows.Forms.Button();
            this.btTCPServerStart = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btLoad = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btUp = new System.Windows.Forms.Button();
            this.btDown = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.ConnectedARDAQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbEntry = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lbNbDataperTCA = new System.Windows.Forms.Label();
            this.entryList = new System.Windows.Forms.CheckedListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btS3 = new System.Windows.Forms.Button();
            this.checkBoxAppend = new System.Windows.Forms.CheckBox();
            this.checkBoxHeader = new System.Windows.Forms.CheckBox();
            this.ckReccording = new System.Windows.Forms.CheckBox();
            this.labelsampling = new System.Windows.Forms.Label();
            this.tbSampling = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btLocation = new System.Windows.Forms.Button();
            this.Calibration = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ArduinoLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A_coef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B_coef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.EntryMonitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabelMonitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueMonitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitMonitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.backgroundWorkerTCP = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.gbEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.Calibration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStart.Location = new System.Drawing.Point(592, 54);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(62, 23);
            this.btStart.TabIndex = 7;
            this.btStart.Text = "Connect";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // boxOut
            // 
            this.boxOut.BackColor = System.Drawing.SystemColors.Window;
            this.boxOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxOut.Location = new System.Drawing.Point(0, 0);
            this.boxOut.Multiline = true;
            this.boxOut.Name = "boxOut";
            this.boxOut.ReadOnly = true;
            this.boxOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.boxOut.Size = new System.Drawing.Size(742, 78);
            this.boxOut.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(145, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 24);
            this.comboBox1.TabIndex = 14;
            // 
            // btPorts
            // 
            this.btPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPorts.Location = new System.Drawing.Point(15, 56);
            this.btPorts.Name = "btPorts";
            this.btPorts.Size = new System.Drawing.Size(99, 23);
            this.btPorts.TabIndex = 15;
            this.btPorts.Text = "get ports";
            this.btPorts.UseVisualStyleBackColor = true;
            this.btPorts.Click += new System.EventHandler(this.btPorts_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.Calibration);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(742, 379);
            this.tabControl1.TabIndex = 24;
            this.tabControl1.Tag = "";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.splitContainer4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(734, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Setup & Control";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer5);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox6);
            this.splitContainer4.Size = new System.Drawing.Size(728, 344);
            this.splitContainer4.SplitterDistance = 260;
            this.splitContainer4.TabIndex = 35;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer5.Size = new System.Drawing.Size(728, 260);
            this.splitContainer5.SplitterDistance = 93;
            this.splitContainer5.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btTCPServerStop);
            this.groupBox2.Controls.Add(this.btTCPServerStart);
            this.groupBox2.Controls.Add(this.btAdd);
            this.groupBox2.Controls.Add(this.btSave);
            this.groupBox2.Controls.Add(this.btLoad);
            this.groupBox2.Controls.Add(this.btStop);
            this.groupBox2.Controls.Add(this.btPorts);
            this.groupBox2.Controls.Add(this.btStart);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(728, 93);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General Setup";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btTCPServerStop
            // 
            this.btTCPServerStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTCPServerStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTCPServerStop.Location = new System.Drawing.Point(612, 19);
            this.btTCPServerStop.Name = "btTCPServerStop";
            this.btTCPServerStop.Size = new System.Drawing.Size(111, 23);
            this.btTCPServerStop.TabIndex = 21;
            this.btTCPServerStop.Text = "Stop TCP Server";
            this.btTCPServerStop.UseVisualStyleBackColor = true;
            this.btTCPServerStop.Click += new System.EventHandler(this.btTCPServerStop_Click);
            // 
            // btTCPServerStart
            // 
            this.btTCPServerStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTCPServerStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTCPServerStart.Location = new System.Drawing.Point(495, 21);
            this.btTCPServerStart.Name = "btTCPServerStart";
            this.btTCPServerStart.Size = new System.Drawing.Size(111, 23);
            this.btTCPServerStart.TabIndex = 20;
            this.btTCPServerStart.Text = "Start TCP Server";
            this.btTCPServerStart.UseVisualStyleBackColor = true;
            this.btTCPServerStart.Click += new System.EventHandler(this.btTCPServerStart_Click);
            // 
            // btAdd
            // 
            this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdd.Location = new System.Drawing.Point(279, 54);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(62, 23);
            this.btAdd.TabIndex = 19;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btSave
            // 
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSave.Location = new System.Drawing.Point(145, 19);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(99, 23);
            this.btSave.TabIndex = 18;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btLoad
            // 
            this.btLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLoad.Location = new System.Drawing.Point(15, 21);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(99, 23);
            this.btLoad.TabIndex = 17;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStop.Location = new System.Drawing.Point(660, 54);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(62, 23);
            this.btStop.TabIndex = 16;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.splitContainer7);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.gbEntry);
            this.splitContainer6.Size = new System.Drawing.Size(728, 163);
            this.splitContainer6.SplitterDistance = 457;
            this.splitContainer6.TabIndex = 34;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.dataGridView3);
            this.splitContainer7.Size = new System.Drawing.Size(457, 163);
            this.splitContainer7.SplitterDistance = 53;
            this.splitContainer7.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btUp);
            this.flowLayoutPanel1.Controls.Add(this.btDown);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(53, 163);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btUp
            // 
            this.btUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUp.Location = new System.Drawing.Point(3, 3);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(47, 23);
            this.btUp.TabIndex = 0;
            this.btUp.Text = "Up";
            this.btUp.UseVisualStyleBackColor = true;
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // btDown
            // 
            this.btDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDown.Location = new System.Drawing.Point(3, 32);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(47, 23);
            this.btDown.TabIndex = 1;
            this.btDown.Text = "Down";
            this.btDown.UseVisualStyleBackColor = true;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConnectedARDAQ});
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(400, 163);
            this.dataGridView3.TabIndex = 0;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            this.dataGridView3.SelectionChanged += new System.EventHandler(this.dataGridView3_SelectionChanged);
            this.dataGridView3.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView3_UserDeletingRow);
            // 
            // ConnectedARDAQ
            // 
            this.ConnectedARDAQ.HeaderText = "Connected ArDAQ";
            this.ConnectedARDAQ.Name = "ConnectedARDAQ";
            this.ConnectedARDAQ.ReadOnly = true;
            this.ConnectedARDAQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gbEntry
            // 
            this.gbEntry.Controls.Add(this.numericUpDown1);
            this.gbEntry.Controls.Add(this.lbNbDataperTCA);
            this.gbEntry.Controls.Add(this.entryList);
            this.gbEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEntry.Location = new System.Drawing.Point(0, 0);
            this.gbEntry.Name = "gbEntry";
            this.gbEntry.Size = new System.Drawing.Size(267, 163);
            this.gbEntry.TabIndex = 33;
            this.gbEntry.TabStop = false;
            this.gbEntry.Text = "Entry Configuration";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(129, 37);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(80, 22);
            this.numericUpDown1.TabIndex = 34;
            this.numericUpDown1.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // lbNbDataperTCA
            // 
            this.lbNbDataperTCA.AutoSize = true;
            this.lbNbDataperTCA.Location = new System.Drawing.Point(127, 19);
            this.lbNbDataperTCA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNbDataperTCA.Name = "lbNbDataperTCA";
            this.lbNbDataperTCA.Size = new System.Drawing.Size(162, 17);
            this.lbNbDataperTCA.TabIndex = 33;
            this.lbNbDataperTCA.Text = "Number of data per TCA";
            // 
            // entryList
            // 
            this.entryList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.entryList.FormattingEnabled = true;
            this.entryList.Items.AddRange(new object[] {
            "TCA entry 0",
            "TCA entry 1",
            "TCA entry 2",
            "TCA entry 3",
            "TCA entry 4",
            "TCA entry 5",
            "TCA entry 6",
            "TCA entry 7"});
            this.entryList.Location = new System.Drawing.Point(15, 25);
            this.entryList.Name = "entryList";
            this.entryList.Size = new System.Drawing.Size(110, 136);
            this.entryList.TabIndex = 32;
            this.entryList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.entryList_ItemCheck_1);
            this.entryList.SelectedIndexChanged += new System.EventHandler(this.entryList_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btS3);
            this.groupBox6.Controls.Add(this.checkBoxAppend);
            this.groupBox6.Controls.Add(this.checkBoxHeader);
            this.groupBox6.Controls.Add(this.ckReccording);
            this.groupBox6.Controls.Add(this.labelsampling);
            this.groupBox6.Controls.Add(this.tbSampling);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.btLocation);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(728, 80);
            this.groupBox6.TabIndex = 34;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Acquisition";
            // 
            // btS3
            // 
            this.btS3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btS3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btS3.Location = new System.Drawing.Point(651, 15);
            this.btS3.Name = "btS3";
            this.btS3.Size = new System.Drawing.Size(72, 23);
            this.btS3.TabIndex = 22;
            this.btS3.Text = "S³";
            this.btS3.UseVisualStyleBackColor = true;
            this.btS3.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxAppend
            // 
            this.checkBoxAppend.AutoSize = true;
            this.checkBoxAppend.Location = new System.Drawing.Point(446, 49);
            this.checkBoxAppend.Name = "checkBoxAppend";
            this.checkBoxAppend.Size = new System.Drawing.Size(101, 21);
            this.checkBoxAppend.TabIndex = 34;
            this.checkBoxAppend.Text = "Append file";
            this.checkBoxAppend.UseVisualStyleBackColor = true;
            this.checkBoxAppend.CheckStateChanged += new System.EventHandler(this.checkBoxAppend_CheckStateChanged);
            // 
            // checkBoxHeader
            // 
            this.checkBoxHeader.AutoSize = true;
            this.checkBoxHeader.Checked = true;
            this.checkBoxHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHeader.Location = new System.Drawing.Point(446, 25);
            this.checkBoxHeader.Name = "checkBoxHeader";
            this.checkBoxHeader.Size = new System.Drawing.Size(108, 21);
            this.checkBoxHeader.TabIndex = 33;
            this.checkBoxHeader.Text = "Print header";
            this.checkBoxHeader.UseVisualStyleBackColor = true;
            // 
            // ckReccording
            // 
            this.ckReccording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckReccording.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckReccording.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ckReccording.Location = new System.Drawing.Point(651, 43);
            this.ckReccording.Name = "ckReccording";
            this.ckReccording.Size = new System.Drawing.Size(72, 23);
            this.ckReccording.TabIndex = 32;
            this.ckReccording.Text = "Reccording";
            this.ckReccording.UseVisualStyleBackColor = true;
            this.ckReccording.CheckedChanged += new System.EventHandler(this.ckReccording_CheckedChanged);
            this.ckReccording.Click += new System.EventHandler(this.ckReccording_Click);
            // 
            // labelsampling
            // 
            this.labelsampling.AutoSize = true;
            this.labelsampling.Location = new System.Drawing.Point(310, 25);
            this.labelsampling.Name = "labelsampling";
            this.labelsampling.Size = new System.Drawing.Size(85, 17);
            this.labelsampling.TabIndex = 31;
            this.labelsampling.Text = "Sampling [s]";
            // 
            // tbSampling
            // 
            this.tbSampling.Location = new System.Drawing.Point(309, 46);
            this.tbSampling.Name = "tbSampling";
            this.tbSampling.Size = new System.Drawing.Size(65, 22);
            this.tbSampling.TabIndex = 30;
            this.tbSampling.Text = "1.0";
            this.tbSampling.TextChanged += new System.EventHandler(this.tbSampling_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "location :";
            // 
            // btLocation
            // 
            this.btLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLocation.Location = new System.Drawing.Point(6, 43);
            this.btLocation.Name = "btLocation";
            this.btLocation.Size = new System.Drawing.Size(273, 23);
            this.btLocation.TabIndex = 0;
            this.btLocation.Text = "no file";
            this.btLocation.UseVisualStyleBackColor = true;
            this.btLocation.Click += new System.EventHandler(this.btLocation_Click);
            // 
            // Calibration
            // 
            this.Calibration.Controls.Add(this.dataGridView1);
            this.Calibration.Location = new System.Drawing.Point(4, 25);
            this.Calibration.Name = "Calibration";
            this.Calibration.Size = new System.Drawing.Size(734, 350);
            this.Calibration.TabIndex = 2;
            this.Calibration.Text = "Calibration";
            this.Calibration.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ArduinoLabel,
            this.label,
            this.A_coef,
            this.B_coef,
            this.Unit});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Size = new System.Drawing.Size(734, 350);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // ArduinoLabel
            // 
            this.ArduinoLabel.HeaderText = "Entry";
            this.ArduinoLabel.Name = "ArduinoLabel";
            this.ArduinoLabel.ReadOnly = true;
            // 
            // label
            // 
            this.label.HeaderText = "Label";
            this.label.Name = "label";
            // 
            // A_coef
            // 
            this.A_coef.HeaderText = "A";
            this.A_coef.Name = "A_coef";
            // 
            // B_coef
            // 
            this.B_coef.HeaderText = "B";
            this.B_coef.Name = "B_coef";
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(734, 350);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Monitoring";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntryMonitor,
            this.LabelMonitor,
            this.ValueMonitor,
            this.UnitMonitor});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Size = new System.Drawing.Size(734, 350);
            this.dataGridView2.TabIndex = 0;
            // 
            // EntryMonitor
            // 
            this.EntryMonitor.HeaderText = "Entry";
            this.EntryMonitor.Name = "EntryMonitor";
            this.EntryMonitor.ReadOnly = true;
            this.EntryMonitor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LabelMonitor
            // 
            this.LabelMonitor.HeaderText = "Label";
            this.LabelMonitor.Name = "LabelMonitor";
            this.LabelMonitor.ReadOnly = true;
            this.LabelMonitor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ValueMonitor
            // 
            this.ValueMonitor.HeaderText = "Value";
            this.ValueMonitor.Name = "ValueMonitor";
            this.ValueMonitor.ReadOnly = true;
            this.ValueMonitor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UnitMonitor
            // 
            this.UnitMonitor.HeaderText = "Unit";
            this.UnitMonitor.Name = "UnitMonitor";
            this.UnitMonitor.ReadOnly = true;
            this.UnitMonitor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Title = "Set the saving file location";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AutoScroll = true;
            this.splitContainer3.Panel2.Controls.Add(this.boxOut);
            this.splitContainer3.Size = new System.Drawing.Size(742, 461);
            this.splitContainer3.SplitterDistance = 379;
            this.splitContainer3.TabIndex = 25;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // serialPort2
            // 
            this.serialPort2.BaudRate = 115200;
            this.serialPort2.DtrEnable = true;
            this.serialPort2.PortName = "COM11";
            this.serialPort2.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort1_ErrorReceived);
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // backgroundWorkerTCP
            // 
            this.backgroundWorkerTCP.WorkerSupportsCancellation = true;
            this.backgroundWorkerTCP.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTCP_DoWork);
            this.backgroundWorkerTCP.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTCP_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(742, 461);
            this.Controls.Add(this.splitContainer3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ArduinoDAQ Control & Monitoring v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.gbEntry.ResumeLayout(false);
            this.gbEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.Calibration.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TextBox boxOut;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btPorts;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelsampling;
        private System.Windows.Forms.TextBox tbSampling;
        private System.Windows.Forms.CheckedListBox entryList;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox gbEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btLocation;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage Calibration;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArduinoLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn label;
        private System.Windows.Forms.DataGridViewTextBoxColumn A_coef;
        private System.Windows.Forms.DataGridViewTextBoxColumn B_coef;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn LabelMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitMonitor;
        private System.Windows.Forms.CheckBox ckReccording;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.CheckBox checkBoxAppend;
        private System.Windows.Forms.CheckBox checkBoxHeader;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConnectedARDAQ;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btUp;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Button btTCPServerStop;
        private System.Windows.Forms.Button btTCPServerStart;
        public System.ComponentModel.BackgroundWorker backgroundWorkerTCP;
        private System.Windows.Forms.Button btS3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lbNbDataperTCA;
    }
}