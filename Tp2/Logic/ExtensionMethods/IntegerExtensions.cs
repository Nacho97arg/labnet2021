namespace TP2.Logic.ExtensionMethods
{
    public static class IntegerExtensions
    {
        public static int DivideByZero(this int value)
        {
            return value / 0;
        }
        public static int DivideBy(this int dividend, int divisor)
        {
            return dividend / divisor;
        }
    }
}
