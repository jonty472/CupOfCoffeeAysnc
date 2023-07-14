using System.ComponentModel;

namespace CupOfCoffeeAysnc
{
    internal class Program
    {

        public class Cup { }
        public class CoffeeGrounds { }
        public class Kettle { }

        static async Task Main(string[] args)
        {
            // Having Task<t> allows us to call a function and not wait on its response before moving to the next line of code/method
            Task<Kettle> taskBoilWater = BoilWaterAsync();
            Task<Cup> taskGetCup = GetCupAsync();
            Task<CoffeeGrounds> taskPrepareCoffee = GetCoffeeAsync();

            Console.WriteLine("Task<T> are all currently running");

            

            // putting await means that it will wait until that task has been completed, so best put the task you want done first in code.
            Cup MyCup = await taskGetCup;
            Console.WriteLine("Cup is ready.");

            CoffeeGrounds Coffee = await taskPrepareCoffee;
            Console.WriteLine("Coffee is ready");
            AddSugar();

            Kettle water = await taskBoilWater;
            Console.WriteLine("Boiling water is ready");
            AddMilk();
            Console.WriteLine("Cup of coffee is ready.");

            // need to create a composition with tasks (probably require nesting of awaits in a method and returning just Task or Task<T>)
        }


        public static async Task<Kettle> BoilWaterAsync()
        {
            Console.WriteLine("Turn kettle on.");
            await Task.Delay(3000);
            return new Kettle();
        }

        public static async Task<Cup> GetCupAsync()
        {
            Console.WriteLine("Grabbed the cup.");
            await Task.Delay(2000);
            return new Cup();
        }

        public static async Task<CoffeeGrounds> GetCoffeeAsync()
        {
            Console.WriteLine("Grabbed the coffee");
            return new CoffeeGrounds();
        }

        public static void AddSugar()
        {
            Console.WriteLine("Sugar added to cup.");
        }
        public static void AddMilk()
        {
            Console.WriteLine("Milk added to cup.");
        }
    }
}