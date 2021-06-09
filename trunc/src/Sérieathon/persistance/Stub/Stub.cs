using modelisation.content;
using modelisation.user;
using System;
using System.Collections.Generic;
using System.Text;

namespace persistance.Stub
{
    /// <summary>
    /// Chargement en dur des données
    /// </summary>
    public class Stub : IPersistanceManager
    {
        /// <summary>
        /// attribut donnant la référence vers le seul stub de l'application, pouvant etre null
        /// </summary>
        private static Stub _singleton;

        private Stub() { }

        public static Stub GetInstance()
        {
            if (_singleton is null) _singleton = new Stub();

            return _singleton;
        }

        public (IEnumerable<ContenuVideoludique>, IEnumerable<Utilisateur>) ChargeDonnees()
        {
            throw new NotImplementedException();
        }

        public void SauvegarderDonnees(IEnumerable<ContenuVideoludique> ListCV, IEnumerable<Utilisateur> listUtilisateur)
        {
            return;
        }
    }
}
