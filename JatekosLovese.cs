using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220104
{
    internal class JatekosLovese
    {
        public static (float X, float Y) Celtabla { get; set; }
        public int Sorszam { get; set; }
        public string Nev { get; set; }
        public (float X, float Y) Loves { get; set; }
        //6. feladat
        public double Tavolsag => 
            Math.Sqrt(
                Math.Pow(Celtabla.X - Loves.X, 2) + 
                Math.Pow(Celtabla.Y - Loves.Y, 2));
        //8. feladat:
        public double Pontszam =>
            (10 - Tavolsag) > 0 ? Math.Round(10 - Tavolsag, 2) : 0F;
        public JatekosLovese(int sorszam, string fileSora)
        {
            Sorszam = sorszam;
            var v = fileSora.Split(';');
            Nev = v[0];
            Loves = (float.Parse(v[1]), float.Parse(v[2]));
        }
    }
}
