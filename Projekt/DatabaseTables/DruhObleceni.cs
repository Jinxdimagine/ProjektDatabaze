using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.DatabaseTables
{
    internal class DruhObleceni
    {
        private int id_DruhObleceni;
        private string nazev;
        public int DruhObleceniId { get { return id_DruhObleceni; } set { id_DruhObleceni = value; } }
        public string Nazev { get { return nazev; } set { nazev = value; } }
    }
}
