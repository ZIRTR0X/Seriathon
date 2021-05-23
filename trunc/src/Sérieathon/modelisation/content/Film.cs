using System;
using System.Collections.Generic;
using System.Text;
using modelisation.genres;
using modelisation.langues;

namespace modelisation.content
{
    public class Film : ContenuVideoludique
    {
        /// <summary>
        /// liste des acteurs ayant participé au film, ne pouvant etre null
        /// </summary>
        public LinkedList<string> Acteurs
        {
            get => _acteurs;

            private set
            {
                if(value is null)
                {
                    _acteurs = new LinkedList<string>();
                } else
                {
                    _acteurs = value;
                }
            }
        }
        private LinkedList<string> _acteurs;

        public Film(string titre, DateTime date, TimeSpan duree, String realisateur, LinkedList<GenreGlobal> genres, Uri image)
            : base(titre, date, duree, realisateur, genres, image)
        {
            this.Acteurs = new LinkedList<string>();
        }

        public Film(string titre, DateTime date, TimeSpan duree, String realisateur, LinkedList<GenreGlobal> genres, Uri image,
            LinkedList<string> acteurs) : base(titre, date, duree, realisateur, genres, image)
        {
            this.Acteurs = acteurs;
        }

        public Film(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd, LinkedList<GenreGlobal> genres,
            string description, LinkedList<Uri> ouRegarder, LinkedList<Langues> audios, LinkedList<Langues> sousTitres, Uri image)
            : base(titre, date, duree, realisateur, studioProd, genres, description, ouRegarder, audios, sousTitres, image)
        {
            this.Acteurs = new LinkedList<string>();
        }

        public Film(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd, LinkedList<GenreGlobal> genres,
            string description, LinkedList<Uri> ouRegarder, LinkedList<Langues> audios, LinkedList<Langues> sousTitres,
            Uri image, LinkedList<string> acteurs)
            : base(titre, date, duree, realisateur, studioProd, genres, description, ouRegarder, audios, sousTitres, image)
        {
            this.Acteurs = acteurs;
        }
    }
}
