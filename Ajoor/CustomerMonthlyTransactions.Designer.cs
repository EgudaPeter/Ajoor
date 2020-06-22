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
            this.lbCustomerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_CustomerTransactionRecords = new System.Windows.Forms.DataGridView();
            this.bgw_PullData = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustomerTransactionRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Location = new System.Drawing.Point(831, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 87);
            this.panel1.TabIndex = 147;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Location = new System.Drawing.Point(7, 13);
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
            this.lb_Total.Location = new System.Drawing.Point(193, 73);
            this.lb_Total.Name = "lb_Total";
            this.lb_Total.Size = new System.Drawing.Size(9, 19);
            this.lb_Total.TabIndex = 146;
            this.lb_Total.Text = "\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 19);
            this.label5.TabIndex = 145;
            this.label5.Text = "Total number of records:";
            // 
            // lbCustomerName
            // 
            this.lbCustomerName.AutoSize = true;
            this.lbCustomerName.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustomerName.Location = new System.Drawing.Point(457, 13);
            this.lbCustomerName.Name = "lbCustomerName";
            this.lbCustomerName.Size = new System.Drawing.Size(0, 39);
            this.lbCustomerName.TabIndex = 144;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(445, 39);
            this.label1.TabIndex = 143;
            this.label1.Text = "Monthly transaction records for:";
            // 
            // dgv_CustomerTransactionRecords
            // 
            this.dgv_CustomerTransactionRecords.AllowUserToAddRows = false;
            this.dgv_CustomerTransactionRecords.AllowUserToDeleteRows = false;
            this.dgv_CustomerTransactionRecords.AllowUserToResizeRows = false;
            this.dgv_CustomerTransactionRecords.BackgroundColor = System.Drawing.Color.White;
            this.dgv_CustomerTransactionRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CustomerTransactionRecords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_CustomerTransactionRecords.Location = new System.Drawing.Point(13, 95);
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
            // CustomerMonthlyTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(989, 470);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_Total);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbCustomerName);
            this.Controls.Add(this.label1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lb_Total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCustomerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_CustomerTransactionRecords;
        private System.ComponentModel.BackgroundWorker bgw_PullData;
    }
}