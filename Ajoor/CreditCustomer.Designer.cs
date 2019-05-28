namespace Ajoor
{
    partial class CreditCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditCustomer));
            this.dgv_CustomerTransactions = new System.Windows.Forms.DataGridView();
            this.bgwGetRecords = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Credit = new System.Windows.Forms.Button();
            this.lb_Total = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Customers = new System.Windows.Forms.ComboBox();
            this.txt_AccountNumber = new System.Windows.Forms.TextBox();
            this.txt_AmountContributed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bgwGetCustomers = new System.ComponentModel.BackgroundWorker();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_TotalDebt = new System.Windows.Forms.TextBox();
            this.txt_Commission = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_TotalCredit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustomerTransactions)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_CustomerTransactions
            // 
            this.dgv_CustomerTransactions.AllowUserToAddRows = false;
            this.dgv_CustomerTransactions.AllowUserToDeleteRows = false;
            this.dgv_CustomerTransactions.AllowUserToResizeRows = false;
            this.dgv_CustomerTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgv_CustomerTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CustomerTransactions.Location = new System.Drawing.Point(9, 230);
            this.dgv_CustomerTransactions.Name = "dgv_CustomerTransactions";
            this.dgv_CustomerTransactions.ReadOnly = true;
            this.dgv_CustomerTransactions.Size = new System.Drawing.Size(932, 469);
            this.dgv_CustomerTransactions.TabIndex = 10;
            // 
            // bgwGetRecords
            // 
            this.bgwGetRecords.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGetRecords_DoWork);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Credit);
            this.panel1.Location = new System.Drawing.Point(953, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 165);
            this.panel1.TabIndex = 11;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Location = new System.Drawing.Point(7, 85);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(142, 59);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Credit
            // 
            this.btn_Credit.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_Credit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Credit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Credit.ForeColor = System.Drawing.Color.White;
            this.btn_Credit.Location = new System.Drawing.Point(7, 20);
            this.btn_Credit.Name = "btn_Credit";
            this.btn_Credit.Size = new System.Drawing.Size(142, 59);
            this.btn_Credit.TabIndex = 0;
            this.btn_Credit.Text = "Credit";
            this.btn_Credit.UseVisualStyleBackColor = false;
            this.btn_Credit.Click += new System.EventHandler(this.btn_Credit_Click);
            // 
            // lb_Total
            // 
            this.lb_Total.AutoSize = true;
            this.lb_Total.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Total.Location = new System.Drawing.Point(190, 208);
            this.lb_Total.Name = "lb_Total";
            this.lb_Total.Size = new System.Drawing.Size(9, 19);
            this.lb_Total.TabIndex = 14;
            this.lb_Total.Text = "\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Total number of records:";
            // 
            // cmb_Customers
            // 
            this.cmb_Customers.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Customers.FormattingEnabled = true;
            this.cmb_Customers.Location = new System.Drawing.Point(9, 111);
            this.cmb_Customers.Name = "cmb_Customers";
            this.cmb_Customers.Size = new System.Drawing.Size(306, 27);
            this.cmb_Customers.Sorted = true;
            this.cmb_Customers.TabIndex = 15;
            this.cmb_Customers.SelectedIndexChanged += new System.EventHandler(this.cmb_Customers_SelectedIndexChanged);
            // 
            // txt_AccountNumber
            // 
            this.txt_AccountNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AccountNumber.Location = new System.Drawing.Point(321, 111);
            this.txt_AccountNumber.Name = "txt_AccountNumber";
            this.txt_AccountNumber.Size = new System.Drawing.Size(154, 27);
            this.txt_AccountNumber.TabIndex = 16;
            // 
            // txt_AmountContributed
            // 
            this.txt_AmountContributed.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AmountContributed.Location = new System.Drawing.Point(799, 111);
            this.txt_AmountContributed.Name = "txt_AmountContributed";
            this.txt_AmountContributed.Size = new System.Drawing.Size(306, 27);
            this.txt_AmountContributed.TabIndex = 17;
            this.txt_AmountContributed.Enter += new System.EventHandler(this.txt_AmountContributed_Enter);
            this.txt_AmountContributed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_AmountContributed_KeyDown);
            this.txt_AmountContributed.Leave += new System.EventHandler(this.txt_AmountContributed_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Search";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(317, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "Account Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(795, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 20;
            this.label4.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 39);
            this.label6.TabIndex = 87;
            this.label6.Text = "Credit Customer";
            // 
            // bgwGetCustomers
            // 
            this.bgwGetCustomers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGetCustomers_DoWork);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(317, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 19);
            this.label9.TabIndex = 93;
            this.label9.Text = "Total Debt (Current)";
            // 
            // txt_TotalDebt
            // 
            this.txt_TotalDebt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalDebt.Location = new System.Drawing.Point(321, 175);
            this.txt_TotalDebt.Name = "txt_TotalDebt";
            this.txt_TotalDebt.Size = new System.Drawing.Size(306, 27);
            this.txt_TotalDebt.TabIndex = 92;
            // 
            // txt_Commission
            // 
            this.txt_Commission.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Commission.Location = new System.Drawing.Point(486, 111);
            this.txt_Commission.Name = "txt_Commission";
            this.txt_Commission.Size = new System.Drawing.Size(306, 27);
            this.txt_Commission.TabIndex = 90;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(482, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 19);
            this.label7.TabIndex = 91;
            this.label7.Text = "Commission";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 19);
            this.label5.TabIndex = 95;
            this.label5.Text = "Total Credit (Current)";
            // 
            // txt_TotalCredit
            // 
            this.txt_TotalCredit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalCredit.Location = new System.Drawing.Point(11, 175);
            this.txt_TotalCredit.Name = "txt_TotalCredit";
            this.txt_TotalCredit.Size = new System.Drawing.Size(306, 27);
            this.txt_TotalCredit.TabIndex = 94;
            // 
            // CreditCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1114, 711);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_TotalCredit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_TotalDebt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Commission);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_AmountContributed);
            this.Controls.Add(this.txt_AccountNumber);
            this.Controls.Add(this.cmb_Customers);
            this.Controls.Add(this.dgv_CustomerTransactions);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_Total);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreditCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Superior Investment: Credit Customer";
            this.Load += new System.EventHandler(this.CreditCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustomerTransactions)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_CustomerTransactions;
        private System.ComponentModel.BackgroundWorker bgwGetRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Credit;
        private System.Windows.Forms.Label lb_Total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Customers;
        private System.Windows.Forms.TextBox txt_AccountNumber;
        private System.Windows.Forms.TextBox txt_AmountContributed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker bgwGetCustomers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_TotalDebt;
        private System.Windows.Forms.TextBox txt_Commission;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_TotalCredit;
    }
}