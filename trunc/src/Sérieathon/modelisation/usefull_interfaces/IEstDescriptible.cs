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
        string Description { get; set; }

        /// <summary>
        /// Retourne la propriété Description
        /// </summary>
        /// <returns>La description, au format string</returns>
        string getDescription();
    }
}
