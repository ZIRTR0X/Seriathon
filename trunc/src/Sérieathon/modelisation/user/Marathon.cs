using modelisation.content;
using modelisation.content.episodique;
using modelisation.genres;
using modelisation.usefull_interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace modelisation.user
{
    public class Marathon
    {
        /// <summary>
        /// TimeSpan Duree du marathon
        /// </summary>
        public TimeSpan Duree
        {
            get => _duree;

            private set
            {
                if(value.CompareTo(new TimeSpan(0)) <= 0)
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
        /// LinkedList<ContenuVideoludique> liste des contenues composant la liste de lecture du marathon
        /// </summary>
        public List<IEstAjoutableAuMarathon> ListContenu
        {
            get => _listContenu;

            private set
            {
                if(value is null)
                {
                    _listContenu = new List<IEstAjoutableAuMarathon>();
                } else
                {
                    _listContenu = value;
                }
            }
        }
        private List<IEstAjoutableAuMarathon> _listContenu;

        /// <summary>
        /// La liste de tous les types possibles et leur liste de contenu vidéoludique
        /// </summary>
        public Dictionary<GenreGlobal, List<ContenuVideoludique>> GenresGlobaux_possibles
        {
            get => _genresGlobaux_possibles;

            private set
            {
                if(value is null)
                {
                    _genresGlobaux_possibles = new Dictionary<GenreGlobal, List<ContenuVideoludique>>();
                } else
                {
                    _genresGlobaux_possibles = value;
                }
            }
        }
        private Dictionary<GenreGlobal, List<ContenuVideoludique>> _genresGlobaux_possibles;

        public Dictionary<GenreAnime, List<Anime>> GenresAnimes_possibles
        {
            get => _genresAnimes_possibles;

            private set
            {
                if(value is null)
                {
                    _genresAnimes_possibles = new Dictionary<GenreAnime, List<Anime>>();
                } else
                {
                    _genresAnimes_possibles = value;
                }
            }
        }
        private Dictionary<GenreAnime, List<Anime>> _genresAnimes_possibles;

        public Marathon(int nbJour, int nbHeureParJour)
        {
            Duree = new TimeSpan((nbJour * nbHeureParJour), 0, 0);
            ListContenu = new List<IEstAjoutableAuMarathon>();
            GenresAnimes_possibles = new Dictionary<GenreAnime, List<Anime>>();
            GenresGlobaux_possibles = new Dictionary<GenreGlobal, List<ContenuVideoludique>>();
        }

        public Marathon(TimeSpan duree)
        {
            Duree = duree;
            ListContenu = new List<IEstAjoutableAuMarathon>();
            GenresAnimes_possibles = new Dictionary<GenreAnime, List<Anime>>();
            GenresGlobaux_possibles = new Dictionary<GenreGlobal, List<ContenuVideoludique>>();
        }

        public bool AjouterContenu(ContenuVideoludique c)
        {
            if(ListContenu.Contains(c))
            {
                return false;
            } else
            {
                ListContenu.Add(c);
                return true;
            }
        }

        public bool EnleverContenu(ContenuVideoludique c)
        {
            return ListContenu.Remove(c);
        }


        // module de génération d'un marathon pour l'application

        public bool AddThemeGlobal(GenreGlobal g, Manager m)
        {
            //return GenresGlobaux_possibles.TryAdd(g, m.ListCV.Where(c => c.Genres.Contains(g)));
            // je préfère imédiatement tester la présence de la clé, pour éviter si déjà présente de faire l'attribution en mémoire de la listeEpisode
            if (GenresGlobaux_possibles.ContainsKey(g)) return false;

            List<ContenuVideoludique> listeContenu = new List<ContenuVideoludique>(m.ListCV.Where(c => c.Genres.Contains(g)));

            GenresGlobaux_possibles.Add(g, listeContenu);
            return true;
        }

        public bool AddThemeAnime(GenreAnime a, Manager m)
        {
            //return GenresAnimes_possibles.TryAdd(a, m.ListCV.Where(c => c is Anime an && an.GenreAnimes.Contains(a)) as IEnumerable<Anime>);
            if (GenresAnimes_possibles.ContainsKey(a)) return false;

            List<Anime> listeAnime = new List<Anime>(m.ListCV.Where(c => c is Anime an && an.GenreAnimes.Contains(a)) as IEnumerable<Anime>);

            GenresAnimes_possibles.Add(a, listeAnime);
            return true;
        }

        private bool AddFilmLecture(Film f, ref TimeSpan duree_restante)
        {
            if (ListContenu.Contains(f)) return false;

            ListContenu.Add(f);
            duree_restante -= f.Duree;
            return true;
        }

        private bool AddEpisodeLecture(Serie s, ref TimeSpan duree_restante)
        {
            if (ListContenu.Contains(s)) return false;

            // je m'arrange pour dépasser un minimum la limite de temps
            ListContenu.AddRange(s.RecepurerListEpisode(ref duree_restante));

            return true;
        }

        public void CreerListeLecture()
        {
            // pour générer des nombres aléatoires, afin de choisir aléatoirement des themes et contenu à ajouter
            Random random = new Random();
            TimeSpan duree_restante = new TimeSpan(Duree.Ticks);

            while(duree_restante.Ticks > 0) // tant que le temps restant a combler est positif
            {
                int random_courant = random.Next(2); // génère un semblant de booléen aléatoire, un int de 0 ou 1, a récupérer car on veut la même valeur pour le choix

                if (random_courant == 0 && GenresGlobaux_possibles.Count != 0) // si ça vaut 0, j'ajoute un type Global a condition qu'il y en ai en theme de marathon
                {
                    // je peux ici avoir soit des séries (ou animes, mais ça ne change pas ), soit des films

                    // je récupère ici une value random, d'abord une value du dictio, puis un élément de la liste


                    List<ContenuVideoludique> value_random = GenresGlobaux_possibles.ElementAt(random.Next(GenresAnimes_possibles.Count)).Value;
                    ContenuVideoludique selection_random = value_random[random.Next(value_random.Count)];

                    if(selection_random is Film fi && AddFilmLecture(fi, ref duree_restante))
                    {
                        // dans ce cas, je veux supprimer toutes les références de ce film
                        foreach(List<ContenuVideoludique> l in GenresGlobaux_possibles.Values)
                        {
                            l.Remove(selection_random);
                        }

                    } else if(selection_random is Serie s && AddEpisodeLecture(s, ref duree_restante))
                    {
                        foreach(List<ContenuVideoludique> l in GenresGlobaux_possibles.Values)
                        {
                            l.Remove(selection_random); // enlève de tout les gens globaux
                        }
                        if(s is Anime a) // ici, la série peut etre un anime
                        {
                            foreach(List<Anime> l in GenresAnimes_possibles.Values)
                            {
                                l.Remove(a);
                            }
                        }

                    } else
                    {
                        continue;
                    }

                }
                else if (random_courant == 1 && GenresAnimes_possibles.Count != 0) // sinon ça vaut 1, j'ajoute un type d'anime,  a condition qu'il y en ai en theme de marathon
                {
                    // je suis sûr d'avoir des animes ici, je choisie d'abord une paire aléatoire (ElementAt est une méthode de Linq)

                    List<Anime> value_random = GenresAnimes_possibles.ElementAt(random.Next(GenresAnimes_possibles.Count)).Value;
                    Anime selection_random = value_random[random.Next(value_random.Count)]; // choisit un épisode aléatoire dans la liste de valeur possible
                    if(AddEpisodeLecture(selection_random, ref duree_restante))
                    {
                        foreach (List<Anime> l in GenresAnimes_possibles.Values)
                        {
                            l.Remove(selection_random);
                        }

                        foreach (List<ContenuVideoludique> l in GenresGlobaux_possibles.Values)
                        {
                            l.Remove(selection_random as ContenuVideoludique);
                        }
                    }

                } else
                {
                    // dans ce cas, l'un des deux dictionnaire est vide, donc on essaye de lancer la selection depuis l'autre dictionnaire

                    if (random_courant == 0 && GenresAnimes_possibles.Count != 0)
                    {
                        List<Anime> value_random = GenresAnimes_possibles.ElementAt(random.Next(GenresAnimes_possibles.Count)).Value;
                        Anime selection_random = value_random[random.Next(value_random.Count)];
                        if (AddEpisodeLecture(selection_random, ref duree_restante))
                        {
                            foreach(List<Anime> l in GenresAnimes_possibles.Values)
                            {
                                l.Remove(selection_random);
                            }
                            foreach(List<ContenuVideoludique> l in GenresGlobaux_possibles.Values)
                            {
                                l.Remove(selection_random as ContenuVideoludique);
                            }
                        }

                        

                    } else if (random_courant == 1 && GenresGlobaux_possibles.Count != 0)
                    {
                        List<ContenuVideoludique> value_random = GenresGlobaux_possibles.ElementAt(random.Next(GenresAnimes_possibles.Count)).Value;
                        ContenuVideoludique selection_random = value_random[random.Next(value_random.Count)];

                        if (selection_random is Film fi && AddFilmLecture(fi, ref duree_restante))
                        {
                            foreach(List<ContenuVideoludique> l in GenresGlobaux_possibles.Values)
                            {
                                l.Remove(selection_random);
                            }
                        }
                        else if (selection_random is Serie s && AddEpisodeLecture(s, ref duree_restante))
                        {
                            foreach(List<ContenuVideoludique> l in GenresGlobaux_possibles.Values)
                            {
                                l.Remove(selection_random);
                            }
                            
                            if(s is Anime a)
                            {
                                foreach(List<Anime> l in GenresAnimes_possibles.Values)
                                {
                                    l.Remove(a);
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else throw new InvalidOperationException("Créer une liste de lecture est impossible sans ajouter au préalable des thèmes (genres) pour ce marathon");
                }

            }

        }
    }
}
