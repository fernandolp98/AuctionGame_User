using System;
using System.Data;
using MySql.Data.MySqlClient;
namespace AuctionGame_User
{
    public class ConfigDb
    {
        public string user { get; set; }
        public string password { get; set; }
        public string host { get; set; }
        public string port { get; set; }
        public string database { get; set; }

        public ConfigDb(string u, string p, string h, string po, string db)
        {
            user = u;
            password = p;
            host = h;
            port = po;
            database = db;
        }
    }
    static class DbConnection
    {
        public static ConfigDb configuracion = new ConfigDb("root", "root", "localhost", "3306", "auctionGame");
        private static MySqlConnection connection = new MySqlConnection();


        #region Conexion y Desconexón Base de Datos
        public static bool consulta_conexion()
        {
            var bEstado = conectar();
            connection.Close();
            return bEstado;
        }

        private static bool conectar()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
            connection.ConnectionString = $"User ID={configuracion.user}; Password={configuracion.password}; Host={configuracion.host}; Port={configuracion.port}; Database={configuracion.database};";
            bool bestado = true;
            try
            {
                connection.Open();

            }
            catch (Exception exc)
            {
                bestado = false;
                System.Windows.Forms.MessageBox.Show($"No se pudo conectar a la base de datos {configuracion.database} en el host {configuracion.host}: {exc.Message}");

            }
            return bestado;
        }
        private static bool desconectar()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    return true;
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show("Existe un problema al tratar de desconectr la base de datos" + exc.Message);
                return false;
            }
            return false;
        }

        #endregion

        #region Ejecución de Consultas

        public static bool ejecutar(String cSql)
        {
            try
            {
                if (conectar())
                {
                    MySqlCommand command = new MySqlCommand(cSql, connection);
                    command.ExecuteScalar();
                    desconectar();
                    return true;
                }
                return false;
            }
            catch (MySqlException exc)
            {

                Console.WriteLine($"Error: {exc.Message} en la consulta '{cSql}'");

                return false;
            }

        }

        #endregion
        #region Consulta de Datos

        public static DataTable consultar_datos(String cSql)
        {
            DataTable data = new DataTable();
            try
            {
                if (conectar())
                {
                    MySqlCommand command = new MySqlCommand(cSql, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                    dataAdapter.Fill(data);
                    desconectar();
                    if (data.Rows.Count > 0)
                    {
                        return data;
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al consultar datos: " + e.Message + "En la sentencia: " + cSql);
                return null;
            }
        }

        public static bool existencia(string cSql, int max)
        {
            DataTable data = new DataTable();
            try
            {
                if (conectar())
                {
                    MySqlCommand command = new MySqlCommand(cSql, connection);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                    dataAdapter.Fill(data);
                    desconectar();
                    if (data.Rows.Count >= max)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al consultar datos: " + e.Message + "En la sentencia: " + cSql);
                return false;
            }
        }
        #endregion
    }
}
