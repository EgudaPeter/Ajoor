namespace Ajoor
{
    partial class Summary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Summary));
            this.bwg_Summary = new System.ComponentModel.BackgroundWorker();
            this.printSummary = new System.Drawing.Printing.PrintDocument();
            this.dgv_Summary = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEClear = new System.Windows.Forms.Button();
            this.btnEGo = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_Subadmin = new System.Windows.Forms.ComboBox();
            this.cmb_Customers = new System.Windows.Forms.ComboBox();
            this.dtp_Start = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtp_End = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_MonthlyView = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Go = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_TotalCredit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TotalDebit = new System.Windows.Forms.TextBox();
            this.txt_TotalCombined = new System.Windows.Forms.TextBox();
            this.bgw_PullReport_DatesOnly = new System.ComponentModel.BackgroundWorker();
            this.lb_Total = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bwg_PullReport_DatesAndSubadminOnly = new System.ComponentModel.BackgroundWorker();
            this.bwg_PullReport_DatesAndCustomerOnly = new System.ComponentModel.BackgroundWorker();
            this.bwg_PullReport_Dates_Customer_Subadmin_Only = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Summary)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bwg_Summary
            // 
            this.bwg_Summary.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwg_Summary_DoWork);
            // 
            // printSummary
            // 
            this.printSummary.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printSummary_PrintPage);
            // 
            // dgv_Summary
            // 
            this.dgv_Summary.AllowUserToAddRows = false;
            this.dgv_Summary.AllowUserToDeleteRows = false;
            this.dgv_Summary.AllowUserToResizeRows = false;
            this.dgv_Summary.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Summary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Summary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Summary.Location = new System.Drawing.Point(10, 178);
            this.dgv_Summary.Name = "dgv_Summary";
            this.dgv_Summary.ReadOnly = true;
            this.dgv_Summary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Summary.Size = new System.Drawing.Size(934, 400);
            this.dgv_Summary.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btnEClear);
            this.groupBox2.Controls.Add(this.btnEGo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmb_Subadmin);
            this.groupBox2.Controls.Add(this.cmb_Customers);
            this.groupBox2.Controls.Add(this.dtp_Start);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.dtp_End);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(266, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(762, 74);
            this.groupBox2.TabIndex = 4;
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "Start Date";
            // 
            // cmb_Subadmin
            // 
            this.cmb_Subadmin.FormattingEnabled = true;
            this.cmb_Subadmin.Location = new System.Drawing.Point(457, 15);
            this.cmb_Subadmin.Name = "cmb_Subadmin";
            this.cmb_Subadmin.Size = new System.Drawing.Size(237, 22);
            this.cmb_Subadmin.TabIndex = 6;
            // 
            // cmb_Customers
            // 
            this.cmb_Customers.FormattingEnabled = true;
            this.cmb_Customers.Location = new System.Drawing.Point(457, 39);
            this.cmb_Customers.Name = "cmb_Customers";
            this.cmb_Customers.Size = new System.Drawing.Size(237, 22);
            this.cmb_Customers.TabIndex = 7;
            // 
            // dtp_Start
            // 
            this.dtp_Start.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Start.Location = new System.Drawing.Point(91, 13);
            this.dtp_Start.Name = "dtp_Start";
            this.dtp_Start.Size = new System.Drawing.Size(241, 21);
            this.dtp_Start.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(382, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 14);
            this.label9.TabIndex = 5;
            this.label9.Text = "Customer";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(382, 18);
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
            this.label13.Location = new System.Drawing.Point(6, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 14);
            this.label13.TabIndex = 1;
            this.label13.Text = "End Start";
            // 
            // dtp_End
            // 
            this.dtp_End.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_End.Location = new System.Drawing.Point(91, 37);
            this.dtp_End.Name = "dtp_End";
            this.dtp_End.Size = new System.Drawing.Size(241, 21);
            this.dtp_End.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Print);
            this.panel1.Controls.Add(this.btn_MonthlyView);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Go);
            this.panel1.Location = new System.Drawing.Point(950, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 292);
            this.panel1.TabIndex = 96;
            // 
            // btn_Print
            // 
            this.btn_Print.BackColor = System.Drawing.Color.Green;
            this.btn_Print.Enabled = false;
            this.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.ForeColor = System.Drawing.Color.White;
            this.btn_Print.Location = new System.Drawing.Point(3, 85);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(142, 59);
            this.btn_Print.TabIndex = 7;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = false;
            this.btn_Print.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btn_MonthlyView
            // 
            this.btn_MonthlyView.BackColor = System.Drawing.Color.White;
            this.btn_MonthlyView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MonthlyView.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MonthlyView.ForeColor = System.Drawing.Color.Black;
            this.btn_MonthlyView.Location = new System.Drawing.Point(3, 150);
            this.btn_MonthlyView.Name = "btn_MonthlyView";
            this.btn_MonthlyView.Size = new System.Drawing.Size(142, 59);
            this.btn_MonthlyView.TabIndex = 6;
            this.btn_MonthlyView.Text = "Monthly view";
            this.btn_MonthlyView.UseVisualStyleBackColor = false;
            this.btn_MonthlyView.Click += new System.EventHandler(this.btn_MonthlyView_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Location = new System.Drawing.Point(3, 215);
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
            this.btn_Go.Location = new System.Drawing.Point(3, 20);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(142, 59);
            this.btn_Go.TabIndex = 0;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = false;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 39);
            this.label1.TabIndex = 97;
            this.label1.Text = "Summary";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 19);
            this.label7.TabIndex = 111;
            this.label7.Text = "Total Amount Contributed";
            // 
            // txt_TotalCredit
            // 
            this.txt_TotalCredit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalCredit.Location = new System.Drawing.Point(10, 111);
            this.txt_TotalCredit.Name = "txt_TotalCredit";
            this.txt_TotalCredit.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalCredit.TabIndex = 110;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(353, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 19);
            this.label4.TabIndex = 109;
            this.label4.Text = "Total Amount Collected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(691, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 19);
            this.label2.TabIndex = 115;
            this.label2.Text = "Total Amount Combined";
            // 
            // txt_TotalDebit
            // 
            this.txt_TotalDebit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalDebit.Location = new System.Drawing.Point(357, 111);
            this.txt_TotalDebit.Name = "txt_TotalDebit";
            this.txt_TotalDebit.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalDebit.TabIndex = 116;
            // 
            // txt_TotalCombined
            // 
            this.txt_TotalCombined.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalCombined.Location = new System.Drawing.Point(695, 111);
            this.txt_TotalCombined.Name = "txt_TotalCombined";
            this.txt_TotalCombined.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalCombined.TabIndex = 117;
            // 
            // bgw_PullReport_DatesOnly
            // 
            this.bgw_PullReport_DatesOnly.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullReport_DatesOnly_DoWork);
            // 
            // lb_Total
            // 
            this.lb_Total.AutoSize = true;
            this.lb_Total.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Total.Location = new System.Drawing.Point(190, 156);
            this.lb_Total.Name = "lb_Total";
            this.lb_Total.Size = new System.Drawing.Size(9, 19);
            this.lb_Total.TabIndex = 100;
            this.lb_Total.Text = "\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 19);
            this.label5.TabIndex = 99;
            this.label5.Text = "Total number of records:";
            // 
            // bwg_PullReport_DatesAndSubadminOnly
            // 
            this.bwg_PullReport_DatesAndSubadminOnly.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullReport_DatesAndSubadminOnly_DoWork);
            // 
            // bwg_PullReport_DatesAndCustomerOnly
            // 
            this.bwg_PullReport_DatesAndCustomerOnly.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullReport_DatesAndCustomerOnly_DoWork);
            // 
            // bwg_PullReport_Dates_Customer_Subadmin_Only
            // 
            this.bwg_PullReport_Dates_Customer_Subadmin_Only.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullReport_Dates_Customer_Subadmin_Only_DoWork);
            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1114, 611);
            this.Controls.Add(this.lb_Total);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_TotalCombined);
            this.Controls.Add(this.txt_TotalDebit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_TotalCredit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_Summary);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Summary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Superior Investment: Summary";
            this.Load += new System.EventHandler(this.Summary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Summary)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bwg_Summary;
        private System.Drawing.Printing.PrintDocument printSummary;
        private System.Windows.Forms.DataGridView dgv_Summary;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEClear;
        private System.Windows.Forms.Button btnEGo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_Subadmin;
        private System.Windows.Forms.ComboBox cmb_Customers;
        private System.Windows.Forms.DateTimePicker dtp_Start;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtp_End;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_TotalCredit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TotalDebit;
        private System.Windows.Forms.TextBox txt_TotalCombined;
        private System.ComponentModel.BackgroundWorker bgw_PullReport_DatesOnly;
        private System.Windows.Forms.Label lb_Total;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker bwg_PullReport_DatesAndSubadminOnly;
        private System.ComponentModel.BackgroundWorker bwg_PullReport_DatesAndCustomerOnly;
        private System.ComponentModel.BackgroundWorker bwg_PullReport_Dates_Customer_Subadmin_Only;
        private System.Windows.Forms.Button btn_MonthlyView;
        private System.Windows.Forms.Button btn_Print;
    }
}