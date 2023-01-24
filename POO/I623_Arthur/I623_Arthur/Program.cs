using System;

namespace I623_Arthur
{
    class Program
    {
        static void Main(string[] args)
        {
            PaintBallGun gun = new PaintBallGun(30, 0);
            string choice = "";
            Console.WriteLine("Bienvenue dans ce jeu de tir ... Vous démarrez avec 30 balles");
            Console.WriteLine("=============================================================");
            do
            {
                if(choice == "r")
                {
                    int oldBullets = gun.BulletMag;
                    if (gun.Reload())
                    {
                        Console.WriteLine("=> Recharge de " + (gun.BulletMag - oldBullets) + " balles dans le chargeur effectuée");
                    }
                    else
                    {
                        Console.WriteLine("Impossible de recharger !");
                    }
                   
                }
                else if(choice == "+")
                {
                    gun.TakeBullets();
                    Console.WriteLine("Recharge de 30 balles effectuée dans votre poche");
                }
                else if(choice == " ")
                {
                    if (gun.Fire())
                    {
                        Console.WriteLine("=> Tir effectué !");
                    }
                    else
                    {
                        Console.WriteLine("=> Impossible de tirer !");
                    }
                    
                }

                Console.WriteLine("Vous avez un total de " + gun.BulletPocket + " dans votre poche et " + gun.BulletMag + " balles dans le chargeur");
                if (gun.IsEmpty())
                {
                    Console.WriteLine("Attention votre chargeur est vide");
                }
                Console.WriteLine("Espace pour tirer \nr pour recharger, \n+ pour reprendre des munitions, \nq pour quitter");
                choice = Console.ReadLine();
            } while (choice != "q");
        }
    }
}
