using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.DatabaseTables
{
    internal class Objednavka
    {

        private int id_objednavka;
        private int id_zakaznik;
        private string datum;
        private int celkovacena;
        public int ObjednavkaId { get { return id_objednavka; } set { id_objednavka = value; } }
        public int ZakaznikId { get { return id_zakaznik; } set { id_zakaznik = value; } }
        public string Datum { get { return datum; } set { datum = "'"+value+"'"; } }
        public int CelkovaCena { get { return celkovacena; } set { celkovacena = value; } }
    }
}
