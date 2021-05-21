using System;
using System.Collections.Generic;
using System.Text;

namespace modelisation.genres
{
    /// <summary>
    /// L'enum GenreGlobal permet de catégoriser toutes les instances de la classe ContenuVideoludique en différents genres (pouvant etre null)
    /// </summary>
    public enum GenreGlobal : byte
    {
        // GenreGlobal? genre = null permettrait aussi d'instancier un enum à null
        None,
        Action,
        Horreur,
        Romance,
        Fantastique,
        Policier,
        ScienceFiction,
        Aventure
    }
}
