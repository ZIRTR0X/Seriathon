using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace modelisation.genres
{
    /// <summary>
    /// permet de catégoriser toutes les instances de la classe ContenuVideoludique en différents genres (pouvant etre null)
    /// </summary>
    [DataContract]
    public enum GenreGlobal : byte
    {
        // GenreGlobal? genre = null permettrait aussi d'instancier un enum à null
        [EnumMember]
        None,
        [EnumMember]
        Action,
        [EnumMember]
        Horreur,
        [EnumMember]
        Romance,
        [EnumMember]
        Fantastique,
        [EnumMember]
        Policier,
        [EnumMember]
        ScienceFiction,
        [EnumMember]
        Aventure
    }
}
