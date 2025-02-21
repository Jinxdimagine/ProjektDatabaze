using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.DatabaseTables
{
    internal class Zakaznik
    {
        private int id_Zakaznik;
        private string jmeno;
        private string email;
        public int ZakaznikId { get { return id_Zakaznik; } set { id_Zakaznik = value; } }
        public string Jmeno { get { return jmeno; } set { jmeno = "'"+value+"'"; } }
        public string Email { get { return email; } set { email = "'" + value + "'"; } }


        // Navigační vlastnosti
        public List<Objednavka> Objednavky { get; set; }
    }
}
