using System;
using System.Collections.Generic;
using System.Text;

namespace modelisation
{
    class Utilisateur
    {
        string pseudo;
        string password;
        string email;
        int age;
        string genre;
        LinkedList<ContenuVideoludique> ListCV = new LinkedList<ContenuVideoludique>;

        public Utilisateur(string pseudo, string password, string email, int age, string genre) 
        {
            this.pseudo = pseudo;
            this.password = password;
            this.email = email;
            this.age = age;
            this.genre = genre;
        }

        public void ajouterCommeVu(ContenuVideoludique c)
        {
            ListCV.AddLast(c);
        }

        public void enleverCommeVu(ContenuVideoludique c)
        {
            ListCV.Remove(c);
        }

        public int getNbAnimeVu()
        {
            int nbAnime = 0;
            foreach (ContenuVideoludique a in ListCV) {
                if (a.GetType() == "Anime")
                {
                    nbAnime++;
                }
            }
            return nbAnime;
        }

        public int getNbSerieVu()
        {
            int nbSerie = 0;
            foreach (ContenuVideoludique a in ListCV)
            {
                if (a.GetType() == "Serie")
                {
                    nbSerie++;
                }
            }
            return nbSerie;
        }

        public int getNbFilmVu()
        {
            int nbFilm = 0;
            foreach (ContenuVideoludique a in ListCV)
            {
                if (a.GetType() == "Film")
                {
                    nbFilm++;
                }
            }
            return nbFilm;
        }

        public int getNbContenuVu()
        {
            return ListCV.Count;
        }

        public int getNbGenreGlobalVu(GenreGlobal g)
        {
            int nbGenreGlobal = 0;

            foreach (ContenuVideoludique a in ListCV)
            {
                if (a.Genre == g)
                {
                    nbGenreGlobal++;
                }
            }

            return nbGenreGlobal;
        }

        public int getNbGenreAnimeVu(GenreAnime a)
        {
            int nbGenreAnime = 0;

            foreach (ContenuVideoludique b in ListCV)
            {
                if (b.Genre == a)
                {
                    nbGenreAnime++;
                }
            }

            return nbGenreAnime;
        }
    }
}
