using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.IO;

/*
 * Pequeño programa de consola que realiza ping a ip registradas en BD
 * si es exitosa la respuesta actualiza el estado del equipo en
 * BD (1 => Activo | 2 => Caido).     
*/


namespace testping2
{
    class Program
    {

        static void Main(string[] args)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string archivo = filePath + @"\auditoriaping.txt";
            try
            {
#if DEBUG
                Console.WriteLine("Haciendo ping a los equipos, no cierre esta ventana... " + DateTime.Now);
#endif
                Ping ping = new Ping();
                int timeout = 10;
                List<Equipo> list_Eq = new List<Equipo>();
                DataTable dt = DB.ShowData("select ip from testping where estatus = 1");

                // Por cada IP se realiza ping y se  agrega a la lista del modelo
                foreach (DataRow item in dt.Rows)
                {

                    if (ping.Send(item[0].ToString(), timeout).Status == IPStatus.Success)
                    {
                        list_Eq.Add(new Equipo
                        {
                            ip = item[0].ToString(),
                            estado = 1
                        });
                    }
                    else
                    {
                        list_Eq.Add(new Equipo
                        {
                            ip = item[0].ToString(),
                            estado = 0
                        });
                    }
                }

                // Se actualiza el estado de las ip segun la respuesta del ping
                foreach (var eq in list_Eq)
                {
                    DB.ExecQuery("update testping set estado = " + eq.estado + " where ip = '" + eq.ip + "'");
                }
#if DEBUG            
                Console.WriteLine("Proceso Terminado... " + DateTime.Now);
                Console.ReadLine();
#endif
            }
            catch (Exception ex)
            {
                // En caso de errores registrar en log

                if (!File.Exists(archivo))
                {
                    using (StreamWriter file = new StreamWriter(archivo))
                    {
                        file.WriteLine(System.Environment.NewLine);
                        file.WriteLine(ex.Message.ToString() + DateTime.Now + "-------------------- \n" + System.Environment.NewLine + ex.InnerException.Message);
                        file.Close();
                    }
                }

                else
                {
                    using (FileStream file = new FileStream(archivo, FileMode.Append, FileAccess.Write))
                    {
                        StreamWriter writer = new StreamWriter(file);
                        writer.WriteLine(System.Environment.NewLine);
                        writer.WriteLine(ex.Message.ToString() + DateTime.Now + "-------------------- \n"+ System.Environment.NewLine + ex.InnerException.Message);
                        writer.Close();
                    }
                }

            }
        }

    }
}

