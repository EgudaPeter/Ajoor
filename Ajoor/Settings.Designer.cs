namespace Ajoor
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.chk_AllowReminder = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_AllowReminderOptions = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_UseDialog = new System.Windows.Forms.RadioButton();
            this.rbtn_UseVoice = new System.Windows.Forms.RadioButton();
            this.chk_AllowFlexibleClosing = new System.Windows.Forms.CheckBox();
            this.cmb_FlexibleClosingOfMonthOptions = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chk_AllowReminder
            // 
            this.chk_AllowReminder.AutoSize = true;
            this.chk_AllowReminder.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_AllowReminder.Location = new System.Drawing.Point(12, 84);
            this.chk_AllowReminder.Name = "chk_AllowReminder";
            this.chk_AllowReminder.Size = new System.Drawing.Size(259, 23);
            this.chk_AllowReminder.TabIndex = 104;
            this.chk_AllowReminder.Text = "Allow reminder for closing month";
            this.chk_AllowReminder.UseVisualStyleBackColor = true;
            this.chk_AllowReminder.CheckedChanged += new System.EventHandler(this.chk_AllowReminder_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 39);
            this.label6.TabIndex = 105;
            this.label6.Text = "Settings";
            // 
            // cmb_AllowReminderOptions
            // 
            this.cmb_AllowReminderOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_AllowReminderOptions.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_AllowReminderOptions.FormattingEnabled = true;
            this.cmb_AllowReminderOptions.Items.AddRange(new object[] {
            "7 days to close of month",
            "6 days to close of month",
            "5 days to close of month",
            "3 days to close of month",
            "2 days to close of month",
            "1 day to close of month"});
            this.cmb_AllowReminderOptions.Location = new System.Drawing.Point(277, 82);
            this.cmb_AllowReminderOptions.Name = "cmb_AllowReminderOptions";
            this.cmb_AllowReminderOptions.Size = new System.Drawing.Size(306, 27);
            this.cmb_AllowReminderOptions.TabIndex = 106;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtn_UseDialog);
            this.groupBox1.Controls.Add(this.rbtn_UseVoice);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 107;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reminder options";
            // 
            // rbtn_UseDialog
            // 
            this.rbtn_UseDialog.AutoSize = true;
            this.rbtn_UseDialog.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_UseDialog.Location = new System.Drawing.Point(8, 65);
            this.rbtn_UseDialog.Name = "rbtn_UseDialog";
            this.rbtn_UseDialog.Size = new System.Drawing.Size(96, 23);
            this.rbtn_UseDialog.TabIndex = 109;
            this.rbtn_UseDialog.TabStop = true;
            this.rbtn_UseDialog.Text = "Use dialog";
            this.rbtn_UseDialog.UseVisualStyleBackColor = true;
            // 
            // rbtn_UseVoice
            // 
            this.rbtn_UseVoice.AutoSize = true;
            this.rbtn_UseVoice.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_UseVoice.Location = new System.Drawing.Point(8, 36);
            this.rbtn_UseVoice.Name = "rbtn_UseVoice";
            this.rbtn_UseVoice.Size = new System.Drawing.Size(90, 23);
            this.rbtn_UseVoice.TabIndex = 108;
            this.rbtn_UseVoice.TabStop = true;
            this.rbtn_UseVoice.Text = "Use voice";
            this.rbtn_UseVoice.UseVisualStyleBackColor = true;
            // 
            // chk_AllowFlexibleClosing
            // 
            this.chk_AllowFlexibleClosing.AutoSize = true;
            this.chk_AllowFlexibleClosing.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_AllowFlexibleClosing.Location = new System.Drawing.Point(12, 134);
            this.chk_AllowFlexibleClosing.Name = "chk_AllowFlexibleClosing";
            this.chk_AllowFlexibleClosing.Size = new System.Drawing.Size(239, 23);
            this.chk_AllowFlexibleClosing.TabIndex = 108;
            this.chk_AllowFlexibleClosing.Text = "Allow flexible closing of month";
            this.chk_AllowFlexibleClosing.UseVisualStyleBackColor = true;
            this.chk_AllowFlexibleClosing.CheckedChanged += new System.EventHandler(this.chk_AllowFlexibleClosing_CheckedChanged);
            // 
            // cmb_FlexibleClosingOfMonthOptions
            // 
            this.cmb_FlexibleClosingOfMonthOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FlexibleClosingOfMonthOptions.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_FlexibleClosingOfMonthOptions.FormattingEnabled = true;
            this.cmb_FlexibleClosingOfMonthOptions.Items.AddRange(new object[] {
            "7 days after end of month",
            "6 days after end of month",
            "5 days after end of month",
            "3 days after end of month",
            "2 days after end of month",
            "1 day after end of month"});
            this.cmb_FlexibleClosingOfMonthOptions.Location = new System.Drawing.Point(277, 132);
            this.cmb_FlexibleClosingOfMonthOptions.Name = "cmb_FlexibleClosingOfMonthOptions";
            this.cmb_FlexibleClosingOfMonthOptions.Size = new System.Drawing.Size(306, 27);
            this.cmb_FlexibleClosingOfMonthOptions.TabIndex = 109;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Add);
            this.groupBox2.Controls.Add(this.btn_Cancel);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(415, 322);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Size = new System.Drawing.Size(303, 89);
            this.groupBox2.TabIndex = 110;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(9, 33);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(139, 44);
            this.btn_Add.TabIndex = 7;
            this.btn_Add.Text = "Save";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Location = new System.Drawing.Point(156, 33);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(139, 44);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(727, 418);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmb_FlexibleClosingOfMonthOptions);
            this.Controls.Add(this.chk_AllowFlexibleClosing);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmb_AllowReminderOptions);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chk_AllowReminder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Superior Investment: Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_AllowReminder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_AllowReminderOptions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtn_UseDialog;
        private System.Windows.Forms.RadioButton rbtn_UseVoice;
        private System.Windows.Forms.CheckBox chk_AllowFlexibleClosing;
        private System.Windows.Forms.ComboBox cmb_FlexibleClosingOfMonthOptions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Cancel;
    }
}