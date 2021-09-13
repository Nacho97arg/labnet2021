using System;
using TP2.UI.Helpers;

namespace TP2.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitFlag = false;
            while (!exitFlag)
            {
                Console.Clear();
                try
                {
                    int selectedOption = MainMenu.MainMenuScreen();
                    switch ((MainMenu.ValidOptions)selectedOption)
                    {
                        case MainMenu.ValidOptions.DividirPorCero:
                            Functionality.DivideByZero();
                            break;
                        case MainMenu.ValidOptions.DividirDosNumeros:
                            Functionality.DivideTwoNumbers();
                            break;
                        case MainMenu.ValidOptions.GenerarExcepcion:
                            Functionality.GenerateException();
                            break;
                        case MainMenu.ValidOptions.GenerarExcepcionPersonalizada:
                            Functionality.GenerateCustomException();
                            break;
                        case MainMenu.ValidOptions.Salir:
                            exitFlag = true;
                            break;
                        default:
                            throw new NotImplementedException("Opcion no implementada");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"\nMensaje de la excepcion:\n    {ex.Message}\nTipo de excepcion:\n    {ex.GetType()}\n");
                    Console.WriteLine(ex.StackTrace);
                }
                finally
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }
            }

        }

        
    }
}
