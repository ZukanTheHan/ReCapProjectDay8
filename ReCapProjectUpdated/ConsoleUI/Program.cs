using Business.Concrete;// Bunu unutma !!!
using DataAccess.Concrete.InMemory; // Bunu unutma !!!
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Project reference'da hepsini seç.
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }


        }
    }
}
