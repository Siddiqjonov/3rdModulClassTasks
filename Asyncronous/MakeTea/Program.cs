using System.Globalization;

namespace MakeTea
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await GetTea();
        }
        public static async Task<string> GetTea()
        {
            var boildedWater = BoilWater();
            Console.WriteLine("Shkafdan choynakni oldik");
            Console.WriteLine("Choynakga quruq choy soldik");

            await boildedWater;

            var res = $"Choynakga {boildedWater.Result} qydik";
            Console.WriteLine(res);

            return res;

        }
        public static async Task<string> BoilWater()
        {
            Console.WriteLine("Tefalni to'kga uladik");

            await Task.Delay(5000);

            Console.WriteLine("Suv qaynadi");

            return "qaynagan suv";
        }
    }
}
