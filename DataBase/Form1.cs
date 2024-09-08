using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;

namespace DataBase
{
    public partial class Form1 : Form
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            
            var graphics = e.Graphics;
            SolidBrush brush = new SolidBrush(ColorTranslator.FromHtml("#A3BFA6"));
            graphics.FillRectangle(brush, 0, 0, 914, 103);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            var rect = new Rectangle(0, 0, 914, 103);
            graphics.DrawString("Детали", new Font("Segoe Print", 23), Brushes.Black, rect,sf);
            graphics.DrawLine(new Pen(Color.Black, 4), 0, 103, 914, 103);
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Hide();
            form2.ShowDialog();
            Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            object name = dataGridView1.CurrentRow.Cells[0].Value;
            object sizes = dataGridView1.CurrentRow.Cells[1].Value;
            object count = dataGridView1.CurrentRow.Cells[2].Value;
            object date = dataGridView1.CurrentRow.Cells[3].Value;
            Form3 form3 = new Form3(name,sizes,count,date);
            Hide();
            form3.ShowDialog();
            Show();
        }
        public DataGridView dataGridView1;
        public Form1()
        {
            this.Refresh();
            // Size the form
            Size = new Size(914, 468);
            // Display the form in the center of the screen.
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = ColorTranslator.FromHtml("#DABFA6");
 
            Button button = new Button
            {
                Text = "Добавить деталь",
                BackColor = ColorTranslator.FromHtml("#B8ABBA"),
                Location = new Point(670, 350),
                Size = new Size(194, 38),
                Font = new Font("Arial", 13),
                
            };

            // Create an instance of the ListBox.

            button.FlatAppearance.BorderColor = Color.Black;
            button.FlatAppearance.BorderSize = 3;
            button.FlatStyle = FlatStyle.Flat;
            Controls.Add(button);
            button.Click += new EventHandler(button1_Click);

            string connStr = @"Server=127.0.0.1;Initial Catalog=db22206;User ID=User072;Password=User072>}96;";
            SqlConnection connection = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblDetail", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<string[]> data = new List<string[]>();
            dataGridView1 = new DataGridView();
            dataGridView1.CellContentDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Наименование "; //текст в шапке
            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Размеры ДхШхВ "; //текст в шапке
            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Количество операций"; //текст в шапке
            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Дата начала - Дата окончания"; //текст в шапке

            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            column2.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            column3.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            column4.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);
            dataGridView1.Width = 807;
            dataGridView1.Height = 164;
            dataGridView1.Location = new Point(60, 140);
            dataGridView1.RowHeadersVisible = false;
            Font F = new Font("Arial", 13, FontStyle.Bold);
          
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = F;
            Font FF = new Font("Arial", 13, FontStyle.Italic);
            dataGridView1.ColumnHeadersHeight = 30;
          

            dataGridView1.Columns[0].DefaultCellStyle.Font = FF;
            dataGridView1.Columns[1].DefaultCellStyle.Font = FF;
            dataGridView1.Columns[2].DefaultCellStyle.Font = FF;
            dataGridView1.Columns[3].DefaultCellStyle.Font = FF;
            dataGridView1.Columns[0].Width = 160;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 237;
            dataGridView1.Columns[3].Width = 290;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            var str1 = "";
            var str1Arr = new string[3];
            var str2Arr = new string[3];
            var str2 = "";
            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[1].ToString();
                data[data.Count - 1][1] = reader[2].ToString() + "x" + reader[3].ToString() + "x" + reader[4].ToString();
                data[data.Count - 1][2] = reader[5].ToString();
                str1 = reader[6].ToString();
                str1Arr = str1.Split(':');
                str1 = str1Arr[0];
                str1 = str1.Substring(0, str1.Length - 1);
                str2 = reader[7].ToString();
                str2Arr = str2.Split(':');
                str2 = str2Arr[0];
                str2 = str2.Substring(0, str2.Length - 1);
                data[data.Count - 1][3] = str1 + "- " + str2;
            }

            reader.Close();

            connection.Close();
            dataGridView1.AllowUserToAddRows = false;
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
            int n = dataGridView1.Rows.Count;
            //dataGridView1.Rows.RemoveAt(n-1);
            Controls.Add(dataGridView1);
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
