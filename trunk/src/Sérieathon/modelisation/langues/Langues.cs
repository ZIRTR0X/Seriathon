using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace modelisation.langues
{
    /// <summary>
    /// permet de repertorier les langues disponibles pour l'oral et les sous-titres des ContenuVideoludique
    /// </summary>
    [DataContract]
    public enum Langues : byte
    {
        //Langues sera utilisé  pour definir les sous-titres et l'audio des ContenuVideoludiques
        [EnumMember]
        Français,
        [EnumMember]
        Japonais,
        [EnumMember]
        Anglais,
        [EnumMember]
        Espagnol,
        [EnumMember]
        Italien,
        [EnumMember]
        Allemand
    }
}
