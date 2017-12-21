using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            var file = new FileStream("./archivo.txt", FileMode.OpenOrCreate);

            Console.WriteLine("Antes de Proocesar");

            //Procesar(file);

            ProcesarAsync(file);

            Console.WriteLine("Despues de Proocesar");

            Console.ReadLine();

        }

        private static void Procesar(FileStream file)
        {
            var msg = "Hola mundo";
            var bytes = Encoding.UTF8.GetBytes(msg);

            Console.WriteLine("Escribiendo");

            for(int i = 0; i < 10000; i++)
            {
                file.Write(bytes,0,bytes.Length);
            }
            file.Close();
        }

        private static async void ProcesarAsync(FileStream file)
        {
            var msg = "Hola mundo";
            var bytes = Encoding.UTF8.GetBytes(msg);

            Console.WriteLine("Escribiendo...");

            for (int i = 0; i < 10000; i++)
            {
                await file.WriteAsync(bytes, 0, bytes.Length);
            }
            file.Close();
            Console.WriteLine("! ! Ya escribio. ! !");
        }
    }
}
