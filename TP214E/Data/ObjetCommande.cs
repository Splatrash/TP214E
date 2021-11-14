using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class ObjetCommande
    {
        public string NomAliment { get; set; }
        public int QuantiteAliment { get; set; }

        public ObjetCommande(string nomAliment, int quantiteAliment)
        {
            NomAliment = nomAliment;
            QuantiteAliment = quantiteAliment;
        }

        public void ChangerQuantite(int quantiteAjoutee)
        {
            QuantiteAliment += quantiteAjoutee;
        }
    }
}
