using System;
using System.Collections.Generic;
using System.Text;
using modelisation.usefull_interfaces;

namespace modelisation.content.episodique
{
    /// <summary>
    /// Classe épisode, répertoriant tout ce qu'il y a a savoir sur un épisode d'une série.
    /// </summary>
    public class Episode : IEstDescriptible, IEquatable<Episode>
    {
        /// <summary>
        /// string Nom représente le nom de l'épisode, son intitulé, ne pouvant etre null ou vide
        /// </summary>
        public string Nom
        {
            get => _nom;

            private set
            {
                if (String.IsNullOrEmpty(_nom))
                {
                    Nom = "Nom inconnu";
                } else
                {
                    Nom = _nom;
                }
            }
        }
        private string _nom;

        /// <summary>
        /// int NumEpisode représente le numéro de l'épisode au sein de sa saison, ne pouvant être négatif
        /// </summary>
        public int NumEpisode
        {
            get => _numEpisode;

            private set
            {
                if(_numEpisode <= 0)
                {
                    NumEpisode = 0;
                } else
                {
                    NumEpisode = _numEpisode;
                }
            }
        }
        private int _numEpisode;

        /// <summary>
        /// DateTime Date représente la date de parution de l'épisode, ne pouvant etre entérieur au 1 janvier 1895, année de l'invention du cinema
        /// </summary>
        public DateTime Date
        {
            get => _date;

            private set
            {
                // le premier film de l'histoire est sortit en 1895, "La Sortie de l'usine Lumière à Lyon"! 
                if (_date.CompareTo(new DateTime(1895, 1, 1)) < 0)
                {
                    Date = new DateTime(1895, 1, 1);
                } else
                {
                    Date = _date;
                }
            }
        }
        private DateTime _date;

        /// <summary>
        /// TimeSpan DureeEpisode représente la durée de l'épisode, et ne peut être une durée négative
        /// </summary>
        public TimeSpan DureeEpisode
        {
            get => _dureeEpisode;

            private set
            {
                if(_dureeEpisode.CompareTo(new TimeSpan(0,0,0)) < 0)
                {
                    DureeEpisode = new TimeSpan(0, 0, 0);
                } else
                {
                    DureeEpisode = _dureeEpisode;
                }
            }
        }
        private TimeSpan _dureeEpisode;

        /// <summary>
        /// string Description présente un court résumé de l'épisode
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Constructeur de la classe Episode, sans description
        /// </summary>
        /// <param name="nom"></param> string intitulé de l'épisode (non vide ou null)
        /// <param name="numEpisode"></param> int numéro de l'épisode dans la série (non négatif)
        /// <param name="date"></param> DateTime date de parution de l'épisode (non antérieur à 1895)
        /// <param name="dureeEpisode"></param> Timespan durée de l'épisode (non négatif)
        public Episode(string nom, int numEpisode, DateTime date, TimeSpan dureeEpisode)
        {
            this.Nom = nom;
            this.NumEpisode = numEpisode;
            this.Date = date;
            this.DureeEpisode = dureeEpisode;
            this.Description = "";
        }

        /// <summary>
        /// Constructeur de la classe Episode, avec description
        /// </summary>
        /// <param name="nom"></param> string intitulé de l'épisode (non vide ou null)
        /// <param name="numEpisode"></param> int numéro de l'épisode dans la série (non négatif)
        /// <param name="date"></param> DateTime date de parution de l'épisode (non antérieur à 1895)
        /// <param name="dureeEpisode"></param> Timespan durée de l'épisode (non négatif)
        /// <param name="description"></param> string résumé de l'épisode
        public Episode(string nom, int numEpisode, DateTime date, TimeSpan dureeEpisode, string description)
        {
            this.Nom = nom;
            this.NumEpisode = numEpisode;
            this.Date = date;
            this.DureeEpisode = dureeEpisode;
            this.Description = description;
        }

        /// <summary>
        /// Retourne la propriété Description
        /// </summary>
        /// <returns>la description, au format string</returns>
        public string GetDescription()
        {
            return Description;
        }

        /// <summary>
        /// Retourne la description détaillée (Nom, durée et descriptif de l'épisode) sous la forme d'un string
        /// </summary>
        /// <returns>un string contenant toutes les informations décrivant l'instance</returns>
        public override string ToString()
        {
            return $"Nom:\t{Nom}\nDate:\t{Date}\nDurée:\t{DureeEpisode}\nDescription:\n{Description}";
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

            return obj is Episode ep && Equals(ep); // ep est la variable de stockage du cast de obj en Episode si le test obj is Episode est true
        }

        /// <summary>
        /// Détermine si l'instance de classe Episode passée en paramètre et celle de la méthode sont identiques
        /// </summary>
        /// <param name="other"></param>Une instance de la classe Episode, a comparer avec l'instance de l'objet
        /// <returns>un bool, true si les deux instances sont égales, false sinon</returns>
        public bool Equals(Episode other)
        {
            if (!Nom.Equals(other.Nom)) return false;
            if (NumEpisode != other.NumEpisode) return false;
            if (!Date.Equals(other.Date)) return false;
            if (!DureeEpisode.Equals(other.DureeEpisode)) return false;
            return Description.Equals(other.Description);
        }

        /// <summary>
        /// Fonction de hashage associant à l'instance de la classe une valeur numérique unique
        /// </summary>
        /// <returns>un int représentant l'instance sous une représentation numérique</returns>
        public override int GetHashCode()
        {
            return ((Nom.GetHashCode() * 29) + NumEpisode * 7 + (Date.GetHashCode() * 3)
                + (DureeEpisode.GetHashCode() * 31) + (Description.GetHashCode() * 11)) * 2;
        }

    }
}
