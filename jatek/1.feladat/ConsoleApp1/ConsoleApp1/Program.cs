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
            Console.WriteLine("1. és 2. feladat");
            List<Game> list = new List<Game>();
            string[] lines = File.ReadAllLines("jatekok.txt");

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                Game obj = new Game(values[0], values[1], values[2], values[3], values[4]);
                list.Add(obj);
            }

            Console.WriteLine("3. feladat");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.sorszam};{item.kateg};{item.nev};{item.ar};{item.db}");
            }

            Console.WriteLine("4. feladat");
            int db = 0;
            foreach (var item in list)
            {
                db += item.db;
            }

            Console.WriteLine($"Az össz darabszám: {db}");

            Console.WriteLine("5. feladat");
            foreach (var item in list)
            {
                if (item.kateg == "Akció")
                {
                    Console.WriteLine($"{item.nev}, {item.ar}");
                }
            }

            Console.WriteLine("6.Feladat");
            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (var item in list)
            {
                if (dic.ContainsKey(item.kateg))
                {
                    dic[item.kateg]++;
                }
                else
                {
                    dic[item.kateg] = 1;
                }
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key}: {item.Value} termék");
            }

            Console.WriteLine("7.Feladat");
            List<Game> games = new List<Game>();
            Game legolcsobb = list[0];
            games.Add(legolcsobb);

            foreach (var item in list)
            {
                if (item.ar < legolcsobb.ar)
                {
                    legolcsobb = item;
                    games.Clear();
                    games.Add(legolcsobb);
                }
                else if (item.ar == legolcsobb.ar)
                {
                    games.Add(item);
                }
            }

            foreach (var item in games)
            {
                Console.WriteLine($"Kategória: {item.kateg}, {item.nev}, Ár: {item.ar}");
            }
        }
    }
}
