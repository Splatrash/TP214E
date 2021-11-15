using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public interface IObjetCommande
    {
        #region PROPRIÉTÉS ET INDEXEURS

        string NomAliment { get; set; }
        int QuantiteAliment { get; set; }

        #endregion
    }

    public class ObjetCommande : IObjetCommande
    {
        #region PROPRIÉTÉS ET INDEXEURS
        public string NomAliment { get; set; }
        public int QuantiteAliment { get; set; }

        #endregion

        #region CONSTRUCTEURS
        public ObjetCommande(string nomAliment, int quantiteAliment)
        {
            NomAliment = nomAliment;
            QuantiteAliment = quantiteAliment;
        }

        #endregion

        #region MÉTHODES

        public void ChangerQuantite(int quantiteAjoutee)
        {
            if (quantiteAjoutee > 0)
                QuantiteAliment += quantiteAjoutee;
            else
                throw new ArgumentOutOfRangeException("Changement de la quantitée",
                    "La quantité n'était pas un nombre positif plus grand que 0");
        }

        public string VerifierEtMettreAJourQuantiteAliments(List<Aliment> inventaireAliments)
        {
            foreach (Aliment aliment in inventaireAliments)
            {
                if (NomAliment == aliment.Nom)
                {
                    if (!aliment.ChangerQuantiteAliment(QuantiteAliment))
                    {
                        string messageAlimentManquant = String.Format(
                            "Il manque d'aliment pour la commande:\n -La commande exige {0} {1}\n -Il reste {2} {3}",
                            QuantiteAliment, NomAliment, aliment.Quantite,
                            aliment.Nom);
                        return messageAlimentManquant;
                    }
                    return "";
                }
            }
            throw new KeyNotFoundException("L'aliment dans la commande n'éxiste pas.");
        }

        #endregion
    }
}
