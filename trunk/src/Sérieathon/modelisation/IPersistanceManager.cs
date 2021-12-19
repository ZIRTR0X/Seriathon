using modelisation.content;
using modelisation.user;
using System;
using System.Collections.Generic;
using System.Text;

namespace modelisation
{
    /// <summary>
    /// interface globalisante pour toutes les classes de persistances
    /// </summary>
    public interface IPersistanceManager
    {
        void SauvegarderDonnees(IEnumerable<ContenuVideoludique> ListCV, IEnumerable<Utilisateur> listUtilisateur);
        (IEnumerable<ContenuVideoludique>, IEnumerable<Utilisateur>) ChargeDonnees();
    }
}
