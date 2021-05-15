using modelisation.content;
using System;
using System.Collections.Generic;
using System.Text;

namespace modelisation
{
    class Marathon
    {
        public int nbJour;
        public int nbHeureParJour;
        public LinkedList<ContenuVideoludique> ListMarathon= new LinkedList<ContenuVideoludique>();

        public Marathon(int nbJour, int nbHeureParJour)
        {
            this.nbJour = nbJour;
            this.nbHeureParJour = nbHeureParJour;
        }

        public void ajouterAVoir(ContenuVideoludique c)
        {
            ListMarathon.AddLast(c);
        }

        public void enleverAVoir(ContenuVideoludique c)
        {
            ListMarathon.Remove(c);
        }

    }
}
