using System;
using System.Collections.Generic;
using System.Text;

namespace modelisation.usefull_interfaces
{
    /// <summary>
    /// L'interface IEstDescriptible décrit ce que doit posséder toutes classes implémentant cette interface, et donc qui est descriptible
    /// </summary>
    public interface IEstDescriptible
    {
        /// <summary>
        /// Attribut décrivant la classe implémentant l'interface, en général un petit texte descriptif
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Retourne la propriété Description
        /// </summary>
        /// <returns>La description, au format string</returns>
        string GetDescription();
    }
}
