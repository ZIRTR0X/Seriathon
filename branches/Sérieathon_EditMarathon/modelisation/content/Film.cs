using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using modelisation.genres;
using modelisation.langues;

namespace modelisation.content
{
    /// <summary>
    /// Film est un ContenuVideoludique, avec en plus une liste d'acteurs
    /// </summary>
    [DataContract]
    public class Film : ContenuVideoludique, IEquatable<Film>
    {
        [OnDeserialized]
        void InitReadOnly(StreamingContext sc = new StreamingContext())
        {
            ActeursR = new ReadOnlyCollection<string>(Acteurs);
        }

        /// <summary>
        /// Wrapper de Acteurs
        /// </summary>
        public ReadOnlyCollection<string> ActeursR { get; private set; }
        
        /// <summary>
        /// liste des acteurs ayant participé au film, ne pouvant etre null
        /// </summary>
        [DataMember]
        private List<string> Acteurs
        {
            get => _acteurs;

            set
            {
                if(value is null)
                {
                    _acteurs = new List<string>();
                } else
                {
                    _acteurs = value;
                }
            }
        }
        private List<string> _acteurs = new List<string>();

        public Film(string titre, DateTime date, TimeSpan duree, String realisateur, IEnumerable<GenreGlobal> genres, string image)
            : base(titre, date, duree, realisateur, genres, image)
        {
            Acteurs = new List<string>();
            ActeursR = new ReadOnlyCollection<string>(Acteurs);
        }

        public Film(string titre, DateTime date, TimeSpan duree, String realisateur, IEnumerable<GenreGlobal> genres, string image,
            IEnumerable<string> acteurs) : base(titre, date, duree, realisateur, genres, image)
        {
            Acteurs = new List<string>(acteurs);
            ActeursR = new ReadOnlyCollection<string>(Acteurs);
        }

        public Film(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd, IEnumerable<GenreGlobal> genres,
            string description, IEnumerable<Uri> ouRegarder, IEnumerable<Langues> audios, IEnumerable<Langues> sousTitres, string image)
            : base(titre, date, duree, realisateur, studioProd, genres, description, ouRegarder, audios, sousTitres, image)
        {
            Acteurs = new List<string>();
            ActeursR = new ReadOnlyCollection<string>(Acteurs);
        }

        public Film(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd, IEnumerable<GenreGlobal> genres,
            string description, IEnumerable<Uri> ouRegarder, IEnumerable<Langues> audios, IEnumerable<Langues> sousTitres,
            string image, IEnumerable<string> acteurs)
            : base(titre, date, duree, realisateur, studioProd, genres, description, ouRegarder, audios, sousTitres, image)
        {
            Acteurs = new List<string>(acteurs);
            ActeursR = new ReadOnlyCollection<string>(Acteurs);
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
