using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2. és 3. feladat");
            List<Festival> list = new List<Festival>();
            string[] lines = File.ReadAllLines("fesztival.txt");

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                Festival obj = new Festival(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                list.Add(obj);
            }

            Console.WriteLine("4. feladat");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.id};{item.nev};{item.hotel};{item.fo};{item.nap};{item.ar};{item.kedvezmeny}");
            }

            Console.WriteLine("5. és 6. feladat");
            Dictionary<string,double> dict = new Dictionary<string,double>();

            foreach (var item in list)
            {
                double osszeg = item.ar * item.nap * item.fo;
                if (item.kedvezmeny == "igen")
                {
                    osszeg *= 0.75;
                }

                if (dict.ContainsKey(item.nev))
                {    
                    
                    dict[item.nev] += osszeg;                
                }
                else
                {
                    dict[item.nev] = osszeg;
                }
            }

            var novDict = dict.OrderBy(x => x.Value);

            foreach (var item in novDict)
            {
                Console.WriteLine($"{item.Key}: {item.Value} Ft");
            }

            Console.WriteLine("7. feladat");
            var maxKolto = dict.OrderByDescending(x => x.Value).First();
            Console.WriteLine($" A legtöbbet költő személy: {maxKolto.Key}, összeg: {maxKolto.Value} Ft");

            Console.WriteLine("8. feladat");
            Dictionary<string, int> bookingCount = new Dictionary<string, int>();

            foreach (var item in list)
            {
                if (bookingCount.ContainsKey(item.nev))
                {
                    bookingCount[item.nev]++;
                }
                else
                {
                    bookingCount[item.nev] = 1;
                }
            }

            var multipleBookings = bookingCount.Where(x => x.Value >= 2);

            foreach (var person in multipleBookings)
            {
                Console.WriteLine($"{person.Key}, {person.Value} alkalommal foglalt szállást.");
            }
        }
    }
}
