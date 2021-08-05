using System;
using System.Threading.Tasks;
using Humanizer;

namespace ConsoleProjetTest
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Quantities: ");
            HumanizeQuantities();

            Console.WriteLine("\nDate/Time Manipulation:");

        }
        private static void HumanizeQuantities()
        {
            Console.WriteLine("case".ToQuantity(0));
            Console.WriteLine("case".ToQuantity(1));
            Console.WriteLine("case".ToQuantity(5));
        }


        private static void HumanizeDates()
        {
            Console.WriteLine(DateTime.UtcNow.AddHours(-24).Humanize());
            Console.WriteLine(DateTime.UtcNow.AddHours(-2).Humanize());
            Console.WriteLine(TimeSpan.FromDays(1).Humanize());
            Console.WriteLine(TimeSpan.FromDays(16).Humanize());
        }

        public async Task<string> isValid(int user_id)
        {
            var fodase = true;
            string text;

            if (user_id == 2)
            {

                return text = $"Vai se tratar parreiras {fodase}";
            }
            else
            {
                return text = $"Vai tomar no cú parreiras {fodase}";
            }

        }

        public async Task<string> execute()
        {
            return await this.isValid(2);

        }

    }
}