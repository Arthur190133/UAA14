using ACT6_Heritages.Animaux;
using System;

namespace ACT6_Heritages
{
    class Program
    {
        static void Main(string[] args)
        {
            Chien chien = new Chien("Damien", DateTime.Now, 0000, 30, true);
            Chat chat = new Chat("jean", DateTime.Now, 0001, 30, false);
            Lapin lapin = new Lapin("L", DateTime.Now, 0002, 20, false , 2);

        }
    }
}
