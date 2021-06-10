using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace modelisation.genres
{
    /// <summary>
    /// permet de catégoriser toutes les instances de la classe Anime en différents genres
    /// </summary>
    [DataContract]
    public enum GenreAnime : byte
    {
        [EnumMember]
        Shojo,
        [EnumMember]
        Josei,
        [EnumMember]
        Shonen,
        [EnumMember]
        Seinen
    }
}
