using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using modelisation.genres;
using modelisation.langues;
using modelisation.usefull_interfaces;

namespace modelisation.content
{
    /// <summary>
    /// classe ContenuVideoludique est une classe abstraite représentant du contenu vidéoludique (Film, Série...)
    /// </summary>
    public abstract class ContenuVideoludique : IEstAjoutableAuMarathon, IEstDescriptible, IEquatable<ContenuVideoludique>
    {

        /// <summary>
        /// string Titre correspond au titre de l'oeuvre, ne pouvant être vide
        /// </summary>
        public string Titre
        {
            get => _titre;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _titre = "Titre inconnu";
                }
                else
                {
                    _titre = value;
                }
            }
        }
        private string _titre;
        
        /// <summary>
        /// DateTime Date représente la date de parution du contenu, ne pouvant etre entérieur au 1 janvier 1895, année de l'invention du cinema
        /// </summary>
        public DateTime Date {
            get => _date;

            private set
            {
                // le premier film de l'histoire est sortit en 1895, "La Sortie de l'usine Lumière à Lyon"! 
                if (value.CompareTo(new DateTime(1895, 1, 1)) < 0)
                {
                    _date = new DateTime(1895, 1, 1);
                } else
                {
                    _date = value;
                }
            }
        }
        private DateTime _date;

        /// <summary>
        /// TimeSpan Duree représente la durée du contenu, et ne peut être une durée négative
        /// </summary>
        public TimeSpan Duree
        {
            get => _duree;

            private set
            {
                if(value.Ticks < 0)
                {
                    _duree = new TimeSpan(0);
                } else
                {
                    _duree = value;
                }
            }
        }
        private TimeSpan _duree;

        /// <summary>
        /// string Réalisateur donne le nom du réalisateur du film, ne pouvant etre null ou vide
        /// </summary>
        public string Realisateur
        {
            get => _realisateur;

            private set
            {
                if(String.IsNullOrWhiteSpace(value))
                {
                    _realisateur = "Realisateur inconnue";
                } else
                {
                    _realisateur = value;
                }
            }
        }
        private string _realisateur;

        /// <summary>
        /// string StudioProduction permet de connaitre le nom du studio de production, ne pouvant etre null
        /// </summary>
        public string StudioProduction
        {
            get => _studioProduction;

            private set
            {
                if(String.IsNullOrWhiteSpace(value))
                {
                    _studioProduction = "Studio inconnu / Non existant";
                } else
                {
                    _studioProduction = value;
                }
            }
        }
        private string _studioProduction;

        /// <summary>
        /// List<GenreGlobal> Genre liste tout les genres auquel appartient l'instance
        /// </summary>
        public List<GenreGlobal> Genres
        {
            get => _genre;

            private set
            {
                if(value is null)
                {
                    _genre = new List<GenreGlobal>();
                } else
                {
                    _genre = value;
                }
            }
        }
        private List<GenreGlobal> _genre;

        /// <summary>
        /// string Description correspond à un résumé du contenu vidéoludique, ne pouvant etre null ou empty
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// List<Uri> OuRegarder répertorie tout les liens pour aller voir le contenu, ne pouvant être null
        /// </summary>
        public List<Uri> OuRegarder
        {
            get => _ouRegarder;

            private set
            {
                if(value is null)
                {
                    _ouRegarder = new List<Uri>();
                } else
                {
                    _ouRegarder = value;
                }
            }
        }
        private List<Uri> _ouRegarder;

        /// <summary>
        /// List<Langues> Audios référence toutes les langues disponibles en audio, ne pouvant etre null
        /// </summary>
        public List<Langues> Audios
        {
            get => _audios;

            private set
            {
                if (value is null)
                {
                    _audios = new List<Langues>();
                }
                else
                {
                    _audios = value;
                }
            }
        }
        private List<Langues> _audios;

        /// <summary>
        /// List<Langues> SousTitres référence toutes les langues disponibles en sous-titres, ne pouvant etre null
        /// </summary>
        public List<Langues> SousTitres
        {
            get => _sousTitres;

            private set
            {
                if (value is null)
                {
                    _sousTitres = new List<Langues>();
                }
                else
                {
                    _sousTitres = value;
                }
            }
        }
        private List<Langues> _sousTitres;

        /// <summary>
        /// Uri Image indique le chemin vers l'illustration du contenu
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Constructeur de la classe ContenuVideoludique
        /// </summary>
        /// <param name="titre"></param> string Intitulé du Contenu
        /// <param name="date"></param> DateTime date de sortie du contenu vidéoludique
        /// <param name="duree"></param> TimeSpan durée du contenu
        /// <param name="realisateur"></param> string Réalisateur du contenu
        /// <param name="genres"></param> List<GenreGlobal> représentant la liste des genres auquel appartient le contenur
        /// <param name="image"></param> string image d'illustration du contenu
        public ContenuVideoludique(string titre, DateTime date, TimeSpan duree, string realisateur,
            IEnumerable<GenreGlobal> genres, string image)
        {
            this.Titre = titre;
            this.Date = date;
            this.Duree = duree;
            this.Realisateur = realisateur;
            this.StudioProduction = "";
            this.Genres = new List<GenreGlobal>(genres);
            this.Description = "";
            this.OuRegarder = new List<Uri>();
            this.Audios = new List<Langues>();
            this.SousTitres = new List<Langues>();
            this.Image = image;
        }

        /// <summary>
        /// Constructeur de la classe ContenuVideoludique
        /// </summary>
        /// <param name="titre"></param> string Intitulé du Contenu
        /// <param name="date"></param> DateTime date de sortie du contenu vidéoludique
        /// <param name="duree"></param> TimeSpan durée du contenu
        /// <param name="realisateur"></param> string Réalisateur du contenu
        /// <param name="studioProd"></param> string Studio ayant produit le contenu
        /// <param name="genres"></param> List<GenreGlobal> représentant la liste des genres auquel appartient le contenur
        /// <param name="description"></param> string présentant un résumé du contenu
        /// <param name="image"></param> string image d'illustration du contenu
        public ContenuVideoludique(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd,
            IEnumerable<GenreGlobal> genres, string description, string image)
        {
            Titre = titre;
            Date = date;
            Duree = duree;
            Realisateur = realisateur;
            StudioProduction = studioProd;
            Genres = new List<GenreGlobal>(genres);
            Description = description;
            OuRegarder = new List<Uri>();
            Audios = new List<Langues>();
            SousTitres = new List<Langues>();
            Image = image;
        }

        /// <summary>
        /// Constructeur de la classe ContenuVideoludique
        /// </summary>
        /// <param name="titre"></param> string Intitulé du Contenu
        /// <param name="date"></param> DateTime date de sortie du contenu vidéoludique
        /// <param name="duree"></param> TimeSpan durée du contenu
        /// <param name="realisateur"></param> string Réalisateur du contenu
        /// <param name="studioProd"></param> string Studio ayant produit le contenu
        /// <param name="genres"></param> List<GenreGlobal> représentant la liste des genres auquel appartient le contenur
        /// <param name="description"></param> string présentant un résumé du contenu
        /// <param name="ouRegarder"></param> List<Uri> listant les sites où l'on peut regarder ce contenu
        /// <param name="audios"></param> List<Uri> listant les langues disponibles pour l'audio du contenu
        /// <param name="sousTitres"></param> List<Uri> listant les langues disponibles pour les sous-titres du contenu
        /// <param name="image"></param>
        public ContenuVideoludique(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd, IEnumerable<GenreGlobal> genres,
            string description, IEnumerable<Uri> ouRegarder, IEnumerable<Langues> audios, IEnumerable<Langues> sousTitres, string image)
        {
            Titre = titre;
            Date = date;
            Duree = duree;
            Realisateur = realisateur;
            StudioProduction = studioProd;
            Genres = new List<GenreGlobal>(genres);
            Description = description;
            OuRegarder = new List<Uri>(ouRegarder);
            Audios = new List<Langues>(audios);
            SousTitres = new List<Langues>(sousTitres);
            Image = image;
        }

        /// <summary>
        /// Retourne la propriété Description
        /// </summary>
        /// <returns>la description, au format string</returns>
        public string GetDescription()
        {
            return Description;
        }

        /// <summary>
        /// Détermine si l'instance passée en paramètre et celle de la méthode sont identiques
        /// </summary>
        /// <param name="obj"></param>Une instance de la classe Objet, a comparer avec l'instance de l'objet
        /// <returns>un bool, true si les deux instances sont égales, false sinon</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            return ReferenceEquals(obj, this) || (obj is ContenuVideoludique cv && Equals(cv));
        }

        /// <summary>
        /// Détermine si l'instance de classe ContenuVideoludique passée en paramètre et celle de la méthode sont identiques
        /// </summary>
        /// <param name="other"></param>Une instance de la classe ContenuVideoludique, a comparer avec l'instance de l'objet
        /// <returns>un bool, true si les deux instances sont égales, false sinon</returns>
        public bool Equals(ContenuVideoludique other)
        {
            if (!Titre.Equals(other.Titre)) return false;
            if (!Date.Equals(other.Date)) return false;
            if (!Duree.Equals(other.Duree)) return false;
            if (!Realisateur.Equals(other.Realisateur)) return false;
            if (!StudioProduction.Equals(other.StudioProduction)) return false;
            if (!Description.Equals(other.Description)) return false;

            LinkedList<GenreGlobal> genres_copies = new LinkedList<GenreGlobal>(other.Genres.OrderBy(g => g.GetHashCode()));
            foreach (GenreGlobal g in Genres.OrderBy(g => g.GetHashCode()))
            {
                if (!g.Equals(genres_copies.First())) return false;
                else genres_copies.RemoveFirst();
            }


            LinkedList<Uri> ouRegarder_copie = new LinkedList<Uri>(other.OuRegarder.OrderBy(u => u.GetHashCode()));
            foreach (Uri u in OuRegarder.OrderBy(u => u.GetHashCode()))
            {
                if (!u.Equals(ouRegarder_copie.First())) return false;
                else ouRegarder_copie.RemoveFirst();
            }


            LinkedList<Langues> audios_copie = new LinkedList<Langues>(other.Audios.OrderBy(a => a.GetHashCode()));
            foreach (Langues a in Audios.OrderBy(a => a.GetHashCode())) 
            {
                if (!a.Equals(audios_copie.First())) return false;
                else audios_copie.RemoveFirst();
            }


            LinkedList<Langues> sousTitres_copie = new LinkedList<Langues>(other.SousTitres.OrderBy(s => s.GetHashCode()));
            foreach (Langues s in SousTitres.OrderBy(s => s.GetHashCode()))
            {
                if (!s.Equals(sousTitres_copie.First())) return false;
                else sousTitres_copie.RemoveFirst();
            }


            return genres_copies.Count == 0 && ouRegarder_copie.Count == 0 && audios_copie.Count == 0 && sousTitres_copie.Count == 0 && Image.Equals(other.Image);
        }

        /// <summary>
        /// Fonction de hashage associant à l'instance de la classe une valeur numérique unique
        /// </summary>
        /// <returns>un int représentant l'instance sous une représentation numérique</returns>
        public override int GetHashCode()
        {
            return ((Titre.GetHashCode() * 7) + (Date.GetHashCode() * 3) + (Duree.GetHashCode() * 21)
                + (Realisateur.GetHashCode() * 31) + (StudioProduction.GetHashCode() * 2) + (Image.GetHashCode() * 3)
                + (Description.GetHashCode() * 3) + (OuRegarder.Sum(u => u.GetHashCode()) * 2)
                + (Audios.Sum(l => l.GetHashCode()) * 5) + (SousTitres.Sum(l => l.GetHashCode()) * 2)) * 3;
        }

    }
}
