using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Act8_Guichet.Models
{
    internal class Personnes
    {
        private MySqlConnection _connexion;
        private readonly string _table = "Personnes";

        public Personnes(MySqlConnection database)
        {
            _connexion = database;
        }

        private MySqlDataAdapter SendRequest(string query)
        {
            _connexion.Open();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, _connexion);
            DataSet infos = new DataSet();
            dataAdapter.Fill(infos, "personnes");

            _connexion.Close();

            return dataAdapter;
        }

        public void read()
        {
            string query = "SELECT * FROM " + _table;
            SendRequest(query);
        }

        public void readById(int Id)
        {
            string query = "SELECT * FROM " + _table + "WHERE Id = " + Id;
            SendRequest(query);
        }
    }
}
