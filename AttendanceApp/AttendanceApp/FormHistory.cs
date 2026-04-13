using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace AttendanceApp
{
    public partial class FormHistory : Form
    {
        public FormHistory()
        {
            InitializeComponent();
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 31; i++)
            {
                dataGridView1.Rows.Add(i.ToString() + "日", "", "");
            }

            string restStart = "";
            string path = "attendance_log.txt";
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);


                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    if (data.Length < 3) continue;

                    string fullDate = data[0].Trim();
                    string time = data[1].Trim();
                    string status = data[2].Trim();

                    string[] dateParts = fullDate.Split('/');
                    int day = int.Parse(dateParts[dateParts.Length - 1]);

                    if (status.Contains("出勤"))
                    {
                        dataGridView1.Rows[day - 1].Cells[1].Value = time;
                    }
                    else if (status.Contains("退勤"))
                    {
                        dataGridView1.Rows[day - 1].Cells[2].Value = time;
                    }
                    else if (status.Contains("休憩開始"))
                    {
                        restStart = time;
                    }
                    else if (status.Contains("休憩終了"))
                    { if (!string.IsNullOrEmpty(restStart)) 
                        { DateTime start = DateTime.Parse(restStart);
                          DateTime end = DateTime.Parse(time);

                            TimeSpan diff = end - start;
                            dataGridView1.Rows[day - 1].Cells[3].Value =  diff.ToString(@"hh\:mm");

                            restStart = "";
           
                        
                        }
                    }

                }
            }
        }
    }
}
