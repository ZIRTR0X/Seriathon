using System;
using System.Collections.Generic;
using System.Text;
using modelisation.genres;
using modelisation.langues;

namespace modelisation.content
{
    public abstract class ContenuVideoludique
    {
        private string Titre { get; set; }
        private TimeSpan Duree { get; set; }
        private bool Vue { get; set; } = false;
        private string Production { get; set; }
        private int Date { get; set; }
        public GenreGlobal Genre { get; set; }
        private string Description { get; set; }
        private string OuRegarder { get; set; }
        private Langues Audio { get; set; }
        private Langues SousTitre { get; set; }


        public ContenuVideoludique(string Titre, TimeSpan Duree,string Production, int Date, GenreGlobal Genre, string Description, string OuRegarder, Langues Audio, Langues SousTitre)
        {
            this.Titre = Titre;
            this.Duree = Duree;
            this.Production = Production;
            this.Date = Date;
            this.Genre = Genre;
            this.Description = Description;
            this.OuRegarder = OuRegarder;
            this.Audio = Audio;
            this.SousTitre = SousTitre;
        }


       

    }
}
