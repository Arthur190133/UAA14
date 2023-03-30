


using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace BaseDeDonne
{
    class Program
    { 
        static void Main()
        {

            Menu();
            



            Console.ReadLine();
        }

        static string DefinirCheminBD() // détermine la chaîne de connexion
        {
            return "server=localhost;database=immobilier;port=3306;User Id=root;password=";
        }

        static void Menu()
        {
            DataSet immoUsers;



            bool Found = true;
            do
            {
                Console.WriteLine("ShowAllUsers     -Afficher tous les utilisateurs\n" +
                  "UpdateUserName   -Modifier le nom d'un utilisateur\n" +
                  "InsertProperty   -Ajouter un bien immobilier\n" +
                  "DeleteImage      -Supprimer une image\n");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "ShowAllUsers":
                        if (ChercherUneTable(out immoUsers, "utilisateurs"))
                        {
                            string listeUser = AfficheDataUsers(immoUsers);
                            Console.WriteLine(listeUser);
                        }
                        else
                        {
                            Console.WriteLine("Impossible d'afficher tous les utilisateurs");
                        }
                        break;
                    case "UpdateUserName":
                        Console.WriteLine("Entré l'Id d'un utilisateur");
                        string Id = Console.ReadLine();

                        Console.WriteLine("Entré le nouveau nom de l'utilisateur");
                        string Name = Console.ReadLine();

                        if (ModifierPrenomUtilisateurs(out immoUsers, Id, Name))
                        {
                            if (ChercherUnUtilisateur(out immoUsers, Id))
                            {
                                string listeUser = AfficheDataUsers(immoUsers);
                                Console.WriteLine(listeUser);
                            }
                            else
                            {
                                Console.WriteLine("Impossible d'afficher tous les utilisateurs");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Une erreur est survenue lors de votre requête");
                        }
                        break;
                    case "InsertProperty":

                        Console.WriteLine("Entré le nom du bien");
                        string nom = Console.ReadLine();

                        Console.WriteLine("Entré la taille du bien");
                        string taille = Console.ReadLine();

                        Console.WriteLine("Entré le prix du bien");
                        string prix = Console.ReadLine();

                        Console.WriteLine("Entré la ville du bien");
                        string ville = Console.ReadLine();

                        Console.WriteLine("Entré le userId du bien");
                        string userId = Console.ReadLine();

                        Console.WriteLine("Entré la description du bien");
                        string description = Console.ReadLine();

                        Console.WriteLine("Entré le nombre de chambres du bien");
                        string chambres = Console.ReadLine();

                        Console.WriteLine("Entré l'image du bien");
                        string imageBien = Console.ReadLine();

                        if (InsererBien(out immoUsers, nom, taille, prix, ville, userId, description, chambres, imageBien))
                        {
                            if (ChercherUneTable(out immoUsers, "biens"))
                            {
                                string listeUser = AfficherDataBiens(immoUsers);
                                Console.WriteLine(listeUser);
                            }
                            else
                            {
                                Console.WriteLine("Impossible d'afficher tous les biens");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Une erreur est survenue lors de votre requête");
                        }
                        break;
                    case "DeleteImage":

                        Console.WriteLine("Entré l'Id de l'image");
                        string IdImage = Console.ReadLine();

                        if (SupprimerImage(out immoUsers, IdImage))
                        {
                            if (ChercherUneTable(out immoUsers, "images"))
                            {
                                string listeUser = AfficherDataImages(immoUsers);
                                Console.WriteLine(listeUser);
                            }
                            else
                            {
                                Console.WriteLine("Impossible d'afficher toutes les images");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Une erreur est survenue lors de votre requête");
                        }
                        break;
                }


            } while (Found);
        }

        static bool ChercherUneTable(out DataSet infos, string table)
        {
            bool ok = false;
            MySqlConnection maConnection = new MySqlConnection(DefinirCheminBD());
            string query = "";
            try
            {
                maConnection.Open();

                query = "SELECT * FROM " + table + ";";

                MySqlDataAdapter da = new MySqlDataAdapter(query, maConnection);
                infos = new DataSet();
                da.Fill(infos, "infoUtilisateurs");

                if (infos.Tables[0].Rows.Count >= 1)
                {
                    ok = true;
                }
                maConnection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            return ok;
        }

        static bool ChercherUnUtilisateur(out DataSet infos, string id)
        {
            bool ok = false;
            MySqlConnection maConnection = new MySqlConnection(DefinirCheminBD());
            string query = "";
            try
            {
                maConnection.Open();

                query = "SELECT * FROM utilisateurs WHERE id = " + id + ";";

                MySqlDataAdapter da = new MySqlDataAdapter(query, maConnection);
                infos = new DataSet();
                da.Fill(infos, "infoUtilisateurs");

                if (infos.Tables[0].Rows.Count >= 1)
                {
                    ok = true;
                }
                maConnection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            return ok;
        }

        static bool ModifierPrenomUtilisateurs(out  DataSet infos, string id, string newName)
        {
            if (VerifInt(id))
            {
                bool ok = false;
                MySqlConnection maConnection = new MySqlConnection(DefinirCheminBD());
                string query = "";
                try
                {
                    maConnection.Open();

                    query = "UPDATE utilisateurs" +
                    " SET nomUser = '" + newName + "'" +
                    " WHERE id=" + id +
                    ";";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, maConnection);
                    infos = new DataSet();
                    da.Fill(infos, "infoUtilisateurs");

                    ok = true;

                    maConnection.Close();

                    ChercherUnUtilisateur(out infos, id);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;
                }

                return ok;
            }

            infos = null;
            return false;

        }

        static bool InsererBien(out DataSet infos, string nom, string taille, string prix, string ville, string userId, string description, string chambres, string imageBien)
        {
            if(VerifInt(taille) && VerifInt(prix) && VerifInt(userId) && VerifInt(chambres) && VerifInt(imageBien))
            {
                bool ok = false;
                MySqlConnection maConnection = new MySqlConnection(DefinirCheminBD());
                string query = "";
                try
                {
                    maConnection.Open();

                    query = "INSERT INTO biens (nom, taille, prix, ville, userId, description, chambres, imageBien) VALUES ('" + nom + "', " + taille + ", " + prix + ", '" + ville + "', " + userId + ", '" + description + "', " + chambres + ", '" + imageBien + "')";


                    MySqlDataAdapter da = new MySqlDataAdapter(query, maConnection);
                    infos = new DataSet();
                    da.Fill(infos, "infoBiens");

                    ok = true;
                    maConnection.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;
                }

                return ok;
            }
            infos = null;
            return false;
        }

        static bool SupprimerImage(out DataSet infos, string id)
        {
            if (VerifInt(id))
            {
                bool ok = false;
                MySqlConnection maConnection = new MySqlConnection(DefinirCheminBD());
                string query = "";
                try
                {
                    maConnection.Open();

                    query = "DELETE FROM images WHERE id= " +id+";";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, maConnection);
                    infos = new DataSet();
                    da.Fill(infos, "infoImage");

                    ok = true;

                    maConnection.Close();

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;
                }

                return ok;
            }

            infos = null;
            return false;
        }

        static bool VerifInt(string i)
        {
            return int.TryParse(i, out _);
        }

        static string AfficheDataUsers(DataSet donnees)
        {
            string infos = "";
            for (int i = 0; i < donnees.Tables[0].Rows.Count; i++)
            {
                infos += donnees.Tables[0].Rows[i]["nomUser"].ToString() + " | " +
                         donnees.Tables[0].Rows[i]["prenomUser"].ToString() + " | " +
                         donnees.Tables[0].Rows[i]["loginUser"].ToString() + " | " +
                         donnees.Tables[0].Rows[i]["passWordUser"].ToString() + " | " + "\n";
            }
            return infos;
        }

        static string AfficherDataBiens(DataSet donnees)
        {
            string infos = "";
            for (int i = 0; i < donnees.Tables[0].Rows.Count; i++)
            {
                infos += donnees.Tables[0].Rows[i]["nom"].ToString() + " | " +
                         donnees.Tables[0].Rows[i]["taille"].ToString() + " | " +
                         donnees.Tables[0].Rows[i]["prix"].ToString() + " | " +
                         donnees.Tables[0].Rows[i]["ville"].ToString() + " | " +
                         donnees.Tables[0].Rows[i]["userId"].ToString() + " | " +
                         donnees.Tables[0].Rows[i]["description"].ToString() + " | " +
                         donnees.Tables[0].Rows[i]["chambres"].ToString() + " | " +
                         donnees.Tables[0].Rows[i]["imageBien"].ToString() + " | " + "\n";
            }
            return infos;
        }

        static string AfficherDataImages(DataSet donnees)
        {
            string infos = "";
            for (int i = 0; i < donnees.Tables[0].Rows.Count; i++)
            {
                infos += donnees.Tables[0].Rows[i]["name"].ToString() + " | " +
                         donnees.Tables[0].Rows[i]["image"].ToString() + " | " +
                         donnees.Tables[0].Rows[i]["FK_bienId"].ToString() + " | " + "\n";
            }
            return infos;
        }
    }

}
