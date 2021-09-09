using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1
{
    class Program
    {
        private static List<Taxi> s_taxis = new List<Taxi>();
        private static List<Omnibus> s_omnibuses = new List<Omnibus>();

        static void Main(string[] args)
        {
            int opcionElegida;
            do
            {
                // MostrarMenuPrincipal devuelve la opcion elegida por el usuario en dicho menu.
                opcionElegida = MostrarMenuPrincipal();
                if (opcionElegida == 1)
                {
                    AltaTransportes();
                }
                else if (opcionElegida == 2)
                {
                    ReporteTransportes();
                }

            } while (opcionElegida != 3);
        }

        static int MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("1. Cargar Transportes");
            Console.WriteLine("2. Mostrar Transportes");
            Console.WriteLine("3. Salir\n");
            Console.Write("Seleccione una opcion: ");
            
            int opcionElegida = ValidarEntrada(Console.ReadLine(), "Por favor elija una opcion valida");
            while ((opcionElegida != 1) && (opcionElegida != 2) && (opcionElegida != 3))
            {
                Console.Write("Pro favor elija una opcion valida: ");
                opcionElegida = ValidarEntrada(Console.ReadLine(), "Por favor elija una opcion valida");
            }

            return opcionElegida;                
        }
        static void AltaTransportes()
        {
            string respuesta = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Que desea cargar:");
                Console.WriteLine("   1. Omnibus");
                Console.WriteLine("   2. Taxi");
                Console.WriteLine("\n   3. Cancelar");
                Console.Write("Seleccione una opcion: ");

                int opcionElegida = ValidarEntrada(Console.ReadLine(), "Por favor elija una opcion valida");
                while ((opcionElegida != 1) && (opcionElegida != 2) && (opcionElegida != 3))
                {
                    Console.Write("Por favor elija una opcion valida: ");
                    opcionElegida = ValidarEntrada(Console.ReadLine(), "Por favor elija una opcion valida");
                }

                if (opcionElegida == 1)
                {                    
                    AgregarOmnibus();
                    Console.WriteLine("\nDesea cargar otro transporte? S/N");
                    respuesta = Console.ReadLine();
                }
                else if (opcionElegida == 2)
                {
                    AgregarTaxi();
                    Console.WriteLine("\nDesea cargar otro transporte? S/N");
                    respuesta = Console.ReadLine();
                }
                else if (opcionElegida == 3)
                {
                    respuesta = "n";
                }

            } while (respuesta == "S" || respuesta == "s");
        }
        static void ReporteTransportes()
        {
            Console.Clear();
            int contador = 1;
            Console.WriteLine("Omnibus cargados:");
            foreach (var omnibus in s_omnibuses)
            {
                Console.WriteLine($"    Omnibus {contador}: {omnibus.Pasajeros} Pasajeros");
                contador++;
            }
            Console.WriteLine("\nTaxis cargados:");
            contador = 1;
            foreach (var taxi in s_taxis)
            {
            
                Console.WriteLine($"    Taxi {contador}: {taxi.Pasajeros} Pasajeros");
                contador++;
             
            }
            Console.WriteLine("\nPresione una tecla para volver al menu principal");
            Console.ReadLine();
        }
        static void AgregarOmnibus()
        {
            Console.Clear();
            Console.WriteLine("Alta de Omnibus\n");
            if (s_omnibuses.Count < 5)
            {
                Console.WriteLine($"Ingresados {s_omnibuses.Count}/5\n");
                Console.Write("Ingrese la cantidad de pasajeros: ");

                Omnibus nuevoOmnibus = new Omnibus();
                nuevoOmnibus.Pasajeros = ValidarEntrada(Console.ReadLine(), "Por favor ingrese un numero entero");
                s_omnibuses.Add(nuevoOmnibus);
            }
            else
            {
                Console.WriteLine("Se alcanzo el maximo permitido de omnibus");
            }
            
        }
        static void AgregarTaxi()
        {
            Console.Clear();
            Console.WriteLine("Alta de Taxi");
            if (s_taxis.Count < 5)
            {
                Console.WriteLine($"Ingresados {s_taxis.Count}/5\n");
                Console.Write("Ingrese la cantidad de pasajeros: ");

                Taxi nuevoTaxi = new Taxi();
                nuevoTaxi.Pasajeros = ValidarEntrada(Console.ReadLine(), "Por favor ingrese un numero entero");
                s_taxis.Add(nuevoTaxi);
            }
            else
            {
                Console.WriteLine("Se alcanzo el maximo permitido de taxis");
            }

        }

        /// <summary>
        /// Valida que el valor ingresado por consola corresponda con un numero entero positivo y solicita reingresarlo, mostrando el mensaje indicado, en caso de que no corresponda.
        /// </summary>
        static int ValidarEntrada(string entrada, string mensaje)
        {
            bool esNumero;
            int salida;

            esNumero = int.TryParse(entrada, out salida);
            while ((!esNumero) || (salida <=0))
            {
                Console.Write($"{mensaje} : ");
                esNumero = int.TryParse(Console.ReadLine(), out salida);
            }
            return salida;
        }
    }
}
