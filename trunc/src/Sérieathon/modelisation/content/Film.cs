using System;
using System.Collections.Generic;
using System.Text;
using modelisation.genres;
using modelisation.langues;

namespace modelisation.content
{
    public class Film : ContenuVideoludique
    {
        string Acteurs;
        public Film(string Titre, TimeSpan Duree, string Production, int Date, GenreGlobal Genre, string Description, string OuRegarder, Langues Audio, Langues SousTitre, string Acteurs)
            :base( Titre,  Duree,  Production,  Date,  Genre,  Description,  OuRegarder,  Audio,  SousTitre)
        {
            this.Acteurs = Acteurs;
        }
    }
}
