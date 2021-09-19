using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Loginn
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\DELL\\Documents\\Userss.accdb");
        OleDbCommand command = new OleDbCommand();
        OleDbDataReader dtr;
        Inicio ini = new Inicio();
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-NV76SQV;Initial Catalog=Loginn;Integrated Security=True");
        public Form1()
        {
          


            InitializeComponent();
        }

       
        public void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            connection.Open();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-NV76SQV;Initial Catalog=Loginn;Integrated Security=True");
            connection.Open();
            SqlCommand comd = new SqlCommand("SELECT Contraseña FROM Usuario WHERE Usuarios= @vusuario AND Contraseña= @vContrasena",connection);
            comd.Parameters.AddWithValue("@vusuario",txtUsuario.Text);
            comd.Parameters.AddWithValue("@vContrasena", txtContraseña.Text);
            try
            {
            SqlDataReader lector = comd.ExecuteReader();
            if (lector.Read());
            {
                ini.Show();
                    this.Close();
            }
            }
            catch(OleDbException k)
            {
                MessageBox.Show(k.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 res = new Form2();
            res.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT Contraseña FROM Usuario WHERE Usuarios='"+txtUsuario.Text+"'";
            try
            {
                dtr = command.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        if (dtr.GetValue(0).ToString() == txtContraseña.Text)
                        {
                            ini.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Contraseña incorrecta");
                        }
                    }
                }
            }
            catch(OleDbException k)
            {
                MessageBox.Show(k.ToString());
            }
        }
    }
}
