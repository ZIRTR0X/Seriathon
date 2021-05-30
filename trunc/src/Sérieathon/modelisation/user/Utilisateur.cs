using modelisation.content;
using modelisation.content.episodique;
using modelisation.genres;
using System;
using System.Collections.Generic;
using System.Linq;


namespace modelisation.user
{
    public class Utilisateur
    {
        /// <summary>
        /// static long permet d'identifier de manière unique un utilisateur, notamment utile pour le nom par défaut, mais permet un même pseudo 
        /// </summary>
        private static long Identifiant { get; set; }

        /// <summary>
        /// string pseudonyme de l'utilisateur
        /// </summary>
        public string Pseudo
        {
            get => _pseudo;

            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    _pseudo = $"Utilisateur{Identifiant}";
                }
                else
                {
                    _pseudo = value;
                }
            }
        }
        private string _pseudo;

        /// <summary>
        /// string mot de passe de l'utilisateur
        /// </summary>
        public string Password
        {
            get => _password;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _password = "1234";
                }
                else
                {
                    _password = value;
                }
            }
        }
        private string _password;

        /// <summary>
        /// string email de l'utilisateur
        /// </summary>
        public string Email
        {
            get => _email;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _email = "email inconnu";
                }
                else
                {
                    _email = value;
                }
            }
        }
        private string _email;

        /// <summary>
        /// int représentant l'age de la personne
        /// </summary>
        public DateTime DateDeNaissance
        {
            get => _dateDeNaissance;

            private set
            {
                if (value.CompareTo(new DateTime(1900, 1, 1)) <= 0)
                {
                    _dateDeNaissance = DateTime.Today;
                }
                else
                {
                    _dateDeNaissance = value;
                }
            }
        }
        private DateTime _dateDeNaissance;

        /// <summary>
        /// string spécifie le genre de l'utilisateur
        /// </summary>
        public string Genre
        {
            get => _genre;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _genre = "Genre non spécifié";
                }
                else
                {
                    _genre = value;
                }
            }
        }
        private string _genre;

        /// <summary>
        /// LinkedList<ContenuVideoludique> liste tout les contenus marqués comme déjà vu par l'utilisateur
        /// </summary>
        public LinkedList<ContenuVideoludique> ListCVvu
        {
            get => _listCVvu;

            private set
            {
                if (value is null)
                {
                    _listCVvu = new LinkedList<ContenuVideoludique>();
                }
                else
                {
                    _listCVvu = value;
                }
            }
        }
        private LinkedList<ContenuVideoludique> _listCVvu;

        //propriétée calculée

        public int Age => new DateTime((DateTime.Today - DateDeNaissance).Ticks).Year;

        /// <summary>
        /// int nombre de contenu vidéoludique vu par l'utilisateur
        /// </summary>
        public int NbContenuVu => ListCVvu.Count;

        /// <summary>
        /// int nombre de films vus par l'utilisateur
        /// </summary>
        public int NbFilmVu => ListCVvu.Count(c => c is Film);

        /// <summary>
        /// int nombre de séries vues par l'utilisateur
        /// </summary>
        public int NbSerieVu => ListCVvu.Count(c => c is Serie && !(c is Anime));

        /// <summary>
        /// int nombre d'animes vus par l'utilisateur
        /// </summary>
        public int NbAnimeVu => ListCVvu.Count(c => c is Anime);

        /// <summary>
        /// Constructeur de la classe Utilisateur, sans paramètre
        /// </summary>
        public Utilisateur()
        {
            Pseudo = "";
            Password = "";
            Email = "";
            DateDeNaissance = new DateTime(0);
            Genre = null;
            ListCVvu = new LinkedList<ContenuVideoludique>();
        }

        /// <summary>
        /// Constructeur de la classe Utilisateur, avec une liste de contenu vu vide
        /// </summary>
        /// <param name="pseudo"></param> string pseudo du nouvel utilisateur, ne pouvant etre null, ou uniquement fait d'espaces
        /// <param name="password"></param> string mot de passe du nouvel utilisateur, ne pouvant etre null, ou uniquement fait d'espaces
        /// <param name="email"></param> string email du nouvel utilsateur, ne pouvant etre null, ou uniquement fait d'espaces
        /// <param name="dateDeNaissance"></param> spécifie la date de naissance de l'utilisateur, ne pouvant etre antérieure à 1900
        /// <param name="genre"></param> string genre de l'utilisateur, ne pouvant etre null, ou uniquement fait d'espaces
        public Utilisateur(string pseudo, string password, string email, DateTime dateDeNaissance, string genre)
        {
            Pseudo = pseudo;
            Password = password;
            Email = email;
            DateDeNaissance = dateDeNaissance;
            Genre = genre;
            ListCVvu = new LinkedList<ContenuVideoludique>();
        }

        /// <summary>
        /// Constructeur de la classe Utilisateur, avec une liste de contenu vu initié avec une liste déjà existante
        /// </summary>
        /// <param name="pseudo"></param> string pseudo du nouvel utilisateur, ne pouvant etre null, ou uniquement fait d'espaces
        /// <param name="password"></param> string mot de passe du nouvel utilisateur, ne pouvant etre null, ou uniquement fait d'espaces
        /// <param name="email"></param> string email du nouvel utilsateur, ne pouvant etre null, ou uniquement fait d'espaces
        /// <param name="dateDeNaissance"></param> spécifie la date de naissance de l'utilisateur, ne pouvant etre antérieure à 1900
        /// <param name="genre"></param> string genre de l'utilisateur, ne pouvant etre null, ou uniquement fait d'espaces
        /// <param name="listCVvu"></param> LinkedList<ContenuVideoludique> listant tout le contenu déjà vu par l'utilisateur, ne pouvant etre null
        public Utilisateur(string pseudo, string password, string email, DateTime dateDeNaissance, string genre, LinkedList<ContenuVideoludique> listCVvu)
        {
            Pseudo = pseudo;
            Password = password;
            Email = email;
            DateDeNaissance = dateDeNaissance;
            Genre = genre;
            ListCVvu = listCVvu;
        }

        /// <summary>
        /// Ajoute un contenu comme vu, donc à la liste ListCVvu
        /// </summary>
        /// <param name="c"></param> le contenu vidéoludique à ajouter comme vu
        /// <returns>bool false si jamais l'ajout n'a pu se faire car c est déjà contenu, et true si c est ajouté</returns>
        public bool AjouterCommeVu(ContenuVideoludique c)
        {
            if (ListCVvu.Contains(c))
            {
                return false;
            }
            else
            {
                ListCVvu.AddLast(c);
                return true;
            }
        }

        /// <summary>
        /// Supprime un contenu de la liste des vus, donc de la liste ListCVvu
        /// </summary>
        /// <param name="c"></param> le contenu vidéoludique à supprimer de la liste des vu
        /// <returns>bool false si jamais la suppression n'a pu se faire car c est déjà contenu, et true si c est supprimé</returns>
        public bool EnleverCommeVu(ContenuVideoludique c)
        {
            return ListCVvu.Remove(c);
        }

        /// <summary>
        /// Peremt de récuperer la liste des films déjà vu par l'utilisateur
        /// </summary>
        /// <returns>IEnumerable<Film> liste des films déjà vu par cet utilisateur</returns>
        public IEnumerable<Film> GetListFilmsVu()
        {
            return (IEnumerable<Film>)ListCVvu.Where(c => c is Film);
        }

        public IEnumerable<Serie> GetListSeriesVu()
        {
            return ListCVvu.Where(c => c is Serie && !(c is Anime)) as IEnumerable<Serie>;
        }

        /// <summary>
        /// Peremt de récuperer la liste des animes déjà vu par l'utilisateur
        /// </summary>
        /// <returns>IEnumerable<Anime> liste des animes déjà vu par cet utilisateur</returns>
        public IEnumerable<Anime> GetListAnimeVu()
        {
            return ListCVvu.Where(c => c is Anime) as IEnumerable<Anime>;
        }

        /// <summary>
        /// Permet de récupérer le nombre de contenus vu contenant le genre global demandé
        /// </summary>
        /// <param name="g"></param> GenreGolobal commun à tout les éléments dénombré
        /// <returns>int nombre de contenu vus possédant le genre spécifié</returns>
        public int GetNbGenreGlobalVu(GenreGlobal g)
        {
            return ListCVvu.Count(c => c.Genres.Contains(g));
        }

        /// <summary>
        /// Permet de récupérer le nombre de contenu vu contenant le genre global demandé
        /// </summary>
        /// <param name="g"></param> GenreGlobal commun à tout les éléments dénombré
        /// <returns>int nombre de contenus vus possédant le genre spécifié</returns>
        public IEnumerable<ContenuVideoludique> GetListGenreGlobalVu(GenreGlobal g)
        {
            return ListCVvu.Where(c => c.Genres.Contains(g));
        }

        /// <summary>
        /// Permet de récupérer le nombre d'animes vu contenant le genre d'animes demandé
        /// </summary>
        /// <param name="a"></param> GenreAnime commun à tout les éléments dénombré
        /// <returns>int nombre d'animes vus possédant le genre spécifié</returns>
        public int GetNbGenreAnimeVu(GenreAnime a)
        {
            return ListCVvu.Count(c => c is Anime an && an.GenreAnimes.Contains(a));
        }

        /// <summary>
        /// Permet de récupérer une liste d'anime contenant le genre d'anime demandé
        /// </summary>
        /// <param name="a"></param> GenreAnime commun à tout les éléments de la liste
        /// <returns>IEnumerable<Anime> liste des animes possédant le genre spécifié</returns>
        public IEnumerable<Anime> GetListGenreAnimeVu(GenreAnime a)
        {
            return ListCVvu.Where(c => c is Anime an && an.GenreAnimes.Contains(a)) as IEnumerable<Anime>;
        }
    }
}
