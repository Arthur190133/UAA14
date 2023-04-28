using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act8_Guichet.Models
{
    internal class Comptes_epargnes
    {
        private MySqlConnection _connexion;
        private readonly string _table = "Comptes_courants";

        public Comptes_epargnes(MySqlConnection database)
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
            string query = "SELECT * FROM " + _table + " WHERE Id = " + Id;
            return SendRequest(query);
        }

        public DataTable readOwn(int Id)
        {
            string query = "SELECT * FROM " + _table + " WHERE PersonneId = " + Id;
            return SendRequest(query);
        }

        public void UpdateMoney (int id, float money)
        {
            string query = "UPDATE " + _table + " SET Money = " + money + " WHERE Id = " + id;
            SendRequest(query);
        }
    }
}
