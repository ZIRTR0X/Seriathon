using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using modelisation.genres;
using modelisation.langues;

namespace modelisation.content
{
    public class Film : ContenuVideoludique, IEquatable<Film>
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

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            return ReferenceEquals(obj, this) || (obj is Film fi && Equals(fi));
        }

        public bool Equals(Film other)
        {
            // il faut order les deux listes, pour comparer les éléments de la lise avec les premiers de l'autre liste
            LinkedList<string> copie_list_acteurs = new LinkedList<string>(other.Acteurs.OrderBy(a => a.GetHashCode()));

            foreach (string a in Acteurs.OrderBy(a => a.GetHashCode()))
            {
                if (!a.Equals(copie_list_acteurs.First()))
                {
                    return false;
                }
                else
                {
                    copie_list_acteurs.RemoveFirst();
                }
            }

            return base.Equals(other as ContenuVideoludique) && copie_list_acteurs.Count == 0;
        }

        public override int GetHashCode()
        {
            return Acteurs.Sum(a => a.GetHashCode()) + (base.GetHashCode() * 3);
        }
    }
}
