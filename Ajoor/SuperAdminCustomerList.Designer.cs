namespace Ajoor
{
    partial class SuperAdminCustomerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperAdminCustomerList));
            this.dgv_CustomerList = new System.Windows.Forms.DataGridView();
            this.bgwGetRecords = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_CreateCustomerAdmin = new System.Windows.Forms.Button();
            this.lb_Total = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_Subadmin = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnEClear = new System.Windows.Forms.Button();
            this.btnEGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bgwSubAdmin = new System.ComponentModel.BackgroundWorker();
            this.bwg_Summary = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustomerList)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_CustomerList
            // 
            this.dgv_CustomerList.AllowUserToAddRows = false;
            this.dgv_CustomerList.AllowUserToDeleteRows = false;
            this.dgv_CustomerList.AllowUserToResizeRows = false;
            this.dgv_CustomerList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_CustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CustomerList.Location = new System.Drawing.Point(10, 80);
            this.dgv_CustomerList.Name = "dgv_CustomerList";
            this.dgv_CustomerList.ReadOnly = true;
            this.dgv_CustomerList.Size = new System.Drawing.Size(932, 469);
            this.dgv_CustomerList.TabIndex = 10;
            // 
            // bgwGetRecords
            // 
            this.bgwGetRecords.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGetRecords_DoWork);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Delete);
            this.panel1.Controls.Add(this.btn_Edit);
            this.panel1.Controls.Add(this.btn_CreateCustomerAdmin);
            this.panel1.Location = new System.Drawing.Point(950, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 298);
            this.panel1.TabIndex = 11;
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
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.Red;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(7, 150);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(142, 59);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.Green;
            this.btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Edit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Edit.ForeColor = System.Drawing.Color.White;
            this.btn_Edit.Location = new System.Drawing.Point(7, 85);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(142, 59);
            this.btn_Edit.TabIndex = 1;
            this.btn_Edit.Text = "Edit";
            this.btn_Edit.UseVisualStyleBackColor = false;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_CreateCustomerAdmin
            // 
            this.btn_CreateCustomerAdmin.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_CreateCustomerAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateCustomerAdmin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CreateCustomerAdmin.ForeColor = System.Drawing.Color.White;
            this.btn_CreateCustomerAdmin.Location = new System.Drawing.Point(7, 20);
            this.btn_CreateCustomerAdmin.Name = "btn_CreateCustomerAdmin";
            this.btn_CreateCustomerAdmin.Size = new System.Drawing.Size(142, 59);
            this.btn_CreateCustomerAdmin.TabIndex = 0;
            this.btn_CreateCustomerAdmin.Text = "Add";
            this.btn_CreateCustomerAdmin.UseVisualStyleBackColor = false;
            this.btn_CreateCustomerAdmin.Click += new System.EventHandler(this.btn_CreateCustomer_Click);
            // 
            // lb_Total
            // 
            this.lb_Total.AutoSize = true;
            this.lb_Total.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Total.Location = new System.Drawing.Point(184, 58);
            this.lb_Total.Name = "lb_Total";
            this.lb_Total.Size = new System.Drawing.Size(9, 19);
            this.lb_Total.TabIndex = 13;
            this.lb_Total.Text = "\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Total number of records:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.cmb_Subadmin);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnEClear);
            this.groupBox2.Controls.Add(this.btnEGo);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(604, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 74);
            this.groupBox2.TabIndex = 134;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // cmb_Subadmin
            // 
            this.cmb_Subadmin.FormattingEnabled = true;
            this.cmb_Subadmin.Location = new System.Drawing.Point(81, 28);
            this.cmb_Subadmin.Name = "cmb_Subadmin";
            this.cmb_Subadmin.Size = new System.Drawing.Size(237, 22);
            this.cmb_Subadmin.TabIndex = 35;
            this.cmb_Subadmin.SelectedIndexChanged += new System.EventHandler(this.cmb_Subadmin_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(6, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 14);
            this.label12.TabIndex = 34;
            this.label12.Text = "Sub admin";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 39);
            this.label2.TabIndex = 137;
            this.label2.Text = "Customers";
            // 
            // bgwSubAdmin
            // 
            this.bgwSubAdmin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_PullReport_SubadminOnly_DoWork);
            // 
            // bwg_Summary
            // 
            this.bwg_Summary.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwg_Summary_DoWork);
            // 
            // SuperAdminCustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1114, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgv_CustomerList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_Total);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuperAdminCustomerList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Superior Investment: Customer list";
            this.Load += new System.EventHandler(this.SuperAdminCustomerList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CustomerList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_CustomerList;
        private System.ComponentModel.BackgroundWorker bgwGetRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_CreateCustomerAdmin;
        private System.Windows.Forms.Label lb_Total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmb_Subadmin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnEClear;
        private System.Windows.Forms.Button btnEGo;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker bgwSubAdmin;
        private System.ComponentModel.BackgroundWorker bwg_Summary;
    }
}