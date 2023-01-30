using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeUAA14Partie2_dec22_Arthur
{
    internal class Joueur
    {
        private int _total = 0;
        private int _location = 0;
        private string _pawn;
        
        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }
        
        public int Location 
        { 
            get { return _location; }
            set { _location = value; }
        }

        public string Pawn 
        {
            get { return _pawn; }
        }

        public Joueur(string Pawn)
        {
            _pawn = Pawn;
        }

        public int PlayersTurn(int CurrentPlayer)
        {
            int NewPlayer;

            if(CurrentPlayer == 3)
            {
                NewPlayer = 0;
            }
            else
            {
                NewPlayer = CurrentPlayer++;
            }

            return NewPlayer;
        }
    }
}
