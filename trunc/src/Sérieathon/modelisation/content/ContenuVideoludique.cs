using System;
using System.Collections.Generic;
using System.Text;

namespace modelisation.content
{
    public abstract class ContenuVideoludique
    {
        public string Titre { get; set; }

        public TimeSpan Duree { get; set; }

        public bool Like { get; set; } = false;

        public string StudioProd { get; set; }
    }
}
