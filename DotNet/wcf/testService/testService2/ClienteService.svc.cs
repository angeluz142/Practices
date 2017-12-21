using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace testService2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ClienteService : ClienteIService
    {


        string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "registro.txt");

        string connStr = ConfigurationManager.ConnectionStrings["northbd"].ConnectionString;

        public int nuevoCliente(string CustomerID, string CompanyName, string ContactName, string ContactTitle, string Address, string City, string Region, string PostalCode, string Country, string Phone, string Fax)
        {
            int valor;
            try
            {
                SqlConnection conn = new SqlConnection(connStr);

                conn.Open();

                SqlCommand cmd = new SqlCommand("InsertCustomers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", ContactName);
                cmd.Parameters.AddWithValue("@ContactTitle", ContactTitle);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Region", Region);
                cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
                cmd.Parameters.AddWithValue("@Country", Country);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@Fax", Fax);

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





        public int editarCliente(string CustomerID, string CompanyName, string ContactName, string ContactTitle, string Address, string City, string Region, string PostalCode, string Country, string Phone, string Fax)
        {
            int valor;
            try
            {
                SqlConnection conn = new SqlConnection(connStr);

                conn.Open();

                SqlCommand cmd = new SqlCommand("UpdateCustomers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", ContactName);
                cmd.Parameters.AddWithValue("@ContactTitle", ContactTitle);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Region", Region);
                cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
                cmd.Parameters.AddWithValue("@Country", Country);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@Fax", Fax);

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




        public int eliminarCliente(String id)
        {
            int valor;
            try
            {
                SqlConnection conn = new SqlConnection(connStr);

                conn.Open();
                SqlCommand cmd = new SqlCommand("DeleteCostumers", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idcostumer", id);

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


        public List<Cliente> listarCliente()
        {

            List<Cliente> listado = new List<Cliente>();

            try
            {
                SqlConnection conn = new SqlConnection(connStr);

                conn.Open();
                SqlCommand cmd = new SqlCommand("ListCustomers", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        listado.Add(new Cliente
                        {
                            id = Convert.ToString(dr["CustomerID"]),
                            contacto = Convert.ToString(dr["ContactName"]),
                            company = Convert.ToString(dr["CompanyName"]),
                            pais = Convert.ToString(dr["Country"]),
                            ciudad = Convert.ToString(dr["City"]),
                            direccion = Convert.ToString(dr["Address"]),
                            tlf = Convert.ToString(dr["Phone"])
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
                throw new FaultException("Ha ocurrido un error inesperado");
            }

            return listado;
        }



        public List<Cliente> BuscarCliente(string id)
        {
            List<Cliente> listado = new List<Cliente>();


            try
            {
                SqlConnection conn = new SqlConnection(connStr);

                conn.Open();
                SqlCommand cmd = new SqlCommand("buscarCostumers", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idcostumer", id);

                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        listado.Add(new Cliente
                        {
                            id = Convert.ToString(dr["CustomerID"]),
                            contacto = Convert.ToString(dr["ContactName"]),
                            company = Convert.ToString(dr["CompanyName"]),
                            pais = Convert.ToString(dr["Country"]),
                            ciudad = Convert.ToString(dr["City"]),
                            direccion = Convert.ToString(dr["Address"]),
                            tlf = Convert.ToString(dr["Phone"])
                        });
                    }
                }

                else
                {
                    throw new FaultException("No se encontraron registros.");
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
    }
}
