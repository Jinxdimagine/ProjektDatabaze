using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.DatabaseTables
{
    internal class ObjednavkaObleceni
    {
        private int id_objednavkaobleceni;
        private int id_objednavka;
        private int id_obleceni;
        private int mnozstvi;
        
        public int ObjednavkaObleceniId { get { return id_objednavkaobleceni; } set { id_objednavkaobleceni = value; } }
        public int ObjednavkaId { get { return id_objednavka; } set { id_objednavka = value; } }
        public int ObleceniId { get { return id_obleceni; } set { id_obleceni = value; } }
        public int Mnozstvi { get { return mnozstvi; } set { mnozstvi = value; } }

    }
}
