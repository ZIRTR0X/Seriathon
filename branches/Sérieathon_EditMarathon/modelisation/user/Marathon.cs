using modelisation.content;
using modelisation.content.episodique;
using modelisation.genres;
using modelisation.usefull_interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace modelisation.user
{
    /// <summary>
    /// represente la liste de suggestions de contenus à voir, selon une duree maximale, et des genres voulus
    /// </summary>
    [DataContract]
    public class Marathon
    {
        [OnDeserialized]
        void InitReadOnly(StreamingContext sc = new StreamingContext())
        {
            ListContenuR = new ReadOnlyCollection<IEstAjoutableAuMarathon>(ListContenu);
            ListContenuJournalifieR = new ReadOnlyCollection<List<IEstAjoutableAuMarathon>>(ListContenuJournalifie);
            GenresAnimes_possiblesR = new ReadOnlyDictionary<GenreAnime, List<Anime>>(GenresAnimes_possibles);
            GenresGlobaux_possiblesR = new ReadOnlyDictionary<GenreGlobal, List<ContenuVideoludique>>(GenresGlobaux_possibles);
        }

        /// <summary>
        /// Duree du marathon
        /// </summary>
        [DataMember]
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

        [DataMember]
        public int NbJour
        {
            get => _nbJour;

            private set
            {
                if(value <= 0)
                {
                    _nbJour = 1;
                }
                else
                {
                    _nbJour = value;
                }
            }
        }
        private int _nbJour;

        [DataMember]
        public int NbHeureParJour
        {
            get => _nbHeureParJour;

            private set
            {
                if (value <= 0)
                {
                    _nbHeureParJour = 1;
                }
                else
                {
                    _nbHeureParJour = value;
                }
            }
        }
        private int _nbHeureParJour;

        /// <summary>
        /// wrapper ListContenu
        /// </summary>
        public ReadOnlyCollection<IEstAjoutableAuMarathon> ListContenuR { get; set; }

        /// <summary>
        /// liste des contenues composant la liste de lecture du marathon
        /// </summary>
        [DataMember]
        private List<IEstAjoutableAuMarathon> ListContenu
        {
            get => _listContenu;

            set
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
        private List<IEstAjoutableAuMarathon> _listContenu = new List<IEstAjoutableAuMarathon>();

        public ReadOnlyCollection<List<IEstAjoutableAuMarathon>> ListContenuJournalifieR { get; private set; }

        [DataMember]
        private List<List<IEstAjoutableAuMarathon>> ListContenuJournalifie { get; set; } = new List<List<IEstAjoutableAuMarathon>>();

        /// <summary>
        /// wrapper de GenresGlobaux_possibles
        /// </summary>
        public ReadOnlyDictionary<GenreGlobal, List<ContenuVideoludique>> GenresGlobaux_possiblesR { get; private set; }

        /// <summary>
        /// La liste de tous les types globaux ajoutables et leur liste de contenu vidéoludique
        /// </summary>
        [DataMember]
        private Dictionary<GenreGlobal, List<ContenuVideoludique>> GenresGlobaux_possibles
        {
            get => _genresGlobaux_possibles;

            set
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
        private Dictionary<GenreGlobal, List<ContenuVideoludique>> _genresGlobaux_possibles = new Dictionary<GenreGlobal, List<ContenuVideoludique>>();

        /// <summary>
        /// wrapper de GenresAnimes_possibles
        /// </summary>
        public ReadOnlyDictionary<GenreAnime, List<Anime>> GenresAnimes_possiblesR { get; private set; }

        /// <summary>
        /// La liste de tous les types d'animes ajoutables et leur liste d'animes
        /// </summary>
        [DataMember]
        private Dictionary<GenreAnime, List<Anime>> GenresAnimes_possibles
        {
            get => _genresAnimes_possibles;

            set
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
        private Dictionary<GenreAnime, List<Anime>> _genresAnimes_possibles = new Dictionary<GenreAnime, List<Anime>>();

        public Marathon(int nbJour, int nbHeureParJour)
        {
            NbJour = nbJour;
            NbHeureParJour = nbHeureParJour;
            Duree = new TimeSpan((nbJour * nbHeureParJour), 0, 0);
            ListContenu = new List<IEstAjoutableAuMarathon>();
            ListContenuR = new ReadOnlyCollection<IEstAjoutableAuMarathon>(ListContenu);

            ListContenuJournalifie = new List<List<IEstAjoutableAuMarathon>>();
            ListContenuJournalifieR = new ReadOnlyCollection<List<IEstAjoutableAuMarathon>>(ListContenuJournalifie);

            GenresAnimes_possibles = new Dictionary<GenreAnime, List<Anime>>();
            GenresAnimes_possiblesR = new ReadOnlyDictionary<GenreAnime, List<Anime>>(GenresAnimes_possibles);

            GenresGlobaux_possibles = new Dictionary<GenreGlobal, List<ContenuVideoludique>>();
            GenresGlobaux_possiblesR = new ReadOnlyDictionary<GenreGlobal, List<ContenuVideoludique>>(GenresGlobaux_possibles);

        }

        /// <summary>
        /// permet de récuperer une liste de liste, chaque sous liste représentant les contenus a voir sur une journée
        /// </summary>
        /// <returns>une liste de liste de IEstAjoutableAuMarathon</returns>
        public List<List<IEstAjoutableAuMarathon>> getListJournalifie()
        {
            List<List<IEstAjoutableAuMarathon>> rendu = new List<List<IEstAjoutableAuMarathon>>();
            List<IEstAjoutableAuMarathon> copie = new List<IEstAjoutableAuMarathon>(ListContenu);
            TimeSpan dureeMaxJour = new TimeSpan(NbHeureParJour, 0, 0);

            while (copie.Count != 0)
            {
                List<IEstAjoutableAuMarathon> list_jour = new List<IEstAjoutableAuMarathon>();
                TimeSpan duree_jour = new TimeSpan(0);

                while(duree_jour < dureeMaxJour && copie.Count > 0)
                {
                    list_jour.Add(copie[0]);
                    if(copie[0] is Film f) { duree_jour = duree_jour.Add(f.Duree); }
                    if(copie[0] is Episode e) { duree_jour = duree_jour.Add(e.DureeEpisode); }
                    copie.RemoveAt(0);
                }
                rendu.Add(list_jour);
            }

            return rendu;
        }

        /// <summary>
        /// permet de remplacer de manière aléatoire un des contenus de la liste
        /// </summary>
        /// <param name="e">élément à remplacer</param>
        /// <returns>false si le contenu n'a pas été échangé</returns>
        public bool RemplacerContenu(IEstAjoutableAuMarathon e)
        {
            // si jamais l'élément n'existe pas, ou qu'il n'y a plus rien a ajouter dans la liste, on ne fait rien
            if (!ListContenu.Contains(e) || (GenresGlobaux_possibles.Count == 0 && GenresAnimes_possibles.Count == 0)) { return false; }

            int index_insert = ListContenu.IndexOf(e);
            int choix = 0;

            ListContenu.Remove(e);

            // ajout du nouvel aléatoire
            Random rand = new Random();
            choix = rand.Next(2);
            if (choix == 0 && GenresGlobaux_possibles.Count != 0)
            {
                List<ContenuVideoludique> listRand = GenresGlobaux_possibles.ElementAt(rand.Next(GenresGlobaux_possibles.Count)).Value;
                ContenuVideoludique CVrand = listRand[rand.Next(listRand.Count)];

                // peut etre soit un film soit une serie
                if(CVrand is Film f)
                {
                    ListContenu.Insert(index_insert, f);
                }
                else if(CVrand is Serie s)
                {
                    // j'ajoute uniquement un épisode
                    ListContenu.Insert(index_insert, s.ListSaisonsR[0].ListEpisodesR[0]);

                    if(s is Anime a)
                    {
                        // dans ce cas il faut aussi supprimer la ref si elle existe dans l'autre dictio
                        foreach(List<Anime> l in GenresAnimes_possibles.Values)
                        {
                            l.Remove(a);
                        }
                    }
                }

                // on supprime l'élément de partout
                foreach (List<ContenuVideoludique> l in GenresGlobaux_possibles.Values)
                {
                    l.Remove(CVrand);
                }
            }
            else if (GenresAnimes_possibles.Count != 0 && choix == 1)
            {
                // dans ce cas je tire un anime
                List<Anime> listRand = GenresAnimes_possibles.ElementAt(rand.Next(GenresAnimes_possibles.Count)).Value;
                Anime Animrand = listRand[rand.Next(listRand.Count)];

                ListContenu.Insert(index_insert, Animrand.ListSaisonsR[0].ListEpisodesR[0]);

                foreach(List<Anime> l in GenresAnimes_possibles.Values)
                {
                    l.Remove(Animrand);
                }
                foreach(List<ContenuVideoludique> l in GenresGlobaux_possibles.Values)
                {
                    l.Remove(Animrand);
                }

            }
            else
            {
                // je n'ai pas tiré ce que je voulais originnellement, donc un des dictios est vide, je regarde juste celui qui est non vide
                if (GenresGlobaux_possibles.Count != 0)
                {
                    List<ContenuVideoludique> listRand = GenresGlobaux_possibles.ElementAt(rand.Next(GenresGlobaux_possibles.Count)).Value;
                    ContenuVideoludique CVrand = listRand[rand.Next(listRand.Count)];

                    // peut etre soit un film soit une serie

                    if (CVrand is Film f)
                    {
                        ListContenu.Insert(index_insert, f);
                    }
                    else if (CVrand is Serie s)
                    {
                        // j'ajoute uniquement un épisode
                        ListContenu.Insert(index_insert, s.ListSaisonsR[0].ListEpisodesR[0]);

                        if (s is Anime a)
                        {
                            // dans ce cas il faut aussi supprimer la ref si elle existe dans l'autre dictio
                            foreach (List<Anime> l in GenresAnimes_possibles.Values)
                            {
                                l.Remove(a);
                            }
                        }
                    }

                    // on supprime l'élément de partout
                    foreach (List<ContenuVideoludique> l in GenresGlobaux_possibles.Values)
                    {
                        l.Remove(CVrand);
                    }
                }

                else if (GenresAnimes_possibles.Count != 0)
                {
                    List<Anime> listRand = GenresAnimes_possibles.ElementAt(rand.Next(GenresAnimes_possibles.Count)).Value;
                    Anime Animrand = listRand[rand.Next(listRand.Count)];

                    ListContenu.Insert(index_insert, Animrand.ListSaisonsR[0].ListEpisodesR[0]);

                    foreach (List<Anime> l in GenresAnimes_possibles.Values)
                    {
                        l.Remove(Animrand);
                    }
                    foreach (List<ContenuVideoludique> l in GenresGlobaux_possibles.Values)
                    {
                        l.Remove(Animrand);
                    }
                }
                else return false; // cette condition ne peut etre reach, mais je la spécifie tout de meme
            }


            foreach (KeyValuePair<GenreGlobal, List<ContenuVideoludique>> kp in GenresGlobaux_possibles)
            {
                // si jamais l'une des listes vaut 0, on supprime direct la paire, pour éviter une exception sur le random au prochain
                // passage
                if (kp.Value.Count == 0)
                {
                    GenresGlobaux_possibles.Remove(kp.Key);
                }
            }

            foreach (KeyValuePair<GenreAnime, List<Anime>> kp in GenresAnimes_possibles)
            {
                if (kp.Value.Count == 0)
                {
                    GenresAnimes_possibles.Remove(kp.Key);
                }
            }


            return true;
        }

        /// <summary>
        /// tente d'ajouter le contenuVideoludique c à la liste des suggestions (méthode dépréciée dans notre contexte)
        /// </summary>
        /// <param name="c">le contenu vidéoludique a ajouter a la liste de suggestions</param>
        /// <returns>false si le contenu est déjà présent, true si il a été ajouté</returns>
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

        /// <summary>
        /// tente de supprimer un contenuVideoludique c de la liste des suggestions
        /// </summary>
        /// <param name="c">le contenu vidéoludique a supprimer de la liste de suggestions</param>
        /// <returns>false si le contenu n'est pas présent dans la liste, true si il a été supprimé</returns>
        public bool EnleverContenu(ContenuVideoludique c)
        {
            return ListContenu.Remove(c);
        }


        // module de génération d'un marathon pour l'application

        /// <summary>
        /// ajoute un thème global de marathon en clé du dictionnaire de themes globaux possibles, ainsi que la liste des contenu possédant
        /// ce genre dans leur liste de genres globaux
        /// </summary>
        /// <param name="g">genre global à tenter d'ajouter comme thème</param
        /// <param name="m">manager du systeme, répertoriant tout les contenus vidéoludique de l'application</param>
        /// <returns>false si jamais g est déjà présent dans le dictionnaire, true s'il a été ajouté</returns>
        public bool AddThemeGlobal(GenreGlobal g, Manager m)
        {
            //return GenresGlobaux_possibles.TryAdd(g, m.ListCV.Where(c => c.Genres.Contains(g)));
            // je préfère imédiatement tester la présence de la clé, pour éviter si déjà présente de faire l'attribution en mémoire de la listeEpisode
            if (GenresGlobaux_possibles.ContainsKey(g)) return false;


            GenresGlobaux_possibles.Add(g, new List<ContenuVideoludique>(m.ListCVR.Where(c => c.GenresR.Contains(g))));
            return true;
        }

        /// <summary>
        /// ajoute un thème d'anime de marathon en clé du dictionnaire de themes d'animes possibles, ainsi que la liste des animes possédant
        /// ce genre dans leur liste de genres d'animes
        /// </summary>
        /// <param name="a">genre d'anime à tenter d'ajouter comme thème</param>
        /// <param name="m">manager du systeme, répertoriant tout les contenus vidéoludique de l'application</param>
        /// <returns>false si jamais a est déjà présent dans le dictionnaire, true s'il a été ajouté</returns>
        public bool AddThemeAnime(GenreAnime a, Manager m)
        {
            //return GenresAnimes_possibles.TryAdd(a, m.ListCV.Where(c => c is Anime an && an.GenreAnimes.Contains(a)) as IEnumerable<Anime>);
            if (GenresAnimes_possibles.ContainsKey(a)) return false;

            List<Anime> listeAnime = new List<Anime>(m.ListCVR.Where(c => c is Anime an && an.GenreAnimesR.Contains(a)).Cast<Anime>());

            GenresAnimes_possibles.Add(a, listeAnime);
            return true;
        }

        /// <summary>
        /// permet d'ajouter un film a la liste de suggestions
        /// </summary>
        /// <param name="f">film à ajouter a la liste des suggestions</param>
        /// <param name="duree_restante">la duree qui reste a combler, décrémentée dans la fonction</param>
        /// <returns>false si la durée restante est égale ou inférieur à 0, ou bien si f est déjà présent. Renvoit true sinon, f
        /// est ajouté</returns>
        private bool AddFilmLecture(Film f, ref TimeSpan duree_restante)
        {
            if (ListContenu.Contains(f) || duree_restante.Ticks <= 0) return false;

            ListContenu.Add(f);
            duree_restante -= f.Duree;
            return true;
        }

        /// <summary>
        /// permet d'ajouter des épisodes d'une série (ou anime) a la liste de suggestions, au nombre max de 3
        /// </summary>
        /// <param name="s">série dont les épisodes sont a ajouté</param>
        /// <param name="duree_restante">la duree qui reste a combler, décrémentée dans la fonction</param>
        /// <returns>false si la durée restante est égale ou inférieur à 0, ou bien si s est déjà présent. Renvoit true sinon, s
        /// est ajouté</returns>
        private bool AddEpisodeLecture(Serie s, ref TimeSpan duree_restante)
        {
            if (ListContenu.Contains(s) || duree_restante.Ticks <= 0) return false;

            // je m'arrange pour dépasser un minimum la limite de temps
            ListContenu.AddRange(s.RecepurerListEpisode(ref duree_restante));

            return true;
        }

        /// <summary>
        /// permet de créer de manière random la liste de suggestion, dans la limite de la Duree (au maximum majorée de la durée du
        /// dernier film ou épisode ajouté, et aussi en respectant les themes globaux et d'animes possibles, dicté par les dictionnaires
        /// </summary>
        public void CreerListeLecturePartial()
        {
            // pour générer des nombres aléatoires, afin de choisir aléatoirement des themes et contenu à ajouter
            Random random = new Random();
            TimeSpan duree_restante = new TimeSpan(Duree.Ticks);

            while(duree_restante.Ticks > 0) // tant que le temps restant a combler est positif
            {
                int random_courant = random.Next(2); // génère un semblant de booléen aléatoire, un int de 0 ou 1, a récupérer car on veut la même valeur pour le choix

                // a chaque itération, je supprime les clé-valeur dont la liste en valeur ne possède plus rien, pour éviter les indexOutOfRange

                foreach (KeyValuePair<GenreGlobal, List<ContenuVideoludique>> kp in GenresGlobaux_possibles)
                {
                    // si jamais l'une des listes vaut 0, on supprime direct la paire, pour éviter une exception sur le random au prochain
                    // passage
                    if (kp.Value.Count == 0)
                    {
                        GenresGlobaux_possibles.Remove(kp.Key);
                    }
                }

                foreach(KeyValuePair<GenreAnime, List<Anime>> kp in GenresAnimes_possibles)
                {
                    if(kp.Value.Count == 0)
                    {
                        GenresAnimes_possibles.Remove(kp.Key);
                    }
                }

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
                            foreach (List<Anime> l in GenresAnimes_possibles.Values)
                            {
                                l.Remove(selection_random);
                            }
                            foreach (List<ContenuVideoludique> l in GenresGlobaux_possibles.Values)
                            {
                                l.Remove(selection_random as ContenuVideoludique);
                            }
                        }



                    }
                    else if (random_courant == 1 && GenresGlobaux_possibles.Count != 0)
                    {
                        List<ContenuVideoludique> value_random = GenresGlobaux_possibles.ElementAt(random.Next(GenresAnimes_possibles.Count)).Value;
                        ContenuVideoludique selection_random = value_random[random.Next(value_random.Count)];

                        if (selection_random is Film fi && AddFilmLecture(fi, ref duree_restante))
                        {
                            foreach (List<ContenuVideoludique> l in GenresGlobaux_possibles.Values)
                            {
                                l.Remove(selection_random);
                            }
                        }
                        else if (selection_random is Serie s && AddEpisodeLecture(s, ref duree_restante))
                        {
                            foreach (List<ContenuVideoludique> l in GenresGlobaux_possibles.Values)
                            {
                                l.Remove(selection_random);
                            }

                            if (s is Anime a)
                            {
                                foreach (List<Anime> l in GenresAnimes_possibles.Values)
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
                    else return;
                }

            }

        }

        public void CreerListeLecture()
        {
            CreerListeLecturePartial();
            ListContenuJournalifie = getListJournalifie();
            ListContenuJournalifieR = new ReadOnlyCollection<List<IEstAjoutableAuMarathon>>(ListContenuJournalifie);
        }
    }
}
