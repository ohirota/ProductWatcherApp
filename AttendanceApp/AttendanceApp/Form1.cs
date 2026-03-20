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
            string nowTime = DateTime.Now.ToString("HH:mm");

            lblStatus.Text ="出勤済 ("+ nowTime +")";

            button1.Enabled = false;

            MessageBox.Show("打刻完了");
        }
    }
}
