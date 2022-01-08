﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace modelisation.content.episodique
{
    /// <summary>
    /// classe Saison, répertoriant tout ce qu'il y a a savoir sur une saison d'une série
    /// </summary>
    [DataContract]
    public class Saison : IEquatable<Saison>
    {
        [OnDeserialized]
        void InitReadOnly(StreamingContext sc = new StreamingContext())
        {
            ListEpisodesR = new ReadOnlyCollection<Episode>(ListEpisodes);
        }

        /// <summary>
        /// permet de connaitre en quelle position la saison se place dans la série, il ne peut etre négatif
        /// </summary>
        [DataMember]
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
        /// wrapper read only de la liste ListEpisodes
        /// </summary>
        public ReadOnlyCollection<Episode> ListEpisodesR { get; private set; }

        /// <summary>
        /// une liste de tout les épisodes composant la saison, la liste ne peut etre null
        /// </summary>
        [DataMember]
        private List<Episode> ListEpisodes
        {
            get => _listEpisodes;

            set
            {
                if(value is null)
                {
                    _listEpisodes = new List<Episode>();
                } else
                {
                    _listEpisodes = value;
                }
            }
        }
        private List<Episode> _listEpisodes = new List<Episode>();

        /// <summary>
        /// propriété calculée retournant le nombre d'épisodes de la liste d'épisode
        /// </summary>
        public int NbEpisodes => ListEpisodes.Count;

        /// <summary>
        /// une propriété calculée renvoyant la somme des durées de tout les épisodes de la saison
        /// </summary>
        // "ListEpisodes.Select(e => e.DureeEpisode.Ticks).Sum()" renvoie la somme (long) de tout les TimeSpan de durée épisode
        public TimeSpan DureeSaison => new TimeSpan(ListEpisodes.Sum(e => e.DureeEpisode.Ticks));

        /// <summary>
        /// une propriété calculée renvoyant la plus petite date de sortie d'épisode de la liste
        /// </summary>
        // ListEpisodes.Select(e => e.Date.Ticks).Min() permet de récupérer la date de la liste la plus antérieure
        public DateTime DateDebutSaison => new DateTime(ListEpisodes.Min(e => e.Date.Ticks));

        /// <summary>
        /// une propriété calculée renvoyant la plus grande date de sortie d'épisode de la liste
        /// </summary>
        public DateTime DateFinSaison => new DateTime(ListEpisodes.Max(e => e.Date.Ticks));

        /// <summary>
        /// Constructeur de la classe Saison
        /// </summary>
        /// <param name="numSaison"></param> int numéro de la saison dans la série
        public Saison(int numSaison)
        {
            NumSaison = numSaison;
            ListEpisodes = new List<Episode>();
            ListEpisodesR = new ReadOnlyCollection<Episode>(ListEpisodes);
        }

        /// <summary>
        /// Constructeur de la classe Saison, permet de passer en paramètre une LinkedList pour préenregistrer des épisodes
        /// </summary>
        /// <param name="numSaison">numéro de la saison dans la série</param>
        /// <param name="episodes">liste préfaite d'épisodes à la nouvelle saison</param>
        public Saison(int numSaison, IEnumerable<Episode> episodes)
        {
            NumSaison = numSaison;
            ListEpisodes = new List<Episode>(episodes);
            ListEpisodesR = new ReadOnlyCollection<Episode>(ListEpisodes);
        }


        /// <summary>
        /// Ajoute un épisode à la liste de la saison
        /// </summary>
        /// <param name="e">Episode à ajouter dans la saison</param>
        /// <returns>bool true si l'épisode a bien été ajouté, et false si jamais l'épisode est déjà présent dans la liste de la saison</returns>
        public bool AjouterEpisode(Episode e)
        {
            if(ListEpisodes.Contains(e))
            {
                return false;
            } else
            {
                ListEpisodes.Add(e);
                return true;
            }
        }

        /// <summary>
        /// supprime un episode de la liste de la saison
        /// </summary>
        /// <param name="e">Episode a supprimer de la saison</param>
        /// <returns>bool retournant true si bien supprimé, sinon false si aucune occurence n'est trouvée</returns>
        public bool SupprimerEpisode(Episode e)
        {
            return ListEpisodes.Remove(e);
        }

        /// <summary>
        /// Recherche un episode de la saison, par son numero d'Episode (retourne le 1er trouvé)
        /// </summary>
        /// <param name="numeroEpisode">numéro de l'épisode recherché</param>
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
        /// Créé une liste d'épisode, dépassant de peu la durée indiqué en paramètres
        /// </summary>
        /// <param name="duree_restante">durée restante a combler avec des épisodes, réduit à 0 ou négatif pour
        /// informer la fonction appelante</param>
        /// <returns>Une liste d'épisodes, de durée environ équivalente à la durée restante (supérieure à la durée d'un épisode près), ou null si la saison n'a pas d'épisodes</returns>
        public List<Episode> RecupererListEpisode(ref TimeSpan duree_restante)
        {
            if (ListEpisodes.Count == 0 || ListEpisodes is null) return null;

            int nbEpisodeAjout = 0;
            List<Episode> episodeAAjouter = new List<Episode>();


            while(duree_restante.Ticks > 0 && nbEpisodeAjout < 4)
            {
                // si jamais nbAjout équivaut au nombre d'éléments, alors on arrete et on retourne ce que l'on a build
                if (nbEpisodeAjout >= ListEpisodes.Count) return episodeAAjouter;

                episodeAAjouter.Add(ListEpisodes[nbEpisodeAjout]);
                duree_restante -= ListEpisodes[nbEpisodeAjout].DureeEpisode;

                
                ++nbEpisodeAjout;
            }
            return episodeAAjouter;
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
        /// <param name="obj">Une instance de la classe Objet, a comparer avec l'instance de l'objet</param>
        /// <returns>true si les deux instances sont égales, false sinon</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            // equivalent à return ReferenceEquals(obj, this) ? true : obj is Saison s && Equals(s);
            return ReferenceEquals(obj, this) || (obj is Saison s && Equals(s));
        }

        /// <summary>
        /// Détermine si l'instance de classe Episode passée en paramètre et celle de la méthode sont identiques
        /// </summary>
        /// <param name="other">Une instance de la classe Saison, a comparer avec l'instance de l'objet</param>
        /// <returns>true si les deux instances sont égales, false sinon</returns>
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
            foreach(Episode e in ListEpisodes)
            {
                hashCode += e.GetHashCode();
                // fort risque de débordement de int, donc si il s'en approche on remet a 0
                if(hashCode > 2147482000) { hashCode = NumSaison * 3; }
            }
            return hashCode;
        }
    }
}
