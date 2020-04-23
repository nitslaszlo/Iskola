using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // 1.f

namespace Iskola
{
    // 7f.: Osztályt definiáló kódrészlet beillesztése
    class JelszóGeneráló
    {
        private Random Rnd;

        public JelszóGeneráló(Random r)
        {
            Rnd = r;
        }

        public string Jelszó(int jelszóHossz)
        {
            string jelszó = "";
            while (jelszó.Length < jelszóHossz)
            {
                char c = (char)Rnd.Next(48, 123);
                if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z'))
                {
                    jelszó += c;
                }
            }
            return jelszó;
        }
    }

    class Tanuló // 2.f
    {
        public string Kezdés { get; private set; }
        public string Osztály { get; private set; }
        public string Név { get; private set; }
        // 4.f.:
        public int NévHossz => Név.Length - Név.Split().Length + 1;

        // 5.f.:
        public string Azon
        {
            get
            {
                char évfolyamUtolsó = Kezdés[3];
                string vnév3 = new string(Név.Take(3).ToArray()).ToLower();
                string knév = Név.Split()[1];
                string knév3 = new string(knév.Take(3).ToArray()).ToLower();
                return évfolyamUtolsó + Osztály + vnév3 + knév3;
            }
        }


        public Tanuló(string sor)
        {
            string[] m = sor.Split(';');
            Kezdés = m[0];
            Osztály = m[1];
            Név = m[2];
        }
    }

    class Iskola // 1.f. -> Program.cs forrás átnevezése Iskola.cs, források hozzáadása
    {
        static void Main(string[] args)
        {
            // 2.f.:
            List<Tanuló> tanulók = new List<Tanuló>();
            foreach (var i in File.ReadAllLines("../../nevek.txt"))
            {
                tanulók.Add(new Tanuló(i));
            }

            // 3.f.:
            Console.WriteLine($"3. feladat: Az iskolába {tanulók.Count} tanuló jár.");

            // 4.f.:
            Tanuló leghosszabbNevűTanuló = tanulók.First();
            foreach (var i in tanulók.Skip(1))
            {
                if (i.NévHossz > leghosszabbNevűTanuló.NévHossz)
                {
                    leghosszabbNevűTanuló = i;
                }
            }
            Console.WriteLine($"4. feladat: A leghosszabb ({leghosszabbNevűTanuló.NévHossz} karakter) nevű tanuló(k):");
            foreach (var i in tanulók)
            {
                if (i.NévHossz == leghosszabbNevűTanuló.NévHossz)
                {
                    Console.WriteLine($"\t{i.Név}");
                }
            }

            // 5.f.:
            Console.WriteLine("5. feladat: Azonosítók");
            Console.WriteLine($"\tElső: {tanulók.First().Név} - {tanulók.First().Azon}");
            Console.WriteLine($"\tUtolsó: {tanulók.Last().Név} - {tanulók.Last().Azon}");

            // 6.f.:
            Console.Write("6. feladat: Kérek egy azonosítót [pl.: 4dvavkri]: ");
            string inputAzon = Console.ReadLine();
            Tanuló keresettTanuló = null; // keresett tanuló
            foreach (var i in tanulók)
            {
                if (i.Azon == inputAzon)
                {
                    keresettTanuló = i;
                    break;
                }
            }
            if (keresettTanuló != null)
            {
                Console.WriteLine($"\t{keresettTanuló.Kezdés} {keresettTanuló.Osztály} {keresettTanuló.Név}");
            }
            else
            {
                Console.WriteLine("\tNincs megfelelő tanuló.");
            }

            // 7.f.: Tanuló kiválasztása, kapott osztály példányosítása
            Console.WriteLine("7. feladat: Jelszó generálása");
            Random r = new Random();
            Tanuló vt = tanulók[r.Next(0, tanulók.Count)];
            JelszóGeneráló jg = new JelszóGeneráló(r);
            Console.WriteLine($"\t{vt.Név} - {jg.Jelszó(8)}");

            Console.ReadKey();
        }
    }
}
