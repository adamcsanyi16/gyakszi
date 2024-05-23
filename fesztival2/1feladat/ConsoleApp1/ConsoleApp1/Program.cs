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

            foreach (var line in lines)
            {
                string[] values = line.Split(',');
                Festival obj = new Festival(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                list.Add(obj);
            }

            Console.WriteLine("4. feladat");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.sorszam};{item.nev};{item.fesztNev};{item.fo};{item.nap};{item.ar};{item.kedvezmeny}");
            }

            Console.WriteLine("5-6. feladat");
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
            Dictionary<string, int> foglalas = new Dictionary<string, int>();

            foreach (var item in list)
            {
                if (foglalas.ContainsKey(item.nev))
                {
                    foglalas[item.nev]++;
                }
                else
                {
                    foglalas[item.nev] = 1;
                }
            }

            var foglalt2 = foglalas.Where(x => x.Value >= 2);

            foreach (var item in foglalt2)
            {
                Console.WriteLine($"Akik 2x foglaltak szállást: {item.Key}");
            }
        }
    }
}
