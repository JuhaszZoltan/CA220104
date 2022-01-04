using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220104
{
    internal class Program
    {
        static List<JatekosLovese> lista = new List<JatekosLovese>();
        static void Main()
        {
            Feladat04();
            Feladat05();
            Feladat07();
            Feladat09();
            Feladat10();
            Feladat11_12_13();

            Console.ReadKey(true);
        }

        private static void Feladat11_12_13()
        {
            var gb = lista.GroupBy(x => x.Nev);

            Console.WriteLine("11. feladat: Lövések száma:");
            foreach (var e in gb)
            {
                Console.WriteLine($"\t{e.Key} - {e.Count()} db");
            }
            Console.WriteLine("12. feladat: Átlagpontszámok:");
            foreach (var e in gb)
            {
                Console.WriteLine($"\t{e.Key} - {e.Average(x => x.Pontszam)}");
            }
            string gy = gb.OrderByDescending(x => x.Average(y => y.Pontszam))
                .First().Key;
            Console.WriteLine($"13. feladat: A játék győztese: {gy}");
        }

        private static void Feladat10()
        {
            int jsz = lista.Select(x => x.Nev)
                .Distinct().Count();
            Console.WriteLine($"10. feladat: Játékosok száma: {jsz}");
        }

        private static void Feladat09()
        {
            int npl = lista.Count(x => x.Pontszam == 0);
            Console.WriteLine($"9. feladat: Nulla pontos lövések száma: {npl} db");
        }

        private static void Feladat07()
        {
            var lpl = lista
                .Where(x => x.Tavolsag == lista.Min(y => y.Tavolsag))
                .First();

            Console.WriteLine("7. feladat: Legpontosabb lövés:\n" +
                $"\t{lpl.Sorszam}.; {lpl.Nev}; " +
                $"x={lpl.Loves.X}; y={lpl.Loves.Y}; távolság: {lpl.Tavolsag}");
        }

        private static void Feladat05()
        {
            Console.WriteLine($"5. feladat: Lövések száma: {lista.Count} db");
        }

        private static void Feladat04()
        {
            using (var sr = new StreamReader(@"..\..\res\lovesek.txt", Encoding.UTF8))
            {
                var c = sr.ReadLine().Split(';');
                JatekosLovese.Celtabla = (float.Parse(c[0]), float.Parse(c[1]));

                int sorszam = 1;
                while (!sr.EndOfStream)
                {
                    lista.Add(new JatekosLovese(sorszam, sr.ReadLine()));
                    sorszam++;
                }
            }
        }
    }
}
