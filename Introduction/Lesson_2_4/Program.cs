using System;
using System.Linq;

namespace Lesson_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new[]
            {
                new {name = "Шампунь", amount = 1, price = 233},
                new {name = "Кондиционер", amount = 1, price = 233},
                new {name = "хлеб", amount = 2, price = 233}
            };
            DateTime dateNow = DateTime.Now;
            string shopName = "Base Shop";

            Console.WriteLine("Чек");
            Console.WriteLine($"Название магазина: {shopName}");
            Console.WriteLine($"Дата: {dateNow}");
            Console.WriteLine("=====");

            Console.WriteLine("№, Name, amount, price");

            for (var i = 0; i < orders.Length; i += 1)
            {
                var order = orders[i];
                Console.WriteLine($"#{i} {order.name} {order.amount} {order.price}");
            }

            Console.WriteLine("=====");

            var sum = orders.Aggregate(0, (acc, order) => acc += order.amount * order.price);

            Console.WriteLine($"Итог: {sum}");
        }
    }
}