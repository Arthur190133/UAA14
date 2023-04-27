using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act8_Guichet.Classes
{
    public class Personne
    {
        private string _name;
        private string _lastName;
        private int _id;
        private DateTime _birthDate;

        public Personne(string name, string lastName,int id, DateTime birthDate)
        {
            _name = name;
            _lastName = lastName;  
            _id = id;
            _birthDate = birthDate;
        }

        public string Name { get { return _name; } }
        public string LastName { get { return _lastName; } }
        public int Id { get { return _id; } }   
        public DateTime BirthDate { get { return _birthDate; } }

    }
}
