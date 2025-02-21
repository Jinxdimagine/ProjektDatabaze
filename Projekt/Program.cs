using Newtonsoft.Json;
using System.Data.SqlClient;

namespace Projekt {

    public class Projekt {

        static void Main(String[] args) {
            try
            {

                Rozhrani rozhrani = new Rozhrani();
                while (rozhrani.Konec)
                {
                    Console.WriteLine(rozhrani.menu());
                    string odpoved = Console.ReadLine();
                    rozhrani.IsKonecMethody = true;
                    try
                    {

                        List<string> otazky = rozhrani.otazkyUzivatele(odpoved);
                        while (rozhrani.IsKonecMethody)
                        {
                            List<string> odpovedi = new List<string>();
                            foreach (string otazky1 in otazky)
                            {
                                Console.WriteLine(otazky1);
                                string odpovedOtazka = Console.ReadLine();
                                odpovedi.Add(odpovedOtazka);
                            }
                            Console.WriteLine(rozhrani.vyberUzivatele(odpovedi));
                            rozhrani.IsKonecMethody = false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            
            
        }
    }
}
