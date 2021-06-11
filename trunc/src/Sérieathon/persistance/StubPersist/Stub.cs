using modelisation;
using modelisation.content;
using modelisation.genres;
using modelisation.user;
using System;
using System.Collections.Generic;
using System.Text;

namespace persistance.StubPersist
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
            LinkedList<ContenuVideoludique> listCV = new LinkedList<ContenuVideoludique>();
            LinkedList<Utilisateur> listUtilisateur = new LinkedList<Utilisateur>();


            // crééer des contenus videoludiques et ajouter a liste

            //listUtilisateur.AddLast(new Utilisateur()); // a suppress
            //listCV.AddLast(new Film("t", new DateTime(0), new TimeSpan(0), "toto", new LinkedList<GenreGlobal>(), "toto.jpg"); // a suppress


            return (listCV, listUtilisateur);
        }

        public void SauvegarderDonnees(IEnumerable<ContenuVideoludique> ListCV, IEnumerable<Utilisateur> listUtilisateur)
        {
            return;
        }
    }
}
