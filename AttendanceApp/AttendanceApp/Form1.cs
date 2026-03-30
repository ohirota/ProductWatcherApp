using System;
using System.IO;

namespace AttendanceApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)　//出勤ボタン
        {
            string nowTime = DateTime.Now.ToString("HH:mm:ss");
            File.AppendAllText("attendance_log.txt", nowTime + ",出勤" + Environment.NewLine);

            lblStatus.Text = "出勤済み(" + DateTime.Now.ToString("HH:mm") + ")";

            button1.Enabled = false;

            MessageBox.Show("打刻完了して記録済み");

            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)　//退勤ボタン
        {
            string nowTime = DateTime.Now.ToString("HH:mm:ss");
            File.AppendAllText("attendance_log.txt", nowTime + ",退勤" + Environment.NewLine);

            lblStatusTAIKIN.Text = "退勤済み(" + DateTime.Now.ToString("HH:mm") + ")";

            button2.Enabled = false;

            MessageBox.Show("おつぽん(^_-)-☆");

            button1.Enabled = true;
        }
    }
}
