using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public interface IObjetCommande
    {
        string NomAliment { get; set; }
        int QuantiteAliment { get; set; }
        
    }

    public class ObjetCommande : IObjetCommande
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
            if (quantiteAjoutee > 0)
                QuantiteAliment += quantiteAjoutee;
            else
                throw new ArgumentOutOfRangeException("Changement de la quantitée",
                    "La quantité n'était pas un nombre positif plus grand que 0");
        }
    }
}
