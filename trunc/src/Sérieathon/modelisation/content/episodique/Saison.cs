using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace modelisation.content.episodique
{
    /// <summary>
    /// classe Saison, répertoriant tout ce qu'il y a a savoir sur une saison d'une série
    /// </summary>
    public class Saison : IEquatable<Saison>
    {
        /// <summary>
        /// int NumSaison permet de connaitre en quelle position la saison se place dans la série, il ne peut etre négatif
        /// </summary>
        public int NumSaison
        {
            get => _numSaison;

            private set
            {
                if(value <= 0)
                {
                    _numSaison = 0;
                } else
                {
                    _numSaison = value;
                }
            }
        }
        private int _numSaison;

        /// <summary>
        /// LinkedList<Episode> ListEpisodes est une liste de tout les épisodes composant la saison, la liste ne peut etre null
        /// </summary>
        public LinkedList<Episode> ListEpisodes
        {
            get => _listEpisodes;

            private set
            {
                if(value is null)
                {
                    _listEpisodes = new LinkedList<Episode>();
                } else
                {
                    _listEpisodes = value;
                }
            }
        }
        private LinkedList<Episode> _listEpisodes;

        /// <summary>
        /// int NbEpisodes est une propriété calculée retournant le nombre d'épisodes de la liste d'épisode
        /// </summary>
        public int NbEpisodes => ListEpisodes.Count;

        /// <summary>
        /// TimeSpan DureeSaison est une propriété calculée renvoyant la somme des durées de tout les épisodes de la saison
        /// </summary>
        // "ListEpisodes.Select(e => e.DureeEpisode.Ticks).Sum()" renvoie la somme (long) de tout les TimeSpan de durée épisode
        public TimeSpan DureeSaison => new TimeSpan(ListEpisodes.Sum(e => e.DureeEpisode.Ticks));

        /// <summary>
        /// DateTime DateDebutSaison est une propriété calculée renvoyant la plus petite date de sortie d'épisode de la liste
        /// </summary>
        // ListEpisodes.Select(e => e.Date.Ticks).Min() permet de récupérer la date de la liste la plus antérieure
        public DateTime DateDebutSaison => new DateTime(ListEpisodes.Min(e => e.Date.Ticks));

        /// <summary>
        /// DateTime DateFinSaison est une propriété calculée renvoyant la plus grande date de sortie d'épisode de la liste
        /// </summary>
        public DateTime DateFinSaison => new DateTime(ListEpisodes.Max(e => e.Date.Ticks));

        /// <summary>
        /// Constructeur de la classe Saison
        /// </summary>
        /// <param name="numSaison"></param> int numéro de la saison dans la série
        public Saison(int numSaison)
        {
            this.NumSaison = numSaison;
            this.ListEpisodes = new LinkedList<Episode>();
        }

        /// <summary>
        /// Constructeur de la classe Saison, permet de passer en paramètre une LinkedList pour préenregistrer des épisodes
        /// </summary>
        /// <param name="numSaison"></param> int numéro de la saison dans la série
        /// <param name="episodes"></param> LinkedList<Episode> liste préfaite d'épisodes à la nouvelle saison
        public Saison(int numSaison, LinkedList<Episode> episodes)
        {
            this.NumSaison = numSaison;
            this.ListEpisodes = episodes;
        }

        /// <summary>
        /// Ajoute un épisode à la liste de la saison
        /// </summary>
        /// <param name="e"></param> Episode à ajouter dans la saison
        /// <returns>bool true si l'épisode a bien été ajouté, et false si jamais l'épisode est déjà présent dans la liste de la saison</returns>
        public bool AjouterEpisode(Episode e)
        {
            if(ListEpisodes.Contains(e))
            {
                return false;
            } else
            {
                ListEpisodes.AddLast(e);
                return true;
            }
        }

        /// <summary>
        /// supprime un episode de la liste de la saison
        /// </summary>
        /// <param name="e"></param> Episode a supprimer de la saison
        /// <returns>bool retournant true si bien supprimé, sinon false si aucune occurence n'est trouvée</returns>
        public bool SupprimerEpisode(Episode e)
        {
            return ListEpisodes.Remove(e);
        }

        /// <summary>
        /// Recherche un episode de la saison, par son numero d'Episode (retourne le 1er trouvé)
        /// </summary>
        /// <param name="numeroEpisode"></param> numéro de l'épisode recherché
        /// <returns>Episode dont le numéro correspond à celui demandé, si aucune occurence n'est trouvée, il renvoit null</returns>
        public Episode RechercherEpisode(int numeroEpisode)
        {
            foreach(Episode e in ListEpisodes)
            {
                if (e.NumEpisode == numeroEpisode)
                {
                    return e;
                }
            }

            return null;
        }

        /// <summary>
        /// Retourne la description détaillée (Nom, durée et descriptif de l'épisode) sous la forme d'un string
        /// </summary>
        /// <returns>un string contenant toutes les informations décrivant l'instance</returns>
        public override string ToString()
        {
            string message = $"Numéro de saison:\t{NumSaison}\n\n";
            foreach(Episode e in ListEpisodes)
            {
                message += $"{e.NumEpisode} : {e.Nom}\n";
            }
            return message;
        }

        /// <summary>
        /// Détermine si l'instance passée en paramètre et celle de la méthode sont identiques
        /// </summary>
        /// <param name="obj"></param>Une instance de la classe Objet, a comparer avec l'instance de l'objet
        /// <returns>un bool, true si les deux instances sont égales, false sinon</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            // equivalent à return ReferenceEquals(obj, this) ? true : obj is Saison s && Equals(s);
            return ReferenceEquals(obj, this) || (obj is Saison s && Equals(s));
        }

        /// <summary>
        /// Détermine si l'instance de classe Episode passée en paramètre et celle de la méthode sont identiques
        /// </summary>
        /// <param name="other"></param>Une instance de la classe Saison, a comparer avec l'instance de l'objet
        /// <returns>un bool, true si les deux instances sont égales, false sinon</returns>
        public bool Equals(Saison other)
        {
            if (NumSaison != other.NumSaison) return false;

            // il faut order les deux listes, pour comparer les éléments de la liste avec les premiers de l'autre liste

            LinkedList<Episode> copie_list_episode = new LinkedList<Episode>(other.ListEpisodes.OrderBy(e => e.GetHashCode()));

            foreach (Episode e in ListEpisodes.OrderBy(e => e.GetHashCode()))
            {
                if (!e.Equals(copie_list_episode.First()))
                {
                    return false;
                } else
                {
                    copie_list_episode.Remove(e);
                }
            }

            return copie_list_episode.Count == 0;
        }

        /// <summary>
        /// Fonction de hashage associant à l'instance de la classe une valeur numérique unique
        /// </summary>
        /// <returns>un int représentant l'instance sous une représentation numérique</returns>
        public override int GetHashCode()
        {
            int hashCode = NumSaison * 3;
            return (hashCode + ListEpisodes.Sum(e => e.GetHashCode())) * 2;
        }
    }
}
