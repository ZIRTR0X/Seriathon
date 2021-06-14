using modelisation;
using modelisation.content;
using modelisation.usefull_interfaces;
using modelisation.user;
using persistance.StubPersist;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace persistance.DataContract
{
    /// <summary>
    /// Chargement et enregistrement des données au format XML
    /// </summary>
    public class DataContract2XML : IPersistanceManager
    {
        /// <summary>
        ///  attribut donnant la référence vers le seul datacontract2xml de l'application, pouvant etre null
        /// </summary>
        private static DataContract2XML _singleton;

        /// <summary>
        /// indique le chemin vers le dossier des fichiers de persistances
        /// </summary>
        public string FilePath
        {
            get => _filePath;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _filePath = Path.Combine(Directory.GetCurrentDirectory(), "..//XML");
                } else
                {
                    _filePath = value;
                }
            }
        }
        private string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "..//XML");

        /// <summary>
        /// indique le nom du fichier de persistance pour les files
        /// </summary>
        public string FileName
        {
            get => _fileName;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _fileName = "utilisateur.xml";
                } else
                {
                    _fileName = value;
                }
            }
        }
        private string _fileName = "utilisateur.xml";
        /// <summary>
        /// chemin complet vers le fichier ml répertoriant les utilisateurs
        /// </summary>
        private string PersFile => Path.Combine(FilePath, FileName);

        private DataContract2XML()
        {
            FilePath = "..//XML";
            FileName = "utilisateur.xml";
        }

        public static DataContract2XML GetInstance()
        {
            if (_singleton is null) _singleton = new DataContract2XML();

            return _singleton;
        }

        public (IEnumerable<ContenuVideoludique>, IEnumerable<Utilisateur>) ChargeDonnees()
        {
            if (!File.Exists(PersFile))
            {
                // dans ce cas, la file n'existe pas, on charge alors depuis le stub
                return Stub.GetInstance().ChargeDonnees();
            }

            DataToPersist data = new DataToPersist();

            var serializer = new DataContractSerializer(typeof(DataToPersist));

            using(Stream s = File.OpenRead(PersFile))
            {
                data = serializer.ReadObject(s) as DataToPersist;
            }

            return (data.ListCVR, data.ListUtilisateurR);
        }

        public void SauvegarderDonnees(IEnumerable<ContenuVideoludique> listCV, IEnumerable<Utilisateur> listUtilisateur)
        {

            DataToPersist data = new DataToPersist(listUtilisateur, listCV);

            // si jamais le directory n'existe pas, il le créé
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }


            // on enregistre d'abord la liste de ContenuVideoludique
            DataContractSerializer serializer = new DataContractSerializer(typeof(DataToPersist),
                new DataContractSerializerSettings() { PreserveObjectReferences = true }) ; // permet de garder les références identiques

            XmlWriterSettings options = new XmlWriterSettings() { Indent = true };

            using (TextWriter tw = File.CreateText(PersFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, options))
                {
                    serializer.WriteObject(writer, data);
                }
            }
        }
    }
}
