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
    /// Serie est un ContenuVideoludique, possédant des saisons d'épisodes
    /// </summary>
    [DataContract]
    public class Serie : ContenuVideoludique, IEquatable<Serie>
    {
        /// <summary>
        /// wrapper ReadOnly de ListSaisons
        /// </summary>
        [DataMember]
        public ReadOnlyCollection<Saison> ListSaisonsR { get; private set; }

        /// <summary>
        /// liste des saisons de la série
        /// </summary>
        [DataMember]
        private List<Saison> ListSaisons
        {
            get => _listSaisons;

            set
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
        private List<Saison> _listSaisons = new List<Saison>();

        /// <summary>
        /// permet de connaitre le nombre de saisons dans la série
        /// </summary>
        public int NbSaisons => ListSaisons.Count;

        /// <summary>
        /// permet de connaitre le nombre d'épisode dans la série
        /// </summary>
        public int NbEpisode => ListSaisons.Sum(s => s.NbEpisodes);

        public Serie(string titre, DateTime date, TimeSpan duree, string realisateur, IEnumerable<GenreGlobal> genres, string image)
            : base(titre, date, duree, realisateur, genres, image)
        {
            ListSaisons = new List<Saison>();
            ListSaisonsR = new ReadOnlyCollection<Saison>(ListSaisons);
        }

        public Serie(string titre, DateTime date, TimeSpan duree, string realisateur, IEnumerable<GenreGlobal> genres, string image,
            IEnumerable<Saison> saisons) : base(titre, date, duree, realisateur, genres, image)
        {
            ListSaisons = new List<Saison>(saisons);
            ListSaisonsR = new ReadOnlyCollection<Saison>(ListSaisons);
        }

        public Serie(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd, IEnumerable<GenreGlobal> genres,
            string description, IEnumerable<Uri> ouRegarder, IEnumerable<Langues> audios, IEnumerable<Langues> sousTitres, string image)
            : base(titre, date, duree, realisateur, studioProd, genres, description, ouRegarder, audios, sousTitres, image)
        {
            ListSaisons = new List<Saison>();
            ListSaisonsR = new ReadOnlyCollection<Saison>(ListSaisons);
        }

        public Serie(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd, IEnumerable<GenreGlobal> genres,
            string description, IEnumerable<Uri> ouRegarder, IEnumerable<Langues> audios, IEnumerable<Langues> sousTitres,
            string image, IEnumerable<Saison> saisons)
            : base(titre, date, duree, realisateur, studioProd, genres, description, ouRegarder, audios, sousTitres, image)
        {
            ListSaisons = new List<Saison>(saisons);
            ListSaisonsR = new ReadOnlyCollection<Saison>(ListSaisons);
        }

        /// <summary>
        /// Recherche une saison de la série, par son numero d'Episode (retourne le 1er trouvé)
        /// </summary>
        /// <param name="numSaison">numéro de la saison recherchée</param>
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
        /// <param name="duree_max">durée restante a combler avec des épisodes, convergant vers 0 pour savoir combien ajouter d'Episode</param>
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
        /// <param name="s">Saison à ajouter dans la série</param>
        /// <returns>true si la saison a bien été ajouté, et false si jamais l'épisode est déjà présent dans la liste de la saison</returns>
        public bool AjouterSaison(Saison s)
        {
            if (ListSaisons.Contains(s)) return false;
            else
            {
                ListSaisons.Add(s);
                return true;
            }
        }

        /// <summary>
        /// Enleve une saison a la liste de la série
        /// </summary>
        /// <param name="s">saison a supprimer de la série</param>
        /// <returns>true si jamais la saison est supprimé, false sinon (souvent car la saison passée en paramètre n'existe pas)</returns>
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
