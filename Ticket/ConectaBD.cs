using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Ticket
{
    /// <summary>
    /// <para>Clase implementada por Gibran Piedra para el uso de una base de datos MySQL en C#.</para>
    /// <remarks>Nota. Reemplaza servidor, basedatos, usuario y password al reutilizar esta clase. </remarks>
    /// </summary>
    class ConectaBD
    {
        private MySqlConnection conexion;
        private string servidor;
        private string basedatos;
        private string usuario;
        private string password;

        //Constructor
        public ConectaBD()
        {
            Initialize();
        }

        //inicializar valores
        private void Initialize()
        {
            servidor = "localhost";
            basedatos = "ticket";
            usuario = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + servidor + ";" + "DATABASE=" +
            basedatos + ";" + "UID=" + usuario + ";" + "PASSWORD=" + password + ";";

            conexion = new MySqlConnection(connectionString);
        }
        /// <summary>
        /// Metodo que abre la conexion a la base de datos
        /// </summary>
        private bool abrirConexion()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        System.Windows.Forms.MessageBox.Show("No se pudo realizar la conexion");
                        break;

                    case 1045:
                        System.Windows.Forms.MessageBox.Show("El usuario o contraseña no es valido, intentelo de nuevo.");
                        break;
                }
                return false;
            }
        }
        /// <summary>
        /// Metodo que cierra la conexion a la base de datos
        /// </summary>
        private bool cerrarConexion()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Metodo que ejecuta un insert a la base de datos
        /// </summary>
        /// <param name="consulta">Aqui va el SQL a ejecutar</param>
        /// 
        public void Insertar(string consulta)
        {
            if (this.abrirConexion() == true)
            {
                //crear comandero y asignar consultas
                MySqlCommand cmd = new MySqlCommand(consulta, conexion);
                //Ejecutar consulta del comandero
                cmd.ExecuteNonQuery();
                //cerrar consulta
                this.cerrarConexion();
            }
        }

        /// <summary>
        /// Metodo que ejecuta un update a la base de datos
        /// </summary>
        /// <param name="consulta">Aqui va el SQL a ejecutar</param>
        /// 
        public void Update(string consulta)
        {
            if (this.abrirConexion() == true)
            {
                //Crear el comandero
                MySqlCommand cmd = new MySqlCommand();
                //Asignar la consulta al comandero
                cmd.CommandText = consulta;
                //Asignar la conexion al comandero
                cmd.Connection = conexion;
                //Ejecutar consulta
                cmd.ExecuteNonQuery();
                //Cerrar conexion
                this.cerrarConexion();
            }
        }
                /// <summary>
        /// Metodo que ejecuta un delete a la base de datos
        /// </summary>
        /// <param name="consulta">Aqui va el SQL a ejecutar</param>
        /// 
        public void Delete(string consulta)
        {
            if (this.abrirConexion() == true)
            {
                MySqlCommand cmd = new MySqlCommand(consulta, conexion);
                cmd.ExecuteNonQuery();
                this.cerrarConexion();
            }
        }
        /// <summary>
        /// Metodo que ejecuta un Select a la base de datos
        /// </summary>
        /// <param name="consulta">Aqui va el SQL a ejecutar</param>
        /// 
        public DataSet Select(string consulta)
        {
            DataSet list = new DataSet();
            if (this.abrirConexion() == true)
            {
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
                da.Fill(list);
                conexion.Close();
                return list;
            }
            else
            {
                return list;
            }
        }
        /// <summary>
        /// Metodo que devuelve el conteo de registros de una base de datos de un select
        /// </summary>
        /// <param name="consulta">Aqui va el SQL a ejecutar</param>
        /// 
        public int Count(string consulta)
        {
            int Count = -1;

            //Open Connection
            if (this.abrirConexion() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(consulta, conexion);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.cerrarConexion();

                return Count;
            }
            else
            {
                return Count;
            }
        }
    }
}
