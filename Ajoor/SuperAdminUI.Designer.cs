namespace Ajoor
{
    partial class SuperAdminUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperAdminUI));
            this.btn_CreateSubAdmin = new System.Windows.Forms.Button();
            this.panel_Controls = new System.Windows.Forms.Panel();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.btn_TransferCustomer = new System.Windows.Forms.Button();
            this.btn_CreateCustomer = new System.Windows.Forms.Button();
            this.btn_Summary = new System.Windows.Forms.Button();
            this.btn_Logout = new System.Windows.Forms.Button();
            this.btn_ExportRecords = new System.Windows.Forms.Button();
            this.btn_BalanceLedger = new System.Windows.Forms.Button();
            this.btn_ChangePassword = new System.Windows.Forms.Button();
            this.btn_Debit = new System.Windows.Forms.Button();
            this.btn_Credit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_LoggedIn = new System.Windows.Forms.Label();
            this.lb_Copyright = new System.Windows.Forms.Label();
            this.lb_Progress = new System.Windows.Forms.Label();
            this.bgwBackup = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_TotalSubAdmin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_TotalAmountCollected = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lb_TotalAmountContributed = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lb_TotalCustomers = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bgw_PullData = new System.ComponentModel.BackgroundWorker();
            this.bgw_EndOfMonthOperations = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_Controls.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_CreateSubAdmin
            // 
            this.btn_CreateSubAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_CreateSubAdmin.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_CreateSubAdmin.FlatAppearance.BorderSize = 0;
            this.btn_CreateSubAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateSubAdmin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CreateSubAdmin.ForeColor = System.Drawing.Color.White;
            this.btn_CreateSubAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CreateSubAdmin.Location = new System.Drawing.Point(3, 119);
            this.btn_CreateSubAdmin.Name = "btn_CreateSubAdmin";
            this.btn_CreateSubAdmin.Size = new System.Drawing.Size(293, 47);
            this.btn_CreateSubAdmin.TabIndex = 0;
            this.btn_CreateSubAdmin.Text = "Create Sub admin";
            this.btn_CreateSubAdmin.UseVisualStyleBackColor = false;
            this.btn_CreateSubAdmin.Click += new System.EventHandler(this.btn_CreateSubAdmin_Click);
            // 
            // panel_Controls
            // 
            this.panel_Controls.BackColor = System.Drawing.Color.Teal;
            this.panel_Controls.Controls.Add(this.btn_Settings);
            this.panel_Controls.Controls.Add(this.btn_TransferCustomer);
            this.panel_Controls.Controls.Add(this.btn_CreateSubAdmin);
            this.panel_Controls.Controls.Add(this.btn_CreateCustomer);
            this.panel_Controls.Controls.Add(this.btn_Summary);
            this.panel_Controls.Controls.Add(this.btn_Logout);
            this.panel_Controls.Controls.Add(this.btn_ExportRecords);
            this.panel_Controls.Controls.Add(this.label1);
            this.panel_Controls.Controls.Add(this.btn_BalanceLedger);
            this.panel_Controls.Controls.Add(this.btn_ChangePassword);
            this.panel_Controls.Controls.Add(this.btn_Debit);
            this.panel_Controls.Controls.Add(this.btn_Credit);
            this.panel_Controls.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Controls.Location = new System.Drawing.Point(0, 0);
            this.panel_Controls.Name = "panel_Controls";
            this.panel_Controls.Size = new System.Drawing.Size(299, 717);
            this.panel_Controls.TabIndex = 1;
            // 
            // btn_Settings
            // 
            this.btn_Settings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Settings.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_Settings.FlatAppearance.BorderSize = 0;
            this.btn_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Settings.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Settings.ForeColor = System.Drawing.Color.White;
            this.btn_Settings.Location = new System.Drawing.Point(3, 585);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(293, 46);
            this.btn_Settings.TabIndex = 10;
            this.btn_Settings.Text = "Settings";
            this.btn_Settings.UseVisualStyleBackColor = false;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // btn_TransferCustomer
            // 
            this.btn_TransferCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_TransferCustomer.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_TransferCustomer.FlatAppearance.BorderSize = 0;
            this.btn_TransferCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TransferCustomer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TransferCustomer.ForeColor = System.Drawing.Color.White;
            this.btn_TransferCustomer.Location = new System.Drawing.Point(3, 534);
            this.btn_TransferCustomer.Name = "btn_TransferCustomer";
            this.btn_TransferCustomer.Size = new System.Drawing.Size(293, 46);
            this.btn_TransferCustomer.TabIndex = 9;
            this.btn_TransferCustomer.Text = "Transfer Customers";
            this.btn_TransferCustomer.UseVisualStyleBackColor = false;
            this.btn_TransferCustomer.Click += new System.EventHandler(this.btn_TransferCustomer_Click);
            // 
            // btn_CreateCustomer
            // 
            this.btn_CreateCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_CreateCustomer.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_CreateCustomer.FlatAppearance.BorderSize = 0;
            this.btn_CreateCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateCustomer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CreateCustomer.ForeColor = System.Drawing.Color.White;
            this.btn_CreateCustomer.Location = new System.Drawing.Point(3, 172);
            this.btn_CreateCustomer.Name = "btn_CreateCustomer";
            this.btn_CreateCustomer.Size = new System.Drawing.Size(293, 46);
            this.btn_CreateCustomer.TabIndex = 1;
            this.btn_CreateCustomer.Text = "Create Customer";
            this.btn_CreateCustomer.UseVisualStyleBackColor = false;
            this.btn_CreateCustomer.Click += new System.EventHandler(this.btn_CreateCustomer_Click);
            // 
            // btn_Summary
            // 
            this.btn_Summary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Summary.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_Summary.FlatAppearance.BorderSize = 0;
            this.btn_Summary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Summary.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Summary.ForeColor = System.Drawing.Color.White;
            this.btn_Summary.Location = new System.Drawing.Point(3, 483);
            this.btn_Summary.Name = "btn_Summary";
            this.btn_Summary.Size = new System.Drawing.Size(293, 46);
            this.btn_Summary.TabIndex = 4;
            this.btn_Summary.Text = "Summary";
            this.btn_Summary.UseVisualStyleBackColor = false;
            this.btn_Summary.Click += new System.EventHandler(this.btn_Summary_Click);
            // 
            // btn_Logout
            // 
            this.btn_Logout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Logout.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_Logout.FlatAppearance.BorderSize = 0;
            this.btn_Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Logout.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Logout.ForeColor = System.Drawing.Color.White;
            this.btn_Logout.Location = new System.Drawing.Point(3, 636);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(293, 46);
            this.btn_Logout.TabIndex = 6;
            this.btn_Logout.Text = "Logout";
            this.btn_Logout.UseVisualStyleBackColor = false;
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // btn_ExportRecords
            // 
            this.btn_ExportRecords.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_ExportRecords.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_ExportRecords.FlatAppearance.BorderSize = 0;
            this.btn_ExportRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExportRecords.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExportRecords.ForeColor = System.Drawing.Color.White;
            this.btn_ExportRecords.Location = new System.Drawing.Point(3, 330);
            this.btn_ExportRecords.Name = "btn_ExportRecords";
            this.btn_ExportRecords.Size = new System.Drawing.Size(293, 46);
            this.btn_ExportRecords.TabIndex = 7;
            this.btn_ExportRecords.Text = "Export records";
            this.btn_ExportRecords.UseVisualStyleBackColor = false;
            this.btn_ExportRecords.Click += new System.EventHandler(this.btn_ExportRecords_Click);
            // 
            // btn_BalanceLedger
            // 
            this.btn_BalanceLedger.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_BalanceLedger.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_BalanceLedger.FlatAppearance.BorderSize = 0;
            this.btn_BalanceLedger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BalanceLedger.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BalanceLedger.ForeColor = System.Drawing.Color.White;
            this.btn_BalanceLedger.Location = new System.Drawing.Point(3, 381);
            this.btn_BalanceLedger.Name = "btn_BalanceLedger";
            this.btn_BalanceLedger.Size = new System.Drawing.Size(293, 46);
            this.btn_BalanceLedger.TabIndex = 8;
            this.btn_BalanceLedger.Text = "Balance Ledger";
            this.btn_BalanceLedger.UseVisualStyleBackColor = false;
            this.btn_BalanceLedger.Click += new System.EventHandler(this.btn_BalanceLedger_Click);
            // 
            // btn_ChangePassword
            // 
            this.btn_ChangePassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_ChangePassword.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_ChangePassword.FlatAppearance.BorderSize = 0;
            this.btn_ChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChangePassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChangePassword.ForeColor = System.Drawing.Color.White;
            this.btn_ChangePassword.Location = new System.Drawing.Point(3, 432);
            this.btn_ChangePassword.Name = "btn_ChangePassword";
            this.btn_ChangePassword.Size = new System.Drawing.Size(293, 46);
            this.btn_ChangePassword.TabIndex = 5;
            this.btn_ChangePassword.Text = "Change Password";
            this.btn_ChangePassword.UseVisualStyleBackColor = false;
            this.btn_ChangePassword.Click += new System.EventHandler(this.btn_ChangePassword_Click);
            // 
            // btn_Debit
            // 
            this.btn_Debit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Debit.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_Debit.FlatAppearance.BorderSize = 0;
            this.btn_Debit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Debit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Debit.ForeColor = System.Drawing.Color.White;
            this.btn_Debit.Location = new System.Drawing.Point(3, 276);
            this.btn_Debit.Name = "btn_Debit";
            this.btn_Debit.Size = new System.Drawing.Size(293, 48);
            this.btn_Debit.TabIndex = 3;
            this.btn_Debit.Text = "Debit Operation";
            this.btn_Debit.UseVisualStyleBackColor = false;
            this.btn_Debit.Click += new System.EventHandler(this.btn_Debit_Click);
            // 
            // btn_Credit
            // 
            this.btn_Credit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Credit.BackColor = System.Drawing.Color.DarkCyan;
            this.btn_Credit.FlatAppearance.BorderSize = 0;
            this.btn_Credit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Credit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Credit.ForeColor = System.Drawing.Color.White;
            this.btn_Credit.Location = new System.Drawing.Point(3, 224);
            this.btn_Credit.Name = "btn_Credit";
            this.btn_Credit.Size = new System.Drawing.Size(293, 46);
            this.btn_Credit.TabIndex = 2;
            this.btn_Credit.Text = "Credit Operation";
            this.btn_Credit.UseVisualStyleBackColor = false;
            this.btn_Credit.Click += new System.EventHandler(this.btn_Credit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Superior Investment";
            // 
            // lb_LoggedIn
            // 
            this.lb_LoggedIn.AutoSize = true;
            this.lb_LoggedIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.lb_LoggedIn.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_LoggedIn.Location = new System.Drawing.Point(1248, 0);
            this.lb_LoggedIn.Name = "lb_LoggedIn";
            this.lb_LoggedIn.Size = new System.Drawing.Size(0, 29);
            this.lb_LoggedIn.TabIndex = 6;
            // 
            // lb_Copyright
            // 
            this.lb_Copyright.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lb_Copyright.AutoSize = true;
            this.lb_Copyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Copyright.Location = new System.Drawing.Point(510, 690);
            this.lb_Copyright.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_Copyright.Name = "lb_Copyright";
            this.lb_Copyright.Size = new System.Drawing.Size(0, 18);
            this.lb_Copyright.TabIndex = 32;
            // 
            // lb_Progress
            // 
            this.lb_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Progress.AutoSize = true;
            this.lb_Progress.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Progress.Location = new System.Drawing.Point(953, 690);
            this.lb_Progress.Name = "lb_Progress";
            this.lb_Progress.Size = new System.Drawing.Size(0, 19);
            this.lb_Progress.TabIndex = 33;
            // 
            // bgwBackup
            // 
            this.bgwBackup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwBackup_DoWork);
            this.bgwBackup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwBackup_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lb_TotalSubAdmin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(305, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 152);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // lb_TotalSubAdmin
            // 
            this.lb_TotalSubAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_TotalSubAdmin.AutoSize = true;
            this.lb_TotalSubAdmin.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TotalSubAdmin.Location = new System.Drawing.Point(84, 88);
            this.lb_TotalSubAdmin.Name = "lb_TotalSubAdmin";
            this.lb_TotalSubAdmin.Size = new System.Drawing.Size(0, 23);
            this.lb_TotalSubAdmin.TabIndex = 4;
            this.lb_TotalSubAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total Sub admins";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.lb_TotalAmountCollected);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(914, 413);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 152);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            // 
            // lb_TotalAmountCollected
            // 
            this.lb_TotalAmountCollected.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_TotalAmountCollected.AutoSize = true;
            this.lb_TotalAmountCollected.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TotalAmountCollected.ForeColor = System.Drawing.Color.Red;
            this.lb_TotalAmountCollected.Location = new System.Drawing.Point(40, 83);
            this.lb_TotalAmountCollected.Name = "lb_TotalAmountCollected";
            this.lb_TotalAmountCollected.Size = new System.Drawing.Size(0, 23);
            this.lb_TotalAmountCollected.TabIndex = 5;
            this.lb_TotalAmountCollected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(39, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 26);
            this.label11.TabIndex = 3;
            this.label11.Text = "Total Withdrawals";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.lb_TotalAmountContributed);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(305, 413);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 152);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            // 
            // lb_TotalAmountContributed
            // 
            this.lb_TotalAmountContributed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_TotalAmountContributed.AutoSize = true;
            this.lb_TotalAmountContributed.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TotalAmountContributed.ForeColor = System.Drawing.Color.Green;
            this.lb_TotalAmountContributed.Location = new System.Drawing.Point(54, 83);
            this.lb_TotalAmountContributed.Name = "lb_TotalAmountContributed";
            this.lb_TotalAmountContributed.Size = new System.Drawing.Size(0, 23);
            this.lb_TotalAmountContributed.TabIndex = 4;
            this.lb_TotalAmountContributed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(53, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 26);
            this.label7.TabIndex = 3;
            this.label7.Text = "Total Savings";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.lb_TotalCustomers);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(914, 172);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(322, 152);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            // 
            // lb_TotalCustomers
            // 
            this.lb_TotalCustomers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_TotalCustomers.AutoSize = true;
            this.lb_TotalCustomers.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TotalCustomers.Location = new System.Drawing.Point(60, 88);
            this.lb_TotalCustomers.Name = "lb_TotalCustomers";
            this.lb_TotalCustomers.Size = new System.Drawing.Size(0, 23);
            this.lb_TotalCustomers.TabIndex = 4;
            this.lb_TotalCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(59, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 26);
            this.label10.TabIndex = 3;
            this.label10.Text = "Total Customers";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bgw_PullData
            // 
            this.bgw_PullData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullData_DoWork);
            this.bgw_PullData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_PullData_RunWorkerCompleted);
            // 
            // bgw_EndOfMonthOperations
            // 
            this.bgw_EndOfMonthOperations.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_EndOfMonthOperations_DoWork);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(302, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 86);
            this.panel1.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 39);
            this.label3.TabIndex = 11;
            this.label3.Text = "Statistical Overview";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SuperAdminUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1248, 717);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb_Progress);
            this.Controls.Add(this.lb_Copyright);
            this.Controls.Add(this.lb_LoggedIn);
            this.Controls.Add(this.panel_Controls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SuperAdminUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Superior Investment: Super Admin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SuperAdminUI_Load);
            this.panel_Controls.ResumeLayout(false);
            this.panel_Controls.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CreateSubAdmin;
        private System.Windows.Forms.Panel panel_Controls;
        private System.Windows.Forms.Button btn_Summary;
        private System.Windows.Forms.Button btn_CreateCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Logout;
        private System.Windows.Forms.Button btn_ChangePassword;
        private System.Windows.Forms.Label lb_LoggedIn;
        private System.Windows.Forms.Label lb_Copyright;
        private System.Windows.Forms.Button btn_ExportRecords;
        private System.Windows.Forms.Button btn_BalanceLedger;
        private System.Windows.Forms.Label lb_Progress;
        private System.ComponentModel.BackgroundWorker bgwBackup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_TotalSubAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lb_TotalAmountContributed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lb_TotalCustomers;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lb_TotalAmountCollected;
        private System.ComponentModel.BackgroundWorker bgw_PullData;
        private System.Windows.Forms.Button btn_TransferCustomer;
        private System.Windows.Forms.Button btn_Settings;
        private System.ComponentModel.BackgroundWorker bgw_EndOfMonthOperations;
        private System.Windows.Forms.Button btn_Debit;
        private System.Windows.Forms.Button btn_Credit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}