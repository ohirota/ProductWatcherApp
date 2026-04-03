using System;
using System.IO;

namespace AttendanceApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)　//出勤ボタン
        {
            string nowTime = DateTime.Now.ToString("HH:mm:ss");
            File.AppendAllText("attendance_log.txt", nowTime + ",出勤" + Environment.NewLine);

            lblStatus.Text = "出勤済み(" + DateTime.Now.ToString("HH:mm") + ")";

            button2.Enabled = false;
            button4.Enabled = false;

            MessageBox.Show("打刻完了して記録済み");

            button3.Enabled = true;
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)　//休憩開始ボタン
        {
            string nowTime = DateTime.Now.ToString("HH:mm:ss");
            File.AppendAllText("attendance_log.txt", nowTime + ",休憩開始" + Environment.NewLine);


            button1.Enabled = false;
            button2.Enabled = false;
            MessageBox.Show("休憩開始");
            button4.Enabled = true;
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nowTime = DateTime.Now.ToString("HH:mm:ss");
            File.AppendAllText("attendance_log.txt", nowTime + ",休憩終了" + Environment.NewLine);


            button1.Enabled = false;
            button3.Enabled = false;
            MessageBox.Show("休憩終了");
            button2.Enabled = true;
            button4.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)　//退勤ボタン
        {
            string nowTime = DateTime.Now.ToString("HH:mm:ss");
            File.AppendAllText("attendance_log.txt", nowTime + ",退勤" + Environment.NewLine);

            lblStatusTAIKIN.Text = "退勤済み(" + DateTime.Now.ToString("HH:mm") + ")";

            button3.Enabled = false;
            button4.Enabled = false;
            

            MessageBox.Show("おつぽん(^_-)-☆");

            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
