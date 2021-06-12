using modelisation;
using modelisation.content;
using modelisation.content.episodique;
using modelisation.genres;
using modelisation.langues;
using modelisation.user;
using System;
using System.Collections.Generic;
using System.Text;
using static modelisation.genres.GenreGlobal;
using static modelisation.langues.Langues;

namespace persistance.StubPersist
{
    /// <summary>
    /// Chargement en dur des données
    /// </summary>
    public class Stub : IPersistanceManager
    {
        /// <summary>
        /// attribut donnant la référence vers le seul stub de l'application, pouvant etre null
        /// </summary>
        private static Stub _singleton;

        private Stub() { }

        public static Stub GetInstance()
        {
            if (_singleton is null) _singleton = new Stub();

            return _singleton;
        }

        public (IEnumerable<ContenuVideoludique>, IEnumerable<Utilisateur>) ChargeDonnees()
        {
            LinkedList<ContenuVideoludique> listCV = new LinkedList<ContenuVideoludique>();
            LinkedList<Utilisateur> listUtilisateur = new LinkedList<Utilisateur>();

            Uri TransformersStream = new Uri("https://www.netflix.com/search?q=transformers&jbv=70058026");

            Film Transformers = new Film(
                "Transformers",
                new DateTime(2007),
                new TimeSpan(2, 24, 0),
                "Michael Bay",
                "HollyWood",
                new List<GenreGlobal> { Aventure, Policier },
                "C'est un film d'action, avec des robots",
                new List<Uri> { TransformersStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Transformers.jpeg",
                new List<string> { "Shia LaBeouf" }

            );


            Uri AvengersStream = new Uri("https://www.disneyplus.com/fr-fr/movies/marvel-studios-avengers/2h6PcHFDbsPy");

            Film Avengers = new Film(
                "Avengers",
                new DateTime(2012),
                new TimeSpan(2, 24, 0),
                "Joss Whedon",
                "Marvel",
                new List<GenreGlobal> { GenreGlobal.Action, Aventure, ScienceFiction },
                "Lorsque Nick Fury, le directeur du S.H.I.E.L.D., l'organisation qui préserve la paix au plan mondial, cherche à former une équipe de choc pour empêcher la destruction du monde, Iron Man, Hulk, Thor, Captain America, Hawkeye et Black Widow répondent présents.Les Avengers ont beau constituer la plus fantastique des équipes, il leur reste encore à apprendre à travailler ensemble, et non les uns contre les autres, d'autant que le redoutable Loki a réussi à accéder au Cube Cosmique et à son pouvoir illimité... ",
                new List<Uri> { AvengersStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Avengers.jpg",
                new List<string> { "Robert Downey Jr." }

            );

            Uri Falcon_Et_Le_Soldat_De_LhiverStream = new Uri("https://www.disneyplus.com/fr-fr/series/falcon-et-le-soldat-de-lhiver/4gglDBMx8icA");

            Episode Ep1FELSDL = new Episode("Un nouvel ordre", 1, new DateTime(2021), new TimeSpan(0, 50, 0), "Sam Wilson et Bucky Barnes comprennent que leur avenir sera tout sauf normal.");
            Episode Ep2FELSDL = new Episode("L'homme à la Bannière étoilée", 2, new DateTime(2021), new TimeSpan(0, 50, 0), "John Walker devient Captain America. Sam et Bucky s'associent pour lutter contre des rebelles.");
            Episode Ep3FELSDL = new Episode("Trafic d'influence", 3, new DateTime(2021), new TimeSpan(0, 54, 0), "Dans un refuge pour criminels, Sam et Bucky cherchent des informations sur le sérum du super-soldat.");
            Episode Ep4FELSDL = new Episode("Le monde nous regarde", 4, new DateTime(2021), new TimeSpan(0, 54, 0), "John Walker perd patience avec Sam et Bucky, qui en apprennent davantage sur Karli Morgenthau.");
            Episode Ep5FELSDL = new Episode("La vérité", 5, new DateTime(2021), new TimeSpan(1, 1, 0), "John Walker doit assumer les conséquences de ses actes. Sam et Bucky rentrent aux États-Unis.");
            Episode Ep6FELSDL = new Episode("Un seul monde, un seul peuple", 6, new DateTime(2021), new TimeSpan(0, 52, 0), "Face à la montée en violence des Flag Smashers, Sam et Bucky passent à l'action.");

            Saison S1_Falcon_Et_Le_Soldat_De_Lhiver = new Saison(1, new List<Episode> { Ep1FELSDL, Ep2FELSDL, Ep3FELSDL, Ep4FELSDL, Ep5FELSDL, Ep6FELSDL });

            Serie Falcon_Et_Le_Soldat_De_Lhiver = new Serie(
                "Falcon et le Soldat de l'hiver",
                new DateTime(2021),
                new TimeSpan(0, 0, 0),
                "Joss Whedon",
                "Marvel",
                new List<GenreGlobal> { GenreGlobal.Action, ScienceFiction },
                "À l'affiche de la nouvelle production Marvel Studios ''Falcon et le Soldat de l'Hiver'', retrouvez Anthony Mackie dans le rôle de Sam Wilson alias Falcon, et Sebastian Stan dans celui de Bucky Barnes alias le Soldat de l'Hiver.Né à la fin de ''Avengers : Endgame'', le duo se reforme pour une aventure planétaire qui va mettre à l'épreuve leurs aptitudes... et leur patience. Avec Kari Skogland à la réalisation et Malcolm Spellman comme scénariste principal, la série de six épisodes met également en scène Daniel Brühl dans le rôle du Baron Zemo, Emily VanCamp dans celui de Sharon Carter, et Wyatt Russell dans celui de John Walker.",
                new List<Uri> { Falcon_Et_Le_Soldat_De_LhiverStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "FalconAndTheWinterSoldier.jpg",
                new List<Saison> { S1_Falcon_Et_Le_Soldat_De_Lhiver }
            );

            Uri ThorStream = new Uri("https://www.disneyplus.com/fr-fr/movies/marvel-studios-thor/1p4vdKzTuhzr");

            Film Thor = new Film(
                "Thor",
                new DateTime(2011),
                new TimeSpan(1, 56, 0),
                "Kenneth Branagh",
                "Marvel",
                new List<GenreGlobal> { GenreGlobal.Action, Aventure, ScienceFiction },
                "Cette aventure étend l'univers Marvel jusqu'au royaume cosmique d'Asgard. Au centre de l'histoire, Thor, guerrier puissant mais arrogant, relance une ancienne guerre. Odin, son père, le bannit alors et l'envoie sur Terre. De là, Thor doit empêcher son frère Loki de détrôner Odin et de prendre le pouvoir. Lorsque les forces les plus obscures sont envoyées sur Terre, Thor découvre ce qu'être un héros implique.",
                new List<Uri> { ThorStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Thor.jpg",
                new List<string> { "Chris Hemsworth" }
            );


            Uri BlackPantherStream = new Uri("https://www.disneyplus.com/fr-fr/movies/marvel-studios-black-panther/1GuXuYPj99Ke");

            Film BlackPanther = new Film(
                "BlackPanther",
                new DateTime(2018),
                new TimeSpan(2, 17, 0),
                "Ryan Coogler",
                "Marvel",
                new List<GenreGlobal> { GenreGlobal.Action, Aventure, ScienceFiction },
                "Après la mort de son père, le roi de Wakanda, le jeune T'Challa rentre chez lui, un lointain pays futuriste africain, afin de prendre sa place comme souverain. Lorsque le destin de Wakanda et du monde entier est mis en péril par l'arrivée d'un redoutable ennemi, le jeune roi T'Challa doit faire appel à ses pouvoirs de Black Panther pour vaincre son adversaire et défendre son peuple. Certaines séquences ou certains motifs lumineux clignotants sont susceptibles d'affecter les téléspectateurs photosensibles.",
                new List<Uri> { BlackPantherStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "BlackPanther.jpg",
                new List<string> { "Chadwick Boseman" }
            );

            Uri CaptainAmericaStream = new Uri("https://www.disneyplus.com/fr-fr/movies/marvel-studios-captain-america-first-avenger/6xvB6xZ4r95O");

            Film CaptainAmerica = new Film(
                "CaptainAmerica",
                new DateTime(2011),
                new TimeSpan(2, 6, 0),
                "Joe Johnston",
                "Marvel",
                new List<GenreGlobal> { GenreGlobal.Action, Aventure, ScienceFiction },
                "Réformé du service militaire, Steve Rogers participe à un projet de recherche top secret qui le transforme en Captain America, un superhéros voué à la défense des valeurs de l'Amérique, combattant de la liberté et ultime rempart contre le mal. Alors qu'une force terrifiante menace la planète, le meilleur soldat du monde part en mission contre HYDRA, l'organisation du cruel Crâne rouge.",
                new List<Uri> { CaptainAmericaStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "CaptainAmerica.jpg",
                new List<string> { "Chris Evans" }
            );

            Uri LesGardiensDeLaGalaxieStream = new Uri("https://www.disneyplus.com/fr-fr/movies/marvel-studios-les-gardiens-de-la-galaxie/1S4WM9h3KRR6");

            Film LesGardiensDeLaGalaxie = new Film(
                "LesGardiensDeLaGalaxie",
                new DateTime(2014),
                new TimeSpan(2, 2, 0),
                "James Gunn",
                "Marvel",
                new List<GenreGlobal> { GenreGlobal.Action, Aventure, ScienceFiction },
                "Une aventure dans l'espace épique et pleine d'action. Les Gardiens de la Galaxie propulsent l'univers Marvel dans le cosmos où l'aventurier Peter Quill se retrouve pourchassé après avoir volé un mystérieux orbe convoité par Ronan, un puissant ennemi dont les pouvoirs menacent l'univers tout entier. Il devra s'allier aux quatre héros marginaux que sont Rocket, Groot, Gamora et Drax. Mais lorsque Quill découvre le véritable pouvoir de l'orbe, il doit faire ce qu'il faut pour sauver la galaxie. Certaines séquences ou certains motifs lumineux clignotants sont susceptibles d'affecter les téléspectateurs photosensibles.",
                new List<Uri> { LesGardiensDeLaGalaxieStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "LesGardiensDeLaGalaxie.jpg",
                new List<string> { "Chris Pratt" }
            );

            Uri AntManStream = new Uri("https://www.disneyplus.com/fr-fr/movies/marvel-studios-ant-man/5c92KVf1zgUX");

            Film AntMan = new Film(
                "AntMan",
                new DateTime(2015),
                new TimeSpan(2, 0, 0),
                "Peyton Reed",
                "Marvel",
                new List<GenreGlobal> { GenreGlobal.Action, Aventure, ScienceFiction },
                "Marvel introduit un membre fondateur des Avengers pour la première fois sur grand écran dans Ant-Man des Studios Marvel. Scott Lang, voleur professionnel qui peut rétrécir sa taille et multiplier sa force, doit aider son mentor, Dr Hank Pym, à protéger les secrets technologiques de son costume. Ils doivent planifier et réussir un cambriolage qui sauvera le monde. Certaines séquences ou certains motifs lumineux clignotants sont susceptibles d'affecter les téléspectateurs photosensibles.",
                new List<Uri> { AntManStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "AntMan.jpg",
                new List<string> { "Paul Reed" }
            );

            Uri DoctorStrangeStream = new Uri("https://www.disneyplus.com/fr-fr/movies/marvel-studios-doctor-strange/4GgMJ1aHKHA2");

            Film DoctorStrange = new Film(
                "DoctorStrange",
                new DateTime(2016),
                new TimeSpan(1, 56, 0),
                "Scott Derrickson",
                "Marvel",
                new List<GenreGlobal> { GenreGlobal.Action, Aventure, Fantastique },
                "Les Studios Marvel présentent l’histoire d’un neurochirurgien célèbre, Dr Stephen Strange, dont la vie change après un accident de voiture. Lorsque la médecine traditionnelle lui fait défaut, il découvre Kamar-Taj. Il apprend vite que des forces du mal sont déterminées à détruire la réalité. Strange, armé de pouvoirs magiques, doit choisir entre retrouver sa vie d’avant et défendre le monde. Certaines séquences ou certains motifs lumineux clignotants sont susceptibles d'affecter les téléspectateurs photosensibles.",
                new List<Uri> { DoctorStrangeStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "DoctorStrange.jpg",
                new List<string> { "Benedict Cumberbatch" }
            );

            Uri DeadpoolStream = new Uri("https://www.disneyplus.com/fr-fr/movies/deadpool/3Kh13Lrb0Pnv");

            Film Deadpool = new Film(
                "Deadpool",
                new DateTime(2016),
                new TimeSpan(1, 49, 0),
                "Tim Miller",
                "Marvel",
                new List<GenreGlobal> { GenreGlobal.Action, Aventure },
                "Deadpool est l’antihéros le plus atypique de l’univers Marvel. À l’origine, il s’appelle Wade Wilson : un ancien militaire des Forces Spéciales devenu mercenaire. Après avoir subi une expérience hors norme qui accélère ses pouvoirs de guérison, il devient Deadpool. Armé de ses nouvelles capacités et d’un humour noir survolté, il va traquer l’homme qui a bien failli anéantir sa vie.",
                new List<Uri> { DeadpoolStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Deadpool.jpg",
                new List<string> { "Ryan Reynolds" }
            );

            Uri LoganStream = new Uri("https://www.disneyplus.com/fr-fr/movies/logan/4BPdGjuoQAvT");

            Film Logan = new Film(
                "Logan",
                new DateTime(2017),
                new TimeSpan(2, 18, 0),
                "James Mangold",
                "Marvel",
                new List<GenreGlobal> { GenreGlobal.Action, Aventure, ScienceFiction },
                "Dans un futur proche, un Logan épuisé s’occupe d’un Professeur Xavier souffrant et affaibli, qu’il garde caché dans un lieu désolé à la frontière Mexicaine. Mais les tentatives de Logan pour se retrancher du monde et rompre avec son passé vont être réduites à néant, lorsqu’une jeune mutante traquée par de sombres individus va se retrouver soudainement face à lui…",
                new List<Uri> { LoganStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Logan.jpg",
                new List<string> { "Hugh Jackman" }
            );

            Uri XMenStream = new Uri("https://www.disneyplus.com/fr-fr/movies/x-men/4QoNe0ea49nP");

            Film XMen = new Film(
                "XMen",
                new DateTime(2000),
                new TimeSpan(1, 44, 0),
                "Bryan Singer",
                "Marvel",
                new List<GenreGlobal> { GenreGlobal.Action, Aventure, ScienceFiction },
                "Les X-Men, un groupe de mutants aux pouvoirs extraordinaires, mènent un combat à la fois contre l'intolérance et contre une autre bande de mutants radicaux ayant l'intention d'éradiquer l'espèce humaine.",
                new List<Uri> { XMenStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "XMen.jpg",
                new List<string> { "Hugh Jackman" }
            );

            Uri AlienStream = new Uri("https://www.disneyplus.com/fr-fr/movies/x-men/4QoNe0ea49nP");

            Film Alien = new Film(
                "Alien",
                new DateTime(1979),
                new TimeSpan(1, 57, 0),
                "Ridley Scott",
                "20th Century Studios",
                new List<GenreGlobal> { Horreur, ScienceFiction },
                "Quand les membres de l'équipage du vaisseau spatial Nostromo captent un signal de détresse provenant d'une planète isolée, ils découvrent qu'une redoutable forme de vie se reproduit en se développant dans le corps des humains. Ils vont devoir lutter pour rester en vie et empêcher ces créatures d'atteindre la Terre. Réalisé par Ridley Scott, avec Sigourney Weaver dans le rôle qui l'a révélée au grand public, ce premier film légendaire de la saga Alien vous coupera le souffle.",
                new List<Uri> { AlienStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Alien.jpg",
                new List<string> { "Tom Skerritt" }
            );

            Uri LeRituelStream = new Uri("https://www.netflix.com/title/80217312");

            Film LeRituel = new Film(
                "LeRituel",
                new DateTime(2018),
                new TimeSpan(1, 34, 0),
                "David Bruckner",
                "Inconnu",
                new List<GenreGlobal> {Horreur },
                "Quatre amis de longue date dont les relations se sont peu à peu tendues s'aventurent dans la nature sauvage de Suède au risque de ne jamais en revenir.",
                new List<Uri> { LeRituelStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "LeRituel.jpg",
                new List<string> { "Arsher Ali" }
            );

            Uri Vendredi13Stream = new Uri("https://www.netflix.com/title/70104894");

            Film Vendredi13 = new Film(
                "Vendredi 13",
                new DateTime(2009),
                new TimeSpan(1, 37, 0),
                "Marcus Nispel",
                "Inconnu",
                new List<GenreGlobal> { Horreur },
                "Dans un camp de vacances, un groupe d'ados provoquent la colère de Jason Voorhees, un maniaque sanguinaire masqué, pour un remake du grand classique de l'épouvante.",
                new List<Uri> { Vendredi13Stream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Vendredi13.jpg",
                new List<string> { "Jared Padalecki" }
            );

            Uri OuijaStream = new Uri("https://www.netflix.com/title/70305901");

            Film Ouija = new Film(
                "Ouija",
                new DateTime(2014),
                new TimeSpan(1, 29, 0),
                "Stiles White",
                "Inconnu",
                new List<GenreGlobal> { Horreur },
                "Après la mort mystérieuse de leur amie, une bande d'ados tente de communiquer avec elle à l'aide d'une planche Ouija, réveillant par la même occasion un esprit du mal.",
                new List<Uri> { OuijaStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Ouija.jpg",
                new List<string> { "Olivia Cooke" }
            );

            Uri AnnabelleStream = new Uri("https://www.netflix.com/title/80013775");

            Film Annabelle = new Film(
                "Annabelle",
                new DateTime(2014),
                new TimeSpan(1, 39, 0),
                "John R. Leonetti",
                "Inconnu",
                new List<GenreGlobal> { Horreur },
                "Un mari offre à sa femme le cadeau idéal, une magnifique poupée de collection, mais la joie apportée par le sinistre objet dans le foyer est de courte durée.",
                new List<Uri> { AnnabelleStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Annabelle.jpg",
                new List<string> { "Annabelle Wallis" }
            );

            Uri LeHobbitStream = new Uri("https://www.netflix.com/title/80013775");

            Film LeHobbit = new Film(
                "Le Hobbit",
                new DateTime(2012),
                new TimeSpan(2, 49, 0),
                "Peter Jackson",
                "Inconnu",
                new List<GenreGlobal> { Fantastique, GenreGlobal.Action, Aventure },
                "Dans UN VOYAGE INATTENDU, Bilbon Sacquet cherche à reprendre le Royaume perdu des Nains d'Erebor, conquis par le redoutable dragon Smaug. Alors qu'il croise par hasard la route du magicien Gandalf le Gris, Bilbon rejoint une bande de 13 nains dont le chef n'est autre que le légendaire guerrier Thorin Écu-de-Chêne. Leur périple les conduit au cœur du Pays Sauvage, où ils devront affronter des Gobelins, des Orques, des Ouargues meurtriers, des Araignées géantes, des Métamorphes et des Sorciers… Bien qu'ils se destinent à mettre le cap sur l'Est et les terres désertiques du Mont Solitaire, ils doivent d'abord échapper aux tunnels des Gobelins, où Bilbon rencontre la créature qui changera à jamais le cours de sa vie : Gollum. C'est là qu'avec Gollum, sur les rives d'un lac souterrain, le modeste Bilbon Sacquet non seulement se surprend à faire preuve d'un courage et d'une intelligence inattendus, mais parvient à mettre la main sur le ''précieux'' anneau de Gollum qui recèle des pouvoirs cachés… Ce simple anneau d'or est lié au sort de la Terre du Milieu, sans que Bilbon s'en doute encore… ",
                new List<Uri> { LeHobbitStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "LeHobbit.jpg",
                new List<string> { "Ian McKellen" }
            );

            Uri HarryPotterStream = new Uri("https://www.primevideo.com/detail/0JXM9K5QSXG0X1O6M4CHGIYACB/ref=atv_sr_def_c_unkc__70_1_16?sr=1-70&qid=1623518347&pageTypeIdSource=ASIN&pageTypeId=B07Q6JY91M&language=fr_FR");

            Film HarryPotter = new Film(
                "Harry Potter",
                new DateTime(2001),
                new TimeSpan(2, 32, 0),
                "Chris Columbus",
                "Inconnu",
                new List<GenreGlobal> { Fantastique, GenreGlobal.Action, Aventure },
                "Orphelin, Harry Potter a été recueilli à contrecœur par son oncle Vernon et sa tante Pétunia, aussi cruels que mesquins, qui n'hésitent pas à le faire dormir dans le placard sous l'escalier. Constamment maltraité, il doit en outre supporter les jérémiades de son cousin Dudley, garçon cupide et archi-gâté par ses parents. De leur côté, Vernon et Pétunia détestent leur neveu dont la présence leur rappelle sans cesse le tempérament ''imprévisible'' des parents du garçon et leur mort mystérieuse.À l'approche de ses 11 ans, Harry ne s'attend à rien de particulier – ni carte, ni cadeau, ni même un goûter d'anniversaire. Et pourtant, c'est à cette occasion qu'il découvre qu'il est le fils de deux puissants magiciens et qu'il possède lui aussi d'extraordinaires pouvoirs.Quand on lui propose d'intégrer Poudlard, la prestigieuse école de sorcellerie, il trouve enfin le foyer et la famille qui lui ont toujours manqué… et s'engage dans l'aventure de sa vie.",
                new List<Uri> { HarryPotterStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "HarryPotter.jpg",
                new List<string> { "Daniel Radcliffe" }
            );

            Uri LeDernierMaitreDeLAirStream = new Uri("https://www.netflix.com/title/70119441");

            Film LeDernierMaitreDeLAir = new Film(
                "Le Dernier Maitre De L'Air",
                new DateTime(2010),
                new TimeSpan(1, 44, 0),
                "M. Night Shyamalan",
                "Inconnu",
                new List<GenreGlobal> { Fantastique, GenreGlobal.Action, Aventure },
                "Dans un monde ravagé par la guerre engagée par la Nation du Feu contre les Nations de l'Air, de l'Eau et de la Terre, un garçon est le seul à pouvoir rétablir la paix.",
                new List<Uri> { LeDernierMaitreDeLAirStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "LeDernierMaitreDeLAir.jpg",
                new List<string> { "Noah Ringer" }
            );

            Uri CinquanteNuancesDeGreyStream = new Uri("https://www.netflix.com/title/80013872");

            Film CinquanteNuancesDeGrey = new Film(
                "Cinquante Nuances De Grey",
                new DateTime(2015),
                new TimeSpan(2, 5, 0),
                "Sam Taylor-Johnson",
                "Inconnu",
                new List<GenreGlobal> { Romance },
                "Une étudiante candide et un homme riche se risquent dans une relation passionnelle dont ils poussent l’érotisme à son paroxysme.",
                new List<Uri> { CinquanteNuancesDeGreyStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "CinquanteNuancesDeGrey.jpg",
                new List<string> { "Dakota Johnson" }
            );

            Uri TroisCentsSoixanteCinqJoursStream = new Uri("https://www.netflix.com/title/81245964");

            Film TroisCentsSoixanteCinqJours = new Film(
                "365 Jours",
                new DateTime(2020),
                new TimeSpan(1, 54, 0),
                "Barbara Bialowas",
                "Inconnu",
                new List<GenreGlobal> { Romance },
                "Une femme tombe entre les mains d'un chef mafieux dominateur qui la séquestre et lui laisse un an pour tomber amoureuse de lui.",
                new List<Uri> { TroisCentsSoixanteCinqJoursStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "365Jours.jpg",
                new List<string> { "Anna-Maria Sieklucka" }
            );

            Uri SexeEntreAmisStream = new Uri("https://www.netflix.com/title/70167075");

            Film SexeEntreAmis = new Film(
                "Sexe Entre Amis",
                new DateTime(2011),
                new TimeSpan(1, 49, 0),
                "Will Gluck",
                "Inconnu",
                new List<GenreGlobal> { Romance },
                "Une recruteuse et un directeur artistique se lient d'amitié et décident d'entamer une relation sexuelle sans engagement, uniquement basée sur leur complicité.",
                new List<Uri> { SexeEntreAmisStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "SexeEntreAmis.jpg",
                new List<string> { "Justin Timberlake" }
            );

            Uri MilfStream = new Uri("https://www.netflix.com/title/81248072");

            Film Milf = new Film(
                "Milf",
                new DateTime(2018),
                new TimeSpan(1, 41, 0),
                "Axelle Laffont",
                "Inconnu",
                new List<GenreGlobal> { Romance },
                "Trois copines quadragénaires partent en virée dans le Sud pour oublier leurs chagrins... et redécouvrir leur pouvoir de séduction auprès de jeunes hommes charmants.",
                new List<Uri> { MilfStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Milf.jpg",
                new List<string> { "Virginie Ledoyen" }
            );

            Uri ZodiacStream = new Uri("https://www.netflix.com/title/70044686");

            Film Zodiac = new Film(
                "Zodiac",
                new DateTime(2007),
                new TimeSpan(2, 37, 0),
                "David Fincher",
                "Inconnu",
                new List<GenreGlobal> { Policier },
                "Dans ce thriller inspiré de faits réels, un dessinateur, un journaliste et des policiers enquêtent sur l'insaisissable tueur en série de San Francisco, Zodiac.",
                new List<Uri> { ZodiacStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "Zodiac.jpg",
                new List<string> { "Jake Gyllenhaal" }
            );

            Uri OceansElevenStream = new Uri("https://www.netflix.com/title/60021783");

            Film OceansEleven = new Film(
                "Ocean's Eleven",
                new DateTime(2001),
                new TimeSpan(1, 57, 0),
                "Steven Soderbergh",
                "Inconnu",
                new List<GenreGlobal> { Policier, Aventure },
                "À peine sorti de prison, le gentleman cambrioleur Danny Ocean réunit une équipe d'experts pour réussir un braquage élaboré visant trois casinos de Las Vegas.",
                new List<Uri> { OceansElevenStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "OceansEleven.jpg",
                new List<string> { "Brad Pitt" }
            );

            Uri LostGirlsStream = new Uri("https://www.netflix.com/title/80223927");

            Film LostGirls = new Film(
                "Lost Girls",
                new DateTime(2020),
                new TimeSpan(1, 35, 0),
                "Liz Garbus",
                "Inconnu",
                new List<GenreGlobal> { Policier },
                "Dans ce film inspiré de faits réels, une mère en quête de vérité se retrouve sur la piste d'une série de meurtres inexpliqués alors qu'elle recherche sa fille disparue.",
                new List<Uri> { LostGirlsStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "LostGirls.jpg",
                new List<string> { "Amy Ryan" }
            );

            Uri TheIrishmanStream = new Uri("https://www.netflix.com/title/80175798");

            Film TheIrishman = new Film(
                "The Irishman",
                new DateTime(2019),
                new TimeSpan(3, 29, 0),
                "Martin Scorsese",
                "Inconnu",
                new List<GenreGlobal> { Policier },
                "Dans ce film plébiscité de Martin Scorsese, le tueur à gages Frank Sheeran évoque des secrets qui remontent à l'époque où il était l'homme de confiance d'un clan mafieux.",
                new List<Uri> { TheIrishmanStream },
                new List<Langues> { Français },
                new List<Langues> { Français },
                "TheIrishman.jpg",
                new List<string> { "Robert de Niro" }
            );

            listCV.AddLast(Transformers);
            listCV.AddLast(Avengers);
            listCV.AddLast(Falcon_Et_Le_Soldat_De_Lhiver);
            listCV.AddLast(Thor); 
            listCV.AddLast(BlackPanther);
            listCV.AddLast(CaptainAmerica); 
            listCV.AddLast(LesGardiensDeLaGalaxie);
            listCV.AddLast(AntMan);
            listCV.AddLast(DoctorStrange);
            listCV.AddLast(Deadpool);
            listCV.AddLast(Logan);
            listCV.AddLast(XMen);
            listCV.AddLast(Alien);  
            listCV.AddLast(LeRituel);
            listCV.AddLast(Vendredi13);
            listCV.AddLast(Ouija);
            listCV.AddLast(Annabelle);
            listCV.AddLast(LeHobbit);
            listCV.AddLast(HarryPotter);
            listCV.AddLast(LeDernierMaitreDeLAir);
            listCV.AddLast(CinquanteNuancesDeGrey);
            listCV.AddLast(TroisCentsSoixanteCinqJours);
            listCV.AddLast(SexeEntreAmis);
            listCV.AddLast(Milf);
            listCV.AddLast(Zodiac);
            listCV.AddLast(OceansEleven);
            listCV.AddLast(TheIrishman);
            listCV.AddLast(LostGirls);


            listUtilisateur.AddLast(new Utilisateur("admin", "admin", "admin", new DateTime(1990, 1, 1), "Indefini"));
            listUtilisateur.AddLast(new Utilisateur("Baptiste F.", "bafoucras", "Baptiste.FOUCRAS@etu.uca.fr",
                new DateTime(2002, 10, 27), "Homme"));
            listUtilisateur.AddLast(new Utilisateur("Julien T.", "jutheme", "Julien.THEME@etu.uca.fr", new DateTime(2002, 07, 21), "Homme"));


            return (listCV, listUtilisateur);
        }

        public void SauvegarderDonnees(IEnumerable<ContenuVideoludique> ListCV, IEnumerable<Utilisateur> listUtilisateur)
        {
            return;
        }
    }
}
