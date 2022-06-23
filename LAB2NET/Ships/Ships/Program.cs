using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;

/*Розробити структуру даних для зберігання інформації про морські 
перевезення. Для об'єктів зберігається наступна інформація: кораблі –
назва, пасажиромісткість, пароплавство, рік побудови, тип (річкове, 
морське); пароплавство – назва, місце розташування (річка/море); річка –
назва, довжина, максимальна ширина, кількість притоків; море – назва, 
площа. Врахувати наступне, що кожен корабель може експлуатуватися 
тільки на річці або тільки на морі. На річці і на морі можуть 
експлуатуватися кілька кораблів.*/

namespace Ships
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

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

            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("seas.xml", settings))
            {
                writer.WriteStartElement("seas");
                foreach (var sea in seas)
                {
                    writer.WriteStartElement("sea");
                    writer.WriteElementString("name", sea.Name);
                    writer.WriteElementString("id", sea.Id.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("square", sea.Square.ToString(CultureInfo.CurrentCulture));
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            using (XmlWriter writer = XmlWriter.Create("rivers.xml", settings))
            {
                writer.WriteStartElement("rivers");
                foreach (var river in rivers)
                {
                    writer.WriteStartElement("river");
                    writer.WriteElementString("name", river.Name);
                    writer.WriteElementString("id", river.Id.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("length", river.Length.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("inflows", river.Inflows.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("maxwidth", river.MaxWidth.ToString(CultureInfo.CurrentCulture));
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            
            using (XmlWriter writer = XmlWriter.Create("ports.xml", settings))
            {
                writer.WriteStartElement("ports");
                foreach (var port in ports)
                {
                    writer.WriteStartElement("port");
                    writer.WriteElementString("portname", port.PortName);
                    writer.WriteElementString("id", port.Id.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("typeid", port.TypeId.ToString(CultureInfo.CurrentCulture));
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            
            using (XmlWriter writer = XmlWriter.Create("ships.xml", settings))
            {
                writer.WriteStartElement("ships");
                foreach (var ship in ships)
                {
                    writer.WriteStartElement("ship");
                    writer.WriteElementString("name", ship.Name);
                    writer.WriteElementString("type", ship.Type.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("portid", ship.PortId.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("year", ship.Year.ToString(CultureInfo.CurrentCulture));
                    writer.WriteElementString("pospas", ship.PosPas.ToString(CultureInfo.CurrentCulture));
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            XDocument seasDocument = XDocument.Load("seas.xml");
            foreach (XElement sea in seasDocument.Descendants("sea"))
            {
                int id = (int)sea.Element("id");
                string name = (string)sea.Element("name");
                double square = (double)sea.Element("square");
                Console.WriteLine($"ID = {id}\tName = {name}\tSquare = {square}");
            }
            XDocument riversDocument = XDocument.Load("rivers.xml");
            foreach (XElement river in riversDocument.Descendants("river"))
            {
                int id = (int)river.Element("id");
                string name = (string)river.Element("name");
                double length = (double)river.Element("length");
                double maxwidth = (double)river.Element("maxwidth");
                int inflows = (int)river.Element("inflows");
                Console.WriteLine($"ID = {id}\tName = {name}\tLength = {length}\tMaxWidth = {maxwidth}\tInflows = {inflows}");
            }
            XDocument portsDocument = XDocument.Load("ports.xml");
            foreach (XElement port in riversDocument.Descendants("port"))
            {
                int id = (int)port.Element("id");
                string portname = (string)port.Element("portname");
                int typeid = (int)port.Element("typeid");
                Console.WriteLine($"ID = {id}\tPortName = {portname}\tTypeId = {typeid}");
            }
            
            XDocument shipsDocument = XDocument.Load("ships.xml");
            foreach (XElement ship in shipsDocument.Descendants("ship"))
            {
                string name = (string)ship.Element("name");
                bool type = (bool)ship.Element("type");
                int portid = (int)ship.Element("portid");
                int year = (int)ship.Element("year");
                int pospas = (int)ship.Element("pospas");
                Console.WriteLine($"Name = {name}\tType = {type}\tPortId = {portid}\tYear = {year}\tPosPas = {pospas}");
            }
            
            Console.WriteLine("Query 1");
            Console.WriteLine("Show Ports information");
            /*var query1 = from a in ports
                select a;
            Console.WriteLine("Result:");
            foreach (var result in query1)
            {
                Console.WriteLine(result.Id + " " + result.PortName + " " +  result.TypeId);
            }*/
            var query1 = portsDocument.Descendants("port").Select(el => new Port()
            {
                Id = (int) el.Element("id"),
                PortName = (string) el.Element("portname"),
                TypeId = (int) el.Element("typeid")
            });
            foreach (var result in query1)
            {
                Console.WriteLine($"Port id = {result.Id}\tPortName = {result.PortName}\tType Id = {result.TypeId}");
            }
            
            Console.WriteLine("Query 2");
            Console.WriteLine("Show all ships");

            /*var query2 = ships.Select(a => new { a.Name, a.Year, a.PosPas });
            
            foreach (var ship in query2)
            {
                Console.WriteLine(ship.Name + " " + ship.Year + " " + ship.PosPas);
            }*/
            
            var query2 = shipsDocument.Descendants("ship").Select(el => new Ship()
            {
                Name = (string) el.Element("name"),
                Year = (int) el.Element ("year"),
                PosPas = (int) el.Element ("pospas")
            });
            
            foreach (var result in query2)
            {
                Console.WriteLine($"Ship name = {result.Name}\tYear = {result.Year}\tPosPas = {result.PosPas}");
            }
            
            
            Console.WriteLine("Query 3");
            Console.WriteLine("Show ships constructed before 2003, if equal, sort by possible passengers amount");
            /*var query3 = from s in ships
                where s.Year < 2003
                orderby s.Year, s.PosPas
                select s;
            
            Console.WriteLine("Result:");
            foreach (var result in query3)
            {
                Console.WriteLine(result.Name + " " + result.Year + " " + result.PosPas);
            }*/
            
            var query3 = shipsDocument.Descendants("ship")
                .Where(el => (int) el.Element("year") < 2003)
                .OrderBy(el => (int) el.Element("year"))
                .ThenBy(el => (int) el.Element("pospas"))
                .Select(el => new Ship()
                {
                    Name = (string) el.Element("name"),
                    Year = (int) el.Element ("year"),
                    PosPas = (int) el.Element ("pospas")
                });
            foreach (var result in query3)
            {
                Console.WriteLine($"Name = {result.Name}\tYear = {result.Year}\tPosPas = {result.PosPas}");
            }
            
            Console.WriteLine("Query 4");
            Console.WriteLine("Show ships names starting with R");
            /*var query4 = from s in ships
                where s.Name[0] == 'R'
                select s;
            
            Console.WriteLine("Result:");
            foreach (var result in query4)
            {
                Console.WriteLine(result.Name);
            }*/
            var query4 = shipsDocument.Descendants("ship")
                .Where(el => ((string)el.Element("name"))[0] == 'R')
                .Select(el => ((string)el.Element("name")));
            foreach (var result in query4)
            {
                Console.WriteLine($"Name = {result}");
            }


            Console.WriteLine("Query 5");
            Console.WriteLine("Show information about ships, sorted by possible passengers in descending order");
            var query5 = shipsDocument.Descendants("ship")
                .OrderByDescending(el => (int) el.Element("pospas"))
                .Select(el => new Ship()
                {
                    Name = (string) el.Element("name"),
                    Year = (int) el.Element ("year"),
                    PosPas = (int) el.Element ("pospas"),
                    PortId = (int) el.Element("portid"),
                    Type = (bool) el.Element("type")
                });
            foreach (var result in query5)
            {
                Console.WriteLine($"Name = {result.Name}\tPosPas = {result.PosPas}");
            }
            
            Console.WriteLine("Query 6");
            Console.WriteLine("Show total length of the rivers");

            /*var query6 = rivers.Sum(r => r.Length);
            Console.WriteLine(query6);*/
            var query6 = riversDocument.Descendants("river").Sum(el => (double) el.Element("length"));
            Console.WriteLine(query6);
            
            
            
            Console.WriteLine("Query 7");
            Console.WriteLine("Show rivers with length > 1000");
            var query7 = riversDocument.Descendants("river").Select(el => new River()
                {
                    Id = (int)el.Element("id"),
                    Name = (string)el.Element("name"),
                    Length = (double)el.Element("length"),
                    MaxWidth = (double)el.Element("maxwidth"),
                    Inflows = (int)el.Element("inflows")
                })
                .Where(r => r.Length > 1000);
            foreach (var result in query7)
            {
                Console.WriteLine($"Name = {result.Name}\tLength = {result.Length}");
            }
            
            Console.WriteLine("Query 8");
            Console.WriteLine("Show total number of seas");
            /*var query8 = seas.Count();
            Console.WriteLine(query8);*/
            var query8 = seasDocument.Descendants("sea").Count();
            Console.WriteLine(query8);
            
            Console.WriteLine("Query 9");
            Console.WriteLine("Show Ports of certain sea/river");
            /*var query9 = rivers.Join(ports,
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
            }*/
            var query9 = riversDocument.Descendants("river").Select(el => new River()
                {
                    Id = (int)el.Element("id"),
                    Name = (string)el.Element("name"),
                    Length = (double)el.Element("length"),
                    MaxWidth = (double)el.Element("maxwidth"),
                    Inflows = (int)el.Element("inflows")

                })
                .Join(portsDocument.Descendants("port").Select(el => new Port()
                    {
                        Id = (int)el.Element("id"),
                        PortName = (string)el.Element("portname"),
                        TypeId = (int)el.Element("typeid")
                    }),
                    r => r.Id,
                    p => p.TypeId,
                    (r, p) => new { PortName = p.PortName, WaterName = r.Name })
                .Union(seasDocument.Descendants("sea").Select(el => new Sea()
                    {
                        Id = (int)el.Element("id"),
                        Name = (string)el.Element("name"),
                        Square = (double)el.Element("square")
                    })
                    .Join(portsDocument.Descendants("port").Select(el => new Port()
                        {
                            Id = (int)el.Element("id"),
                            PortName = (string)el.Element("portname"),
                            TypeId = (int)el.Element("typeid")
                        }),
                        s => s.Id,
                        p => p.TypeId,
                        (s, p) => new { PortName = p.PortName, WaterName = s.Name }));
            foreach (var result in query9)
            {
                Console.WriteLine(result.PortName + " " + result.WaterName);
            }
            Console.WriteLine("Query 10");
            Console.WriteLine("Show total square of all seas");
            /*var query10 = seas.Sum(s => s.Square);*/
            var query10 = seasDocument.Descendants("sea").Sum(el => (double) el.Element("square"));
            Console.WriteLine(query10);
            
            Console.WriteLine("Query 11");
            Console.WriteLine("Show all ships of each port except the first one");
            var query11 = shipsDocument.Descendants("ship").Select(el => new Ship()
                {
                    Name = (string) el.Element("name"),
                    Year = (int) el.Element ("year"),
                    PosPas = (int) el.Element ("pospas"),
                    PortId = (int) el.Element("portid"),
                    Type = (bool) el.Element("type")
                })
                .GroupBy(s => s.PortId)
                .Select(g => new
                {
                    Port = ports.FirstOrDefault(a => g.Key == a.Id),
                    Ships = g.Skip(1)
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
            /*var query12 = ships.Select(s => s.Name).Distinct();*/
            var query12 = shipsDocument.Descendants("ship").Select(el => (string) el.Element("name")).Distinct();
            foreach (var result in query12)
            {
                Console.WriteLine(result);
            }
            Console.WriteLine("Query 13");
            Console.WriteLine("Show amount of seas with square more than 40000");
            /*var query13 = seas.Count(s => s.Square > 40000);*/
            var query13 = seasDocument.Descendants("sea").Select(el => new Sea()
            {
                Id = (int)el.Element("id"),
                Name = (string)el.Element("name"),
                Square = (double)el.Element("square")
            }).Where(s => s.Square > 40000).Count();
            Console.WriteLine(query13);
            
            Console.WriteLine("Query 14");
            Console.WriteLine("Show the longest river");
            /*var query14 = rivers.Max(r => r.Length);*/
            var query14 = riversDocument.Descendants("river").Select(el => new River()
            {
                Id = (int)el.Element("id"),
                Name = (string)el.Element("name"),
                Length = (double)el.Element("length"),
                MaxWidth = (double)el.Element("maxwidth"),
                Inflows = (int)el.Element("inflows")

            }).Max(r => r.Length);
            Console.WriteLine(query14);
            
            Console.WriteLine("Query 15");
            Console.WriteLine("Show the amount of the ships starting with letter R");
            /*var query15 = ships.Count(s => s.Name.StartsWith("R"));*/
            var query15 = shipsDocument.Descendants("ship")
                .Where(el => ((string)el.Element("name"))[0] == 'R').Count();
            Console.WriteLine(query15);
        }
}
}
