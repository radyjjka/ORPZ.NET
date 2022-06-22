using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Ships
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sea> seas = new List<Sea>()
            { 
                new Sea() { Id = 1, Name = "Black Sea", Square = 30000 },
                new Sea() { Id = 2, Name = "White Sea", Square = 20000 }, 
                new Sea() { Id = 3, Name = "Gray Sea", Square = 50000 },
                new Sea() { Id = 4, Name = "Blue Sea", Square = 60000 }
            };
            List<River> rivers = new List<River>()
            { 
                new River() { Id = 4, Name = "Dnipro River", Length = 2200, MaxWidth = 5, Inflows = 13},
                new River() { Id = 5, Name = "Dnister River", Length = 1300 , MaxWidth = 4, Inflows = 12},  
                new River() { Id = 6, Name = "Desna River", Length = 1130, MaxWidth = 2, Inflows = 18},
                new River() { Id = 7, Name = "Vesna River", Length = 800, MaxWidth = 8, Inflows = 15},
                new River() { Id = 8, Name = "Kolomyyka River", Length = 800, MaxWidth = 8, Inflows = 11}
            };
        
            List<Port> ports = new List<Port>()
            { 
                new Port() { Id = 1, PortName = "Port1", TypeId = 4},
                new Port() { Id = 2, PortName = "Port2", TypeId = 4},
                new Port() { Id = 3, PortName = "Port3", TypeId = 5},
                new Port() { Id = 4, PortName = "Port4", TypeId = 6},
                new Port() { Id = 5, PortName = "Port5", TypeId = 6},
                new Port() { Id = 6, PortName = "Port6", TypeId = 6},
                new Port() { Id = 7, PortName = "Port7", TypeId = 1},
                new Port() { Id = 8, PortName = "Port8", TypeId = 2},
                new Port() { Id = 9, PortName = "Port9", TypeId = 2},
                new Port() { Id = 10, PortName = "Port10", TypeId = 3},
            };
            
            List<Ship> ships = new List<Ship>()
            { 
                new Ship() { Name = "RS-232", Type = false, PortId = 1, Year = 2002, PosPas = 50},
                new Ship() { Name = "RV-434", Type = false, PortId = 1, Year = 2005, PosPas = 45},
                new Ship() { Name = "RI-232", Type = false, PortId = 1, Year = 2004, PosPas = 40},
                new Ship() { Name = "DA-124", Type = false, PortId = 1, Year = 2002, PosPas = 60},
                new Ship() { Name = "FA-124", Type = false, PortId = 1, Year = 2003, PosPas = 45},
                new Ship() { Name = "FA-124", Type = false, PortId = 2, Year = 2010, PosPas = 45},
                new Ship() { Name = "RA-124", Type = false, PortId = 2, Year = 1999, PosPas = 40},
                new Ship() { Name = "River-8", Type = false, PortId = 2, Year = 2012, PosPas = 55},
                new Ship() { Name = "Rage-2", Type = false, PortId = 2, Year = 2016, PosPas = 70},
                new Ship() { Name = "SV-2", Type = false, PortId = 2, Year = 1990, PosPas = 60},
                new Ship() { Name = "Jack-10", Type = false, PortId = 3, Year = 1998, PosPas = 40},
                new Ship() { Name = "Stream-5", Type = false, PortId = 3, Year = 2005, PosPas = 45},
                new Ship() { Name = "Stream-5", Type = false, PortId = 3, Year = 2006, PosPas = 45},
                new Ship() { Name = "Fury-5", Type = false, PortId = 4, Year = 2003, PosPas = 45},
                new Ship() { Name = "HE-8", Type = false, PortId = 4, Year = 2003, PosPas = 30},
                new Ship() { Name = "Johnsons", Type = false, PortId = 4, Year = 2001, PosPas = 25},
                new Ship() { Name = "Karai-5", Type = false, PortId = 4, Year = 1999, PosPas = 60},
                new Ship() { Name = "Wave-10", Type = false, PortId = 5, Year = 2005, PosPas = 50},
                new Ship() { Name = "Dale-15", Type = false, PortId = 5, Year = 1995, PosPas = 50},
                new Ship() { Name = "Cheap-16", Type = false, PortId = 6, Year = 1996, PosPas = 53},
                new Ship() { Name = "Funny-221", Type = false, PortId = 6, Year = 2006, PosPas = 42},
                new Ship() { Name = "Sheero-10", Type = false, PortId = 6, Year = 2016, PosPas = 45},
                new Ship() { Name = "Shark-5", Type = true, PortId = 7, Year = 2005, PosPas = 100},
                new Ship() { Name = "Flagman-10", Type = true, PortId = 7, Year = 2006, PosPas = 110},
                new Ship() { Name = "Flagman-15", Type = true, PortId = 7, Year = 2007, PosPas = 120},
                new Ship() { Name = "Flagman-20", Type = true, PortId = 7, Year = 2008, PosPas = 140},
                new Ship() { Name = "Revolt-330", Type = true, PortId = 8, Year = 2001, PosPas = 150},
                new Ship() { Name = "Kraken", Type = true, PortId = 8, Year = 2001, PosPas = 140},
                new Ship() { Name = "Leviathan-300", Type = true, PortId = 9, Year = 2005, PosPas = 150},
                new Ship() { Name = "Leader-920", Type = true, PortId = 9, Year = 1990, PosPas = 200},
                new Ship() { Name = "Whale", Type = true, PortId = 9, Year = 1985, PosPas = 90},
                new Ship() { Name = "Titanic", Type = true, PortId = 9, Year = 2005, PosPas = 180},
                new Ship() { Name = "Moby-500", Type = true, PortId = 10, Year = 2018, PosPas = 250},
                new Ship() { Name = "Shore-230", Type = true, PortId = 10, Year = 2000, PosPas = 150},
            };
            
            Console.WriteLine("Query 1");
            Console.WriteLine("Show Ports information");
            var query1 = from a in ports
                select a;
            Console.WriteLine("Result:");
            foreach (var result in query1)
            {
                Console.WriteLine(result.Id + " " + result.PortName + " " +  result.TypeId);
            }
            
            Console.WriteLine("Query 2");
            Console.WriteLine("Show all ships");

            var query2 = ships.Select(a => new { a.Name, a.Year, a.PosPas });
            
            foreach (var ship in query2)
            {
                Console.WriteLine(ship.Name + " " + ship.Year + " " + ship.PosPas);
            }
            
            
            Console.WriteLine("Query 3");
            Console.WriteLine("Show ships constructed before 2003, if equal, sort by possible passengers amount");
            var query3 = from s in ships
                where s.Year < 2003
                orderby s.Year, s.PosPas
                select s;
            
            Console.WriteLine("Result:");
            foreach (var result in query3)
            {
                Console.WriteLine(result.Name + " " + result.Year + " " + result.PosPas);
            }
            
            Console.WriteLine("Query 4");
            Console.WriteLine("Show ships names starting with R");
            var query4 = from s in ships
                where s.Name[0] == 'R'
                select s;
            
            Console.WriteLine("Result:");
            foreach (var result in query4)
            {
                Console.WriteLine(result.Name);
            }

            Console.WriteLine("Query 5");
            Console.WriteLine("Show ports and ships by possible passengers amount descending");

            var query5 = from s in ships
                join p in ports on s.PortId equals p.Id
                orderby s.PosPas descending
                select new { p.PortName, s.Name, s.PosPas };
            
            foreach (var result in query5)
            {
                Console.WriteLine(result.PortName + " " + result.Name + " " + result.PosPas);
            }
            
            Console.WriteLine("Query 6");
            Console.WriteLine("Show total length of the rivers with more than 12 inflows");

            var query6 = rivers.Where(r => r.Inflows > 12).Sum(r => r.Length);
            Console.WriteLine(query6);
            
            Console.WriteLine("Query 7");
            Console.WriteLine("Show total possible passengers for each port");
            var query7 = from s in ships
                join p in ports on s.PortId equals p.Id into result
                group s by result.Single().PortName;
            foreach (var r in query7)
            {
                int possiblePassengers = 0;
                foreach (var r2 in r)
                {
                    possiblePassengers += r2.PosPas;
                }
                Console.WriteLine(r.Key + " " + possiblePassengers);
            }
            
            Console.WriteLine("Query 8");
            Console.WriteLine("Show total number of seas");
            var query8 = seas.Count();
            Console.WriteLine(query8);
            
            Console.WriteLine("Query 9");
            Console.WriteLine("Show total number of seas");
            var query9 = rivers.Join(ports,
                r => r.Id,
                p => p.TypeId,
                (r, p) => new { PortName = p.PortName, WaterName = r.Name }
            ).Union(seas.Join(ports,
                s => s.Id,
                p => p.TypeId,
                (s, p) => new { PortName = p.PortName, WaterName = s.Name }));
            foreach (var p in query9)
            {
                Console.WriteLine(p.PortName + " " + p.WaterName);
            }
            
            Console.WriteLine("Query 10");
            Console.WriteLine("Show total square of all seas");
            var query10 = seas.Sum(s => s.Square);
            Console.WriteLine(query10);
            
            Console.WriteLine("Query 11");
            Console.WriteLine("Show all ships of each port except the first one");
            var query11 = ships.GroupBy(s => s.PortId).Select(
                r => new
                {
                    Port = ports.FirstOrDefault(p => r.Key == p.Id ),
                    Ships = r.Skip(1)
                });
            foreach (var result in query11)
            {
                Console.WriteLine(result.Port.PortName);
                foreach (var shipss in result.Ships)
                {
                    Console.WriteLine(shipss.Name);
                }
                
            }
            Console.WriteLine("Query 12");
            Console.WriteLine("Show all unique ship names");
            var query12 = ships.Select(s => s.Name).Distinct();
            foreach (var result in query12)
            {
                Console.WriteLine(result);
            }
            Console.WriteLine("Query 13");
            Console.WriteLine("Show amount of seas with square more than 40000");
            var query13 = seas.Count(s => s.Square > 40000);
            Console.WriteLine(query13);
            
            Console.WriteLine("Query 14");
            Console.WriteLine("Show the longest river");
            var query14 = rivers.Max(r => r.Length);
            Console.WriteLine(query14);
            
            Console.WriteLine("Query 15");
            Console.WriteLine("Show the amount of the ships starting with letter R");
            var query15 = ships.Count(s => s.Name.StartsWith("R"));
            Console.WriteLine(query15);
        }
}
}