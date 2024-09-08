using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DataBase
{
    public partial class Form3 : Form
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            SolidBrush brush = new SolidBrush(ColorTranslator.FromHtml("#96C08F"));
            graphics.FillRectangle(brush, 10, 50, 875, 31);
            graphics.FillRectangle(brush, 10, 100, 875, 31);
            graphics.FillRectangle(brush, 10, 150, 875, 31);
            graphics.FillRectangle(brush, 10, 200, 875, 31);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            var rect = new Rectangle(0, 0, 914, 43);
            graphics.DrawString("Деталь", new Font("Segoe Print", 15), Brushes.Black, rect, sf);
        }
        public object nameF;
        public object sizesF;
        public object countF;
        public object dateF;
        private void button_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(nameF,sizesF,countF,dateF);
            Hide();
            form4.ShowDialog();
            Form3 form3 = new Form3(nameF,sizesF, countF,dateF);
            form3.ShowDialog();
            Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        public Form3(object name, object sizes, object count, object date)
        {
            nameF = name;
            sizesF = sizes;
            countF = count;
            dateF = date;
            InitializeComponent();
            // Size the form
            Size = new Size(914, 468);
            // Display the form in the center of the screen.
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = ColorTranslator.FromHtml("#42582C");



            Label label = new Label();
            label.Text = "Наименование";
            label.Location = new Point(30, 55);
            label.Font = new Font("Arial", 11);
            Controls.Add(label);

            Label label2 = new Label();
            label2.Text = name.ToString(); 
            label2.Location = new Point(780, 55);
            label2.Font = new Font("Arial", 11);
            Controls.Add(label2);


            Label label3 = new Label();
            label3.Text = "Размеры(ДхШхВ)";
            label3.Location = new Point(30, 105);
            label3.Font = new Font("Arial", 11);
            Controls.Add(label3);

            Label label4 = new Label();
            label4.Text = sizes.ToString();
            label4.Location = new Point(780, 105);
            label4.Font = new Font("Arial", 11);
            Controls.Add(label4);


            Label label5 = new Label();
            label5.Text = "Количество операций";
            label5.Location = new Point(30, 155);
            label5.Font = new Font("Arial", 11);
            Controls.Add(label5);

            Label label6 = new Label();
            label6.Text = count.ToString();
            label6.Location = new Point(780, 155);
            label6.Font = new Font("Arial", 11);
            Controls.Add(label6);


            Label label7 = new Label();
            label7.Text = "Дата начала-дата окончания";
            label7.Location = new Point(30, 205);
            label7.Font = new Font("Arial", 11);
            Controls.Add(label7);

            Label label8 = new Label();
            label8.Text = date.ToString();
            label8.Location = new Point(700, 205);
            label8.Font = new Font("Arial", 11);
            Controls.Add(label8);


            label.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;

            label.Width = 300;

            label3.Width = 300;
            label4.Width = 100;
            label5.Width = 300;
            label6.Width = 100;
            label7.Width = 300;
            label8.Width = 300;

            List<string[]> data = new List<string[]>();
            DataGridView dataGridView1 = new DataGridView();
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Номер п/п "; //текст в шапке
            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Наименование типа операции "; //текст в шапке
            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Разряд рабочего"; //текст в шапке
            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Описание операции"; //текст в шапке
            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Время выполнения"; //текст в шапке

 
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            column2.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            column3.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            column4.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            column5.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);
            dataGridView1.Columns.Add(column5);
            Font F = new Font("Arial", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = F;
            Font FF = new Font("Arial", 11, FontStyle.Italic);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#42582C");
            dataGridView1.Columns[0].DefaultCellStyle.Font = FF;
            dataGridView1.Columns[1].DefaultCellStyle.Font = FF;
            dataGridView1.Columns[2].DefaultCellStyle.Font = FF;
            dataGridView1.Columns[3].DefaultCellStyle.Font = FF;
            dataGridView1.Columns[4].DefaultCellStyle.Font = FF;
            dataGridView1.Width = 890;
            dataGridView1.Height = 110;
            dataGridView1.Location = new Point(5, 245);
            dataGridView1.RowHeadersVisible = false;

            string connStr = @"Server=127.0.0.1;Initial Catalog=db22206;User ID=User072;Password=User072>}96;";
            SqlConnection connection = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("SELECT intNumber,txtTaskTypeName,intTaskTypeRank,txtTaskDescription,intDuration" +
                " FROM tblTaskType, tblTask,tblDetail " +
                "WHERE txtDetailName=\'" + name.ToString() + "\' AND tblTaskType.intTaskTypeId=tblTask.intTaskTypeId AND " +
                "tblDetail.intDetailId=tblTask.intDetailId", connection);
           
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                data.Add(new string[20]);

                data[data.Count - 1][0] = reader[0].ToString();
                 data[data.Count - 1][1] = reader[1].ToString();
                 data[data.Count - 1][2] = reader[2].ToString();
                 data[data.Count - 1][3] = reader[3].ToString();
                 data[data.Count - 1][4] = reader[4].ToString();
               
               
            }
            reader.Close();

            connection.Close();
            dataGridView1.AllowUserToAddRows = false;
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
            
            Controls.Add(dataGridView1);
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 290;
            dataGridView1.Columns[4].Width = 130;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Button button = new Button
            {
                Text = "Добавить операцию",
                BackColor = ColorTranslator.FromHtml("#B8ABBA"),
                Location = new Point(450, 380),
                Size = new Size(194, 34),
                Font = new Font("Arial", 12),

            };

            Button button2 = new Button
            {
                Text = "Отмена",
                BackColor = ColorTranslator.FromHtml("#D9D9D9"),
                Location = new Point(690, 380),
                Size = new Size(194, 34),
                Font = new Font("Arial", 12),

            };
            button.Click += new EventHandler(button_Click);
            button2.Click += new EventHandler(button1_Click);

            // Create an instance of the ListBox.

            button.FlatAppearance.BorderColor = Color.Black;
            button.FlatAppearance.BorderSize = 1;
            button.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderColor = Color.Black;
            button2.FlatAppearance.BorderSize = 1;
            button2.FlatStyle = FlatStyle.Flat;
            Controls.Add(button);
            Controls.Add(button2);
            button.Click += new EventHandler(button1_Click);
        }
    }
}
