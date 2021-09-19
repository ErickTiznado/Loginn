using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;	


namespace Loginn
{
    public partial class Form2 : Form
    {
		Form1 formu = new Form1();
		public Form2()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
			SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-NV76SQV;Initial Catalog=Loginn;Integrated Security=True");
			string query = "INSERT INTO Users (USuario,Contraseña) VALUES (@Usuario,@Contra )";
			conexion.Open();
			SqlCommand comando = new SqlCommand(query,conexion);
			comando.Parameters.AddWithValue("@Usuario", Convert.ToString(txtUsuario.Text));
			comando.Parameters.AddWithValue("@Contra", Convert.ToString(txtContraseña.Text));
			comando.ExecuteNonQuery();
			MessageBox.Show("Datos insertados con exito");
			this.Close();
			formu.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
			try
			{
				OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DELL\Documents\Userss.accdb ");
				conexion.Open();
				string insertar = "INSERT INTO Usuario  VALUES ( @Id,@Usuario, @Cont)";
				OleDbCommand cmd = new OleDbCommand(insertar, conexion);
				cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(txtId.Text));
				cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
				cmd.Parameters.AddWithValue("@Cont", txtContraseña.Text);
				cmd.ExecuteNonQuery();
				this.Close();
				formu.Show();

			}

			catch (DBConcurrencyException ex)
			{
				MessageBox.Show("Error de concurrencia:\n" + ex.Message);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
    }


}
