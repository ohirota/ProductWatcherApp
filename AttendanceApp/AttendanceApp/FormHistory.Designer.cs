namespace AttendanceApp
{
    partial class FormHistory
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
            dataGridView1 = new DataGridView();
            ColDate = new DataGridViewTextBoxColumn();
            ColWorkbegin = new DataGridViewTextBoxColumn();
            ColWorkFinish = new DataGridViewTextBoxColumn();
            ColWorkRest = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColDate, ColWorkbegin, ColWorkFinish, ColWorkRest });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 426);
            dataGridView1.TabIndex = 0;
            // 
            // ColDate
            // 
            ColDate.HeaderText = "日付";
            ColDate.MinimumWidth = 6;
            ColDate.Name = "ColDate";
            ColDate.ReadOnly = true;
            // 
            // ColWorkbegin
            // 
            ColWorkbegin.HeaderText = "出勤";
            ColWorkbegin.MinimumWidth = 6;
            ColWorkbegin.Name = "ColWorkbegin";
            ColWorkbegin.ReadOnly = true;
            // 
            // ColWorkFinish
            // 
            ColWorkFinish.HeaderText = "退勤";
            ColWorkFinish.MinimumWidth = 6;
            ColWorkFinish.Name = "ColWorkFinish";
            ColWorkFinish.ReadOnly = true;
            // 
            // ColWorkRest
            // 
            ColWorkRest.HeaderText = "休憩時間";
            ColWorkRest.MinimumWidth = 6;
            ColWorkRest.Name = "ColWorkRest";
            ColWorkRest.ReadOnly = true;
            // 
            // FormHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Name = "FormHistory";
            Text = "FormHistory";
            Load += FormHistory_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColDate;
        private DataGridViewTextBoxColumn ColWorkbegin;
        private DataGridViewTextBoxColumn ColWorkFinish;
        private DataGridViewTextBoxColumn ColWorkRest;
    }
}