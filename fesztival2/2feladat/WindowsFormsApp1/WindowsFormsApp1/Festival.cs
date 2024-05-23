using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Festival
    {
        public int sorszam;
        public string nev;
        public string fesztNev;
        public int fo;
        public int nap;
        public int ar;
        public string kedvezmeny;

        public Festival(string sorszam, string nev, string fesztNev, string fo, string nap, string ar, string kedvezmeny)
        {
            this.sorszam = int.Parse(sorszam);
            this.nev = nev;
            this.fesztNev = fesztNev;
            this.fo = int.Parse(fo);
            this.nap = int.Parse(nap);
            this.ar = int.Parse(ar);
            this.kedvezmeny = kedvezmeny;
        }
    }
}
