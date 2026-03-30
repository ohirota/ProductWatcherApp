namespace AttendanceApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            lblStatus = new Label();
            button2 = new Button();
            lblStatusTAIKIN = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(88, 69);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "出勤";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Yu Gothic UI", 12F);
            lblStatus.Location = new Point(480, 70);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(72, 28);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "未出勤";
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(88, 234);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "退勤";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // lblStatusTAIKIN
            // 
            lblStatusTAIKIN.AutoSize = true;
            lblStatusTAIKIN.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblStatusTAIKIN.Location = new Point(480, 238);
            lblStatusTAIKIN.Name = "lblStatusTAIKIN";
            lblStatusTAIKIN.Size = new Size(72, 28);
            lblStatusTAIKIN.TabIndex = 3;
            lblStatusTAIKIN.Text = "未退勤";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStatusTAIKIN);
            Controls.Add(button2);
            Controls.Add(lblStatus);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label lblStatus;
        private Button button2;
        private Label lblStatusTAIKIN;
    }
}
