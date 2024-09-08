using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace DataBase
{
    public partial class Form4 : Form
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            SolidBrush brush1 = new SolidBrush(ColorTranslator.FromHtml("#9B85BD"));
            SolidBrush brush = new SolidBrush(ColorTranslator.FromHtml("#96C08F"));
            SolidBrush brush3 = new SolidBrush(ColorTranslator.FromHtml("#42582C"));
            
            graphics.FillRectangle(brush3, 5, 50, 885, 200);
            graphics.FillRectangle(brush, 10, 60, 875, 31);
            graphics.FillRectangle(brush, 10, 110, 875, 31);
            graphics.FillRectangle(brush, 10, 160, 875, 31);
            graphics.FillRectangle(brush, 10, 210, 875, 31);
        
            graphics.FillRectangle(brush1, 0, 0, 914, 40);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            var rect = new Rectangle(0, 0, 914, 40);
            graphics.DrawString("Добавить операцию", new Font("Segoe Print", 13), Brushes.Black, rect, sf);
            graphics.DrawLine(new Pen(Color.Black, 2), 0, 40, 914, 40);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = @"Server=127.0.0.1;Initial Catalog=db22206;User ID=User072;Password=User072>}96;";
            SqlConnection sqlConnection1 = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("SELECT *  FROM tblDetail WHERE txtDetailName = \'" + nameF + "\'");
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            object id_detail=null;
            object id_op = null;
            while (reader.Read())
                 id_detail = reader[0];
            reader.Close();
            cmd = new SqlCommand("SELECT tblTaskType.intTaskTypeId" +
                " FROM tblTaskType, tblTask" +
                " WHERE tblTaskType.intTaskTypeId=tblTask.intTaskTypeId AND txtTaskTypeName=\'" + list.Text + "\'");
            cmd.Connection = sqlConnection1;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                id_op = reader[0];
            reader.Close();
          
            string str = "DECLARE @count INT;" +
                "SET @count = (SELECT COUNT(*) FROM tblTask);" +
                "DBCC CHECKIDENT(tblTask, RESEED, @count)" +
                "INSERT tblTask (txtTaskDescription,intDetailId, intTaskTypeId,intDuration,intNumber) " +
            "VALUES(\'"+textBox1.Text +"\',"+ id_detail+","+id_op+","+textBox2.Text+","+trackBar1.Value+ ")";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
            
            textBox1.Clear();
            textBox2.Clear();
            labelVal.Text = "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

        }
        public object nameF;
        public Form4(object name, object sizes, object count, object date)
        {
            nameF = name;
            InitializeComponent();
            // Size the form
            Size = new Size(914, 600);
            // Display the form in the center of the screen.
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = ColorTranslator.FromHtml("#B88686");

            Label label = new Label();
            label.Text = "Наименование";
            label.Location = new Point(30, 65);
            label.Font = new Font("Arial", 11);
            Controls.Add(label);

            Label label2 = new Label();
            label2.Text = name.ToString();
            label2.Location = new Point(780, 65);
            label2.Font = new Font("Arial", 11);
            Controls.Add(label2);


            Label label3 = new Label();
            label3.Text = "Размеры(ДхШхВ)";
            label3.Location = new Point(30, 115);
            label3.Font = new Font("Arial", 11);
            Controls.Add(label3);

            Label label4 = new Label();
            label4.Text = sizes.ToString();
            label4.Location = new Point(780, 115);
            label4.Font = new Font("Arial", 11);
            Controls.Add(label4);


            Label label5 = new Label();
            label5.Text = "Количество операций";
            label5.Location = new Point(30, 165);
            label5.Font = new Font("Arial", 11);
            Controls.Add(label5);

            Label label6 = new Label();
            label6.Text = count.ToString();
            label6.Location = new Point(780, 165);
            label6.Font = new Font("Arial", 11);
            Controls.Add(label6);


            Label label7 = new Label();
            label7.Text = "Дата начала-дата окончания";
            label7.Location = new Point(30, 215);
            label7.Font = new Font("Arial", 11);
            Controls.Add(label7);

            Label label8 = new Label();
            label8.Text = date.ToString();
            label8.Location = new Point(700, 215);
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


            Label num_PP = new Label();
            num_PP.Text = "Номер П/П";
            num_PP.Location = new Point(20, 265);
            num_PP.Font = new Font("Arial", 13);
            num_PP.BackColor = Color.Transparent;
            num_PP.Width = 110;
            Controls.Add(num_PP);

            trackBar1 = new System.Windows.Forms.TrackBar();
            
            trackBar1.Location = new Point(150, 265);
            trackBar1.AutoSize = false;
            trackBar1.Size = new Size(724, 25);

           
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 1;
            labelVal = new Label();
            labelVal.Location = new Point(500,300);
            labelVal.Font = new Font("Arial", 11);
            labelVal.BackColor = Color.Transparent;
            labelVal.Text = "1";
            Controls.Add(labelVal);
           trackBar1.BackColor = ColorTranslator.FromHtml("#9B85BD");
  
            Controls.Add(trackBar1);
           trackBar1.ValueChanged += new EventHandler(TrackBarOnValueChanged);

            Label type_Op = new Label();
            type_Op.Text = "Тип операции";
            type_Op.Location = new Point(20, 330);
            type_Op.Font = new Font("Arial", 13);
            type_Op.BackColor = Color.Transparent;
            type_Op.Width = 200;
            Controls.Add(type_Op);

            list = new System.Windows.Forms.ComboBox();
            list.Location = new Point(250,330);
            list.Size = new Size(500,100);
            list.Font = new Font("Arial", 12);
            string connStr = @"Server=127.0.0.1;Initial Catalog=db22206;User ID=User072;Password=User072>}96;";
            SqlConnection connection = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblTaskType", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<string[]> data = new List<string[]>();
            int i = 0;
            while (reader.Read())
            {
                list.Items.Add(reader["txtTaskTypeName"].ToString());
                i++;
            }
            Controls.Add(list);
            reader.Close();

            connection.Close();
            Label descrip = new Label();
            descrip.Text = "Описание";
            descrip.Location = new Point(20, 395);
            descrip.Font = new Font("Arial", 13);
            descrip.BackColor = Color.Transparent;
            Controls.Add(descrip);

            textBox1 = new System.Windows.Forms.TextBox();
            textBox1.Location = new Point(250, 395);
            textBox1.Size = new Size(500, 100);
            
            textBox1.Font = new Font("Arial", 12);
            Controls.Add(textBox1);

            Label time = new Label();
            time.Text = "Время выполнения";
            time.Location = new Point(20, 460);
            time.Font = new Font("Arial", 13);
            Controls.Add(time);

            textBox2 = new System.Windows.Forms.TextBox();
            textBox2.Location = new Point(250, 460);
            textBox2.Size = new Size(500, 100);
            textBox2.Font = new Font("Arial", 12);
            Controls.Add(textBox2);


            Button button = new Button
            {
                Text = "Сохранить",
                BackColor = ColorTranslator.FromHtml("#9B85BD"),
                Location = new Point(750, 520),
                Size = new Size(124, 30),
                Font = new Font("Arial", 12),

            };
            Button button2 = new Button
            {
                Text = "Отмена",
                BackColor = ColorTranslator.FromHtml("#D9D9D9"),
                Location = new Point(600, 520),
                Size = new Size(124, 30),
                Font = new Font("Arial", 12),
            };
            

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
            button2.Click += new EventHandler(button2_Click);
        }

        public System.Windows.Forms.TrackBar trackBar1;
        public Label labelVal;
        public System.Windows.Forms.ComboBox list;
        public TextBox textBox1;
        public TextBox textBox2;
        private void TrackBarOnValueChanged(object sender, EventArgs e)
        {
            labelVal.Text =  trackBar1.Value.ToString();
        }
    }
}
