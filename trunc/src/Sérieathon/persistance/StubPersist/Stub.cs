using modelisation;
using modelisation.content;
using modelisation.content.episodique;
using modelisation.genres;
using modelisation.langues;
using modelisation.user;
using System;
using System.Collections.Generic;
using System.Text;
using static modelisation.genres.GenreGlobal;
using static modelisation.langues.Langues;

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

            Uri TransformersStream = new Uri("https://www.netflix.com/search?q=transformers&jbv=70058026");

            Film Transformers = new Film(
                "Transformers",
                new DateTime(2007),
                new TimeSpan(2, 24, 0),
                "Michael Bay",
                "HollyWood",
                new List<GenreGlobal> { Aventure, Policier },
                "C'est un film d'action, avec des robots",
                new List<Uri> { TransformersStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Transformers.jpeg",
                new List<string> { "Shia LaBeouf" }

            );


            Uri AvengersStream = new Uri("https://www.disneyplus.com/fr-fr/movies/marvel-studios-avengers/2h6PcHFDbsPy");

            Film Avengers = new Film(
                "Avengers",
                new DateTime(2012),
                new TimeSpan(2, 24, 0),
                "Joss Whedon",
                "Marvel",
                new List<GenreGlobal> { GenreGlobal.Action, Aventure, ScienceFiction },
                "Lorsque Nick Fury, le directeur du S.H.I.E.L.D., l'organisation qui préserve la paix au plan mondial, cherche à former une équipe de choc pour empêcher la destruction du monde, Iron Man, Hulk, Thor, Captain America, Hawkeye et Black Widow répondent présents.Les Avengers ont beau constituer la plus fantastique des équipes, il leur reste encore à apprendre à travailler ensemble, et non les uns contre les autres, d'autant que le redoutable Loki a réussi à accéder au Cube Cosmique et à son pouvoir illimité... ",
                new List<Uri> { AvengersStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Avengers.jpg",
                new List<string> { "Robert Downey Jr." }

            );

            Uri Falcon_Et_Le_Soldat_De_LhiverStream = new Uri("https://www.disneyplus.com/fr-fr/series/falcon-et-le-soldat-de-lhiver/4gglDBMx8icA");

            Episode Ep1FELSDL = new Episode("Un nouvel ordre", 1, new DateTime(2021), new TimeSpan(0, 50, 0), "Sam Wilson et Bucky Barnes comprennent que leur avenir sera tout sauf normal.");
            Episode Ep2FELSDL = new Episode("L'homme à la Bannière étoilée", 2, new DateTime(2021), new TimeSpan(0, 50, 0), "John Walker devient Captain America. Sam et Bucky s'associent pour lutter contre des rebelles.");
            Episode Ep3FELSDL = new Episode("Trafic d'influence", 3, new DateTime(2021), new TimeSpan(0, 54, 0), "Dans un refuge pour criminels, Sam et Bucky cherchent des informations sur le sérum du super-soldat.");
            Episode Ep4FELSDL = new Episode("Le monde nous regarde", 4, new DateTime(2021), new TimeSpan(0, 54, 0), "John Walker perd patience avec Sam et Bucky, qui en apprennent davantage sur Karli Morgenthau.");
            Episode Ep5FELSDL = new Episode("La vérité", 5, new DateTime(2021), new TimeSpan(1, 1, 0), "John Walker doit assumer les conséquences de ses actes. Sam et Bucky rentrent aux États-Unis.");
            Episode Ep6FELSDL = new Episode("Un seul monde, un seul peuple", 6, new DateTime(2021), new TimeSpan(0, 52, 0), "Face à la montée en violence des Flag Smashers, Sam et Bucky passent à l'action.");

            Saison S1_Falcon_Et_Le_Soldat_De_Lhiver = new Saison(1, new List<Episode> { Ep1FELSDL, Ep2FELSDL, Ep3FELSDL, Ep4FELSDL, Ep5FELSDL, Ep6FELSDL });

            Serie Falcon_Et_Le_Soldat_De_Lhiver = new Serie(
                "Falcon et le Soldat de l'hiver",
                new DateTime(2021),
                new TimeSpan(0, 0, 0),
                "Joss Whedon",
                "Marvel",
                new List<GenreGlobal> { GenreGlobal.Action, ScienceFiction },
                "À l'affiche de la nouvelle production Marvel Studios ''Falcon et le Soldat de l'Hiver'', retrouvez Anthony Mackie dans le rôle de Sam Wilson alias Falcon, et Sebastian Stan dans celui de Bucky Barnes alias le Soldat de l'Hiver.Né à la fin de ''Avengers : Endgame'', le duo se reforme pour une aventure planétaire qui va mettre à l'épreuve leurs aptitudes... et leur patience. Avec Kari Skogland à la réalisation et Malcolm Spellman comme scénariste principal, la série de six épisodes met également en scène Daniel Brühl dans le rôle du Baron Zemo, Emily VanCamp dans celui de Sharon Carter, et Wyatt Russell dans celui de John Walker.",
                new List<Uri> { Falcon_Et_Le_Soldat_De_LhiverStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "FalconAndTheWinterSoldier.jpg",
                new List<Saison> { S1_Falcon_Et_Le_Soldat_De_Lhiver }


            );

            listCV.AddLast(Transformers);
            listCV.AddLast(Avengers);
            listCV.AddLast(Falcon_Et_Le_Soldat_De_Lhiver);

            listUtilisateur.AddLast(new Utilisateur("admin", "admin", "admin", new DateTime(1990, 1, 1), "Indefini"));
            listUtilisateur.AddLast(new Utilisateur("Baptiste F.", "bafoucras", "Baptiste.FOUCRAS@etu.uca.fr",
                new DateTime(2002, 10, 27), "Homme"));
            listUtilisateur.AddLast(new Utilisateur("Julien T.", "jutheme", "Julien.THEME@etu.uca.fr", new DateTime(2002, 07, 21), "Homme"));


            return (listCV, listUtilisateur);
        }

        public void SauvegarderDonnees(IEnumerable<ContenuVideoludique> ListCV, IEnumerable<Utilisateur> listUtilisateur)
        {
            return;
        }
    }
}
