using System;
using ACT6_HeritagesEX3.Personnes;

namespace ACT6_HeritagesEX3
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne[] personnes = new Personne[10];

            for(int i = 0; i < 5; i++)
            {
                personnes[i] = new Employe(i + " mat", "nom :" + i, "prenom : " + i, DateTime.Now, i + 23);
            }

            for (int i = 5; i < 8; i++)
            {
                personnes[i] = new Cadre(i + " mat", "nom :" + i, "prenom : " + i, DateTime.Now, i - 2);
            }

            for (int i = 8; i < 10; i++)
            {
                personnes[i] = new Directeur(i + " mat", "nom :" + i, "prenom : " + i, DateTime.Now, 3000000, (i-6)*10);
            }

            foreach(Personne person in personnes)
            {
                if(person != null)
                {
                    person.CalculSalaire();
                    Console.WriteLine(person);
                }

            }   

            Console.ReadLine();

        }
    }
}
