using modelisation;
using modelisation.content;
using modelisation.usefull_interfaces;
using modelisation.user;
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
        public string FileName_utilisateur
        {
            get => _fileName_utilisateur;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _fileName_utilisateur = "utilisateur.xml";
                } else
                {
                    _fileName_utilisateur = value;
                }
            }
        }
        private string _fileName_utilisateur = "utilisateur.xml";

        /// <summary>
        /// indique le nom du fichier de persistance pour les ContenuVideoludique
        /// </summary>
        public string FileName_CV
        {
            get => _fileName_CV;

            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    _fileName_CV = "contenu_videoludique.xml";
                } else
                {
                    _fileName_CV = value;
                }
            }
        }
        private string _fileName_CV = "contenu_videoludique.xml";


        private DataContract2XML() { }

        public static DataContract2XML GetInstance()
        {
            if (_singleton is null) _singleton = new DataContract2XML();

            return _singleton;
        }

        public (IEnumerable<ContenuVideoludique>, IEnumerable<Utilisateur>) ChargeDonnees()
        {
            throw new NotImplementedException();
        }

        public void SauvegarderDonnees(IEnumerable<ContenuVideoludique> listCV, IEnumerable<Utilisateur> listUtilisateur)
        {

            DataToPersist d = new DataToPersist(listUtilisateur, listCV);

            // si jamais le directory n'existe pas, il le créé
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }


            // on enregistre d'abord la liste de ContenuVideoludique
            var serializer = new DataContractSerializer(typeof(DataToPersist),
                new DataContractSerializerSettings() { PreserveObjectReferences = true }) ; // permet de garder les références identiques

            var options = new XmlWriterSettings() { Indent = true };

            using (TextWriter tw = File.CreateText(Path.Combine(FilePath, FileName_CV)))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, options))
                {
                    serializer.WriteObject(writer, d);
                }
            }
        }
    }
}
