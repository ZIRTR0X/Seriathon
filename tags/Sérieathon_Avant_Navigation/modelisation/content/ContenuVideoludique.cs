using System;
using System.Collections.Generic;
using System.Text;
using modelisation.genres;
using modelisation.langues;

namespace modelisation.content
{
    public abstract class ContenuVideoludique
    {
        public string Titre { get; set; }
        public TimeSpan Duree { get; set; }
        public bool Vue { get; set; } = false;
        public string Production { get; set; }
        public int Date { get; set; }
        public GenreGlobal Genre { get; set; }
        public string Description { get; set; }
        public string OuRegarder { get; set; }
        public Langues Audio { get; set; }
        public Langues SousTitre { get; set; }
        public string Image { get; set; }


        public ContenuVideoludique(string Titre, TimeSpan Duree,string Production, int Date, GenreGlobal Genre, string Description, string OuRegarder, Langues Audio, Langues SousTitre, string Image)
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
            this.Image = Image;
        }


       

    }
}
