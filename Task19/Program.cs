using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task19
{
    //    1.    Модель компьютера  характеризуется кодом  и названием  марки компьютера, типом  процессора, 
    //        частотой работы  процессора,  объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты,
    //        стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии.Создать список,
    //            содержащий 6-10 записей с различным набором значений характеристик.

    //Определить:

    //- все компьютеры с указанным процессором.Название процессора запросить у пользователя;
    //- все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;
    //- вывести весь список, отсортированный по увеличению стоимости;
    //- вывести весь список, сгруппированный по типу процессора;
    //- найти самый дорогой и самый бюджетный компьютер;
    //- есть ли хотя бы один компьютер в количестве не менее 30 штук?
    class Computer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CpuType { get; set; }
        public double CpuFrequency { get; set; }
        public int Ram { get; set; }
        public int Hdd { get; set; }
        public int Gpu { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }


    }
    class Program
    {
        static void Main(string[] args)
        {


            List<Computer> computers = new List<Computer>()
            {
            new Computer() {Id=101, Name = "celeron",CpuType = "i3", CpuFrequency = 2.53, Ram = 16, Hdd = 80, Gpu = 1, Price=250, Amount = 10},
            new Computer() {Id=102, Name = "intel",CpuType = "i5", CpuFrequency = 1.60, Ram = 8, Hdd = 120, Gpu = 3, Price=300, Amount = 20},
            new Computer() {Id=103, Name = "amd",CpuType = "i7", CpuFrequency = 2.10, Ram = 16, Hdd = 250, Gpu = 4, Price=750, Amount = 30},
            new Computer() {Id=104, Name = "celeron",CpuType = "i9", CpuFrequency = 5.00, Ram = 128, Hdd = 1024, Gpu = 6, Price=950, Amount = 40},
            new Computer() {Id=105, Name = "intel",CpuType = "i7", CpuFrequency = 4.20, Ram = 16, Hdd = 120, Gpu = 5, Price=550, Amount = 21},
            new Computer() {Id=106, Name = "amd",CpuType = "i3", CpuFrequency = 2.50, Ram = 64, Hdd = 125, Gpu = 4, Price=320, Amount = 31},
            new Computer() {Id=107, Name = "intel",CpuType = "i5", CpuFrequency = 4.90, Ram = 32, Hdd = 250, Gpu = 1, Price=650, Amount = 41},
            };

            Console.Write("i3, i5, i7 или i9?: ");
            string cputype = Convert.ToString(Console.ReadLine());
            List<Computer> byCpuType = computers.Where(c=>c.CpuType == cputype).ToList();
            Print(byCpuType);

            Console.WriteLine("RAM не ниже (8-128): ");
            int ram = Convert.ToInt32(Console.ReadLine());
            List<Computer> byRam = computers.Where(c => c.Ram >= ram).ToList();
            Print(byRam);


            Console.WriteLine("по стоимости:");
            List<Computer> byCost = computers.OrderBy(c => c.Price).ToList();
            Print(byCost);

            Console.WriteLine("группировка:");
            IEnumerable<IGrouping<string, Computer>> byCpu = computers.GroupBy(c => c.CpuType);
            foreach (var gr in byCpu)
            {
                Console.WriteLine(gr.Key);
                foreach (Computer c in gr)
                {
                    Console.WriteLine($"{c.Id} {c.Name} {c.CpuType} {c.CpuFrequency}GHz RAM:{c.Ram}Gb HDD:{c.Hdd}Gb GPU:{c.Gpu}Gb {c.Price}$ {c.Amount}шт");
                }
            }

            Console.WriteLine("\nстоимость max, min:");
            Computer c1 = computers.OrderByDescending(c => c.Price).FirstOrDefault();
            Console.WriteLine($"{c1.Id} {c1.Name} {c1.CpuType} {c1.CpuFrequency}GHz RAM:{c1.Ram}Gb HDD:{c1.Hdd}Gb GPU:{c1.Gpu}Gb {c1.Price}$ {c1.Amount}шт");
            Computer c2 = computers.OrderBy(c => c.Price).FirstOrDefault();
            Console.WriteLine($"{c2.Id} {c2.Name} {c2.CpuType} {c2.CpuFrequency}GHz RAM:{c2.Ram}Gb HDD:{c2.Hdd}Gb GPU:{c2.Gpu}Gb {c2.Price}$ {c2.Amount}шт");

            Console.WriteLine("\nесть ли хотя бы один компьютер в количестве не менее 30 штук");
            Console.WriteLine(computers.Any(c => c.Amount > 30));



            Console.ReadKey();



            
        }

        static void Print(List<Computer> computers)
        {
            foreach (Computer c in computers)
                Console.WriteLine($"{c.Id} {c.Name} {c.CpuType} {c.CpuFrequency}GHz RAM:{c.Ram}Gb HDD:{c.Hdd}Gb GPU:{c.Gpu}Gb {c.Price}$ {c.Amount}шт");

            Console.WriteLine();
        }
        
    } 
}
