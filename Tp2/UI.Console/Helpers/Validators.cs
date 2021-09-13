using System;

namespace TP2.UI.Helpers
{
    /// <summary>
    /// Contiene metodos utilizados para validar datos ingresados por el usuario.
    /// </summary>
    public static class Validators
    {
        public static int ReadUserSelectedOption(int lowerOptionsRange, int upperOptionsRange)
        {
            string userInput = Console.ReadLine();
            bool parseResult = int.TryParse(userInput, out int parsedInput);
            while (!parseResult || ((parsedInput < lowerOptionsRange) || (parsedInput > upperOptionsRange)))
            {
                Console.WriteLine("Por favor, ingrese una opcion valida: ");
                userInput = Console.ReadLine();
                parseResult = int.TryParse(userInput, out parsedInput);
            }
            return parsedInput;
        }

        public static int ReadUserEnteredNumber()
        {
            int parsedInput;
            string userInput = Console.ReadLine();
            while (!int.TryParse(userInput, out parsedInput))
            {
                Console.Write("Por favor ingrese un numero valido: ");
                userInput = Console.ReadLine();
            }
            return parsedInput;
        }

    }
}
