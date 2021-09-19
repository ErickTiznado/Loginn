using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Loginn
{
    class Contad
    {
		public int cont()
		{
			OleDbConnection conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DELL\Documents\Usuario.accdb ");
			OleDbCommand com = new OleDbCommand();
			conexion.Open();
			com.Connection = conexion;
			com.CommandType = CommandType.Text;
			com.CommandText = "SELECT Count(*) AS Id";
			int cantidad = Convert.ToInt32(com.ExecuteScalar());
			return cantidad;
		}
    }
}
