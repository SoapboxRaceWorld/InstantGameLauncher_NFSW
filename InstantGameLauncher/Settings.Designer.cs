namespace InstantGameLauncher
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
            this.emailLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.serverLabel = new System.Windows.Forms.Label();
            this.executableLabel = new System.Windows.Forms.Label();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.serverText = new System.Windows.Forms.ComboBox();
            this.executableText = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(12, 15);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(39, 13);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.Text = "E-Mail:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(12, 41);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Password:";
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Location = new System.Drawing.Point(12, 68);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(41, 13);
            this.serverLabel.TabIndex = 2;
            this.serverLabel.Text = "Server:";
            // 
            // executableLabel
            // 
            this.executableLabel.AutoSize = true;
            this.executableLabel.Location = new System.Drawing.Point(12, 95);
            this.executableLabel.Name = "executableLabel";
            this.executableLabel.Size = new System.Drawing.Size(117, 13);
            this.executableLabel.TabIndex = 3;
            this.executableLabel.Text = "Executable (nfsw.exe): ";
            // 
            // usernameText
            // 
            this.usernameText.Location = new System.Drawing.Point(155, 12);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(177, 20);
            this.usernameText.TabIndex = 4;
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(155, 38);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(177, 20);
            this.passwordText.TabIndex = 5;
            // 
            // serverText
            // 
            this.serverText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serverText.FormattingEnabled = true;
            this.serverText.Location = new System.Drawing.Point(155, 65);
            this.serverText.Name = "serverText";
            this.serverText.Size = new System.Drawing.Size(177, 21);
            this.serverText.TabIndex = 6;
            // 
            // executableText
            // 
            this.executableText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.executableText.FormattingEnabled = true;
            this.executableText.Location = new System.Drawing.Point(155, 92);
            this.executableText.Name = "executableText";
            this.executableText.Size = new System.Drawing.Size(177, 21);
            this.executableText.TabIndex = 7;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(221, 119);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(111, 28);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save and Run";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 159);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.executableText);
            this.Controls.Add(this.serverText);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.executableLabel);
            this.Controls.Add(this.serverLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.emailLabel);
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.Label executableLabel;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.ComboBox serverText;
        private System.Windows.Forms.ComboBox executableText;
        private System.Windows.Forms.Button saveButton;
    }
}