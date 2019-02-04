namespace Ajoor
{
    partial class SuperAdminBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperAdminBalance));
            this.lb_TotalRecordsReceived = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bwg_PullReport_Received = new System.ComponentModel.BackgroundWorker();
            this.txt_TotalPayment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_TotalBalanceReceived = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Go = new System.Windows.Forms.Button();
            this.dgv_Received = new System.Windows.Forms.DataGridView();
            this.printSummary = new System.Drawing.Printing.PrintDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_PullRecordsForSuperAdmin = new System.Windows.Forms.Button();
            this.bwg_PullReports_Payment = new System.ComponentModel.BackgroundWorker();
            this.dgv_Payment = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_TotalRecordsPaid = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEClear = new System.Windows.Forms.Button();
            this.btnEGo = new System.Windows.Forms.Button();
            this.cmb_Subadmin = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtp_End = new System.Windows.Forms.DateTimePicker();
            this.dtp_Start = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.bwg_SubAdmin = new System.ComponentModel.BackgroundWorker();
            this.bgw_PullReportsForSuperAdmin_Received = new System.ComponentModel.BackgroundWorker();
            this.bgw_PullReportsForSuperAdmin_Payment = new System.ComponentModel.BackgroundWorker();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Shortage = new System.Windows.Forms.TextBox();
            this.txt_PhysicalCash = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_TotalBalancePayment = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_TotalReceived = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Received)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Payment)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_TotalRecordsReceived
            // 
            this.lb_TotalRecordsReceived.AutoSize = true;
            this.lb_TotalRecordsReceived.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TotalRecordsReceived.Location = new System.Drawing.Point(197, 245);
            this.lb_TotalRecordsReceived.Name = "lb_TotalRecordsReceived";
            this.lb_TotalRecordsReceived.Size = new System.Drawing.Size(9, 19);
            this.lb_TotalRecordsReceived.TabIndex = 124;
            this.lb_TotalRecordsReceived.Text = "\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 19);
            this.label5.TabIndex = 123;
            this.label5.Text = "Total number of records:";
            // 
            // bwg_PullReport_Received
            // 
            this.bwg_PullReport_Received.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwg_PullReport_Received_DoWork);
            // 
            // txt_TotalPayment
            // 
            this.txt_TotalPayment.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalPayment.Location = new System.Drawing.Point(613, 207);
            this.txt_TotalPayment.Name = "txt_TotalPayment";
            this.txt_TotalPayment.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalPayment.TabIndex = 132;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(609, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 19);
            this.label3.TabIndex = 128;
            this.label3.Text = "Total Payment";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 19);
            this.label7.TabIndex = 127;
            this.label7.Text = "Total Balance";
            // 
            // txt_TotalBalanceReceived
            // 
            this.txt_TotalBalanceReceived.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalBalanceReceived.Location = new System.Drawing.Point(16, 146);
            this.txt_TotalBalanceReceived.Name = "txt_TotalBalanceReceived";
            this.txt_TotalBalanceReceived.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalBalanceReceived.TabIndex = 126;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 39);
            this.label1.TabIndex = 122;
            this.label1.Text = "Balance Ledger";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Location = new System.Drawing.Point(3, 145);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(142, 59);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Go
            // 
            this.btn_Go.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_Go.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Go.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Go.ForeColor = System.Drawing.Color.White;
            this.btn_Go.Location = new System.Drawing.Point(5, 20);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(142, 59);
            this.btn_Go.TabIndex = 0;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = false;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // dgv_Received
            // 
            this.dgv_Received.AllowUserToAddRows = false;
            this.dgv_Received.AllowUserToDeleteRows = false;
            this.dgv_Received.AllowUserToResizeRows = false;
            this.dgv_Received.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Received.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Received.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Received.Location = new System.Drawing.Point(15, 267);
            this.dgv_Received.Name = "dgv_Received";
            this.dgv_Received.ReadOnly = true;
            this.dgv_Received.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Received.Size = new System.Drawing.Size(579, 444);
            this.dgv_Received.TabIndex = 120;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_PullRecordsForSuperAdmin);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Go);
            this.panel1.Location = new System.Drawing.Point(1199, 267);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 219);
            this.panel1.TabIndex = 121;
            // 
            // btn_PullRecordsForSuperAdmin
            // 
            this.btn_PullRecordsForSuperAdmin.BackColor = System.Drawing.Color.Green;
            this.btn_PullRecordsForSuperAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PullRecordsForSuperAdmin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PullRecordsForSuperAdmin.ForeColor = System.Drawing.Color.White;
            this.btn_PullRecordsForSuperAdmin.Location = new System.Drawing.Point(5, 80);
            this.btn_PullRecordsForSuperAdmin.Name = "btn_PullRecordsForSuperAdmin";
            this.btn_PullRecordsForSuperAdmin.Size = new System.Drawing.Size(142, 59);
            this.btn_PullRecordsForSuperAdmin.TabIndex = 4;
            this.btn_PullRecordsForSuperAdmin.Text = "Pull records for super admin";
            this.btn_PullRecordsForSuperAdmin.UseVisualStyleBackColor = false;
            this.btn_PullRecordsForSuperAdmin.Click += new System.EventHandler(this.btn_PullRecordsForSuperAdmin_Click);
            // 
            // bwg_PullReports_Payment
            // 
            this.bwg_PullReports_Payment.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwg_PullReport_Payment_DoWork);
            // 
            // dgv_Payment
            // 
            this.dgv_Payment.AllowUserToAddRows = false;
            this.dgv_Payment.AllowUserToDeleteRows = false;
            this.dgv_Payment.AllowUserToResizeRows = false;
            this.dgv_Payment.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Payment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Payment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Payment.Location = new System.Drawing.Point(613, 267);
            this.dgv_Payment.Name = "dgv_Payment";
            this.dgv_Payment.ReadOnly = true;
            this.dgv_Payment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Payment.Size = new System.Drawing.Size(579, 444);
            this.dgv_Payment.TabIndex = 133;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(274, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 39);
            this.label6.TabIndex = 136;
            this.label6.Text = "RECEIVED";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(742, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 39);
            this.label2.TabIndex = 137;
            this.label2.Text = "PAYMENT";
            // 
            // lb_TotalRecordsPaid
            // 
            this.lb_TotalRecordsPaid.AutoSize = true;
            this.lb_TotalRecordsPaid.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TotalRecordsPaid.Location = new System.Drawing.Point(793, 245);
            this.lb_TotalRecordsPaid.Name = "lb_TotalRecordsPaid";
            this.lb_TotalRecordsPaid.Size = new System.Drawing.Size(9, 19);
            this.lb_TotalRecordsPaid.TabIndex = 139;
            this.lb_TotalRecordsPaid.Text = "\r\n";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(609, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 19);
            this.label9.TabIndex = 138;
            this.label9.Text = "Total number of records:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btnEClear);
            this.groupBox2.Controls.Add(this.btnEGo);
            this.groupBox2.Controls.Add(this.cmb_Subadmin);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dtp_End);
            this.groupBox2.Controls.Add(this.dtp_Start);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(1013, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 91);
            this.groupBox2.TabIndex = 140;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // btnEClear
            // 
            this.btnEClear.BackColor = System.Drawing.Color.DarkGray;
            this.btnEClear.FlatAppearance.BorderSize = 0;
            this.btnEClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEClear.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEClear.ForeColor = System.Drawing.Color.White;
            this.btnEClear.Location = new System.Drawing.Point(1245, 53);
            this.btnEClear.Name = "btnEClear";
            this.btnEClear.Size = new System.Drawing.Size(79, 34);
            this.btnEClear.TabIndex = 25;
            this.btnEClear.Text = "Clear!";
            this.btnEClear.UseVisualStyleBackColor = false;
            // 
            // btnEGo
            // 
            this.btnEGo.BackColor = System.Drawing.Color.Green;
            this.btnEGo.FlatAppearance.BorderSize = 0;
            this.btnEGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEGo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEGo.ForeColor = System.Drawing.Color.White;
            this.btnEGo.Location = new System.Drawing.Point(1245, 11);
            this.btnEGo.Name = "btnEGo";
            this.btnEGo.Size = new System.Drawing.Size(79, 34);
            this.btnEGo.TabIndex = 14;
            this.btnEGo.Text = "Go!";
            this.btnEGo.UseVisualStyleBackColor = false;
            // 
            // cmb_Subadmin
            // 
            this.cmb_Subadmin.FormattingEnabled = true;
            this.cmb_Subadmin.Location = new System.Drawing.Point(91, 62);
            this.cmb_Subadmin.Name = "cmb_Subadmin";
            this.cmb_Subadmin.Size = new System.Drawing.Size(241, 22);
            this.cmb_Subadmin.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "Start Date";
            // 
            // dtp_End
            // 
            this.dtp_End.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_End.Location = new System.Drawing.Point(91, 34);
            this.dtp_End.Name = "dtp_End";
            this.dtp_End.Size = new System.Drawing.Size(241, 21);
            this.dtp_End.TabIndex = 3;
            // 
            // dtp_Start
            // 
            this.dtp_Start.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Start.Location = new System.Drawing.Point(91, 10);
            this.dtp_Start.Name = "dtp_Start";
            this.dtp_Start.Size = new System.Drawing.Size(241, 21);
            this.dtp_Start.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(6, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 14);
            this.label12.TabIndex = 4;
            this.label12.Text = "Sub admin";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(6, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 14);
            this.label13.TabIndex = 1;
            this.label13.Text = "End Start";
            // 
            // bwg_SubAdmin
            // 
            this.bwg_SubAdmin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwg_SubAdmin_DoWork);
            // 
            // bgw_PullReportsForSuperAdmin_Received
            // 
            this.bgw_PullReportsForSuperAdmin_Received.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullReportsForSuperAdmin_Received_DoWork);
            // 
            // bgw_PullReportsForSuperAdmin_Payment
            // 
            this.bgw_PullReportsForSuperAdmin_Payment.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullReportsForSuperAdmin_Payment_DoWork);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(277, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 19);
            this.label10.TabIndex = 144;
            this.label10.Text = "Shortage";
            // 
            // txt_Shortage
            // 
            this.txt_Shortage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Shortage.Location = new System.Drawing.Point(281, 146);
            this.txt_Shortage.Name = "txt_Shortage";
            this.txt_Shortage.Size = new System.Drawing.Size(250, 27);
            this.txt_Shortage.TabIndex = 143;
            // 
            // txt_PhysicalCash
            // 
            this.txt_PhysicalCash.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PhysicalCash.Location = new System.Drawing.Point(879, 146);
            this.txt_PhysicalCash.Name = "txt_PhysicalCash";
            this.txt_PhysicalCash.Size = new System.Drawing.Size(250, 27);
            this.txt_PhysicalCash.TabIndex = 146;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(875, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 19);
            this.label11.TabIndex = 145;
            this.label11.Text = "Physical Cash";
            // 
            // txt_TotalBalancePayment
            // 
            this.txt_TotalBalancePayment.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalBalancePayment.Location = new System.Drawing.Point(613, 146);
            this.txt_TotalBalancePayment.Name = "txt_TotalBalancePayment";
            this.txt_TotalBalancePayment.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalBalancePayment.TabIndex = 148;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(609, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 19);
            this.label14.TabIndex = 147;
            this.label14.Text = "Total Balance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 19);
            this.label4.TabIndex = 150;
            this.label4.Text = "Total Received";
            // 
            // txt_TotalReceived
            // 
            this.txt_TotalReceived.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalReceived.Location = new System.Drawing.Point(18, 207);
            this.txt_TotalReceived.Name = "txt_TotalReceived";
            this.txt_TotalReceived.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalReceived.TabIndex = 149;
            // 
            // SuperAdminBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 718);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_TotalReceived);
            this.Controls.Add(this.txt_TotalBalancePayment);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_PhysicalCash);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_Shortage);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lb_TotalRecordsPaid);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgv_Payment);
            this.Controls.Add(this.lb_TotalRecordsReceived);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_TotalPayment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_TotalBalanceReceived);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Received);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuperAdminBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Superior Investment: Balance Ledger";
            this.Load += new System.EventHandler(this.SuperAdminBalance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Received)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Payment)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_TotalRecordsReceived;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker bwg_PullReport_Received;
        private System.Windows.Forms.TextBox txt_TotalPayment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_TotalBalanceReceived;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.DataGridView dgv_Received;
        private System.Drawing.Printing.PrintDocument printSummary;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker bwg_PullReports_Payment;
        private System.Windows.Forms.DataGridView dgv_Payment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_TotalRecordsPaid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEClear;
        private System.Windows.Forms.Button btnEGo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_Subadmin;
        private System.Windows.Forms.DateTimePicker dtp_Start;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtp_End;
        private System.ComponentModel.BackgroundWorker bwg_SubAdmin;
        private System.Windows.Forms.Button btn_PullRecordsForSuperAdmin;
        private System.ComponentModel.BackgroundWorker bgw_PullReportsForSuperAdmin_Received;
        private System.ComponentModel.BackgroundWorker bgw_PullReportsForSuperAdmin_Payment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Shortage;
        private System.Windows.Forms.TextBox txt_PhysicalCash;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_TotalBalancePayment;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_TotalReceived;
    }
}