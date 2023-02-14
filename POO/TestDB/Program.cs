using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net.Sockets;
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

            
            string[] Noms = SelectBySociety(Console.ReadLine());

            foreach(string nom in Noms)
            {
                Console.WriteLine(nom);
            }
            Console.ReadLine();

            


        }

        static public string[] SelectBySociety(string society)
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

        static public void AddCategory()
        {
            try
            {
                Console.WriteLine("Nom de catégorie à ajouter ?");
                string CatName = Console.ReadLine();
                Console.WriteLine("description de catégorie à ajouter ?");
                string CatDesc = Console.ReadLine();

                string query = "INSERT INTO catégorie(nom, description) VALUES (\"" + CatName + "\", \"" + CatDesc + "\")";

                DataSet ds = new DataSet();

                OleDbConnection maConnexion = new OleDbConnection(GetDataBasePath());

                maConnexion.Open();

                OleDbDataAdapter da = new OleDbDataAdapter(query, maConnexion);

                da.Fill(ds, "mesdonnees");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;

            }
        }

        static public void UpdateMessager()
        {
            Console.WriteLine("Nom du messager dont on veut modifier le téléphone (speedy express / united package / federal shippping ?");
            string messager = Console.ReadLine();
            Console.WriteLine("Nouveau numéro de téléphone");
            string telephone = Console.ReadLine();

            string query = "UPDATE Messager SET téléphone=@parametre WHERE Nom =" + messager + ";";


            try
            {
                OleDbConnection maConnexion = new OleDbConnection(GetDataBasePath());
                OleDbCommand upCommand = new OleDbCommand(query, maConnexion);
                maConnexion.Open();
                upCommand.Parameters.AddWithValue("@paramètre", telephone);
                upCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        static public void ListAllCat()
        {
            Console.WriteLine("Liste des catégories disponible :");

            string query = "SELECT * from table";
        }
    }
}
