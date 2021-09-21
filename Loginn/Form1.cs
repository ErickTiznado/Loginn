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
        public Form1()
        { //Nathaly Milena Zelaya Caballero
          //Julissa Odaly Sosa Flores
          //Oscar Manuel Lopez Velasquez
          //Ana Carolina Guevara Rodriguez.
     OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DELL\Documents\Usuario.accdb ");
            OleDbCommand com = new OleDbCommand();
            OleDbDataReader dtr;


            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-NV76SQV;Initial Catalog=Loginn;Integrated Security=True");
        public void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DELL\Documents\Usuario.accdb ");
            OleDbCommand com = new OleDbCommand();
            OleDbDataReader dtr;
            conexion.Open();
            com.Connection = conexion;
            com.CommandType = CommandType.Text;
            com.CommandText = "SELECT Contraseña FROM Usuarios WHERE nUsuario='" + txtUsuario.Text +"'";
            try
            {
                dtr = com.ExecuteReader();
                if (dtr.HasRows)
                {
                    while(dtr.Read())
                    {
                        if (dtr.GetValue(0).ToString() == txtContraseña.Text)
                        {
                            MessageBox.Show("Loggin Exitiso");
                        }
                       
                        else
                        {
                            MessageBox.Show("Contraseña incorrecta");
                        }
                       
                    }
                }
            }
            catch(Exception k)
            {
                MessageBox.Show(k.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-NV76SQV;Initial Catalog=Loginn;Integrated Security=True");
            connection.Open();
            SqlCommand comd = new SqlCommand("SELECT Contraseña FROM Users WHERE USuario= @vusuario AND Contraseña= @vContrasena",connection);
            comd.Parameters.AddWithValue("@vusuario",txtUsuario.Text);
            comd.Parameters.AddWithValue("@vContrasena", txtContraseña.Text);
            SqlDataReader lector = comd.ExecuteReader();
            if (lector.Read());
            {
                MessageBox.Show("Contraseña correcta");
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
