using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using modelisation.content;
using modelisation.genres;
using modelisation.langues;
using static System.Console;

namespace modelisation
{
    public class Manager
    {
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
