﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // 1.f

namespace Iskola
{
    class Tanuló // 2.f
    {
        public string Kezdés { get; private set; }
        public string Osztály { get; private set; }
        public string Név { get; private set; }

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

            // 3. f.:
            Console.WriteLine($"3. feladat: Az iskolába {tanulók.Count} tanuló jár.");

            Console.ReadKey();
        }
    }
}
