namespace Ajoor
{
    partial class TransferCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferCustomers));
            this.lb_Total = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bgw_PullCustomers = new System.ComponentModel.BackgroundWorker();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Go = new System.Windows.Forms.Button();
            this.dgv_Customers = new System.Windows.Forms.DataGridView();
            this.cmb_Subadmin = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bgw_PullSubAdmins = new System.ComponentModel.BackgroundWorker();
            this.lb_Progress = new System.Windows.Forms.Label();
            this.bgw_TransferCustomers = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Customers)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Total
            // 
            this.lb_Total.AutoSize = true;
            this.lb_Total.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Total.Location = new System.Drawing.Point(195, 166);
            this.lb_Total.Name = "lb_Total";
            this.lb_Total.Size = new System.Drawing.Size(9, 19);
            this.lb_Total.TabIndex = 123;
            this.lb_Total.Text = "\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 19);
            this.label5.TabIndex = 122;
            this.label5.Text = "Total number of records:";
            // 
            // bgw_PullCustomers
            // 
            this.bgw_PullCustomers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullCustomers_DoWork);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 19);
            this.label7.TabIndex = 126;
            this.label7.Text = "Search";
            // 
            // txt_Search
            // 
            this.txt_Search.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.Location = new System.Drawing.Point(15, 121);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(250, 27);
            this.txt_Search.TabIndex = 125;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 39);
            this.label1.TabIndex = 121;
            this.label1.Text = "Transfer Customers";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Go);
            this.panel1.Location = new System.Drawing.Point(825, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 164);
            this.panel1.TabIndex = 120;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Location = new System.Drawing.Point(5, 85);
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
            // dgv_Customers
            // 
            this.dgv_Customers.AllowUserToAddRows = false;
            this.dgv_Customers.AllowUserToDeleteRows = false;
            this.dgv_Customers.AllowUserToResizeRows = false;
            this.dgv_Customers.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Customers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Customers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_Customers.Location = new System.Drawing.Point(15, 188);
            this.dgv_Customers.Name = "dgv_Customers";
            this.dgv_Customers.ReadOnly = true;
            this.dgv_Customers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Customers.Size = new System.Drawing.Size(804, 400);
            this.dgv_Customers.TabIndex = 119;
            // 
            // cmb_Subadmin
            // 
            this.cmb_Subadmin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Subadmin.FormattingEnabled = true;
            this.cmb_Subadmin.Location = new System.Drawing.Point(286, 121);
            this.cmb_Subadmin.Name = "cmb_Subadmin";
            this.cmb_Subadmin.Size = new System.Drawing.Size(250, 27);
            this.cmb_Subadmin.TabIndex = 128;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(282, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 129;
            this.label2.Text = "Sub-admin";
            // 
            // bgw_PullSubAdmins
            // 
            this.bgw_PullSubAdmins.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullSubAdmins_DoWork);
            // 
            // lb_Progress
            // 
            this.lb_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Progress.AutoSize = true;
            this.lb_Progress.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Progress.Location = new System.Drawing.Point(12, 591);
            this.lb_Progress.Name = "lb_Progress";
            this.lb_Progress.Size = new System.Drawing.Size(0, 19);
            this.lb_Progress.TabIndex = 130;
            // 
            // bgw_TransferCustomers
            // 
            this.bgw_TransferCustomers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_TransferCustomers_DoWork);
            // 
            // TransferCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(989, 611);
            this.Controls.Add(this.lb_Progress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_Subadmin);
            this.Controls.Add(this.lb_Total);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_Customers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TransferCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Superior Investment: Transfer Customers";
            this.Load += new System.EventHandler(this.TransferCustomers_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Customers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_Total;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker bgw_PullCustomers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.DataGridView dgv_Customers;
        private System.Windows.Forms.ComboBox cmb_Subadmin;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker bgw_PullSubAdmins;
        private System.Windows.Forms.Label lb_Progress;
        private System.ComponentModel.BackgroundWorker bgw_TransferCustomers;
    }
}