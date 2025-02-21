using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace Projekt
{
    internal class DbConfig
    {
        public string Datasource { get; set; }
        public string Catalog { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public string TrustServerCertificate { get; set; }
        public void pripojeni()
        {
             try { 
            string configfile = "config.json";
            string configText = File.ReadAllText(configfile);
            var configdata = JsonSerializer.Deserialize<DbConfig>(configText);
            Datasource = configdata.Datasource;
            Catalog=configdata.Catalog;
            User = configdata.User;
            Password = configdata.Password;
                TrustServerCertificate = configdata.TrustServerCertificate;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
           
        }

        public DbConfig() { 
        
        }

        public string urlPripojeni() {
            string text= @"Data Source="+Datasource+";Initial Catalog="+Catalog+";User ID="+User+";Password="+Password+";TrustServerCertificate ="+TrustServerCertificate+";"; 
            return text;
        }
    }

}
