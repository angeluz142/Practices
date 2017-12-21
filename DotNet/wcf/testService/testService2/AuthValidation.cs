using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace testService2
{
    public class AuthValidation : UserNamePasswordValidator
    {

        public override void Validate(string userName, string password)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["northbd"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);

                if (userName == null && password == null)
                {
                    throw new ArgumentNullException();
                }

                else
                {

                    conn.Open();

                    SqlCommand cmd = new SqlCommand("loginUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Login", userName);
                    cmd.Parameters.AddWithValue("@Pass", password);

                    SqlDataReader dr = cmd.ExecuteReader();


                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            if ((int)dr["result"] == 1)
                            {
                                return;
                            }
                            else
                            {
                                throw new System.IdentityModel.Tokens.SecurityTokenException("Unknown Username or Password");
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                logger.logEvent(ex);
                throw new FaultException("Ha ocurrido un error inesperado.");
            }

        }

    }
}