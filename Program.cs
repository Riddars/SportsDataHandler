using ConsoleApp1.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Print()
        {
            using (SportContext context = new SportContext())
            {
                var sportsmenList = context.sportsmens.ToList();
                Console.WriteLine("Список спортсменов:");
                foreach (var sportsman in sportsmenList)
                {
                    Console.WriteLine($"Имя: {sportsman.Name}, Фамилия: {sportsman.Surname}, Название игры: {sportsman.Namesport}");
                }
            }
            using (SportContext context = new SportContext())
            {
                sportsman sportsman = new sportsman();

                String a;
                Console.WriteLine("Введите имя:");
                a = Console.ReadLine();
                sportsman.Name = a;
                Console.WriteLine("Введите Фамилию:");
                a = Console.ReadLine();
                sportsman.Surname = a;
                Console.WriteLine("Введите название игры:");
                a = Console.ReadLine();
                sportsman.Namesport = a;

                context.sportsmens.Add(sportsman);
                context.SaveChanges();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Что вы хотите сделать?");
            string a;
            do
            {
                Console.WriteLine("Добавление записи спортсменов - 1");
                Console.WriteLine("Вывод списка всех спортсменов - 2");
                Console.WriteLine("Выход - 3");
                a = Console.ReadLine();
                if (a == "1")
                {
                    Print();
                }
                else if (a == "2")
                {
                    using (var context = new SportContext())
                    {
                        var sportsmenList = context.sportsmens.ToList();
                        Console.WriteLine("Список спортсменов:");
                        foreach (var sportsman in sportsmenList)
                        {
                            Console.WriteLine($"Имя: {sportsman.Name}, Фамилия: {sportsman.Surname}, Название игры: {sportsman.Namesport}");
                        }
                    }
                }
            } while (a != "3");
        }
    }
}
