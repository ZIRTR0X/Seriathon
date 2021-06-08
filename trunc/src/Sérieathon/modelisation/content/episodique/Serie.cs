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
        /// List<Saison> liste des saisons de la série
        /// </summary>
        public List<Saison> ListSaisons
        {
            get => _listSaisons;

            private set
            {
                if(value is null)
                {
                    _listSaisons = new List<Saison>();
                } else
                {
                    _listSaisons = value;
                }
            }
        }
        private List<Saison> _listSaisons;

        /// <summary>
        /// int permet de connaitre le nombre de saisons dans la série
        /// </summary>
        public int NbSaisons => ListSaisons.Count;

        /// <summary>
        /// int permet de connaitre le nombre d'épisode dans la série
        /// </summary>
        public int NbEpisode => ListSaisons.Sum(s => s.NbEpisodes);

        public Serie(string titre, DateTime date, TimeSpan duree, string realisateur, IEnumerable<GenreGlobal> genres, string image)
            : base(titre, date, duree, realisateur, genres, image)
        {
            ListSaisons = new List<Saison>();
        }

        public Serie(string titre, DateTime date, TimeSpan duree, string realisateur, IEnumerable<GenreGlobal> genres, string image,
            IEnumerable<Saison> saisons) : base(titre, date, duree, realisateur, genres, image)
        {
            ListSaisons = new List<Saison>(saisons);
        }
        
        public Serie(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd, IEnumerable<GenreGlobal> genres,
            string description, IEnumerable<Uri> ouRegarder, IEnumerable<Langues> audios, IEnumerable<Langues> sousTitres, string image)
            : base(titre, date, duree, realisateur, studioProd, genres, description, ouRegarder, audios, sousTitres, image)
        {
            ListSaisons = new List<Saison>();
        }

        public Serie(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd, IEnumerable<GenreGlobal> genres,
            string description, IEnumerable<Uri> ouRegarder, IEnumerable<Langues> audios, IEnumerable<Langues> sousTitres,
            string image, IEnumerable<Saison> saisons)
            : base(titre, date, duree, realisateur, studioProd, genres, description, ouRegarder, audios, sousTitres, image)
        {
            ListSaisons = new List<Saison>(saisons);
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

        /// <summary>
        /// Créé une liste d'épisode, dépassant de peu la durée indiqué en paramètres
        /// </summary>
        /// <param name="duree_max"></param> durée restante a combler avec des épisodes, convergant vers 0 pour savoir combien ajouter d'Episode
        /// <returns>Une liste d'épisodes, de durée environ équivalente à la durée max (supérieure à la durée d'un épisode près), de max 3 épisodes</returns>
        internal List<Episode> RecepurerListEpisode(ref TimeSpan duree_max)
        {
            int numSaison = 1;
            List<Episode> episodeAAjouter = new List<Episode>();

            while (duree_max.Ticks > 0 && episodeAAjouter.Count < 4)
            {
                episodeAAjouter.AddRange(RechercherSaison(numSaison).RecupererListEpisode(ref duree_max));
                ++numSaison;
            }

            return episodeAAjouter;
        }

        /// <summary>
        /// Ajoute une saison à la liste de la série
        /// </summary>
        /// <param name="s"></param> Saison à ajouter dans la série
        /// <returns>bool true si la saison a bien été ajouté, et false si jamais l'épisode est déjà présent dans la liste de la saison</returns>
        public bool AjouterSaison(Saison s)
        {
            if (ListSaisons.Contains(s)) return false;
            else
            {
                ListSaisons.Add(s);
                return true;
            }
        }

        public bool SupprimerSaison(Saison s)
        {
            return ListSaisons.Remove(s);
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

            return copie_list_saison.Count == 0 && base.Equals(other as ContenuVideoludique);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + (ListSaisons.Sum(s => s.GetHashCode()) * 3);
        }
    }
}
