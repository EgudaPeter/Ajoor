namespace Ajoor
{
    partial class DebitCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebitCustomer));
            this.txt_TotalDebt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Commission = new System.Windows.Forms.TextBox();
            this.bgwGetCustomers = new System.ComponentModel.BackgroundWorker();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_AmountCollected = new System.Windows.Forms.TextBox();
            this.txt_AccountNumber = new System.Windows.Forms.TextBox();
            this.lb_Total = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Debit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ExtraCommision = new System.Windows.Forms.Button();
            this.btn_ChargeCommission = new System.Windows.Forms.Button();
            this.bgwGetRecords = new System.ComponentModel.BackgroundWorker();
            this.cmb_Customers = new System.Windows.Forms.ComboBox();
            this.dgv_CustomerTransactions = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_TotalCredit = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustomerTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_TotalDebt
            // 
            this.txt_TotalDebt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalDebt.Location = new System.Drawing.Point(324, 171);
            this.txt_TotalDebt.Name = "txt_TotalDebt";
            this.txt_TotalDebt.Size = new System.Drawing.Size(306, 27);
            this.txt_TotalDebt.TabIndex = 108;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(485, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 19);
            this.label7.TabIndex = 107;
            this.label7.Text = "Commission";
            // 
            // txt_Commission
            // 
            this.txt_Commission.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Commission.Location = new System.Drawing.Point(489, 103);
            this.txt_Commission.Name = "txt_Commission";
            this.txt_Commission.Size = new System.Drawing.Size(306, 27);
            this.txt_Commission.TabIndex = 106;
            // 
            // bgwGetCustomers
            // 
            this.bgwGetCustomers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGetCustomers_DoWork);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(320, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 19);
            this.label9.TabIndex = 109;
            this.label9.Text = "Total Debt (Current)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 39);
            this.label6.TabIndex = 105;
            this.label6.Text = "Debit Customer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(798, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 104;
            this.label4.Text = "Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(320, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 19);
            this.label3.TabIndex = 103;
            this.label3.Text = "Account Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 102;
            this.label2.Text = "Search";
            // 
            // txt_AmountCollected
            // 
            this.txt_AmountCollected.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AmountCollected.Location = new System.Drawing.Point(802, 103);
            this.txt_AmountCollected.Name = "txt_AmountCollected";
            this.txt_AmountCollected.Size = new System.Drawing.Size(306, 27);
            this.txt_AmountCollected.TabIndex = 101;
            this.txt_AmountCollected.Enter += new System.EventHandler(this.txt_AmountCollected_Enter);
            this.txt_AmountCollected.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_AmountCollected_KeyDown);
            this.txt_AmountCollected.Leave += new System.EventHandler(this.txt_AmountCollected_Leave);
            // 
            // txt_AccountNumber
            // 
            this.txt_AccountNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AccountNumber.Location = new System.Drawing.Point(324, 103);
            this.txt_AccountNumber.Name = "txt_AccountNumber";
            this.txt_AccountNumber.Size = new System.Drawing.Size(154, 27);
            this.txt_AccountNumber.TabIndex = 100;
            // 
            // lb_Total
            // 
            this.lb_Total.AutoSize = true;
            this.lb_Total.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Total.Location = new System.Drawing.Point(193, 200);
            this.lb_Total.Name = "lb_Total";
            this.lb_Total.Size = new System.Drawing.Size(9, 19);
            this.lb_Total.TabIndex = 98;
            this.lb_Total.Text = "\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 19);
            this.label1.TabIndex = 96;
            this.label1.Text = "Total number of records:";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Location = new System.Drawing.Point(7, 207);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(142, 59);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Debit
            // 
            this.btn_Debit.BackColor = System.Drawing.Color.Red;
            this.btn_Debit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Debit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Debit.ForeColor = System.Drawing.Color.White;
            this.btn_Debit.Location = new System.Drawing.Point(7, 20);
            this.btn_Debit.Name = "btn_Debit";
            this.btn_Debit.Size = new System.Drawing.Size(142, 59);
            this.btn_Debit.TabIndex = 0;
            this.btn_Debit.Text = "Debit";
            this.btn_Debit.UseVisualStyleBackColor = false;
            this.btn_Debit.Click += new System.EventHandler(this.btn_Debit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_ExtraCommision);
            this.panel1.Controls.Add(this.btn_ChargeCommission);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Debit);
            this.panel1.Location = new System.Drawing.Point(956, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 277);
            this.panel1.TabIndex = 95;
            // 
            // btn_ExtraCommision
            // 
            this.btn_ExtraCommision.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_ExtraCommision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExtraCommision.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExtraCommision.ForeColor = System.Drawing.Color.White;
            this.btn_ExtraCommision.Location = new System.Drawing.Point(7, 143);
            this.btn_ExtraCommision.Name = "btn_ExtraCommision";
            this.btn_ExtraCommision.Size = new System.Drawing.Size(142, 59);
            this.btn_ExtraCommision.TabIndex = 5;
            this.btn_ExtraCommision.Text = "Charge Extra Commission";
            this.btn_ExtraCommision.UseVisualStyleBackColor = false;
            this.btn_ExtraCommision.Click += new System.EventHandler(this.btn_ExtraCommision_Click);
            // 
            // btn_ChargeCommission
            // 
            this.btn_ChargeCommission.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_ChargeCommission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChargeCommission.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChargeCommission.ForeColor = System.Drawing.Color.White;
            this.btn_ChargeCommission.Location = new System.Drawing.Point(7, 81);
            this.btn_ChargeCommission.Name = "btn_ChargeCommission";
            this.btn_ChargeCommission.Size = new System.Drawing.Size(142, 59);
            this.btn_ChargeCommission.TabIndex = 4;
            this.btn_ChargeCommission.Text = "Charge Commission";
            this.btn_ChargeCommission.UseVisualStyleBackColor = false;
            this.btn_ChargeCommission.Click += new System.EventHandler(this.btn_ChargeCommission_Click);
            // 
            // bgwGetRecords
            // 
            this.bgwGetRecords.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGetRecords_DoWork);
            // 
            // cmb_Customers
            // 
            this.cmb_Customers.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Customers.FormattingEnabled = true;
            this.cmb_Customers.Location = new System.Drawing.Point(12, 103);
            this.cmb_Customers.Name = "cmb_Customers";
            this.cmb_Customers.Size = new System.Drawing.Size(306, 27);
            this.cmb_Customers.TabIndex = 99;
            this.cmb_Customers.SelectedIndexChanged += new System.EventHandler(this.cmb_Customers_SelectedIndexChanged);
            // 
            // dgv_CustomerTransactions
            // 
            this.dgv_CustomerTransactions.AllowUserToAddRows = false;
            this.dgv_CustomerTransactions.AllowUserToDeleteRows = false;
            this.dgv_CustomerTransactions.AllowUserToResizeRows = false;
            this.dgv_CustomerTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgv_CustomerTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CustomerTransactions.Location = new System.Drawing.Point(12, 222);
            this.dgv_CustomerTransactions.Name = "dgv_CustomerTransactions";
            this.dgv_CustomerTransactions.ReadOnly = true;
            this.dgv_CustomerTransactions.Size = new System.Drawing.Size(932, 469);
            this.dgv_CustomerTransactions.TabIndex = 94;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 19);
            this.label5.TabIndex = 111;
            this.label5.Text = "Total Credit (Current)";
            // 
            // txt_TotalCredit
            // 
            this.txt_TotalCredit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalCredit.Location = new System.Drawing.Point(12, 171);
            this.txt_TotalCredit.Name = "txt_TotalCredit";
            this.txt_TotalCredit.Size = new System.Drawing.Size(306, 27);
            this.txt_TotalCredit.TabIndex = 110;
            // 
            // DebitCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1114, 711);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_TotalCredit);
            this.Controls.Add(this.txt_TotalDebt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Commission);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_AmountCollected);
            this.Controls.Add(this.txt_AccountNumber);
            this.Controls.Add(this.lb_Total);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmb_Customers);
            this.Controls.Add(this.dgv_CustomerTransactions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebitCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Superior Investment: Debit Customer";
            this.Load += new System.EventHandler(this.DebitCustomer_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustomerTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_TotalDebt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Commission;
        private System.ComponentModel.BackgroundWorker bgwGetCustomers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_AmountCollected;
        private System.Windows.Forms.TextBox txt_AccountNumber;
        private System.Windows.Forms.Label lb_Total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Debit;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker bgwGetRecords;
        private System.Windows.Forms.ComboBox cmb_Customers;
        private System.Windows.Forms.DataGridView dgv_CustomerTransactions;
        private System.Windows.Forms.Button btn_ChargeCommission;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_TotalCredit;
        private System.Windows.Forms.Button btn_ExtraCommision;
    }
}