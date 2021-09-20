using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Loginn
{
    class conexion
    {
      
        public  MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; port=3306; user id=root; database=intusurario");
            try
            {
                conectar.Open();
                MessageBox.Show("Concexion establecida");
            }
            catch
            {

            }
            return conectar;
        }
    }
}
