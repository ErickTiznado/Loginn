using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Loginn
{
    public partial class Form2 : Form
    {
		Contad obj = new Contad();
		public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			try 
			{
				OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DELL\Documents\Usuario.accdb ");
				conexion.Open();
				int Id = obj.cont() + 1;
				string insertar = "INSERT INTO Usuarios  VALUES ( @Id,@Usuario, @Cont)";
				OleDbCommand cmd = new OleDbCommand(insertar, conexion);
				cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(txtId.Text));
				cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
				cmd.Parameters.AddWithValue("@Cont", txtContraseña.Text);
				cmd.ExecuteNonQuery();
				
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
