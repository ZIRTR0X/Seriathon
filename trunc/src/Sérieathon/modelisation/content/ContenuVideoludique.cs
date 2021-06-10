using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using modelisation.content.episodique;
using modelisation.genres;
using modelisation.langues;
using modelisation.usefull_interfaces;

namespace modelisation.content
{
    /// <summary>
    /// classe ContenuVideoludique est une classe abstraite représentant du contenu vidéoludique (Film, Série...)
    /// </summary>
    [DataContract, KnownType(typeof(Film)), KnownType(typeof(Serie))]
    public abstract class ContenuVideoludique : IEstAjoutableAuMarathon, IEstDescriptible, IEquatable<ContenuVideoludique>
    {
        [OnDeserialized]
        void InitReadOnly(StreamingContext sc = new StreamingContext())
        {
            GenresR = new ReadOnlyCollection<GenreGlobal>(Genres);
            OuRegarderR = new ReadOnlyCollection<Uri>(OuRegarder);
            AudiosR = new ReadOnlyCollection<Langues>(Audios);
            SousTitresR = new ReadOnlyCollection<Langues>(SousTitres);
        }

        /// <summary>
        /// correspond au titre de l'oeuvre, ne pouvant être vide
        /// </summary>
        [DataMember]
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
        /// représente la date de parution du contenu, ne pouvant etre entérieur au 1 janvier 1895, année de l'invention du cinema
        /// </summary>
        [DataMember]
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
        /// représente la durée du contenu, et ne peut être une durée négative
        /// </summary>
        [DataMember]
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
        /// donne le nom du réalisateur du film, ne pouvant etre null ou vide
        /// </summary>
        [DataMember]
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
        /// permet de connaitre le nom du studio de production, ne pouvant etre null
        /// </summary>
        [DataMember]
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
        /// wrapper de Genres
        /// </summary>
        public ReadOnlyCollection<GenreGlobal> GenresR { get; private set; }

        /// <summary>
        /// liste tout les genres auquel appartient l'instance
        /// </summary>
        [DataMember]
        private List<GenreGlobal> Genres
        {
            get => _genre;

            set
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
        private List<GenreGlobal> _genre = new List<GenreGlobal>();

        /// <summary>
        /// correspond à un résumé du contenu vidéoludique, ne pouvant etre null ou empty
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// wrapper de OuRegarder
        /// </summary>
        public ReadOnlyCollection<Uri> OuRegarderR { get; private set; }

        /// <summary>
        /// répertorie tout les liens pour aller voir le contenu, ne pouvant être null
        /// </summary>
        [DataMember]
        private List<Uri> OuRegarder
        {
            get => _ouRegarder;

            set
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
        private List<Uri> _ouRegarder = new List<Uri>();

        /// <summary>
        /// wrapper de Audios
        /// </summary>
        public ReadOnlyCollection<Langues> AudiosR { get; set; }

        /// <summary>
        /// List<Langues> Audios référence toutes les langues disponibles en audio, ne pouvant etre null
        /// </summary>
        [DataMember]
        private List<Langues> Audios
        {
            get => _audios;

            set
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
        private List<Langues> _audios = new List<Langues>();

        /// <summary>
        /// wrapper de SousTitre
        /// </summary>
        public ReadOnlyCollection<Langues> SousTitresR { get; set; }

        /// <summary>
        /// List<Langues> SousTitres référence toutes les langues disponibles en sous-titres, ne pouvant etre null
        /// </summary>
        [DataMember]
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
        private List<Langues> _sousTitres = new List<Langues>();

        /// <summary>
        /// Uri Image indique le chemin vers l'illustration du contenu
        /// </summary>
        [DataMember]
        public string Image { get; set; }

        /// <summary>
        /// Constructeur de la classe ContenuVideoludique
        /// </summary>
        /// <param name="titre">Intitulé du Contenu</param>
        /// <param name="date">date de sortie du contenu vidéoludique</param>
        /// <param name="duree">durée du contenu</param>
        /// <param name="realisateur">Réalisateur du contenu</param>
        /// <param name="genres">représentant la liste des genres auquel appartient le contenur</param>
        /// <param name="image">image d'illustration du contenu</param>
        public ContenuVideoludique(string titre, DateTime date, TimeSpan duree, string realisateur,
            IEnumerable<GenreGlobal> genres, string image)
        {
            Titre = titre;
            Date = date;
            Duree = duree;
            Realisateur = realisateur;
            StudioProduction = "";
            Genres = new List<GenreGlobal>(genres);
            GenresR = new ReadOnlyCollection<GenreGlobal>(Genres);

            Description = "";
            OuRegarder = new List<Uri>();
            OuRegarderR = new ReadOnlyCollection<Uri>(OuRegarder);

            Audios = new List<Langues>();
            AudiosR = new ReadOnlyCollection<Langues>(Audios);

            SousTitres = new List<Langues>();
            SousTitresR = new ReadOnlyCollection<Langues>(SousTitres);

            Image = image;
        }

        /// <summary>
        /// Constructeur de la classe ContenuVideoludique
        /// </summary>
        /// <param name="titre">Intitulé du Contenu</param>
        /// <param name="date">date de sortie du contenu vidéoludique</param>
        /// <param name="duree">durée du contenu</param>
        /// <param name="realisateur">Réalisateur du contenu</param>
        /// <param name="studioProd">Studio ayant produit le contenu</param>
        /// <param name="genres">représente la liste des genres auquel appartient le contenur</param>
        /// <param name="description">présente un résumé du contenu</param>
        /// <param name="image">image d'illustration du contenu</param>
        public ContenuVideoludique(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd,
            IEnumerable<GenreGlobal> genres, string description, string image)
        {
            Titre = titre;
            Date = date;
            Duree = duree;
            Realisateur = realisateur;
            StudioProduction = studioProd;
            Genres = new List<GenreGlobal>(genres);
            GenresR = new ReadOnlyCollection<GenreGlobal>(Genres);

            Description = description;
            OuRegarder = new List<Uri>();
            OuRegarderR = new ReadOnlyCollection<Uri>(OuRegarder);

            Audios = new List<Langues>();
            AudiosR = new ReadOnlyCollection<Langues>(Audios);

            SousTitres = new List<Langues>();
            SousTitresR = new ReadOnlyCollection<Langues>(SousTitres);

            Image = image;
        }

        /// <summary>
        /// Constructeur de la classe ContenuVideoludique
        /// </summary>
        /// <param name="titre">Intitulé du Contenu</param>
        /// <param name="date">date de sortie du contenu vidéoludique</param
        /// <param name="duree">durée du contenu</param>
        /// <param name="realisateur">Réalisateur du contenu</param>
        /// <param name="studioProd">Studio ayant produit le contenu</param>
        /// <param name="genres">représente la liste des genres auquel appartient le contenur</param>
        /// <param name="description">présente un résumé du contenu</param>
        /// <param name="ouRegarder">liste les sites où l'on peut regarder ce contenu</param>
        /// <param name="audios">listd les langues disponibles pour l'audio du contenu</param>
        /// <param name="sousTitres">liste les langues disponibles pour les sous-titres du contenu</param>
        /// <param name="image">image d'illustration du contenu</param>
        public ContenuVideoludique(string titre, DateTime date, TimeSpan duree, string realisateur, string studioProd, IEnumerable<GenreGlobal> genres,
            string description, IEnumerable<Uri> ouRegarder, IEnumerable<Langues> audios, IEnumerable<Langues> sousTitres, string image)
        {
            Titre = titre;
            Date = date;
            Duree = duree;
            Realisateur = realisateur;
            StudioProduction = studioProd;
            Genres = new List<GenreGlobal>(genres);
            GenresR = new ReadOnlyCollection<GenreGlobal>(Genres);

            Description = description;
            OuRegarder = new List<Uri>(ouRegarder);
            OuRegarderR = new ReadOnlyCollection<Uri>(OuRegarder);

            Audios = new List<Langues>(audios);
            AudiosR = new ReadOnlyCollection<Langues>(Audios);

            SousTitres = new List<Langues>(sousTitres);
            SousTitresR = new ReadOnlyCollection<Langues>(SousTitres);

            Image = image;
        }

        /// <summary>
        /// Détermine si l'instance passée en paramètre et celle de la méthode sont identiques
        /// </summary>
        /// <param name="obj">Une instance a comparer avec l'instance de l'objet</param>
        /// <returns>true si les deux instances sont égales, false sinon</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            return ReferenceEquals(obj, this) || (obj is ContenuVideoludique cv && Equals(cv));
        }

        /// <summary>
        /// Détermine si l'instance de classe ContenuVideoludique passée en paramètre et celle de la méthode sont identiques
        /// </summary>
        /// <param name="other">Une instance de la classe ContenuVideoludique, a comparer avec l'instance de l'objet</param>
        /// <returns>true si les deux instances sont égales, false sinon</returns>
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
        /// <returns>un intreprésentant l'instance sous une représentation numérique</returns>
        public override int GetHashCode()
        {
            return ((Titre.GetHashCode() * 7) + (Date.GetHashCode() * 3) + (Duree.GetHashCode() * 21)
                + (Realisateur.GetHashCode() * 31) + (StudioProduction.GetHashCode() * 2) + (Image.GetHashCode() * 3)
                + (Description.GetHashCode() * 3) + (OuRegarder.Sum(u => u.GetHashCode()) * 2)
                + (Audios.Sum(l => l.GetHashCode()) * 5) + (SousTitres.Sum(l => l.GetHashCode()) * 2)) * 3;
        }

    }
}
