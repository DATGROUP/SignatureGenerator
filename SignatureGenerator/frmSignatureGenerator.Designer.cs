namespace SignatureGenerator
{
    partial class frmSignatureGenerator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignatureGenerator));
            this.lblCustomerNumber = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtCustomerNumber = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtResultPgpRaw = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtResultPgpUrlEnc = new System.Windows.Forms.TextBox();
            this.txtResultPgpBase64 = new System.Windows.Forms.TextBox();
            this.lblPgpRaw = new System.Windows.Forms.Label();
            this.lblPgpUrlEnc = new System.Windows.Forms.Label();
            this.lblPgpBase64 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCustomerNumber
            // 
            this.lblCustomerNumber.AutoSize = true;
            this.lblCustomerNumber.Location = new System.Drawing.Point(25, 27);
            this.lblCustomerNumber.Name = "lblCustomerNumber";
            this.lblCustomerNumber.Size = new System.Drawing.Size(97, 13);
            this.lblCustomerNumber.TabIndex = 0;
            this.lblCustomerNumber.Text = "Customer Number :";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(25, 53);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(66, 13);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "User Name :";
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Location = new System.Drawing.Point(137, 24);
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Size = new System.Drawing.Size(117, 20);
            this.txtCustomerNumber.TabIndex = 2;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(137, 50);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(117, 20);
            this.txtUserName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Password :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(137, 76);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(117, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // txtResultPgpRaw
            // 
            this.txtResultPgpRaw.Location = new System.Drawing.Point(125, 23);
            this.txtResultPgpRaw.Name = "txtResultPgpRaw";
            this.txtResultPgpRaw.ReadOnly = true;
            this.txtResultPgpRaw.Size = new System.Drawing.Size(711, 20);
            this.txtResultPgpRaw.TabIndex = 6;
            this.txtResultPgpRaw.Click += new System.EventHandler(this.txtResult_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(278, 22);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Generate";
            this.toolTip.SetToolTip(this.btnGenerate, "Generate Signatures ...");
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtResultPgpUrlEnc
            // 
            this.txtResultPgpUrlEnc.Location = new System.Drawing.Point(126, 49);
            this.txtResultPgpUrlEnc.Name = "txtResultPgpUrlEnc";
            this.txtResultPgpUrlEnc.ReadOnly = true;
            this.txtResultPgpUrlEnc.Size = new System.Drawing.Size(711, 20);
            this.txtResultPgpUrlEnc.TabIndex = 8;
            this.txtResultPgpUrlEnc.Click += new System.EventHandler(this.txtResult_Click);
            // 
            // txtResultPgpBase64
            // 
            this.txtResultPgpBase64.Location = new System.Drawing.Point(126, 76);
            this.txtResultPgpBase64.Name = "txtResultPgpBase64";
            this.txtResultPgpBase64.ReadOnly = true;
            this.txtResultPgpBase64.Size = new System.Drawing.Size(711, 20);
            this.txtResultPgpBase64.TabIndex = 9;
            this.txtResultPgpBase64.Click += new System.EventHandler(this.txtResult_Click);
            // 
            // lblPgpRaw
            // 
            this.lblPgpRaw.AutoSize = true;
            this.lblPgpRaw.Location = new System.Drawing.Point(13, 26);
            this.lblPgpRaw.Name = "lblPgpRaw";
            this.lblPgpRaw.Size = new System.Drawing.Size(39, 13);
            this.lblPgpRaw.TabIndex = 10;
            this.lblPgpRaw.Text = "RAW :";
            // 
            // lblPgpUrlEnc
            // 
            this.lblPgpUrlEnc.AutoSize = true;
            this.lblPgpUrlEnc.Location = new System.Drawing.Point(13, 52);
            this.lblPgpUrlEnc.Name = "lblPgpUrlEnc";
            this.lblPgpUrlEnc.Size = new System.Drawing.Size(81, 13);
            this.lblPgpUrlEnc.TabIndex = 11;
            this.lblPgpUrlEnc.Text = "URL Encoded :";
            // 
            // lblPgpBase64
            // 
            this.lblPgpBase64.AutoSize = true;
            this.lblPgpBase64.Location = new System.Drawing.Point(13, 79);
            this.lblPgpBase64.Name = "lblPgpBase64";
            this.lblPgpBase64.Size = new System.Drawing.Size(87, 13);
            this.lblPgpBase64.TabIndex = 12;
            this.lblPgpBase64.Text = "Base64 (SOAP) :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(739, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(359, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.toolTip.SetToolTip(this.btnSave, "Save Signatures to File ...");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.lblPgpRaw);
            this.grpResult.Controls.Add(this.txtResultPgpRaw);
            this.grpResult.Controls.Add(this.lblPgpBase64);
            this.grpResult.Controls.Add(this.txtResultPgpUrlEnc);
            this.grpResult.Controls.Add(this.txtResultPgpBase64);
            this.grpResult.Controls.Add(this.lblPgpUrlEnc);
            this.grpResult.Location = new System.Drawing.Point(12, 127);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(846, 112);
            this.grpResult.TabIndex = 15;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Signatures :  ...    Click to copy the content to Clipboard";
            // 
            // frmSignatureGenerator
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 249);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtCustomerNumber);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblCustomerNumber);
            this.Controls.Add(this.grpResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSignatureGenerator";
            this.Text = "SilverDAT Signature Generator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpResult.ResumeLayout(false);
            this.grpResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomerNumber;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtCustomerNumber;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtResultPgpRaw;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtResultPgpUrlEnc;
        private System.Windows.Forms.TextBox txtResultPgpBase64;
        private System.Windows.Forms.Label lblPgpRaw;
        private System.Windows.Forms.Label lblPgpUrlEnc;
        private System.Windows.Forms.Label lblPgpBase64;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

