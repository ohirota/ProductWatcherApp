using System;
using System.IO;
using System.Windows.Forms;

namespace AttendanceApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //最初は出勤ボタンだけ押せる状態にする
            UpdatebuttonStates(false);
        }

        private void UpdatebuttonStates(bool isWorking)
        { 
            //出勤中なら、出勤ボタン1（button1）を無効にする
            button1.Enabled = !isWorking;
        　　
            //出勤中なら、退勤ボタン2(button2)と休憩開始(button3)を有効にする
            button2.Enabled = isWorking;
            button3.Enabled = isWorking;

            //休憩終了(button4)は、休憩開始を押すまでは常に無効
            button4.Enabled = false; 
 
        }


        private void SaveLog(string status)
        {
            string log = DateTime.Now.ToString("yyyy/MM/dd") + "," + DateTime.Now.ToString("HH:mm:ss") + "," + status + "\n" ;
            File.AppendAllText("attendance_log.txt",log);
        }

        //出勤ボタン
　　　  private void button1_Click(object sender, EventArgs e)
        {
            SaveLog("出勤");
            UpdatebuttonStates(true);  //勤務中状態にする
            lblStatus.Text = "出勤済み(" + DateTime.Now.ToString("HH:mm") + " )";
                MessageBox.Show("打刻完了して記入済み");
        }

        //休憩時間開始ボタン
        private void button3_Click(object sender, EventArgs e)
        {
            SaveLog("休憩時間開始");
            button3.Enabled = false;   //連続で押せないように
            button4.Enabled = true;　　//休憩終了で押せるように
            button2.Enabled= false;　　//休憩中は打刻させない
            MessageBox.Show("休憩開始");

        }


        //休憩終了ボタン
        private void button4_Click(object sender, EventArgs e)
        {
            SaveLog("休憩時間終了");
            button3.Enabled = false;   //連続で押せないように
            button4.Enabled = true;　　//休憩行けるようにする
            button2.Enabled = true;　　//退勤できるように戻す
            MessageBox.Show("休憩終了");
        }

        //勤務終了ボタン
        private void button2_Click(object sender, EventArgs e)
        {
            SaveLog("退勤");
            UpdatebuttonStates(false); //勤務終了状態に戻す

            lblStatusTAIKIN.Text = "退勤済み("+ DateTime.Now.ToString("HH:mm") + ")";
            MessageBox.Show("おつぽん(^_-)-☆");
        }

        //履歴表示ボタン
        private void button5_Click(object sender, EventArgs e)
        {
            FormHistory historyform = new FormHistory();
            historyform.Show();
        }


    }
}
