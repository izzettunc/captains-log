namespace Günlük_Uygulaması
{
    partial class changeAccountInfoForm
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.MinimizeButton = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.secwordLabel = new System.Windows.Forms.Label();
            this.newInfoLabel = new System.Windows.Forms.Label();
            this.oldInfoLabel = new System.Windows.Forms.Label();
            this.oldInfoInput = new System.Windows.Forms.TextBox();
            this.newInfoInput = new System.Windows.Forms.TextBox();
            this.secwordInput = new System.Windows.Forms.TextBox();
            this.processLabel = new System.Windows.Forms.Label();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(42)))), ((int)(((byte)(51)))));
            this.topPanel.Controls.Add(this.MinimizeButton);
            this.topPanel.Controls.Add(this.pictureBox3);
            this.topPanel.Controls.Add(this.CloseButton);
            this.topPanel.Controls.Add(this.label4);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(755, 59);
            this.topPanel.TabIndex = 9;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.topPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(59)))));
            this.MinimizeButton.Image = global::Günlük_Uygulaması.Properties.Resources.minimize;
            this.MinimizeButton.Location = new System.Drawing.Point(667, 12);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(35, 35);
            this.MinimizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MinimizeButton.TabIndex = 10;
            this.MinimizeButton.TabStop = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Günlük_Uygulaması.Properties.Resources.icon;
            this.pictureBox3.Location = new System.Drawing.Point(12, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(52, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(59)))));
            this.CloseButton.Image = global::Günlük_Uygulaması.Properties.Resources.close;
            this.CloseButton.InitialImage = null;
            this.CloseButton.Location = new System.Drawing.Point(708, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(35, 35);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 9;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(70, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Captain\'s Log V.1.0.0";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.label4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.label4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            // 
            // secwordLabel
            // 
            this.secwordLabel.AutoSize = true;
            this.secwordLabel.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.secwordLabel.ForeColor = System.Drawing.Color.LightGray;
            this.secwordLabel.Location = new System.Drawing.Point(46, 195);
            this.secwordLabel.Name = "secwordLabel";
            this.secwordLabel.Size = new System.Drawing.Size(126, 20);
            this.secwordLabel.TabIndex = 17;
            this.secwordLabel.Text = "Secure Word:";
            // 
            // newInfoLabel
            // 
            this.newInfoLabel.AutoSize = true;
            this.newInfoLabel.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.newInfoLabel.ForeColor = System.Drawing.Color.LightGray;
            this.newInfoLabel.Location = new System.Drawing.Point(46, 161);
            this.newInfoLabel.Name = "newInfoLabel";
            this.newInfoLabel.Size = new System.Drawing.Size(46, 20);
            this.newInfoLabel.TabIndex = 16;
            this.newInfoLabel.Text = "New";
            // 
            // oldInfoLabel
            // 
            this.oldInfoLabel.AutoSize = true;
            this.oldInfoLabel.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.oldInfoLabel.ForeColor = System.Drawing.Color.LightGray;
            this.oldInfoLabel.Location = new System.Drawing.Point(46, 122);
            this.oldInfoLabel.Name = "oldInfoLabel";
            this.oldInfoLabel.Size = new System.Drawing.Size(38, 20);
            this.oldInfoLabel.TabIndex = 15;
            this.oldInfoLabel.Text = "Old";
            // 
            // oldInfoInput
            // 
            this.oldInfoInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.oldInfoInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.oldInfoInput.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.oldInfoInput.ForeColor = System.Drawing.Color.LightGray;
            this.oldInfoInput.Location = new System.Drawing.Point(384, 121);
            this.oldInfoInput.MaxLength = 32;
            this.oldInfoInput.Name = "oldInfoInput";
            this.oldInfoInput.Size = new System.Drawing.Size(359, 21);
            this.oldInfoInput.TabIndex = 18;
            // 
            // newInfoInput
            // 
            this.newInfoInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.newInfoInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newInfoInput.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.newInfoInput.ForeColor = System.Drawing.Color.LightGray;
            this.newInfoInput.Location = new System.Drawing.Point(384, 161);
            this.newInfoInput.MaxLength = 32;
            this.newInfoInput.Name = "newInfoInput";
            this.newInfoInput.Size = new System.Drawing.Size(359, 21);
            this.newInfoInput.TabIndex = 19;
            // 
            // secwordInput
            // 
            this.secwordInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.secwordInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.secwordInput.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.secwordInput.ForeColor = System.Drawing.Color.LightGray;
            this.secwordInput.Location = new System.Drawing.Point(384, 188);
            this.secwordInput.MaxLength = 32;
            this.secwordInput.Name = "secwordInput";
            this.secwordInput.Size = new System.Drawing.Size(359, 21);
            this.secwordInput.TabIndex = 20;
            // 
            // processLabel
            // 
            this.processLabel.BackColor = System.Drawing.Color.Transparent;
            this.processLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.processLabel.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.processLabel.ForeColor = System.Drawing.Color.LightGray;
            this.processLabel.Location = new System.Drawing.Point(0, 59);
            this.processLabel.Name = "processLabel";
            this.processLabel.Size = new System.Drawing.Size(755, 49);
            this.processLabel.TabIndex = 21;
            this.processLabel.Text = "Process";
            this.processLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(66)))));
            this.saveSettingsButton.FlatAppearance.BorderSize = 0;
            this.saveSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveSettingsButton.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.saveSettingsButton.ForeColor = System.Drawing.Color.LightGray;
            this.saveSettingsButton.Location = new System.Drawing.Point(595, 305);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(148, 32);
            this.saveSettingsButton.TabIndex = 22;
            this.saveSettingsButton.Text = "Save";
            this.saveSettingsButton.UseVisualStyleBackColor = false;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // changeAccountInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(755, 349);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.processLabel);
            this.Controls.Add(this.secwordInput);
            this.Controls.Add(this.newInfoInput);
            this.Controls.Add(this.oldInfoInput);
            this.Controls.Add(this.secwordLabel);
            this.Controls.Add(this.newInfoLabel);
            this.Controls.Add(this.oldInfoLabel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "changeAccountInfoForm";
            this.Text = "changeAccountInfoForm";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.PictureBox MinimizeButton;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox CloseButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label secwordLabel;
        private System.Windows.Forms.Label newInfoLabel;
        private System.Windows.Forms.Label oldInfoLabel;
        private System.Windows.Forms.TextBox oldInfoInput;
        private System.Windows.Forms.TextBox newInfoInput;
        private System.Windows.Forms.TextBox secwordInput;
        private System.Windows.Forms.Label processLabel;
        private System.Windows.Forms.Button saveSettingsButton;
    }
}