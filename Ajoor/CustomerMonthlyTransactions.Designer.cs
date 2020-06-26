namespace Ajoor
{
    partial class CustomerMonthlyTransactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerMonthlyTransactions));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lb_Total = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_CustomerTransactionRecords = new System.Windows.Forms.DataGridView();
            this.bgw_PullData = new System.ComponentModel.BackgroundWorker();
            this.lbMonthName = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txt_TotalDebit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_TotalCredit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbYears = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbMonths = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnEClear = new System.Windows.Forms.Button();
            this.btnEGo = new System.Windows.Forms.Button();
            this.bgwFilterRecords = new System.ComponentModel.BackgroundWorker();
            this.txt_TotalDifference = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustomerTransactionRecords)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Location = new System.Drawing.Point(830, 184);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 139);
            this.panel1.TabIndex = 147;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Location = new System.Drawing.Point(4, 77);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(142, 59);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lb_Total
            // 
            this.lb_Total.AutoSize = true;
            this.lb_Total.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Total.Location = new System.Drawing.Point(192, 162);
            this.lb_Total.Name = "lb_Total";
            this.lb_Total.Size = new System.Drawing.Size(0, 19);
            this.lb_Total.TabIndex = 146;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 19);
            this.label5.TabIndex = 145;
            this.label5.Text = "Total number of records:";
            // 
            // dgv_CustomerTransactionRecords
            // 
            this.dgv_CustomerTransactionRecords.AllowUserToAddRows = false;
            this.dgv_CustomerTransactionRecords.AllowUserToDeleteRows = false;
            this.dgv_CustomerTransactionRecords.AllowUserToResizeRows = false;
            this.dgv_CustomerTransactionRecords.BackgroundColor = System.Drawing.Color.White;
            this.dgv_CustomerTransactionRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CustomerTransactionRecords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_CustomerTransactionRecords.Location = new System.Drawing.Point(11, 184);
            this.dgv_CustomerTransactionRecords.Name = "dgv_CustomerTransactionRecords";
            this.dgv_CustomerTransactionRecords.ReadOnly = true;
            this.dgv_CustomerTransactionRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_CustomerTransactionRecords.Size = new System.Drawing.Size(812, 362);
            this.dgv_CustomerTransactionRecords.TabIndex = 142;
            // 
            // bgw_PullData
            // 
            this.bgw_PullData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullData_DoWork);
            // 
            // lbMonthName
            // 
            this.lbMonthName.AutoSize = true;
            this.lbMonthName.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMonthName.Location = new System.Drawing.Point(7, 9);
            this.lbMonthName.Name = "lbMonthName";
            this.lbMonthName.Size = new System.Drawing.Size(0, 29);
            this.lbMonthName.TabIndex = 148;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.White;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.Black;
            this.btnFilter.Location = new System.Drawing.Point(4, 3);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(142, 59);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txt_TotalDebit
            // 
            this.txt_TotalDebit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalDebit.Location = new System.Drawing.Point(268, 77);
            this.txt_TotalDebit.Name = "txt_TotalDebit";
            this.txt_TotalDebit.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalDebit.TabIndex = 153;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(264, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 19);
            this.label6.TabIndex = 152;
            this.label6.Text = "Total Debt";
            // 
            // txt_TotalCredit
            // 
            this.txt_TotalCredit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalCredit.Location = new System.Drawing.Point(12, 77);
            this.txt_TotalCredit.Name = "txt_TotalCredit";
            this.txt_TotalCredit.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalCredit.TabIndex = 151;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 19);
            this.label3.TabIndex = 150;
            this.label3.Text = "Total Credit";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.cmbYears);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmbMonths);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnEClear);
            this.groupBox2.Controls.Add(this.btnEGo);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(650, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 74);
            this.groupBox2.TabIndex = 154;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // cmbYears
            // 
            this.cmbYears.FormattingEnabled = true;
            this.cmbYears.Location = new System.Drawing.Point(54, 46);
            this.cmbYears.Name = "cmbYears";
            this.cmbYears.Size = new System.Drawing.Size(237, 22);
            this.cmbYears.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(6, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 14);
            this.label10.TabIndex = 36;
            this.label10.Text = "Year";
            // 
            // cmbMonths
            // 
            this.cmbMonths.FormattingEnabled = true;
            this.cmbMonths.Location = new System.Drawing.Point(54, 18);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new System.Drawing.Size(237, 22);
            this.cmbMonths.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(6, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 14);
            this.label12.TabIndex = 34;
            this.label12.Text = "Month";
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
            // bgwFilterRecords
            // 
            this.bgwFilterRecords.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwFilterRecords_DoWork);
            // 
            // txt_TotalDifference
            // 
            this.txt_TotalDifference.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalDifference.Location = new System.Drawing.Point(11, 129);
            this.txt_TotalDifference.Name = "txt_TotalDifference";
            this.txt_TotalDifference.Size = new System.Drawing.Size(250, 27);
            this.txt_TotalDifference.TabIndex = 156;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 19);
            this.label4.TabIndex = 155;
            this.label4.Text = "Total Difference";
            // 
            // CustomerMonthlyTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(989, 558);
            this.Controls.Add(this.txt_TotalDifference);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txt_TotalDebit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_TotalCredit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbMonthName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_Total);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgv_CustomerTransactionRecords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerMonthlyTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Superior Investment: Customer Monthly Transactions";
            this.Load += new System.EventHandler(this.CustomerMonthlyTransactions_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustomerTransactionRecords)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lb_Total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_CustomerTransactionRecords;
        private System.ComponentModel.BackgroundWorker bgw_PullData;
        private System.Windows.Forms.Label lbMonthName;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txt_TotalDebit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_TotalCredit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbYears;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbMonths;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnEClear;
        private System.Windows.Forms.Button btnEGo;
        private System.ComponentModel.BackgroundWorker bgwFilterRecords;
        private System.Windows.Forms.TextBox txt_TotalDifference;
        private System.Windows.Forms.Label label4;
    }
}