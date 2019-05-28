namespace Ajoor
{
    partial class SuperAdminMonthlyView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperAdminMonthlyView));
            this.dtp_End = new System.Windows.Forms.DateTimePicker();
            this.lb_Total = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_Start = new System.Windows.Forms.DateTimePicker();
            this.txt_TotalAmountPayable = new System.Windows.Forms.TextBox();
            this.txt_TotalCommission = new System.Windows.Forms.TextBox();
            this.txt_TotalDebit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_TotalCredit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.printSummary = new System.Drawing.Printing.PrintDocument();
            this.btnEClear = new System.Windows.Forms.Button();
            this.btnEGo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_Subadmin = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_Go = new System.Windows.Forms.Button();
            this.bgw_PullReport_DatesOnly = new System.ComponentModel.BackgroundWorker();
            this.dgv_SummaryMonthlyView = new System.Windows.Forms.DataGridView();
            this.bgw_PullReport_DatesAndSubadminOnly = new System.ComponentModel.BackgroundWorker();
            this.bgw_SubAdmin = new System.ComponentModel.BackgroundWorker();
            this.txt_TotalDebt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bgw_PullData = new System.ComponentModel.BackgroundWorker();
            this.chkUseDate = new System.Windows.Forms.CheckBox();
            this.txt_TotalExtraCommission = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bgw_PullReport_SubAdminOnly = new System.ComponentModel.BackgroundWorker();
            this.cmb_Customers = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bgw_PullReport_CustomerOnly = new System.ComponentModel.BackgroundWorker();
            this.bgw_PullReport_SubAdminAndCustomerOnly = new System.ComponentModel.BackgroundWorker();
            this.bgw_PullReport_DatesAndSubAdminAndCustomerOnly = new System.ComponentModel.BackgroundWorker();
            this.bgw_DatesAndCustomerOnly = new System.ComponentModel.BackgroundWorker();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SummaryMonthlyView)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp_End
            // 
            this.dtp_End.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_End.Location = new System.Drawing.Point(85, 42);
            this.dtp_End.Name = "dtp_End";
            this.dtp_End.Size = new System.Drawing.Size(241, 21);
            this.dtp_End.TabIndex = 33;
            // 
            // lb_Total
            // 
            this.lb_Total.AutoSize = true;
            this.lb_Total.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Total.Location = new System.Drawing.Point(195, 198);
            this.lb_Total.Name = "lb_Total";
            this.lb_Total.Size = new System.Drawing.Size(9, 19);
            this.lb_Total.TabIndex = 138;
            this.lb_Total.Text = "\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 19);
            this.label5.TabIndex = 137;
            this.label5.Text = "Total number of records:";
            // 
            // dtp_Start
            // 
            this.dtp_Start.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Start.Location = new System.Drawing.Point(85, 15);
            this.dtp_Start.Name = "dtp_Start";
            this.dtp_Start.Size = new System.Drawing.Size(241, 21);
            this.dtp_Start.TabIndex = 32;
            // 
            // txt_TotalAmountPayable
            // 
            this.txt_TotalAmountPayable.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalAmountPayable.Location = new System.Drawing.Point(15, 163);
            this.txt_TotalAmountPayable.Name = "txt_TotalAmountPayable";
            this.txt_TotalAmountPayable.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalAmountPayable.TabIndex = 146;
            // 
            // txt_TotalCommission
            // 
            this.txt_TotalCommission.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalCommission.Location = new System.Drawing.Point(527, 111);
            this.txt_TotalCommission.Name = "txt_TotalCommission";
            this.txt_TotalCommission.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalCommission.TabIndex = 145;
            // 
            // txt_TotalDebit
            // 
            this.txt_TotalDebit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalDebit.Location = new System.Drawing.Point(271, 111);
            this.txt_TotalDebit.Name = "txt_TotalDebit";
            this.txt_TotalDebit.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalDebit.TabIndex = 144;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(523, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 19);
            this.label2.TabIndex = 143;
            this.label2.Text = "Total Commission";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 19);
            this.label3.TabIndex = 142;
            this.label3.Text = "Total Credit";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 19);
            this.label7.TabIndex = 141;
            this.label7.Text = "Total Savings";
            // 
            // txt_TotalCredit
            // 
            this.txt_TotalCredit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalCredit.Location = new System.Drawing.Point(15, 111);
            this.txt_TotalCredit.Name = "txt_TotalCredit";
            this.txt_TotalCredit.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalCredit.TabIndex = 140;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(14, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 14);
            this.label8.TabIndex = 30;
            this.label8.Text = "Start Date";
            // 
            // printSummary
            // 
            this.printSummary.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printSummary_BeginPrint);
            this.printSummary.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printSummary_PrintPage);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(267, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 19);
            this.label4.TabIndex = 139;
            this.label4.Text = "Total Withdrawal";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Location = new System.Drawing.Point(7, 215);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(142, 59);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 39);
            this.label1.TabIndex = 136;
            this.label1.Text = "Summary (Compact View)";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.cmb_Customers);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmb_Subadmin);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dtp_Start);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.dtp_End);
            this.groupBox2.Controls.Add(this.btnEClear);
            this.groupBox2.Controls.Add(this.btnEGo);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(371, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(662, 74);
            this.groupBox2.TabIndex = 133;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // cmb_Subadmin
            // 
            this.cmb_Subadmin.FormattingEnabled = true;
            this.cmb_Subadmin.Location = new System.Drawing.Point(407, 17);
            this.cmb_Subadmin.Name = "cmb_Subadmin";
            this.cmb_Subadmin.Size = new System.Drawing.Size(237, 22);
            this.cmb_Subadmin.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(332, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 14);
            this.label12.TabIndex = 34;
            this.label12.Text = "Sub admin";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(14, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 14);
            this.label13.TabIndex = 31;
            this.label13.Text = "End Start";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btn_Print);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Go);
            this.panel1.Location = new System.Drawing.Point(955, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 289);
            this.panel1.TabIndex = 135;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.Red;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(7, 150);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(142, 59);
            this.btnView.TabIndex = 150;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.BackColor = System.Drawing.Color.Green;
            this.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.ForeColor = System.Drawing.Color.White;
            this.btn_Print.Location = new System.Drawing.Point(7, 85);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(142, 59);
            this.btn_Print.TabIndex = 149;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = false;
            this.btn_Print.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btn_Go
            // 
            this.btn_Go.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_Go.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Go.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Go.ForeColor = System.Drawing.Color.White;
            this.btn_Go.Location = new System.Drawing.Point(7, 20);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(142, 59);
            this.btn_Go.TabIndex = 0;
            this.btn_Go.Text = "Filter";
            this.btn_Go.UseVisualStyleBackColor = false;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // bgw_PullReport_DatesOnly
            // 
            this.bgw_PullReport_DatesOnly.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullReport_DatesOnly_DoWork);
            // 
            // dgv_SummaryMonthlyView
            // 
            this.dgv_SummaryMonthlyView.AllowUserToAddRows = false;
            this.dgv_SummaryMonthlyView.AllowUserToDeleteRows = false;
            this.dgv_SummaryMonthlyView.AllowUserToResizeRows = false;
            this.dgv_SummaryMonthlyView.BackgroundColor = System.Drawing.Color.White;
            this.dgv_SummaryMonthlyView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SummaryMonthlyView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_SummaryMonthlyView.Location = new System.Drawing.Point(15, 222);
            this.dgv_SummaryMonthlyView.Name = "dgv_SummaryMonthlyView";
            this.dgv_SummaryMonthlyView.ReadOnly = true;
            this.dgv_SummaryMonthlyView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_SummaryMonthlyView.Size = new System.Drawing.Size(934, 400);
            this.dgv_SummaryMonthlyView.TabIndex = 134;
            // 
            // bgw_PullReport_DatesAndSubadminOnly
            // 
            this.bgw_PullReport_DatesAndSubadminOnly.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullReport_DatesAndSubadminOnly_DoWork);
            // 
            // bgw_SubAdmin
            // 
            this.bgw_SubAdmin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwg_SubAdmin_DoWork);
            // 
            // txt_TotalDebt
            // 
            this.txt_TotalDebt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalDebt.Location = new System.Drawing.Point(271, 163);
            this.txt_TotalDebt.Name = "txt_TotalDebt";
            this.txt_TotalDebt.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalDebt.TabIndex = 148;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(267, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 19);
            this.label6.TabIndex = 147;
            this.label6.Text = "Total Debt";
            // 
            // bgw_PullData
            // 
            this.bgw_PullData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullData_DoWork);
            // 
            // chkUseDate
            // 
            this.chkUseDate.AutoSize = true;
            this.chkUseDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseDate.Location = new System.Drawing.Point(527, 165);
            this.chkUseDate.Name = "chkUseDate";
            this.chkUseDate.Size = new System.Drawing.Size(271, 23);
            this.chkUseDate.TabIndex = 149;
            this.chkUseDate.Text = "Use selected dates to filter records?";
            this.chkUseDate.UseVisualStyleBackColor = true;
            // 
            // txt_TotalExtraCommission
            // 
            this.txt_TotalExtraCommission.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalExtraCommission.Location = new System.Drawing.Point(787, 111);
            this.txt_TotalExtraCommission.Name = "txt_TotalExtraCommission";
            this.txt_TotalExtraCommission.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalExtraCommission.TabIndex = 151;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(783, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 19);
            this.label9.TabIndex = 150;
            this.label9.Text = "Total Extra Commission";
            // 
            // bgw_PullReport_SubAdminOnly
            // 
            this.bgw_PullReport_SubAdminOnly.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullReport_SubAdminOnly_DoWork);
            // 
            // cmb_Customers
            // 
            this.cmb_Customers.FormattingEnabled = true;
            this.cmb_Customers.Location = new System.Drawing.Point(407, 44);
            this.cmb_Customers.Name = "cmb_Customers";
            this.cmb_Customers.Size = new System.Drawing.Size(237, 22);
            this.cmb_Customers.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(332, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 14);
            this.label10.TabIndex = 36;
            this.label10.Text = "Customers";
            // 
            // bgw_PullReport_CustomerOnly
            // 
            this.bgw_PullReport_CustomerOnly.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullReport_CustomerOnly_DoWork);
            // 
            // bgw_PullReport_SubAdminAndCustomerOnly
            // 
            this.bgw_PullReport_SubAdminAndCustomerOnly.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullReport_SubAdminAndCustomerOnly_DoWork);
            // 
            // bgw_PullReport_DatesAndSubAdminAndCustomerOnly
            // 
            this.bgw_PullReport_DatesAndSubAdminAndCustomerOnly.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullReport_DatesAndSubAdminAndCustomerOnly_DoWork);
            // 
            // bgw_DatesAndCustomerOnly
            // 
            this.bgw_DatesAndCustomerOnly.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DatesAndCustomerOnly_DoWork);
            // 
            // SuperAdminMonthlyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1114, 661);
            this.Controls.Add(this.txt_TotalExtraCommission);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkUseDate);
            this.Controls.Add(this.txt_TotalDebt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_Total);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_TotalAmountPayable);
            this.Controls.Add(this.txt_TotalCommission);
            this.Controls.Add(this.txt_TotalDebit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_TotalCredit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_SummaryMonthlyView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuperAdminMonthlyView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Superior Investment: Monthly View";
            this.Load += new System.EventHandler(this.SuperAdminMonthlyView_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SummaryMonthlyView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_End;
        private System.Windows.Forms.Label lb_Total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_Start;
        private System.Windows.Forms.TextBox txt_TotalAmountPayable;
        private System.Windows.Forms.TextBox txt_TotalCommission;
        private System.Windows.Forms.TextBox txt_TotalDebit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_TotalCredit;
        private System.Windows.Forms.Label label8;
        private System.Drawing.Printing.PrintDocument printSummary;
        private System.Windows.Forms.Button btnEClear;
        private System.Windows.Forms.Button btnEGo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Go;
        private System.ComponentModel.BackgroundWorker bgw_PullReport_DatesOnly;
        private System.Windows.Forms.DataGridView dgv_SummaryMonthlyView;
        private System.Windows.Forms.ComboBox cmb_Subadmin;
        private System.Windows.Forms.Label label12;
        private System.ComponentModel.BackgroundWorker bgw_PullReport_DatesAndSubadminOnly;
        private System.ComponentModel.BackgroundWorker bgw_SubAdmin;
        private System.Windows.Forms.TextBox txt_TotalDebt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Print;
        private System.ComponentModel.BackgroundWorker bgw_PullData;
        private System.Windows.Forms.CheckBox chkUseDate;
        private System.Windows.Forms.TextBox txt_TotalExtraCommission;
        private System.Windows.Forms.Label label9;
        private System.ComponentModel.BackgroundWorker bgw_PullReport_SubAdminOnly;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox cmb_Customers;
        private System.Windows.Forms.Label label10;
        private System.ComponentModel.BackgroundWorker bgw_PullReport_CustomerOnly;
        private System.ComponentModel.BackgroundWorker bgw_PullReport_SubAdminAndCustomerOnly;
        private System.ComponentModel.BackgroundWorker bgw_PullReport_DatesAndSubAdminAndCustomerOnly;
        private System.ComponentModel.BackgroundWorker bgw_DatesAndCustomerOnly;
    }
}