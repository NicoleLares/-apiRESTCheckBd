using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

using apiRESTCheckBdTADS.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace apiRESTCheckBdTADS.Models
{
    public class clsCheckBd
    {
        // Definición de atributos
        private string cadConn = ConfigurationManager.ConnectionStrings["bdControlAcceso"].ConnectionString;
        // Definicion de atributos de salida
        public string statusMsg;
        public int ban;
        // Definición de métodos (chequeo de conexión a MySql)
        public void checkBd()
        {
            try
            {
                // Prueba de conexión a MySql
                MySqlConnection conn = new MySqlConnection(cadConn);
                // -----------
                conn.Open();
                conn.Close();

                // Conexion exitosa, enviar salida:
                ban = 1;
                statusMsg = "Conexion exitosa MySql";
                // -------------------------
            }
            catch (Exception ex)
            {

                // Conexion fallida, enviar salida:
                ban = 0;
                statusMsg = ex.Message.ToString();
                // -------------------------
            }
        }


    }
}