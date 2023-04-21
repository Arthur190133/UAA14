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

        private DataTable SendRequest(string query)
        {
            _connexion.Open();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, _connexion);
            DataTable infos = new DataTable();
            dataAdapter.Fill(infos);

            _connexion.Close();

            return infos;
        }

        public DataTable read()
        {
            string query = "SELECT * FROM " + _table;
            return SendRequest(query);
        }

        public DataTable readById(int Id)
        {
            string query = "SELECT * FROM " + _table + "WHERE Id = " + Id;
            return SendRequest(query);
        }

        public DataTable login(string name, string password)
        {
            string query = "SELECT * FROM " + _table + "WHERE Name = " + name + " AND Password = " + password;
            return SendRequest(query);
        }
    }
}
