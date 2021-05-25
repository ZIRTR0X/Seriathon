using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using modelisation.content;
using modelisation.content.episodique;
using modelisation.genres;
using modelisation.langues;
using static System.Console;
using static modelisation.genres.GenreGlobal;
using static modelisation.langues.Langues;

namespace modelisation
{
    public class Manager
    {
        public ReadOnlyCollection<ContenuVideoludique> ContenuVideoludiques { get; set; }
        List<ContenuVideoludique> contenuVideoludiques = new List<ContenuVideoludique>();

        public bool AjouterFIlm(Film film)
        {
            if (contenuVideoludiques.Contains(film))
            {
                return false;
            }
            contenuVideoludiques.Add(film);
            return true;
        }

        public bool SupprimerFilm(Film film)
        {
            if (!contenuVideoludiques.Contains(film))
            {
                return false;
            }
            contenuVideoludiques.Remove(film);
            return true;
        }

        public bool AjouterAnime(Anime anime)
        {
            if (contenuVideoludiques.Contains(anime))
            {
                return false;
            }
            contenuVideoludiques.Add(anime);
            return true;
        }

        public bool SupprimerAnime(Anime anime)
        {
            if (!contenuVideoludiques.Contains(anime))
            {
                return false;
            }
            contenuVideoludiques.Remove(anime);
            return true;
        }

        public bool AjouterSerie(Serie serie)
        {
            if (contenuVideoludiques.Contains(serie))
            {
                return false;
            }
            contenuVideoludiques.Add(serie);
            return true;
        }

        public bool SupprimerSerie(Serie serie)
        {
            if (!contenuVideoludiques.Contains(serie))
            {
                return false;
            }
            contenuVideoludiques.Remove(serie);
            return true;
        }


        private void Initialisation()
        {

            Uri TransformersStream = new Uri("https://www.netflix.com/search?q=transformers&jbv=70058026");
            Uri AvengersStream = new Uri("https://www.disneyplus.com/fr-fr/movies/marvel-studios-avengers/2h6PcHFDbsPy");

            Film Transformers = new Film(
                "Transformers",
                new DateTime(2007),
                new TimeSpan(2, 24, 0),
                "Michael Bay",
                "HollyWood",
                new List<GenreGlobal> { Aventure, Policier },
                "C'est un film d'action, avec des robots",
                new List<Uri> { TransformersStream },
                new List<Langues>{ Français },
                new List<Langues> { Français },
                "baruto.jpg",
                new List<string> { "Shia LaBeouf" }

            );

            Film Avengers = new Film(
                "Avengers",
                new DateTime(2012),
                new TimeSpan(2, 24, 0),
                "Joss Whedon",
                "Marvel",
                new List<GenreGlobal> { GenreGlobal.Action },
                "C'est un film de super héros.",
                new List<Uri> { AvengersStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Naruto.jpg",
                new List<string> { "Robert Downey Jr." }

            );
            
            
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
                new List<Uri> { AvengersStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Naruto.jpg",
                new List<Saison> { S1_Falcon_Et_Le_Soldat_De_Lhiver }


            );


            AjouterFIlm(Transformers);
            AjouterFIlm(Avengers);
        }



        //public bool AjouterContenueVideoludique(ContenuVideoludique contenuVideoludique)
        //{
        //    if (contenuVideoludiques.Contains(contenuVideoludique))
        //    {
        //        return false;
        //    }
        //    contenuVideoludiques.Add(contenuVideoludique);
        //    return true;
        //}

        //public bool SupprimerContenueVideoludique(ContenuVideoludique contenuVideoludique)
        //{
        //    if (!contenuVideoludiques.Contains(contenuVideoludique))
        //    {
        //        return false;
        //    }
        //    contenuVideoludiques.Remove(contenuVideoludique);
        //    return true;
        //}


        public Manager()
        {
            ContenuVideoludiques = new ReadOnlyCollection<ContenuVideoludique>(contenuVideoludiques);
            Initialisation();
        }

        /*public ReadOnlyCollection<Film> Films { get; set; }
        List<Film> films = new List<Film>();

        public ReadOnlyCollection<ContenuVideoludique> ContenuVideoludiques { get; set; }
        List<ContenuVideoludique> contenuVideoludique = new List<ContenuVideoludique>();


        public Manager()
        {
            Films = new ReadOnlyCollection<Film>(films);
            ContenuVideoludiques = new ReadOnlyCollection<ContenuVideoludique>(contenuVideoludique);
            Initialisation();
        }

        public void Initialisation()
        {
            Film b = new Film(
                "Tra", 
                new TimeSpan(2, 54, 15),
                "HollyWood", 
                201, 
                GenreGlobal.Action,
                "C'est un film de robot", 
                "Netflix", 
                Langues.Japonais, 
                Langues.Français, 
                "Naruto.jpeg", 
                "Moi"
            );
            Film a = new Film(
                "Tra",
                new TimeSpan(1, 54, 15),
                "FranceWood",
                2010,
                GenreGlobal.Action,
                "C'est un film d'action",
                "Netflix",
                Langues.Français,
                Langues.Français,
                "baruto.jpg",
                "Moi"
            );
            AjouterFilm(a);
            AjouterFilm(b);
        }

        public void AjouterFilm(Film f)
        {
            contenuVideoludique.Add(f);
        }

        public bool SupprimerFilm(Film f)
        {
            return contenuVideoludique.Remove(f);
        }
        */
    }
}
