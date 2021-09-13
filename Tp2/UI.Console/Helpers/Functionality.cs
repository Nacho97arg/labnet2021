using System;
using TP2.Logic;

namespace TP2.UI.Helpers
{
    /// <summary>
    /// Implementa la funcionalidad de la UI.
    /// </summary>
    public static class Functionality
    {
        public static void DivideByZero()
        {
            try
            {
                Console.Write("\nIngrese un numero a dividir por cero: ");
                new LogicClass().DivideByZero(Validators.ReadUserEnteredNumber());
            }
            catch (DivideByZeroException e)
            {
                throw new DivideByZeroException(e.Message);
            }
            finally
            {
                Console.WriteLine("\nOperacion finalizada\n");
            }
        }
        public static void DivideTwoNumbers()
        {
            try
            {
                Console.Write("\nIngrese el dividendo: ");
                int dividend = int.Parse(Console.ReadLine());
                Console.Write("\nIngrese el divisor: ");
                int divisor = int.Parse(Console.ReadLine());

                int divisionResult = new LogicClass().DivideBy(dividend, divisor);

                Console.WriteLine($"\nEl resultado es: {divisionResult}");
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"Seguro ingreso una letra o no ingreso nada!    {e.Message}");
            }
            catch (FormatException e)
            {
                throw new FormatException($"Seguro ingreso una letra o no ingreso nada!    {e.Message}");
            }
            catch (DivideByZeroException e)
            {
                throw new DivideByZeroException($"Solo Chuck Norris divide por cero!    {e.Message}");
            }
        }
        public static void GenerateException()
        {
            Console.WriteLine("\nSe generara una excepcion. Presione una tecla para continuar.");
            Console.ReadKey();
            new LogicClass().GenerateException();
        }
        public static void GenerateCustomException()
        {
            Console.WriteLine("\nSe generara una excepcion personalizada. Presione una tecla para continuar.");
            Console.ReadKey();
            new LogicClass().GenerateCustomException();
        }
    }
}
