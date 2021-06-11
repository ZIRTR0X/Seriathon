using modelisation.user;
using modelisation.content;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using static modelisation.genres.GenreAnime;
using static modelisation.genres.GenreGlobal;
using System.IO;

namespace modelisation
{
    /// <summary>
    /// manager de l'application, répertoriant toutes les données de l'application, et responsable du lien avec la persistance
    /// </summary>
    public class Manager
    {
        public int Nb_jour { get; set; }
        public int Nb_heure { get; set; }

        [OnDeserialized]
        void InitReadOnly()
        {
            ListUtilisateurR = new ReadOnlyCollection<Utilisateur>(ListUtilisateur);
            ListCVR = new ReadOnlyCollection<ContenuVideoludique>(ListCV);
        }

        /// <summary>
        /// attribut donnant la référence vers le seul manager de l'application, pouvant etre null
        /// </summary>
        private static Manager _singleton;

        /// <summary>
        /// wrapper de ListUtilisateur
        /// </summary>
        public ReadOnlyCollection<Utilisateur> ListUtilisateurR { get; private set; }
        /// <summary>
        /// liste répertoriant tout les utilisateurs locaux
        /// </summary>
        private List<Utilisateur> ListUtilisateur { get; set; } = new List<Utilisateur>();

        /// <summary>
        /// répertorie l'utilisateur courant
        /// </summary>
        public Utilisateur UtilisateurCourant { get; private set; }

        /// <summary>
        /// wrapper de ListCV
        /// </summary>
        public ReadOnlyCollection<ContenuVideoludique> ListCVR { get; private set; }
        /// <summary>
        /// liste répertoriant tout les Contenus de l'application
        /// </summary>
        private List<ContenuVideoludique> ListCV { get; set; } = new List<ContenuVideoludique>();

        private IPersistanceManager Persistance { get; set; }

        /// <summary>
        /// déprécié car rends impossible la persistance
        /// </summary>
        private Manager()
        {
            ListUtilisateurR = new ReadOnlyCollection<Utilisateur>(ListUtilisateur);
            UtilisateurCourant = null;
            ListCVR = new ReadOnlyCollection<ContenuVideoludique>(ListCV);


            AdminAdd();
        }

        private Manager(IPersistanceManager pm)
        {
            ListUtilisateurR = new ReadOnlyCollection<Utilisateur>(ListUtilisateur);
            UtilisateurCourant = null;
            ListCVR = new ReadOnlyCollection<ContenuVideoludique>(ListCV);
            Persistance = pm;

            AdminAdd();
        }

        private Manager(List<Utilisateur> listUser, List<ContenuVideoludique> listCV)
        {
            ListUtilisateur = listUser;
            ListUtilisateurR = new ReadOnlyCollection<Utilisateur>(ListUtilisateur);
            UtilisateurCourant = null;
            ListCV = listCV;
        }

        /// <summary>
        /// méthode pour créer un manager et retourner sa référence, ou bien si une instance existe déjà,
        /// il retourne la référence de cette instance
        /// </summary>
        /// <returns></returns>
        public static Manager GetInstance()
        {
            if (_singleton is null) _singleton = new Manager();

            return _singleton;
        }

        /// <summary>
        /// méthode pour créer un manager avec arguments et retourner sa référence, ou bien si une instance existe déjà,
        /// il retourne la référence de cette instance
        /// </summary>
        /// <param name="listUser">liste des utilisateurs a ajouter au manager</param>
        /// <param name="listCV">les des contenus vidéoludiques à ajouter au manager</param>
        /// <returns></returns>
        public static Manager GetInstanceArguments(List<Utilisateur> listUser, List<ContenuVideoludique> listCV)
        {
            if (_singleton is null) _singleton = new Manager(listUser, listCV);

            return _singleton;
        }

        /// <summary>
        /// tente de créer et d'ajouter un utilisateur à la liste des utilisateurs existants
        /// </summary>
        /// <param name="pseudo">pseudonyme de l'utilisateur à créer et ajouter</param>
        /// <param name="password">password de l'utilisateur à créer et ajouter</param>
        /// <param name="email">email de l'utilisateur à créer et ajouter</param>
        /// <param name="dateNaissance">date de naissance de l'utilsateur à ajouter</param>
        /// <param name="genre">genre auquel s'identifie l'utilisateur à ajouter</param>
        /// <returns>false si le nouvel utilisateur est déjà contenu dans la liste du manager, true s'il est ajouté</returns>
        public bool CreerUtilisateur(string pseudo, string password, string email, DateTime dateNaissance, string genre)
        {
            Utilisateur nouveau = new Utilisateur(pseudo, password, email, dateNaissance, genre);
            if (ListUtilisateur.Contains(nouveau)) return false;

            ListUtilisateur.Add(nouveau);
            return true;
        }

        /// <summary>
        /// tente d'ajouter un utilisateur à la liste des utilisateurs existants
        /// </summary>
        /// <param name="u">utilisateur à ajouter</param>
        /// <returns>false si l'utilisateur est déjà contenu dans la liste du manager, true s'il est ajouté</returns>
        public bool AjouterUtilisateur(Utilisateur u)
        {
            if (ListUtilisateur.Contains(u)) return false;

            ListUtilisateur.Add(u);
            return true;
        }

        public void SupprimerUtilisateur()
        {
            ListUtilisateur.Remove(UtilisateurCourant);
        }


        /// <summary>
        /// tente la connexion a chaque compte existant
        /// </summary>
        /// <param name="email">email auquel doit correspondre le pseudo de l'un des utilisateurs</param>
        /// <param name="password">password auquel doit correspondre le pseudo de l'un des utilisateurs</param>
        /// <returns>true si jamais le couple email-password passé en paramètre correspond à celui de l'utilisateur, false sinon</returns>
        public bool SeConnecter(string email, string password)
        {
            foreach(Utilisateur u in ListUtilisateur)
            {
                if (u.IdentifiableA(email, password))
                {
                    UtilisateurCourant = u;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// tente la deconnexion du compte courant, stocké dans UtilisateurCourant
        /// </summary>
        /// <returns>false si UtilisateurCourant est null, donc que l'on est pas connecté, true sinon, UtilisateurCourant est mis à null</returns>
        public bool SeDeconnecter()
        {
            if (UtilisateurCourant is null) return false;

            UtilisateurCourant = null;
            return true;
        }

        public void AdminAdd()
        {
            Utilisateur Admin = new Utilisateur("a","admin","admin", new DateTime(1990, 10, 10),"Homme");
            ListUtilisateur.Add(Admin);
        }

        /// <summary>
        /// Permet de creer un nouveau marathon contenant le nombre de jour ainsi que le nombre d'heure par jour et des genres null
        /// </summary>
        /// <param name="nbJour"></param>
        /// <param name="nbHeureParJour"></param>
        public void CreerMarathon1(int nbJour, int nbHeureParJour)
        {
            UtilisateurCourant.CreerMarathon(nbJour, nbHeureParJour);

            Nb_jour = nbJour;
            Nb_heure = nbHeureParJour;
            //NouveauMarathon = new Marathon(nbJour, nbHeureParJour);
            //ListMarathon.Add(NouveauMarathon);
        }


        public void ChargerDonnees()
        {
            if (ReferenceEquals(Persistance, null))
            {
                throw new InvalidOperationException("Le moyen de persistance est null, on ne peux appeler la fonction de sauvegarde");
            }

            try {
                (var listCV_temp, var listUtilisateur_temp) = Persistance.ChargeDonnees();
                ListCV.AddRange(listCV_temp);
                ListUtilisateur.AddRange(listUtilisateur_temp);
            }
            catch(FileNotFoundException e)
            {
                System.Console.WriteLine(e);
            }
        }

        public void SauvegarderDonnees()
        {
            if (ReferenceEquals(Persistance, null))
            {
                throw new InvalidOperationException("Le moyen de persistance est null, on ne peux appeler la fonction de sauvegarde");
            }

            Persistance.SauvegarderDonnees(ListCVR, ListUtilisateurR);

        }

    }

}
