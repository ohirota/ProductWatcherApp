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
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(62, 73);
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
            lblStatus.Location = new Point(190, 70);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(72, 28);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "未出勤";
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(62, 165);
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
            lblStatusTAIKIN.Location = new Point(190, 165);
            lblStatusTAIKIN.Name = "lblStatusTAIKIN";
            lblStatusTAIKIN.Size = new Size(72, 28);
            lblStatusTAIKIN.TabIndex = 3;
            lblStatusTAIKIN.Text = "未退勤";
            // 
            // button3
            // 
            button3.Location = new Point(399, 73);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 4;
            button3.Text = "休憩開始";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(399, 168);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 5;
            button4.Text = "休憩終了";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(253, 242);
            button5.Name = "button5";
            button5.Size = new Size(145, 42);
            button5.TabIndex = 6;
            button5.Text = "履歴表示";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
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
        private Button button3;
        private Button button4;
        private Button button5;
    }
}
