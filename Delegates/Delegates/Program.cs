using System.Reflection.Metadata.Ecma335;

namespace Delegates
{
    internal class Program
    {
        public delegate void SendMessage(string message);
        public delegate double PlusMinus(double n1, double n2);

        static void Main()
        {
            // Func //anything can be returned and recieved
            // Action // returns void recieves anything
            // Predicate // returns bool gets only one parameter
            Predicate<int> isOdd = IsOdd;
            var res = isOdd.Invoke(1);
            Console.WriteLine(res);

            Predicate<int> isPasitive = (int num) => num > 0;
            Console.WriteLine(isPasitive.Invoke(-3));

            List<int> ints = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,
            };

            ints.Where((int n) => n % 2 == 0);

            var a = ints.Sum((int a) => 2 * a);

            Console.WriteLine(a);
        }

        public static bool IsOdd(int num) => num % 2 != 0;
        public static bool IsPositive(int num) => num > 0;

        //static void Main()
        //{
        //    MyClass.PrintDelegate printDelegate = (int num) => Console.WriteLine(num);

        //    //MyClass myClass = new MyClass();
        //    //MyClass.PrintDelegate s = myClass.MyClassPrintDelegate = DisplayNumber;
        //    //MyClass.PrintNumbers(s);

        //    MyClass.PrintNumbers((int num) => Console.WriteLine(num));
        //    //MyClass.PrintNumbers(printDelegate);

        //    //int a = Method(4, 5);
        //    //Console.WriteLine(a);

        //}
        public static void DisplayNumber(int num) => Console.WriteLine(num);

        public static int Method(int s, int b) => s + b;

        //static void Main(string[] args)
        //{
        //    //SendMessage sendMessage = new SendMessage(SendMessageByEmail);
        //    //SendMessage sendMessage = SendMessageByEmail;
        //    //sendMessage += SendMessageByTelegram;
        //    //sendMessage.Invoke("Assalom alekum");
        //    PlusMinus plusMinus = Plus;
        //    plusMinus += Minus;
        //    // plusMinus -= Minus; // we can also dis connect or dis link
        //    var res = plusMinus.Invoke(5, 4); // gets the result of last method return argument that was linked to delegate
        //    Console.WriteLine(res);

        //}
        //public static void SendMessageByEmail(string message)
        //{
        //    Console.WriteLine($"{message} Message was send successfully");
        //}
        //public static void SendMessageByTelegram(string meassage)
        //{
        //    Console.WriteLine($"{meassage} Message was send successfully");
        //}
        public static double Plus(double num1, double num2)
        {
            return num1 + num2;
        }
        public static double Minus(double num1, double num2)
        {
            return num1 - num2;
        }
    }
}
