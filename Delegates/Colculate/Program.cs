using System.Threading.Channels;

namespace Colculate
{
    internal class Program
    {
        public delegate void Colculate(double num1, double num2);
        static void Main(string[] args)
        {
            Action<double, double> colculate = Sum;
            colculate += Substruct;
            colculate += Devide;
            colculate += Multiply;
            Func<int, int, int, int> d;

            colculate(80, 20);
        }
        public static void Sum(double num1, double num2) => Console.WriteLine(num1 + num2);
        public static void Substruct(double num1, double num2) => Console.WriteLine(num1 - num2);
        public static void Devide(double num1, double num2) => Console.WriteLine(num1 / num2);
        public static void Multiply(double num1, double num2) => Console.WriteLine(num1 * num2);
    }
}
