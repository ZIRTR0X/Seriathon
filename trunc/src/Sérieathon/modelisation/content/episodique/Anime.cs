using modelisation.genres;
using modelisation.langues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace modelisation.content.episodique
{
    public class Anime : Serie, IEquatable<Anime>
    {
        /// <summary>
        /// LinkedList<GenreAnime> liste les genres de type animé de cet anime
        /// </summary>
        public LinkedList<GenreAnime> GenreAnimes
        {
            get => _genreAnimes;

            private set
            {
                if (value is null)
                {
                    _genreAnimes = new LinkedList<GenreAnime>();
                } else
                {
                    _genreAnimes = value;
                }
            }
        }
        private LinkedList<GenreAnime> _genreAnimes;

        public Anime(string titre, DateTime date, TimeSpan duree, string realisateur, LinkedList<GenreGlobal> genres, Uri image)
            :base(titre, date, duree, realisateur, genres, image)
        {
            this.GenreAnimes = new LinkedList<GenreAnime>();
        }

        public Anime(string titre, DateTime date, TimeSpan duree, string realisateur, LinkedList<GenreGlobal> genres, Uri image,
            LinkedList<Saison> saisons, LinkedList<GenreAnime> genreAnimes)
            :base(titre, date, duree, realisateur, genres, image, saisons)
        {
            this.GenreAnimes = genreAnimes;
        }

        public Anime(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd, LinkedList<GenreGlobal> genres,
            string description, LinkedList<Uri> ouRegarder, LinkedList<Langues> audios, LinkedList<Langues> sousTitres,
            Uri image, LinkedList<Saison> saisons, LinkedList<GenreAnime> genreAnimes)
            : base(titre, date, duree, realisateur, studioProd, genres, description, ouRegarder, audios, sousTitres, image, saisons)
        {
            this.GenreAnimes = genreAnimes;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            return ReferenceEquals(obj, this) || (obj is Anime a && Equals(a));
        }

        public bool Equals(Anime other)
        {
            LinkedList<GenreAnime> genreAnimes_copie = new LinkedList<GenreAnime>(other.GenreAnimes.OrderBy(a => a.GetHashCode()));

            foreach (GenreAnime a in GenreAnimes.OrderBy(a => a.GetHashCode()))
            {
                if (!a.Equals(genreAnimes_copie.First)) return false;
                else genreAnimes_copie.RemoveFirst();
            }

            return genreAnimes_copie.Count == 0 && base.Equals(other as Serie);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + (GenreAnimes.Sum(a => a.GetHashCode()) * 3);
        }
    }
}
