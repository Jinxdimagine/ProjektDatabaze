using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Projekt.DatabaseTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Rozhrani
    {
        private DbConfig config;
        public DbConfig Config { get { return config; } set { config = value; } }

        private bool konec;
        private bool KonecMethody;
        private int vyber;
        private int pocet;

        public bool Konec { get { return konec; } set { konec = value; } }

        public int Vyber { get { return vyber; } set { vyber = value; } }

        public int Pocet { get { return pocet; } set { pocet = value; } }

        public bool IsKonecMethody { get { return KonecMethody; } set { KonecMethody = value; } }

        public Rozhrani() { 
        Config = new DbConfig();
            test();
            Konec = true;
            IsKonecMethody=true;
        }

        public void test() { 
        Config.pripojeni();
        using (SqlConnection conn = new SqlConnection(config.urlPripojeni())) {
                try
                {
                    conn.Open();
                }
                catch {
                    throw new Exception("Zkontrolujte configuraci databaze");
                }
            
            }
        }

        public string menu() {
            string textMenu = $@"
1.Pridat Zakaznika
2.Pridat Objednavku
3.Smazat objednavku
4.Upravit Objednavku
5.Vypis Objednavek
6.Vypnuti Aplikace
";
            return textMenu;
        }

        public List<string> otazkyUzivatele(string odpoved) {
            int odpoved1;
            try {
                 odpoved1 = Int32.Parse(odpoved);
            }
            catch  {
                throw new Exception("Zadejte odpoved znova");
            }
            Vyber = odpoved1;
            List<string> list = new List<string>();
            switch (odpoved1) {
                case 1:
                    list.Add("Zadejte jmeno zakaznka");
                    list.Add("Zadejte email zakaznika");
                    return list;
                case 2:
                    list.Add("Zadejte cislo zakazinka"+"\n"+SeznamZakazniku());
                    list.Add("Zadejte datum objednavky(format YYYY-MM-DD,ROKY-MESICE-DNY)");
                    list.Add("Zadejte celkovou cenu objednavky");
                    return list;
                case 3:
                    list.Add("Zadejte jakou Objednavku chcete vymazat (Zadejte cislo objednavky)" +"\n" +SeznamObjednavek());
                    return list;
                case 4:
                    list.Add("Zadejte jakou Objednavku chcete upravit(Zadejte cislo objednavky)" + "\n" + SeznamObjednavek());
                    list.Add("Zadejte co budete chctit pozmenit(Zadejte cislo =1,2,3):"+"\n"+"1.Cislo Zakaznika"+"\n"+"2.Datum"+"\n"+"3.Cenu");
                    list.Add("Zadejte Prosim Hodnotu(format Datumu =YYY-MM-DD,ROKY-MESICE-DNY)");
                    return list;
                case 5:
                    
                    list.Add(SeznamObjednavek()+"\n"+"Pro pokracovani zmacknete enter");
                    return list;
                case 6:
                    Konec=false;
                    return list;
                    
                
            }
            return null;
        }
        public string vyberUzivatele(List<string> odpovedi) {
            string[] odpovedi2 = odpovedi.ToArray();
            switch (Vyber) {
                case 1:
                    if (pridatZakaznika(odpovedi2))
                    {
                        return "Zakaznik uspesne pridan";
                    }
                    else {
                        return "Zakaznika se nepodarilo pridat";
                    }
                case 2:
                    if (pridatObjednavku(odpovedi2))
                    {
                        return "Objednavka  uspesne pridana";
                    }
                    else {
                        return "Objednavka se nepodarilo pridat";
                    }
                case 3:
                    if (smazaniObjednavky(odpovedi2)) {
                        return "Objednavka byla uspesne smazana";
                    }
                    else
                    {
                        return "Objednavka se nepodarilo smazat";
                    }
                case 4:
                    if (upravaObjednavky(odpovedi2))
                    {
                        return "Objednavka byla uspesne upravena";
                    }
                    else
                    {
                        return "Objednavka se nepodarilo upravit";
                    }
                
            
            }
            return "";
        }

        public bool zpracovaniCommandu(string cmd) {
          
            using (SqlConnection conn = new SqlConnection(config.urlPripojeni())) { 
            conn.Open();
                
            SqlCommand command=new SqlCommand(cmd, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
                return true; 
        }

        public string SelectCommand(string cmd) {
            
            string text = "";
            using (SqlConnection conn = new SqlConnection(config.urlPripojeni()))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(cmd, conn);
                SqlDataReader reader = command.ExecuteReader();
                switch (Vyber) {
                    case 2:
                        
                        while (reader.Read())
                        {
                            text += reader.GetValue(0).ToString() + "-----" + reader.GetValue(1).ToString() + "\n";
                        }
                        if (text == "")
                        {
                            text = "Pridejte Prosim Zaznam";
                        }
                        reader.Close();
                        conn.Close();
                        return text;
                    case 3:
                        
                        
                        while (reader.Read())
                        {
                            
                            text += reader.GetValue(0).ToString() + "\n";
                        }
                        if (text == "") {
                            text = "Pridejte Prosim Zaznam";
                            
                        }
                        reader.Close();
                        conn.Close();
                        return text;
                     case 4:
                        while (reader.Read()) {
                            text += reader.GetValue(0).ToString() + "-" + reader.GetValue(1).ToString() + "-" + reader.GetValue(2).ToString() + "-" + reader.GetValue(3).ToString() + "\n";
                        }
                        if (text == "")
                        {
                            text = "Pridejte Prosim Zaznam";

                        }
                        reader.Close();
                        conn.Close();
                        return text;
                        case 5:
                        while (reader.Read())
                        {
                            text += reader.GetValue(0).ToString() + "-" + reader.GetValue(1).ToString() + "-" + reader.GetValue(2).ToString() + "-" + reader.GetValue(3).ToString() + "\n";
                        }
                        if (text == "")
                        {
                            text = "Pridejte Prosim Zaznam";

                        }
                        reader.Close();
                        conn.Close();
                        return text;
                }
            }
            return text;
        }
        public bool pridatZakaznika (string[] odpovedi){
            Zakaznik zakaznik = new Zakaznik();
            zakaznik.Jmeno = odpovedi[0];
            zakaznik.Email = odpovedi[1];
            string cmd= "insert into Zakaznik(jmeno,email)values(" + zakaznik.Jmeno + "," + zakaznik.Email + ")";
            if (zpracovaniCommandu(cmd))
            {
                return true;
            }
            else { 
            return false ;
            }
            
        }

        public bool pridatObjednavku(string[] odpovedi) { 
        Objednavka objednavka=new Objednavka();
            objednavka.ZakaznikId = Int32.Parse(odpovedi[0]);
            objednavka.Datum = odpovedi[1];
            objednavka.CelkovaCena= Int32.Parse(odpovedi[2]);
            string cmd = "insert into Objednavka(id_zakaznik,datum,celkovacena)values("+objednavka.ZakaznikId+","+objednavka.Datum+","+objednavka.CelkovaCena+")";
            if (zpracovaniCommandu(cmd))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool smazaniObjednavky(string[] odpovedi) {
            string cmd = "delete from Objednavka where id_objednavka=" + odpovedi[0];
            if (zpracovaniCommandu(cmd))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool upravaObjednavky(string[] odpovedi) {
            
            switch (Int32.Parse(odpovedi[1]))
            {
                case 1:
                    odpovedi[1] = "id_zakaznik";
                    break;
                case 2:
                    
                    odpovedi[1] = "datum";
                    break;
                case 3:
                    odpovedi[1] = "celkovacena";
                    break;

            }
            string cmd = "Update Objednavka set " + odpovedi[1] + "=" + odpovedi[2] + "where id_objednavka=" + odpovedi[0]+";";
            Console.WriteLine(odpovedi[1]);
            if (zpracovaniCommandu(cmd))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public string SeznamZakazniku() {
            string cmd = "Select id_zakaznik,jmeno from Zakaznik";
            string text=SelectCommand(cmd);
            string hlavicka = "Cislo  Jmeno" + "\n";
            if (text == "")
            {
                text = "Pridejte Prosim Zaznam";
                IsKonecMethody = false;
                return null;
            }
            else { 
            return hlavicka+text;
            }
            
       }
        public string SeznamObjednavek() {
            string cmd;
            string text="";
            string hlavicka=""  ;
            if (Vyber == 3) {

                cmd = "Select id_objednavka from Objednavka";
                text = SelectCommand(cmd);
                hlavicka = "Cislo Objednavky" + "\n";
            } else if (Vyber==4||Vyber==5) { 
                     cmd = "Select * from Objednavka";
                     text = SelectCommand(cmd);
                    hlavicka = "Cislo Objednavky-" + "Cislo Zakaznika-" + "Datum-"+"Cena"+"\n";
            } 
            if (text == "")
            {
                Console.WriteLine(text);
                text = "Pridejte Prosim Zaznam";
                hlavicka = "";
                IsKonecMethody = false;
                return null;
            }
            else
            {
                return hlavicka+text;
            }
            
        }

        
        
    }
}
