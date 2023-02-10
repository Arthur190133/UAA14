using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testion les acces aux bases de données");
            Console.WriteLine("Chercher une information particuliere ou lister toute une table \nPar exemple dans la table des clients, faire une rechercdhe sur base du nom de la societe");
            
            string[] Noms = FindBySociety(Console.ReadLine());

            foreach(string nom in Noms)
            {
                Console.WriteLine(nom);
            }
            Console.ReadLine();

            


        }

        static public string[] FindBySociety(string society)
        {
            try
            {
                if(society == "")
                {
                    society = "*";
                }
                string query = "SELECT * FROM Clients WHERE Société=\"" + society + "\";";

                DataSet ds = new DataSet();

                OleDbConnection maConnexion = new OleDbConnection(GetDataBasePath());

                maConnexion.Open();

                OleDbDataAdapter da = new OleDbDataAdapter(query, maConnexion);

                da.Fill(ds, "mesdonnees");

                string[] valeurs = new string[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    valeurs[i] = (Concat(ds.Tables[0].Rows[i]));
                }

                return valeurs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;

            }
        }

        static public string Concat(DataRow data)
        {
            string ConcacData = data["Code client"].ToString() + " | "  + data["Société"].ToString()  + " | " + data["Contact"].ToString() + " | " + data["Adresse"].ToString() + " | " + data["Code postal"].ToString() + " | " + data["Ville"].ToString();

            return ConcacData;
        }

        static public string GetDataBasePath()
        {
            string CheminBDRelatif = System.IO.Directory.GetCurrentDirectory() + "\\Comptoirs.accdb";

            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + CheminBDRelatif;
        }
    }
}
