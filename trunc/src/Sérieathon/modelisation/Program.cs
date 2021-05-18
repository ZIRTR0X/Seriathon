using System;
using System.Collections.Generic;
using System.Text;
using modelisation.content;
using modelisation.genres;
using modelisation.langues;
using static System.Console;

namespace modelisation
{
    class Program
    {
        public void Main(string[] args)
        {
            Film a = new Film("Transformer", new TimeSpan(1, 54, 15), "HollyWood", 2010, GenreGlobal.Action, "C'est un film de robot", "Netflix", Langues.Français, Langues.Français, "../../image/affiche/boruto.jpg","The Rock");
            WriteLine(a.Titre);
            WriteLine(a.Duree);
            WriteLine(a.Production);
            WriteLine(a.Date);
            WriteLine(a.Genre);
            WriteLine(a.Description);
            WriteLine(a.OuRegarder);
            WriteLine(a.Audio);
            WriteLine(a.SousTitre);
            WriteLine(a.Acteurs);
        }
    }
}
