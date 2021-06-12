using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using modelisation.usefull_interfaces;

namespace modelisation.content.episodique
{
    /// <summary>
    /// Classe Episode, répertoriant tout ce qu'il y a a savoir sur un épisode d'une série.
    /// </summary>
    [DataContract]
    public class Episode : IEstAjoutableAuMarathon, IEstDescriptible, IEquatable<Episode>
    {
        /// <summary>
        /// représente le nom de l'épisode, son intitulé, ne pouvant etre null ou vide
        /// </summary>
        [DataMember]
        public string Nom
        {
            get => _nom;

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    _nom = "Nom inconnu";
                } else
                {
                    _nom = value;
                }
            }
        }
        private string _nom;

        /// <summary>
        /// représente le numéro de l'épisode au sein de sa saison, ne pouvant être négatif
        /// </summary>
        [DataMember]
        public int NumEpisode
        {
            get => _numEpisode;

            private set
            {
                if(value <= 0)
                {
                    _numEpisode = 0;
                } else
                {
                    _numEpisode = value;
                }
            }
        }
        private int _numEpisode;

        /// <summary>
        /// représente la date de parution de l'épisode, ne pouvant etre entérieur au 1 janvier 1895, année de l'invention du cinema
        /// </summary>
        [DataMember]
        public DateTime Date
        {
            get => _date;

            private set
            {
                // le premier film de l'histoire est sortit en 1895, "La Sortie de l'usine Lumière à Lyon"! 
                if (value.CompareTo(new DateTime(1895, 1, 1)) < 0)
                {
                    _date = new DateTime(1895, 1, 1);
                } else
                {
                    _date = value;
                }
            }
        }
        private DateTime _date;

        /// <summary>
        /// représente la durée de l'épisode, et ne peut être une durée négative
        /// </summary>
        [DataMember]
        public TimeSpan DureeEpisode
        {
            get => _dureeEpisode;

            private set
            {
                if(value.CompareTo(new TimeSpan(0,0,0)) < 0)
                {
                    _dureeEpisode = new TimeSpan(0, 0, 0);
                } else
                {
                    _dureeEpisode = value;
                }
            }
        }
        private TimeSpan _dureeEpisode;

        /// <summary>
        /// présente un court résumé de l'épisode
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Constructeur de la classe Episode, sans description
        /// </summary>
        /// <param name="nom">intitulé de l'épisode (non vide ou null)</param>
        /// <param name="numEpisode">numéro de l'épisode dans la série (non négatif)</param>
        /// <param name="date">date de parution de l'épisode (non antérieur à 1895)</param>
        /// <param name="dureeEpisode">durée de l'épisode (non négatif)</param>
        public Episode(string nom, int numEpisode, DateTime date, TimeSpan dureeEpisode)
        {
            Nom = nom;
            NumEpisode = numEpisode;
            Date = date;
            DureeEpisode = dureeEpisode;
            Description = "";
        }

        /// <summary>
        /// Constructeur de la classe Episode, avec description
        /// </summary>
        /// <param name="nom">intitulé de l'épisode (non vide ou null)</param>
        /// <param name="numEpisode">numéro de l'épisode dans la série (non négatif)</param>
        /// <param name="date">date de parution de l'épisode (non antérieur à 1895)</param>
        /// <param name="dureeEpisode">durée de l'épisode (non négatif)</param>
        /// <param name="description">résumé de l'épisode</param>
        public Episode(string nom, int numEpisode, DateTime date, TimeSpan dureeEpisode, string description)
        {
            Nom = nom;
            NumEpisode = numEpisode;
            Date = date;
            DureeEpisode = dureeEpisode;
            Description = description;
        }

        /// <summary>
        /// permet de récuperer les infos d'affichage d'un épisode
        /// </summary>
        /// <param name="e">episode dont il faut retrouver les infos</param>
        /// <returns>un tuple d'image et du numéro de saison auquel adhère l'épisode, égal a null et 0 si jamais trouvé</returns>
        public (string image, int numSaison) RecupInfo(Episode e)
        {
            foreach(Serie s in Manager.GetInstance().ListCVR.Where(c => c is Serie))
            {
                foreach(Saison sa in s.ListSaisonsR)
                {
                    if (sa.ListEpisodesR.Contains(e))
                    {
                        return (s.Image, sa.NumSaison);
                    }
                }
            }

            return (null, -1);
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
        /// <param name="obj">Une instance de la classe Objet, a comparer avec l'instance de l'objet</param>
        /// <returns>un bool, true si les deux instances sont égales, false sinon</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            return ReferenceEquals(obj, this) || (obj is Episode ep && Equals(ep));
            // ep est la variable de stockage du cast de obj en Episode si le test obj is Episode est true
        }

        /// <summary>
        /// Détermine si l'instance de classe Episode passée en paramètre et celle de la méthode sont identiques
        /// </summary>
        /// <param name="other">Une instance de la classe Episode, a comparer avec l'instance de l'objet</param>
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
