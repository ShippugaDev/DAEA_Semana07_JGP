using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        private readonly string connectionString =
            @"Data Source=LAPTOP-0LK2EPQG\SQLEXPRESS;
              Initial Catalog=Neptuno;
              Integrated Security=True;
              TrustServerCertificate=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }
    }
}