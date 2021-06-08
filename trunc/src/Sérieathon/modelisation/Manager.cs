using modelisation.user;
using modelisation.content;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace modelisation
{
    public class Manager
    {
        public ReadOnlyCollection<Utilisateur> Utilisateur { get; set; }
        public List<Utilisateur> ListUtilisateur { get; private set; }

        public Utilisateur UtilisateurCourant { get; private set; }

        public LinkedList<ContenuVideoludique> ListCV { get; private set; }

        private void ajouterUtilisateur(Utilisateur utilisateur)
        {
            ListUtilisateur.Add(utilisateur);
        }

    }
}
