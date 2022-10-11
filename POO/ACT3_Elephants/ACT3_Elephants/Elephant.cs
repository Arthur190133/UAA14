using System;
using System.Collections.Generic;
using System.Text;

namespace ACT3_Elephants
{
    class Elephant
    {
        private string _nom;
        private uint _tailleOreilles;

        public Elephant(string nom, uint tailleOreilles)
        {
            _nom = nom;
            _tailleOreilles = tailleOreilles;
        }

        public string AfficherQuiJeSuis()
        {
            return _nom + " et j'ai des oreilles de " +  _tailleOreilles.ToString() + " cm";
        }

        public uint GetEar()
        {
            return _tailleOreilles;
        }

        public void EcouteMessage(string message, Elephant quiDit)
        {
            Console.WriteLine(_nom + " a entendu un message \n" + quiDit._nom + " a dit : " + message);
        }


        public void EnvoieMessage(string message, Elephant quiRecoit)
        {
            quiRecoit.EcouteMessage(message, this);
        }

    }
}
