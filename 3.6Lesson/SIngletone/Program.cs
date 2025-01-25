namespace SIngletone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (int, string) myValue = (45, "salom");
            //var name = (344, "kjlg");
            Console.WriteLine(myValue.Item1);
            Console.WriteLine(myValue.Item2);

            var res = GetMaxAndMin(45, 545, 11);
            Console.WriteLine("max: " + res.Item1);
            Console.WriteLine("min: " + res.Item2);
            
            Console.ReadLine();
        }

        public static (int, int) GetMaxAndMin(int nm1, int nm2, int nm3)
        {
            var res = (0, 0);
            res.Item1 = Math.Max(nm1, Math.Max(nm2, nm3));
            res.Item2 = Math.Min(nm1, Math.Min(nm2, nm3));
            return res;

        }
        public void SingletonInfo()
        {
            var instanse1 = MyClass.GetInstanse();
            var instanse2 = MyClass.GetInstanse();
            var instanse3 = MyClass.GetInstanse();

            instanse3.Id = 55;
            instanse2.Id = 33;
            instanse1.Id = 11;

            Console.WriteLine(ReferenceEquals(instanse1, instanse2));
            Console.WriteLine(ReferenceEquals(instanse2, instanse3));
            Console.WriteLine(ReferenceEquals(instanse3, instanse1));

            Console.WriteLine(instanse3.Id);
            Console.WriteLine(instanse1.Id);
            Console.WriteLine(instanse2.Id);
        }
    }
}
