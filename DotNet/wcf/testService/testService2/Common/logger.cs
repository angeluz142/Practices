using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace testService2
{
    public class logger
    {

        public static void logEvent(Exception ex)
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "registro.txt");
            StreamWriter writer = new StreamWriter(dir, false, Encoding.UTF8);


            writer.WriteLine("-----------------  Error:" + ex.Message + "\n\n");
            writer.WriteLine(ex.ToString());
            writer.Close();
        }

    }
}