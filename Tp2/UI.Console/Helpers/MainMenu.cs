using System;

namespace TP2.UI.Helpers
{
    /// <summary>
    /// Implementa un menu principal para la aplicacion.
    /// </summary>
    public static class MainMenu
    {
        const int lastValidMenuOption = 5;
        public static int MainMenuScreen()
        {
            Console.WriteLine("Menu Principal\n");
            Console.WriteLine("    1. Dividir por cero\n    2. Dividir dos numeros\n    3. Generar excepcion\n    4. Generar excepcion personalizada\n    5. Salir\n");
            Console.Write("Opcion seleccionada: ");
            return Validators.ReadUserSelectedOption(1, lastValidMenuOption);
        }
        public enum ValidOptions
        {
            DividirPorCero = 1,
            DividirDosNumeros = 2,
            GenerarExcepcion = 3,
            GenerarExcepcionPersonalizada = 4,
            Salir = 5
        }
    }
}
