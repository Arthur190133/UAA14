using System;
using System.Collections.Generic;
using System.Text;

namespace I1P622_Arthur
{
    class Feu
    {
        private string feuId;
        private int feuCouleur;
        private bool feuEtat;

        public Feu(string id, int couleur, bool etat)
        {
            feuId = id;
            feuCouleur = couleur;
            feuEtat = etat;
        }
        public void changerCouleur(int newCouleur)
        {
            feuCouleur = newCouleur;
        }

        public string switchFeuEtat()
        {
            feuEtat = !feuEtat;
            if(feuEtat) { return "allumé"; };
            return "éteint";
        }

        public string getFeuId()
        {
            return feuId;
        }

        public string getFeuCouleur()
        {
            string couleur = null;
            switch (feuCouleur)
            {
                case 0:
                    couleur = "rouge";
                    break;

                case 1:
                    couleur = "orange";
                    break;

                case 2:
                    couleur = "vert";
                    break;
            }
            return couleur;
        }
    }


}
