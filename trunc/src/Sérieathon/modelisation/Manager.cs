using modelisation.user;
using modelisation.content;
using System;
using System.Collections.Generic;
using System.Text;

namespace modelisation
{
    class Manager
    {
        public LinkedList<Utilisateur> ListUtilisateur { get; private set; }

        public Utilisateur UtilisateurCourant { get; private set; }

        public LinkedList<ContenuVideoludique> ListCV { get; private set; }

    }
}
