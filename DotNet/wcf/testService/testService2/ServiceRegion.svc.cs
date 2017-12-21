using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace testService2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceRegion" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceRegion.svc o ServiceRegion.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceRegion : IServiceRegion
    {

        string connStr = ConfigurationManager.ConnectionStrings["northbd"].ConnectionString;

        public int nuevaRegion(int IdRegion, string Rdescripcion)
        {
            int valor;

            try
            {
                SqlConnection conn = new SqlConnection(connStr);

                conn.Open();

                SqlCommand cmd = new SqlCommand("InsertRegion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRegion", IdRegion);
                cmd.Parameters.AddWithValue("@RDescripcion", Rdescripcion);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.RecordsAffected > 0) { valor = 1; } else valor = 0;

            }
            catch (Exception ex)
            {
                logger.logEvent(ex);
                throw new FaultException("Ha ocurrido un error inesperado.");
            }

            return valor;
        }

        public int editarRegion(int IdRegion, string Rdescripcion)
        {
            int valor;
            try
            {
                SqlConnection conn = new SqlConnection(connStr);

                conn.Open();

                SqlCommand cmd = new SqlCommand("editarRegion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRegion", IdRegion);
                cmd.Parameters.AddWithValue("@Descripcion", Rdescripcion);


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.RecordsAffected > 0) { valor = 1; } else valor = 0;

            }
            catch (Exception ex)
            {
                logger.logEvent(ex);
                throw new FaultException("Ha ocurrido un error inesperado.");
            }

            return valor;
        }


        public List<ClienteRegion> listarRegion()
        {

            List<ClienteRegion> listado = new List<ClienteRegion>();

            try
            {
                SqlConnection conn = new SqlConnection(connStr);

                conn.Open();
                SqlCommand cmd = new SqlCommand("ListarRegion", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        listado.Add(new ClienteRegion
                        {
                            id = (int)dr["RegionID"],
                            descripcion = dr.GetString(1),

                        });
                    }
                }

                else
                {
                    throw new FaultException("No hay registros");
                }

                conn.Close();

            }
            catch (Exception ex)
            {

                logger.logEvent(ex);
                throw new FaultException("Ha ocurrido un error inesperado.");
            }

            return listado;
        }


        public int eliminarRegion(int IdRegion)
        {
            int valor;
            try
            {
                SqlConnection conn = new SqlConnection(connStr);

                conn.Open();
                SqlCommand cmd = new SqlCommand("EliminarRegion", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idRegion", IdRegion);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.RecordsAffected > 0) { valor = 1; } else valor = 0;
            }
            catch (Exception ex)
            {
                logger.logEvent(ex);
                throw new FaultException("Ha ocurrido un error inesperado.");

            }
            return valor;
        }
    }
}
