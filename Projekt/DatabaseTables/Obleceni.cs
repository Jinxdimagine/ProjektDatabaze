using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.DatabaseTables
{
    internal class Obleceni
    {
        private int id_Obleceni;
        private string nazev;
        private int cena;
        private int id_DruhObleceni;
        public int ObleceniId { get { return id_Obleceni; } set { id_Obleceni = value; } }
        public string Nazev { get { return nazev; } set { nazev = value; } }
        public int Cena { get { return cena; } set { cena = value; } }
        public int DruhObleceniId { get { return id_DruhObleceni; } set { id_DruhObleceni = value; } }

    }
}
