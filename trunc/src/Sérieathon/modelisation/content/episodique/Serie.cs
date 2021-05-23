using modelisation.genres;
using modelisation.langues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace modelisation.content.episodique
{
    public class Serie : ContenuVideoludique, IEquatable<Serie>
    {
        /// <summary>
        /// LinkedList<Saison> liste des saisons de la série
        /// </summary>
        public LinkedList<Saison> ListSaisons
        {
            get => _listSaisons;

            private set
            {
                if(value is null)
                {
                    _listSaisons = new LinkedList<Saison>();
                } else
                {
                    _listSaisons = value;
                }
            }
        }
        private LinkedList<Saison> _listSaisons;

        public Serie(string titre, DateTime date, TimeSpan duree, String realisateur, LinkedList<GenreGlobal> genres, Uri image)
            : base(titre, date, duree, realisateur, genres, image)
        {
            this.ListSaisons = new LinkedList<Saison>();
        }

        public Serie(string titre, DateTime date, TimeSpan duree, String realisateur, LinkedList<GenreGlobal> genres, Uri image,
            LinkedList<Saison> saisons) : base(titre, date, duree, realisateur, genres, image)
        {
            this.ListSaisons = saisons;
        }

        public Serie(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd, LinkedList<GenreGlobal> genres,
            string description, LinkedList<Uri> ouRegarder, LinkedList<Langues> audios, LinkedList<Langues> sousTitres, Uri image)
            : base(titre, date, duree, realisateur, studioProd, genres, description, ouRegarder, audios, sousTitres, image)
        {
            this.ListSaisons = new LinkedList<Saison>();
        }

        public Serie(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd, LinkedList<GenreGlobal> genres,
            string description, LinkedList<Uri> ouRegarder, LinkedList<Langues> audios, LinkedList<Langues> sousTitres,
            Uri image, LinkedList<Saison> saisons)
            : base(titre, date, duree, realisateur, studioProd, genres, description, ouRegarder, audios, sousTitres, image)
        {
            this.ListSaisons = saisons;
        }

        /// <summary>
        /// Recherche une saison de la série, par son numero d'Episode (retourne le 1er trouvé)
        /// </summary>
        /// <param name="numSaison"></param> numéro de la saison recherchée
        /// <returns>Saison dont le numéro correspond à celui demandé, si aucune occurence n'est trouvée, il renvoit null</returns>
        public Saison RechercherSaison(int numSaison)
        {
            foreach(Saison s in ListSaisons)
            {
                if (s.NumSaison == numSaison) return s;
            }
            return null;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            return ReferenceEquals(obj, this) || (obj is Serie se && Equals(se));
        }

        public bool Equals(Serie other)
        {
            // il faut order les deux listes, pour comparer les éléments de la lise avec les premiers de l'autre liste
            LinkedList<Saison> copie_list_saison = new LinkedList<Saison>(other.ListSaisons.OrderBy(s => s.GetHashCode()));

            foreach (Saison s in ListSaisons.OrderBy(s => s.GetHashCode()))
            {
                if (!s.Equals(copie_list_saison.First()))
                {
                    return false;
                }
                else
                {
                    copie_list_saison.Remove(s);
                }
            }

            return base.Equals(other as ContenuVideoludique) && copie_list_saison.Count == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + (ListSaisons.Select(s => s.GetHashCode()).Sum() * 3);
        }
    }
}
