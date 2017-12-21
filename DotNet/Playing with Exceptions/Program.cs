using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             
             Otra forma seria usar using el cual realiza ejecuta implicitamente un
             file.close y un finally; queda de la siguiente forma.

               using (Stream f = File.Open("./File.txt", FileMode.Open))
                    {
                        try
                        {
                            int a = 10, b = 0;
                            int res = a / b;
                        }
                        catch (DivideByZeroException) {
                            Console.WriteLine("Division por cero.");
                        }
                        catch (Exception ex){
                            Console.WriteLine($"Uups, ha ocurrido un error!: {ex.Message}");
                        }

                        Console.ReadLine();
                    }

             */




            Stream f = null;
            try
            {
                f = File.Open("./File.txt",FileMode.Open);
                int a = 10, b = 0;
                int res = a / b;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division por cero.");
            }
            catch (FileNotFoundException fileEx)
            {
                Console.WriteLine($"Error de archivo: {fileEx.ToString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Uups, ha ocurrido un error!: {ex.Message}");
            }

            // Finally se ejecuta haya o no haya ocurrido alguna excepcion
            finally
            {
                f.Close();
            }

            Console.ReadLine();
        }
    }
}
