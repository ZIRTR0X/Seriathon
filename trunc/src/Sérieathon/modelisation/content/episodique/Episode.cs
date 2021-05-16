using System;
using System.Collections.Generic;
using System.Text;
using modelisation.usefull_interfaces;

namespace modelisation.content.episodique
{
    class Episode : IEstDescriptible
    {
        public string Nom { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan DureeEpisode { get; set; }

        public string Description { get; set; }

        public Episode(string nom, DateTime date, TimeSpan dureeEpisode, string description)
        {
            this.Nom = nom;
            this.Date = date;
            this.DureeEpisode = dureeEpisode;
            this.Description = description;
        }

        /// <summary>
        /// Retourne la propriété Description
        /// </summary>
        /// <returns>la description, au format string</returns>
        public string getDescription()
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
    }
}
