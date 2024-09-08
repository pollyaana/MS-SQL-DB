using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Form2 : Form
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            SolidBrush brush = new SolidBrush(ColorTranslator.FromHtml("#C09191"));
            graphics.FillRectangle(brush, 0, 0, 914, 103);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            var rect = new Rectangle(0, 0, 914, 103);
            graphics.DrawString("Новая деталь", new Font("Segoe Print", 23), Brushes.Black, rect, sf);
            graphics.DrawLine(new Pen(Color.Black, 4), 0, 103, 914, 103);
            graphics.DrawLine(new Pen(Color.Black, 4), 0, 300, 914, 300);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        void button2_Click(object sender, EventArgs e)
        {

            string connStr = @"Server=127.0.0.1;Initial Catalog=db22206;User ID=User072;Password=User072>}96;";
            SqlConnection sqlConnection1 = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
          
            string str = "DECLARE @count INT; " +
                "SET @count = (SELECT COUNT(*) FROM tblDetail);"+
            "DBCC CHECKIDENT(tblDetail, RESEED, @count)" +
                "INSERT tblDetail (txtDetailName, fltDetailLength, " +
                "fltDetailWidth, fltDetailHeight," +
            " intTaskCount, datDetailBegin,datDetailEnd) " +
            "VALUES(\'" + textBox1.Text + "\', " + textBox2.Text + ", " + textBox5.Text + ", " + textBox6.Text +
            ", " + textBox3.Text + ",\'" + textBox4.Text + "\',\'" + textBox7.Text + "\')";
            cmd.CommandText = str;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
        public TextBox textBox1;
        public TextBox textBox2;
        public TextBox textBox3;
        public TextBox textBox4;
        public TextBox textBox5;
        public TextBox textBox6;
        public TextBox textBox7;
        public Form2()
        {
            InitializeComponent();
            // Size the form
            Size = new Size(914, 468);
            // Display the form in the center of the screen.
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = ColorTranslator.FromHtml("#C09191");

            Label label1 = new Label();
            label1.Text = "Наименование";
            label1.Location = new Point(100, 125);
            label1.Font = new Font("Arial", 9);
            Controls.Add(label1);

            textBox1 = new TextBox();
            textBox1.Location = new Point(100, 150);
            Controls.Add(textBox1);

            Label label2 = new Label();
            label2.Text = "Размеры";
            label2.Location = new Point(330, 125);
            label2.Font = new Font("Arial", 9);
            Controls.Add(label2);

            Label label8 = new Label();
            label8.Text = "Д";
            label8.Location = new Point(300, 150);
            label8.Font = new Font("Arial", 7);
            label8.Size = new Size(10, 15);
            Controls.Add(label8);

            textBox2 = new TextBox();
            textBox2.Location = new Point(330, 150);
            Controls.Add(textBox2);

            Label label9 = new Label();
            label9.Text = "Ш";
            label9.Location = new Point(300, 200);
            label9.Font = new Font("Arial", 7);
            label9.Size = new Size(15, 15);
            Controls.Add(label9);

            textBox5 = new TextBox();
            textBox5.Location = new Point(330, 200);
            Controls.Add(textBox5);

            Label label10 = new Label();
            label10.Text = "В";
            label10.Size = new Size(10, 15);
            label10.Location = new Point(300, 250);
            label10.Font = new Font("Arial", 7);
            Controls.Add(label10);

            textBox6 = new TextBox();
            textBox6.Location = new Point(330, 250);
            Controls.Add(textBox6);

            Label label3 = new Label();
            label3.Text = "Кол-во операций";
            label3.Size = new Size(80, 35);
            label3.Location = new Point(500, 125);
            label3.Font = new Font("Arial",9);
            Controls.Add(label3);

            textBox3 = new  TextBox();
            textBox3.Location = new Point(500, 160);
            Controls.Add(textBox3);

            Label label4 = new Label();
            label4.Text = "Дата начала";
            label4.Location = new Point(700, 125);
            label4.Font = new Font("Arial", 9);
            Controls.Add(label4);

            textBox4 = new TextBox();
            textBox4.Location = new Point(700, 150);
            Controls.Add(textBox4);

            Label label5 = new Label();
            label5.Text = "Дата окончания";
            label5.Location = new Point(700, 175);
            label5.Font = new Font("Arial", 9);
            Controls.Add(label5);

            textBox7 = new TextBox();
            textBox7.Location = new Point(700, 200);
            Controls.Add(textBox7);

            Button button1 = new Button
            {
                Text = "Сохранить",
                BackColor = ColorTranslator.FromHtml("#D9D9D9"),
                Location = new Point(450, 380),
                Size = new Size(194, 34),
                Font = new Font("Arial", 12),

            };

            Button button2 = new Button
            {
                Text = "Отмена",
                BackColor = ColorTranslator.FromHtml("#D9D9D9"),
                Location = new Point(670, 380),
                Size = new Size(194, 34),
                Font = new Font("Arial", 12),

            };
            List<TextBox> list = new List<TextBox>{ textBox1, textBox2, textBox5, textBox6, textBox3, textBox4, textBox7 };
            
            button2.Click += new EventHandler(button1_Click);

            button1.Tag = textBox1;
            button1.Click += button2_Click;
            Controls.Add(button1);
            Controls.Add(button2);
        }
    }
}
