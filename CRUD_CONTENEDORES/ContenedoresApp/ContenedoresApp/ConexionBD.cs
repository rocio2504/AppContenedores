using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContenedoresApp
{
    public class ConexionBD
    {

      
        SqlConnection cnn = new SqlConnection("Data source=LAPTOP-1JK1J506\\SQLEXPRESS;Initial Catalog=Db_contenedores;" +
            "User=sa;Password=12345678;" + "Integrated Security=true;TrustServerCertificate=Yes");


        public ConexionBD()
        {
            try
            {
                SqlConnection cnn = new SqlConnection("Data source=LAPTOP-1JK1J506\\SQLEXPRESS;Initial Catalog=Db_contenedores;" +
            "User=sa;Password=12345678;" + "Integrated Security=true;TrustServerCertificate=Yes");
                // cnn.Open();
                //MessageBox.Show("Conectado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto a la base de datos: " + ex.ToString());
            }
        }


        public DataTable mostrarContent()
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spMostrarContent", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;
        }

        public DataTable loadData(int? Id)
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spLoadData", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@numero", SqlDbType.Int).Value = Id;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;
        }

        public string GuardarContenedor(int numero, string tipo, int tamanio, float peso,
          float tara)
        {
            string mensaje = "";
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spGuardarContenedor", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@numero", SqlDbType.Int).Value = numero;
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 50).Value = tipo;
                cmd.Parameters.Add("@tamanio", SqlDbType.Int, 40).Value = tamanio;
                cmd.Parameters.Add("@peso", SqlDbType.Float).Value = peso;
                cmd.Parameters.Add("@tara", SqlDbType.Float).Value = tara;
                cmd.ExecuteNonQuery();
                mensaje = "Se guardó el registro correctamente";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }
            return mensaje;
        }

        public string editarContenedor(int numero, string tipo, int tamanio, float peso,
          float tara)

        {
            string mensaje = "";
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spActualizarContenedor", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@numero", SqlDbType.Int).Value = numero;
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 50).Value = tipo;
                cmd.Parameters.Add("@tamanio", SqlDbType.Int, 40).Value = tamanio;
                cmd.Parameters.Add("@peso", SqlDbType.Float).Value = peso;
                cmd.Parameters.Add("@tara", SqlDbType.Float).Value = tara;
                cmd.ExecuteNonQuery();
                mensaje = "Se actualizó el registro correctamente";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }
            return mensaje;
        }

        public string eliminarContenedor(int numero)

        {
            string mensaje = "";
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spEliminarContenedor", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@numero", SqlDbType.Int).Value = numero;
               
                cmd.ExecuteNonQuery();
                mensaje = "Se eliminó el registro correctamente";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }
            return mensaje;
        }

        public DataTable cargarComboTipo()
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spCargarTipo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;

        }

        public DataTable cargarComboTamanio()
        {
            DataTable tabla2 = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spCargarTamanio", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla2);
            cnn.Close();
            return tabla2;

        }

    }

}
