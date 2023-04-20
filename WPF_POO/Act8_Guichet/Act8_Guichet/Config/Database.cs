using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act8_Guichet.Config
{
    internal class Database
    {
        private readonly string host = "localhost";
        private readonly string database = "guichet";
        private readonly string port = "3306";
        private readonly string username = "root";
        private readonly string password = "";
        private readonly string convertDateTime = "True";

        private MySqlConnection _connexion;

        public MySqlConnection Connexion()
        {
            _connexion = null;
            try
            {
                _connexion = new MySqlConnection("Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password + ";convert zero datetime=" + convertDateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return _connexion;
        }
    }
}
