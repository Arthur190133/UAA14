using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {

            selectBookByTitle("Kaimiloa");
            Console.ReadLine();
        }

        static string getDatabasePath() { return "Data Source = PCI42106\\SQLEXPRESS; Initial Catalog = bibliotheque_bb; Integrated Security = True"; }

        static void selectBookByTitle(string title)
        {
         
           string query = string.Format("SELECT * from listeLivre where titre = @title", title);

            SqlConnection connexion = new SqlConnection(getDatabasePath());
            SqlCommand command = new SqlCommand(query, connexion);
            connexion.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                
                Console.WriteLine(reader[3]);
            }


        }
    }
}
