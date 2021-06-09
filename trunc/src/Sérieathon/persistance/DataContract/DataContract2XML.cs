using modelisation.content;
using modelisation.user;
using System;
using System.Collections.Generic;
using System.Text;

namespace persistance.DataContract
{
    /// <summary>
    /// Chargement et enregistrement des données au format XML
    /// </summary>
    public class DataContract2XML : IPersistanceManager
    {
        /// <summary>
        ///  attribut donnant la référence vers le seul datacontract2xml de l'application, pouvant etre null
        /// </summary>
        private static DataContract2XML _singleton;

        private DataContract2XML() { }

        public static DataContract2XML GetInstance()
        {
            if (_singleton is null) _singleton = new DataContract2XML();

            return _singleton;
        }

        public (IEnumerable<ContenuVideoludique>, IEnumerable<Utilisateur>) ChargeDonnees()
        {
            throw new NotImplementedException();
        }

        public void SauvegarderDonnees(IEnumerable<ContenuVideoludique> ListCV, IEnumerable<Utilisateur> listUtilisateur)
        {
            throw new NotImplementedException();
        }
    }
}
