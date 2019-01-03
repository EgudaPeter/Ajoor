namespace Ajoor
{
    partial class LoginRestoreDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginRestoreDialog));
            this.btn_Restore = new System.Windows.Forms.Button();
            this.btn_Login = new System.Windows.Forms.Button();
            this.chk_DoNotShowScreenAgain = new System.Windows.Forms.CheckBox();
            this.lb_Progress = new System.Windows.Forms.Label();
            this.bgwRestore = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btn_Restore
            // 
            this.btn_Restore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Restore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Restore.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Restore.Location = new System.Drawing.Point(296, 61);
            this.btn_Restore.Name = "btn_Restore";
            this.btn_Restore.Size = new System.Drawing.Size(216, 100);
            this.btn_Restore.TabIndex = 8;
            this.btn_Restore.Text = "Restore work";
            this.btn_Restore.UseVisualStyleBackColor = true;
            this.btn_Restore.Click += new System.EventHandler(this.btn_Restore_Click);
            // 
            // btn_Login
            // 
            this.btn_Login.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.Location = new System.Drawing.Point(61, 61);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(216, 100);
            this.btn_Login.TabIndex = 7;
            this.btn_Login.Text = "Continue with start-up process";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // chk_DoNotShowScreenAgain
            // 
            this.chk_DoNotShowScreenAgain.AutoSize = true;
            this.chk_DoNotShowScreenAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_DoNotShowScreenAgain.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_DoNotShowScreenAgain.Location = new System.Drawing.Point(387, 233);
            this.chk_DoNotShowScreenAgain.Name = "chk_DoNotShowScreenAgain";
            this.chk_DoNotShowScreenAgain.Size = new System.Drawing.Size(193, 23);
            this.chk_DoNotShowScreenAgain.TabIndex = 9;
            this.chk_DoNotShowScreenAgain.Text = "Do not show screen again\r\n";
            this.chk_DoNotShowScreenAgain.UseVisualStyleBackColor = true;
            // 
            // lb_Progress
            // 
            this.lb_Progress.AutoSize = true;
            this.lb_Progress.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Progress.Location = new System.Drawing.Point(12, 239);
            this.lb_Progress.Name = "lb_Progress";
            this.lb_Progress.Size = new System.Drawing.Size(0, 19);
            this.lb_Progress.TabIndex = 10;
            // 
            // bgwRestore
            // 
            this.bgwRestore.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRestore_DoWork);
            this.bgwRestore.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRestore_RunWorkerCompleted);
            // 
            // LoginRestoreDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.lb_Progress);
            this.Controls.Add(this.chk_DoNotShowScreenAgain);
            this.Controls.Add(this.btn_Restore);
            this.Controls.Add(this.btn_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginRestoreDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Superior Investment";
            this.Load += new System.EventHandler(this.LoginRestoreDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Restore;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.CheckBox chk_DoNotShowScreenAgain;
        private System.Windows.Forms.Label lb_Progress;
        private System.ComponentModel.BackgroundWorker bgwRestore;
    }
}