using System;
using System.Collections.Generic;
using System.Text;

namespace ACT4_Sandwichs
{
    class SandwichMaker
    {
        private string[] _proteines;
        private string[] _condiments;
        private string[] _pains;
        private string[] _crudités;

        public string[] Proteines
        {
            get
            {
                return _proteines;
            }
        }

        public string[] Condiments
        {
            get
            {
                return _condiments;
            }
        }

        public string[] Pains
        {
            get
            {
                return _pains;
            }
        }

        public string[] Crudités
        {
            get
            {
                return _crudités;
            }
        }

        public SandwichMaker()
        {
            // Ajout proteines
            _proteines = new string[4];
            _proteines[0] = "jambon";
            _proteines[1] = "fromage";
            _proteines[2] = "roast beef";
            _proteines[3] = "salami";

            // Ajout condiments
            _condiments = new string[3];
            _condiments[0] = "PREMIER condiment";
            _condiments[1] = "DEUXIEME condiment";
            _condiments[2] = "TROISIEME condiment";

            // Ajout pains
            _pains = new string[2];
            _pains[0] = "pain 1";
            _pains[1] = "pain 2";

            // Ajout crudités
            _crudités = new string[2];
            _crudités[0] = "aucun";
            _crudités[1] = "crudités 27";
        }
        public void composeSandwich()
        {
            Random random = new Random();
            string prot = _proteines[random.Next(0, _proteines.Length)];
            string cond = _condiments[random.Next(0, _condiments.Length)];
            string pain = _pains[random.Next(0, _pains.Length)];
            string crud = _crudités[random.Next(0, _crudités.Length)];

            Console.WriteLine("voici votre sandwich : " + pain + ", " + prot + ", " + cond + ", " + crud);
        }
    }


}
