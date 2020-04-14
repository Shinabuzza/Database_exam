using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SQLiteConnection DB;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data Source=D:/Exam/kinolenta.db;");
            DB.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "insert Into Kino(Film_name,First_name,Second_name,Film_Date, Country, Price,Income,Profit) values( @Film_name, @First_name, @Second_name,@Film_Date,@Country,@Price,@Income,@profit)";
            CMD.Parameters.Add("@Film_name", System.Data.DbType.String).Value = textBox1.Text;
            CMD.Parameters.Add("@First_name", System.Data.DbType.String).Value = textBox2.Text;
            CMD.Parameters.Add("@Second_name", System.Data.DbType.String).Value = textBox3.Text;
            CMD.Parameters.Add("@Film_Date", System.Data.DbType.String).Value = textBox4.Text;
            CMD.Parameters.Add("@Country", System.Data.DbType.String).Value = textBox5.Text;
            CMD.Parameters.Add("@Price", System.Data.DbType.Int32).Value = textBox6.Text;
            CMD.Parameters.Add("@Income", System.Data.DbType.Int32).Value = textBox7.Text;
            CMD.Parameters.Add("@Profit", System.Data.DbType.Int32).Value = textBox8.Text;
            CMD.ExecuteNonQuery();
    }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                listBox1.Items.Clear();
                SQLiteCommand CMD = DB.CreateCommand();
                CMD.CommandText = "select * From Kino";
                SQLiteDataReader SQL = CMD.ExecuteReader();
                if (SQL.HasRows)
                {
                    while (SQL.Read())
                    {
                        listBox1.Items.Add("Фильм: " + SQL["Film_name"] + " Имя : " + SQL["First_name"] + " Фамилия : " + SQL["Second_name"] + " Дата : " + SQL["Film_date"] + " Страна : " + SQL["Country"] + " Цена : " + SQL["Price"] + " Поступило : " + SQL["Income"] + " Профит : " + SQL["Profit"] + "\t\r\n");
                    }
                }
               
             
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select Film_name from Kino";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                while(SQL.Read())
                {
                    comboBox1.Items.Add(SQL["film_name"]);
                }
            }

            {

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
      
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandType = CommandType.Text;
            CMD.CommandText = "DELETE  from Kino where Film_name LIKE" +"'"+ this.comboBox1.Text + "%'";

            CMD.ExecuteNonQuery();
            
        }

        private void button5_Click(object sender, EventArgs e)

        {
            listBox1.Items.Clear();
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select * From Kino where film_name LIKE" +"'"+this.textBox9.Text+ "%'";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {                    
                    listBox1.Items.Add("Фильм: " + SQL["Film_name"] + " Имя : " + SQL["First_name"] + " Фамилия : " + SQL["Second_name"] + " Дата : " + SQL["Film_date"] + " Страна : " + SQL["Country"] + " Цена : " + SQL["Price"] + " Поступило : " + SQL["Income"] + " Профит : " + SQL["Profit"] + "\t\r\n");
                }
            }


        }
    }
}
