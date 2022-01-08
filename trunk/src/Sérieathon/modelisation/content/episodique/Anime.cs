using modelisation.genres;
using modelisation.langues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace modelisation.content.episodique
{
    /// <summary>
    /// Anime est une extension de Serie, intégrant une liste de GenreAnime en plus
    /// </summary>
    [DataContract]
    public class Anime : Serie, IEquatable<Anime>
    {
        /// <summary>
        /// Permet d'instancier les wrapper
        /// </summary>
        /// <param name="sc"></param> décrit la source de la deserialization
        [OnDeserialized]
        void InitReadOnly(StreamingContext sc = new StreamingContext())
        {
            GenreAnimesR = new ReadOnlyCollection<GenreAnime>(GenreAnimes);
        }

        /// <summary>
        /// wrapper de GenreAnimes
        /// </summary>
        public ReadOnlyCollection<GenreAnime> GenreAnimesR { get; private set; }

        /// <summary>
        /// liste les genres de type animé de cet anime
        /// </summary>
        [DataMember]
        private List<GenreAnime> GenreAnimes
        {
            get => _genreAnimes;

            set
            {
                if (value is null)
                {
                    _genreAnimes = new List<GenreAnime>();
                } else
                {
                    _genreAnimes = value;
                }
            }
        }
        private List<GenreAnime> _genreAnimes = new List<GenreAnime>();

        public Anime(string titre, DateTime date, TimeSpan duree, string realisateur, IEnumerable<GenreGlobal> genres, string image)
            :base(titre, date, duree, realisateur, genres, image)
        {
            GenreAnimes = new List<GenreAnime>();
            GenreAnimesR = new ReadOnlyCollection<GenreAnime>(GenreAnimes);
        }

        public Anime(string titre, DateTime date, TimeSpan duree, string realisateur, IEnumerable<GenreGlobal> genres, string image,
            IEnumerable<Saison> saisons, IEnumerable<GenreAnime> genreAnimes)
            :base(titre, date, duree, realisateur, genres, image, saisons)
        {
            GenreAnimes = new List<GenreAnime>(genreAnimes);
            GenreAnimesR = new ReadOnlyCollection<GenreAnime>(GenreAnimes);
        }

        public Anime(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd, IEnumerable<GenreGlobal> genres,
            string description, IEnumerable<Uri> ouRegarder, IEnumerable<Langues> audios, IEnumerable<Langues> sousTitres,
            string image, IEnumerable<Saison> saisons, IEnumerable<GenreAnime> genreAnimes)
            : base(titre, date, duree, realisateur, studioProd, genres, description, ouRegarder, audios, sousTitres, image, saisons)
        {
            GenreAnimes = new List<GenreAnime>(genreAnimes);
            GenreAnimesR = new ReadOnlyCollection<GenreAnime>(GenreAnimes);
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
