using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Game
    {
        public int sorszam;
        public string kateg;
        public string nev;
        public int ar;
        public int db;

        public Game(string sorszam, string kateg, string nev, string ar, string db)
        {
            this.sorszam = int.Parse(sorszam);
            this.kateg = kateg;
            this.nev = nev;
            this.ar = int.Parse(ar);
            this.db = int.Parse(db);
        }
    }
}
