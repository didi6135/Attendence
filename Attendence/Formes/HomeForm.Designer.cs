namespace Attendence.Formes
{
    partial class HomeForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            linkLabel1 = new LinkLabel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(499, 110);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "זהות עובד";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.LimeGreen;
            label2.Location = new Point(411, 110);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 1;
            label2.Text = "123456789";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.LimeGreen;
            label3.Location = new Point(440, 231);
            label3.Name = "label3";
            label3.Size = new Size(43, 20);
            label3.TabIndex = 3;
            label3.Text = "enter";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(439, 197);
            label4.Name = "label4";
            label4.Size = new Size(132, 20);
            label4.TabIndex = 2;
            label4.Text = "תאריך כניסה אחרון";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(440, 332);
            label5.Name = "label5";
            label5.Size = new Size(33, 20);
            label5.TabIndex = 5;
            label5.Text = "exit";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(440, 301);
            label6.Name = "label6";
            label6.Size = new Size(131, 20);
            label6.TabIndex = 4;
            label6.Text = "תאריך יציאה אחרון";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(407, 390);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(44, 20);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "ביטול";
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.Location = new Point(486, 485);
            button1.Name = "button1";
            button1.Size = new Size(94, 64);
            button1.TabIndex = 7;
            button1.Text = "כניסה";
            button1.UseVisualStyleBackColor = false;
            button1.Click += EnterUser;
            // 
            // button2
            // 
            button2.Location = new Point(171, 485);
            button2.Name = "button2";
            button2.Size = new Size(0, 0);
            button2.TabIndex = 8;
            button2.Text = "יציאה";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.BackColor = Color.LightCoral;
            button3.Location = new Point(194, 485);
            button3.Name = "button3";
            button3.Size = new Size(94, 64);
            button3.TabIndex = 9;
            button3.Text = "יציאה";
            button3.UseVisualStyleBackColor = false;
            button3.Click += ExitFromProgrem;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 597);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(linkLabel1);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "HomeForm";
            Text = "HomePage";
            FormClosed += HomeForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private LinkLabel linkLabel1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}