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
                if(value == null)
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
        /// Permet de récupérer le nombre d'épisode de la série
        /// </summary>
        /// <returns>nombre d'épisode de la série</returns>
        public int GetNbEpisode()
        {
            return ListEpisodes.Count;
        }

        /// <summary>
        /// Permet de récupérer la durée totale de la saion, en récupérant les Ticks des TimeSpan de durée de chaque épisode de la liste d'épisodes, les ajoutes, et convertie cette somme de ticks en un TimeSPan
        /// </summary>
        /// <returns>durée totale de la saison</returns>
        public TimeSpan GetDuree()
        {
            // "ListEpisodes.Select(e => e.DureeEpisode.Ticks).Sum()" renvoie la somme (long) de tout les TimeSpan de durée épisode
            return new TimeSpan(ListEpisodes.Select(e => e.DureeEpisode.Ticks).Sum());
        }

        /// <summary>
        /// Permet de connaitre la date de début de la saison, correspondant à la date de parution d'épisode la plus antérieure de la liste d'épisode
        /// </summary>
        /// <returns>date de début de la saions</returns>
        public DateTime GetDateDebut()
        {
            // ListEpisodes.Select(e => e.Date.Ticks).Min() permet de récupérer la date de la liste la plus antérieure
            return new DateTime(ListEpisodes.Select(e => e.Date.Ticks).Min());
        }

        /// <summary>
        /// Permet de connaitre la date de fin de la saison, correspondant à la date de parution d'épisode la plus ultérieure de la liste d'épisode
        /// </summary>
        /// <returns>date de fin de la saions</returns>
        public DateTime GetDateFin()
        {
            return new DateTime(ListEpisodes.Select(e => e.Date.Ticks).Max());
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
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;

            return obj is Saison s && Equals(s);
        }

        /// <summary>
        /// Détermine si l'instance de classe Episode passée en paramètre et celle de la méthode sont identiques
        /// </summary>
        /// <param name="other"></param>Une instance de la classe Saison, a comparer avec l'instance de l'objet
        /// <returns>un bool, true si les deux instances sont égales, false sinon</returns>
        public bool Equals(Saison other)
        {
            if (NumSaison != other.NumSaison) return false;

            foreach(Episode e in ListEpisodes)
            {
                if (!other.ListEpisodes.Contains(e))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Fonction de hashage associant à l'instance de la classe une valeur numérique unique
        /// </summary>
        /// <returns>un int représentant l'instance sous une représentation numérique</returns>
        public override int GetHashCode()
        {
            int hashCode = NumSaison * 3;
            return (hashCode + ListEpisodes.Select(e => e.GetHashCode()).Sum()) * 2;
        }
    }
}
