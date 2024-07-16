namespace Attendence.Formes
{
    partial class ChangePasswordForm
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
            button1 = new Button();
            employeeNatLabel = new TextBox();
            label1 = new Label();
            oldPass = new TextBox();
            label2 = new Label();
            newPass1 = new TextBox();
            label3 = new Label();
            reNewPass = new TextBox();
            label4 = new Label();
            button2 = new Button();
            testOld = new Label();
            oldPassError = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(151, 427);
            button1.Name = "button1";
            button1.Size = new Size(219, 48);
            button1.TabIndex = 10;
            button1.Text = "שינוי סיסמא";
            button1.UseVisualStyleBackColor = true;
            button1.Click += label_changePassword_Click;
            // 
            // employeeNatLabel
            // 
            employeeNatLabel.Location = new Point(126, 93);
            employeeNatLabel.Multiline = true;
            employeeNatLabel.Name = "employeeNatLabel";
            employeeNatLabel.Size = new Size(262, 41);
            employeeNatLabel.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(404, 105);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 6;
            label1.Text = "תעודת זהות";
            // 
            // oldPass
            // 
            oldPass.Location = new Point(126, 168);
            oldPass.Multiline = true;
            oldPass.Name = "oldPass";
            oldPass.Size = new Size(262, 41);
            oldPass.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(404, 180);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 12;
            label2.Text = "סיסמא ישנה";
            // 
            // newPass1
            // 
            newPass1.Location = new Point(126, 251);
            newPass1.Multiline = true;
            newPass1.Name = "newPass1";
            newPass1.Size = new Size(262, 41);
            newPass1.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(404, 263);
            label3.Name = "label3";
            label3.Size = new Size(96, 20);
            label3.TabIndex = 14;
            label3.Text = "סיסמא חדשה";
            // 
            // reNewPass
            // 
            reNewPass.Location = new Point(126, 323);
            reNewPass.Multiline = true;
            reNewPass.Name = "reNewPass";
            reNewPass.Size = new Size(262, 41);
            reNewPass.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(404, 335);
            label4.Name = "label4";
            label4.Size = new Size(138, 20);
            label4.TabIndex = 16;
            label4.Text = "אישור סיסמא חדשה";
            // 
            // button2
            // 
            button2.Location = new Point(151, 492);
            button2.Name = "button2";
            button2.Size = new Size(219, 48);
            button2.TabIndex = 18;
            button2.Text = "ביטול";
            button2.UseVisualStyleBackColor = true;
            button2.Click += CancelAndReturnToHomePage;
            // 
            // testOld
            // 
            testOld.AutoSize = true;
            testOld.ForeColor = Color.Red;
            testOld.Location = new Point(253, 376);
            testOld.Name = "testOld";
            testOld.Size = new Size(0, 20);
            testOld.TabIndex = 19;
            // 
            // oldPassError
            // 
            oldPassError.AutoSize = true;
            oldPassError.ForeColor = Color.Red;
            oldPassError.Location = new Point(253, 228);
            oldPassError.Name = "oldPassError";
            oldPassError.Size = new Size(0, 20);
            oldPassError.TabIndex = 21;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 596);
            Controls.Add(oldPassError);
            Controls.Add(testOld);
            Controls.Add(button2);
            Controls.Add(reNewPass);
            Controls.Add(label4);
            Controls.Add(newPass1);
            Controls.Add(label3);
            Controls.Add(oldPass);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(employeeNatLabel);
            Controls.Add(label1);
            Name = "ChangePasswordForm";
            Text = "CangePassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private TextBox employeeNatLabel;
        private Label label1;
        private TextBox oldPass;
        private Label label2;
        private TextBox newPass1;
        private Label label3;
        private TextBox reNewPass;
        private Label label4;
        private Button button2;
        private Label testOld;
        private Label oldPassError;
    }
}