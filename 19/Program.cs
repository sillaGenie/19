using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19
{
    class Сomputer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPU { get; set; }
        public double CPUClockSpeed { get; set; }
        public int RAM { get; set; }
        public int HardDisk { get; set; }
        public int VideoMemory { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Сomputer> listComputers = new List<Сomputer>()
            {
                new Сomputer () { Id =1, Name ="ROG Strix Special", CPU ="AMD Ryzen 5",CPUClockSpeed = 3.7, RAM = 8, HardDisk = 512 , VideoMemory =4, Cost = 69.999, Quantity =30 },
                new Сomputer () { Id =2, Name ="Acer Aspire", CPU ="Intel Core i5",CPUClockSpeed = 2.9, RAM = 8, HardDisk = 512 , VideoMemory =4, Cost = 64.999, Quantity =5 },
                new Сomputer () { Id =3, Name ="Prestigio Xtreme", CPU ="Intel Core i5",CPUClockSpeed = 2.9, RAM = 16, HardDisk = 512 , VideoMemory =8, Cost = 129.999, Quantity =5 },
                new Сomputer () { Id =4, Name ="HyperPC Epix Force", CPU ="Intel Core i5",CPUClockSpeed = 2.9, RAM = 16, HardDisk = 512 , VideoMemory =4, Cost = 95.999, Quantity =15 },
                new Сomputer () { Id =5, Name ="MSI MAG Infinite", CPU ="Intel Core i5",CPUClockSpeed = 2.6, RAM = 16, HardDisk = 512 , VideoMemory =12, Cost = 129.999, Quantity =1 },
                new Сomputer () { Id =6, Name ="MSI MEG Aegis Ti5", CPU ="Intel Core i7",CPUClockSpeed =3.6, RAM = 64, HardDisk = 2048 , VideoMemory =8, Cost = 289.999, Quantity =2 }
            };
            Console.WriteLine("Введите тип процессора.Например: AMD Ryzen 5");
            string cpu = Console.ReadLine();
            IEnumerable<Сomputer> CPU = from c in listComputers
                                        where c.CPU == cpu
                                        select c;
            foreach (Сomputer c in CPU)
                Console.WriteLine($"{c.Id} {c.Name} {c.CPU}");

            Console.WriteLine("Введите минимальный объем ОЗУ (Гб)");
            int ram = Convert.ToInt32(Console.ReadLine());
            IEnumerable<Сomputer> RAM = from c in listComputers
                                        where c.RAM >= ram
                                        select c;
            foreach (Сomputer c in RAM)
                Console.WriteLine($"{c.Id} {c.Name} {c.RAM}");
            var cost = listComputers
                .OrderBy(c => c.Cost)
                .ToList();
            foreach (Сomputer c in cost)
                Console.WriteLine($"{c.Id} {c.Name} {c.CPU}");
            double MAXcost = listComputers
               .Max(c => c.Cost);
            List<Сomputer> maxcost = listComputers
                .Where(v => v.Cost == MAXcost)
                .ToList();
            foreach (Сomputer v in maxcost)
                Console.WriteLine($"{v.Id} {v.Name} {v.Cost}");
            double MINcost = listComputers
               .Min(c => c.Cost);
            List<Сomputer> mincost = listComputers
                .Where(v => v.Cost == MINcost)
                .ToList();
            foreach (Сomputer v in mincost)
                Console.WriteLine($"{v.Id} {v.Name} {v.Cost}");
            IEnumerable<IGrouping<string,Сomputer>> group = listComputers
               .GroupBy(g1 => g1.CPU);
            foreach (IGrouping < string,Сomputer> gI in group)
            {
                Console.WriteLine(gI.Key);
                foreach ( Сomputer c in gI)
                    Console.WriteLine($"{c.Id} {c.Name} {c.CPU}");
            }
            bool availability = listComputers
                .Any(a => a.Quantity >= 30 == true);
            Console.WriteLine("{0}", availability ? "есть в наличии" : "нет в наличии");
        }
    }
}