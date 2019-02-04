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
            this.label3 = new System.Windows.Forms.Label();
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
            this.panel_Controls.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_CreateSubAdmin
            // 
            this.btn_CreateSubAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_CreateSubAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateSubAdmin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CreateSubAdmin.Location = new System.Drawing.Point(19, 58);
            this.btn_CreateSubAdmin.Name = "btn_CreateSubAdmin";
            this.btn_CreateSubAdmin.Size = new System.Drawing.Size(243, 47);
            this.btn_CreateSubAdmin.TabIndex = 0;
            this.btn_CreateSubAdmin.Text = "Create Sub admin";
            this.btn_CreateSubAdmin.UseVisualStyleBackColor = true;
            this.btn_CreateSubAdmin.Click += new System.EventHandler(this.btn_CreateSubAdmin_Click);
            // 
            // panel_Controls
            // 
            this.panel_Controls.Controls.Add(this.btn_TransferCustomer);
            this.panel_Controls.Controls.Add(this.btn_CreateSubAdmin);
            this.panel_Controls.Controls.Add(this.btn_CreateCustomer);
            this.panel_Controls.Controls.Add(this.btn_Summary);
            this.panel_Controls.Controls.Add(this.btn_Logout);
            this.panel_Controls.Controls.Add(this.btn_ExportRecords);
            this.panel_Controls.Controls.Add(this.btn_BalanceLedger);
            this.panel_Controls.Controls.Add(this.btn_ChangePassword);
            this.panel_Controls.Controls.Add(this.btn_Debit);
            this.panel_Controls.Controls.Add(this.btn_Credit);
            this.panel_Controls.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Controls.Location = new System.Drawing.Point(0, 0);
            this.panel_Controls.Name = "panel_Controls";
            this.panel_Controls.Size = new System.Drawing.Size(278, 594);
            this.panel_Controls.TabIndex = 1;
            // 
            // btn_TransferCustomer
            // 
            this.btn_TransferCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_TransferCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TransferCustomer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TransferCustomer.Location = new System.Drawing.Point(19, 483);
            this.btn_TransferCustomer.Name = "btn_TransferCustomer";
            this.btn_TransferCustomer.Size = new System.Drawing.Size(243, 46);
            this.btn_TransferCustomer.TabIndex = 9;
            this.btn_TransferCustomer.Text = "Transfer Customers";
            this.btn_TransferCustomer.UseVisualStyleBackColor = true;
            this.btn_TransferCustomer.Click += new System.EventHandler(this.btn_TransferCustomer_Click);
            // 
            // btn_CreateCustomer
            // 
            this.btn_CreateCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_CreateCustomer.BackColor = System.Drawing.Color.Green;
            this.btn_CreateCustomer.FlatAppearance.BorderSize = 0;
            this.btn_CreateCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateCustomer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CreateCustomer.ForeColor = System.Drawing.Color.White;
            this.btn_CreateCustomer.Location = new System.Drawing.Point(19, 111);
            this.btn_CreateCustomer.Name = "btn_CreateCustomer";
            this.btn_CreateCustomer.Size = new System.Drawing.Size(243, 46);
            this.btn_CreateCustomer.TabIndex = 1;
            this.btn_CreateCustomer.Text = "Create Customer";
            this.btn_CreateCustomer.UseVisualStyleBackColor = false;
            this.btn_CreateCustomer.Click += new System.EventHandler(this.btn_CreateCustomer_Click);
            // 
            // btn_Summary
            // 
            this.btn_Summary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Summary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Summary.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Summary.Location = new System.Drawing.Point(19, 430);
            this.btn_Summary.Name = "btn_Summary";
            this.btn_Summary.Size = new System.Drawing.Size(243, 46);
            this.btn_Summary.TabIndex = 4;
            this.btn_Summary.Text = "Summary";
            this.btn_Summary.UseVisualStyleBackColor = true;
            this.btn_Summary.Click += new System.EventHandler(this.btn_Summary_Click);
            // 
            // btn_Logout
            // 
            this.btn_Logout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Logout.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Logout.Location = new System.Drawing.Point(19, 536);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(243, 46);
            this.btn_Logout.TabIndex = 6;
            this.btn_Logout.Text = "Logout";
            this.btn_Logout.UseVisualStyleBackColor = true;
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // btn_ExportRecords
            // 
            this.btn_ExportRecords.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_ExportRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExportRecords.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExportRecords.Location = new System.Drawing.Point(19, 270);
            this.btn_ExportRecords.Name = "btn_ExportRecords";
            this.btn_ExportRecords.Size = new System.Drawing.Size(243, 46);
            this.btn_ExportRecords.TabIndex = 7;
            this.btn_ExportRecords.Text = "Export records";
            this.btn_ExportRecords.UseVisualStyleBackColor = true;
            this.btn_ExportRecords.Click += new System.EventHandler(this.btn_ExportRecords_Click);
            // 
            // btn_BalanceLedger
            // 
            this.btn_BalanceLedger.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_BalanceLedger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BalanceLedger.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BalanceLedger.Location = new System.Drawing.Point(19, 323);
            this.btn_BalanceLedger.Name = "btn_BalanceLedger";
            this.btn_BalanceLedger.Size = new System.Drawing.Size(243, 46);
            this.btn_BalanceLedger.TabIndex = 8;
            this.btn_BalanceLedger.Text = "Balance Ledger";
            this.btn_BalanceLedger.UseVisualStyleBackColor = true;
            this.btn_BalanceLedger.Click += new System.EventHandler(this.btn_BalanceLedger_Click);
            // 
            // btn_ChangePassword
            // 
            this.btn_ChangePassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_ChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChangePassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChangePassword.Location = new System.Drawing.Point(19, 377);
            this.btn_ChangePassword.Name = "btn_ChangePassword";
            this.btn_ChangePassword.Size = new System.Drawing.Size(243, 46);
            this.btn_ChangePassword.TabIndex = 5;
            this.btn_ChangePassword.Text = "Change Password";
            this.btn_ChangePassword.UseVisualStyleBackColor = true;
            this.btn_ChangePassword.Click += new System.EventHandler(this.btn_ChangePassword_Click);
            // 
            // btn_Debit
            // 
            this.btn_Debit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Debit.BackColor = System.Drawing.Color.Red;
            this.btn_Debit.FlatAppearance.BorderSize = 0;
            this.btn_Debit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Debit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Debit.ForeColor = System.Drawing.Color.White;
            this.btn_Debit.Location = new System.Drawing.Point(19, 217);
            this.btn_Debit.Name = "btn_Debit";
            this.btn_Debit.Size = new System.Drawing.Size(243, 46);
            this.btn_Debit.TabIndex = 3;
            this.btn_Debit.Text = "Debit";
            this.btn_Debit.UseVisualStyleBackColor = false;
            this.btn_Debit.Click += new System.EventHandler(this.btn_Debit_Click);
            // 
            // btn_Credit
            // 
            this.btn_Credit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Credit.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_Credit.FlatAppearance.BorderSize = 0;
            this.btn_Credit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Credit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Credit.ForeColor = System.Drawing.Color.White;
            this.btn_Credit.Location = new System.Drawing.Point(19, 163);
            this.btn_Credit.Name = "btn_Credit";
            this.btn_Credit.Size = new System.Drawing.Size(243, 46);
            this.btn_Credit.TabIndex = 2;
            this.btn_Credit.Text = "Credit";
            this.btn_Credit.UseVisualStyleBackColor = false;
            this.btn_Credit.Click += new System.EventHandler(this.btn_Credit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 9);
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
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(510, 567);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "Copyright © 2018";
            // 
            // lb_Progress
            // 
            this.lb_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Progress.AutoSize = true;
            this.lb_Progress.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Progress.Location = new System.Drawing.Point(953, 567);
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
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lb_TotalSubAdmin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(368, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 162);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // lb_TotalSubAdmin
            // 
            this.lb_TotalSubAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_TotalSubAdmin.AutoSize = true;
            this.lb_TotalSubAdmin.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TotalSubAdmin.Location = new System.Drawing.Point(53, 88);
            this.lb_TotalSubAdmin.Name = "lb_TotalSubAdmin";
            this.lb_TotalSubAdmin.Size = new System.Drawing.Size(0, 23);
            this.lb_TotalSubAdmin.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total Sub admins";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.lb_TotalAmountCollected);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(914, 357);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 162);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            // 
            // lb_TotalAmountCollected
            // 
            this.lb_TotalAmountCollected.AutoSize = true;
            this.lb_TotalAmountCollected.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TotalAmountCollected.ForeColor = System.Drawing.Color.Red;
            this.lb_TotalAmountCollected.Location = new System.Drawing.Point(40, 83);
            this.lb_TotalAmountCollected.Name = "lb_TotalAmountCollected";
            this.lb_TotalAmountCollected.Size = new System.Drawing.Size(0, 23);
            this.lb_TotalAmountCollected.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(39, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(214, 26);
            this.label11.TabIndex = 3;
            this.label11.Text = "Total Amount Collected";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.lb_TotalAmountContributed);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(368, 357);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 162);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            // 
            // lb_TotalAmountContributed
            // 
            this.lb_TotalAmountContributed.AutoSize = true;
            this.lb_TotalAmountContributed.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TotalAmountContributed.ForeColor = System.Drawing.Color.Green;
            this.lb_TotalAmountContributed.Location = new System.Drawing.Point(23, 83);
            this.lb_TotalAmountContributed.Name = "lb_TotalAmountContributed";
            this.lb_TotalAmountContributed.Size = new System.Drawing.Size(0, 23);
            this.lb_TotalAmountContributed.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(236, 26);
            this.label7.TabIndex = 3;
            this.label7.Text = "Total Amount Contributed";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.lb_TotalCustomers);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(914, 175);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(273, 127);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            // 
            // lb_TotalCustomers
            // 
            this.lb_TotalCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_TotalCustomers.AutoSize = true;
            this.lb_TotalCustomers.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TotalCustomers.Location = new System.Drawing.Point(60, 88);
            this.lb_TotalCustomers.Name = "lb_TotalCustomers";
            this.lb_TotalCustomers.Size = new System.Drawing.Size(0, 23);
            this.lb_TotalCustomers.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(59, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 26);
            this.label10.TabIndex = 3;
            this.label10.Text = "Total Customers";
            // 
            // bgw_PullData
            // 
            this.bgw_PullData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullData_DoWork);
            // 
            // SuperAdminUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1248, 594);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb_Progress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_LoggedIn);
            this.Controls.Add(this.label1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CreateSubAdmin;
        private System.Windows.Forms.Panel panel_Controls;
        private System.Windows.Forms.Button btn_Summary;
        private System.Windows.Forms.Button btn_CreateCustomer;
        private System.Windows.Forms.Button btn_Debit;
        private System.Windows.Forms.Button btn_Credit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Logout;
        private System.Windows.Forms.Button btn_ChangePassword;
        private System.Windows.Forms.Label lb_LoggedIn;
        private System.Windows.Forms.Label label3;
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
    }
}