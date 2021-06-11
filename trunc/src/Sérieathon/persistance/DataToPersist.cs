using modelisation.content;
using modelisation.user;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;

namespace persistance
{
    class DataToPersist
    {
        [OnDeserialized]
        void InitReadOnly()
        {
            ListUtilisateurR = new ReadOnlyCollection<Utilisateur>(ListUtilisateur);
            ListCVR = new ReadOnlyCollection<ContenuVideoludique>(ListCV);
        }

        /// <summary>
        /// wrapper de ListUtilisateur
        /// </summary>
        public ReadOnlyCollection<Utilisateur> ListUtilisateurR { get; private set; }
        /// <summary>
        /// liste répertoriant tout les utilisateurs locaux
        /// </summary>
        [DataMember]
        private List<Utilisateur> ListUtilisateur { get; set; } = new List<Utilisateur>();

        /// <summary>
        /// wrapper de ListCV
        /// </summary>
        public ReadOnlyCollection<ContenuVideoludique> ListCVR { get; private set; }
        /// <summary>
        /// liste répertoriant tout les Contenus de l'application
        /// </summary>
        [DataMember]
        private List<ContenuVideoludique> ListCV { get; set; } = new List<ContenuVideoludique>();

        public DataToPersist()
        {
            ListUtilisateur = new List<Utilisateur>();
            ListUtilisateurR = new ReadOnlyCollection<Utilisateur>(ListUtilisateur);

            ListCV = new List<ContenuVideoludique>();
            ListCVR = new ReadOnlyCollection<ContenuVideoludique>(ListCV);
        }

        public DataToPersist(IEnumerable<Utilisateur> listUser, IEnumerable<ContenuVideoludique> listCV)
        {
            ListUtilisateur = new List<Utilisateur>(listUser);
            ListUtilisateurR = new ReadOnlyCollection<Utilisateur>(ListUtilisateur);

            ListCV = new List<ContenuVideoludique>(listCV);
            ListCVR = new ReadOnlyCollection<ContenuVideoludique>(ListCV);
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

        /// <summary>
        /// tente d'ajouter un ContenuVideoludique à la liste des utilisateurs existants
        /// </summary>
        /// <param name="cv">contenu à ajouter</param>
        /// <returns>false si le contenu est déjà contenu dans la liste du manager, true s'il est ajouté</returns>
        public bool AjouterContenuVideoludique(ContenuVideoludique cv)
        {
            if (ListCV.Contains(cv)) return false;

            ListCV.Add(cv);
            return true;
        }

    }
}
