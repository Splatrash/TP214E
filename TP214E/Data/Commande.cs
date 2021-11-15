using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace TP214E.Data
{
    public interface ICommande
    {
        int NumeroCommande { get; set; }
        List<ObjetCommande> ObjetsCommande { get; set; }
        DateTime CreerLe { get; set; }
        int ObtenirNumeroCommande();
    }

    public class Commande : ICommande
    {
        //Si dans le futur on a besoin de mettre dans une base de données
        //public ObjectId Id { get; set; }
        public int NumeroCommande { get; set; }
        public List<ObjetCommande> ObjetsCommande { get; set; }
        public DateTime CreerLe { get; set; }

        public Commande(List<ObjetCommande> objetsCommande, DateTime creerLe)
        {
            NumeroCommande = ObtenirNumeroCommande();
            ObjetsCommande = objetsCommande;
            CreerLe = creerLe;
        }

        public int ObtenirNumeroCommande()
        {
            int numeroCommande;

            if (Commandes.ListeCommandes.Any())
                numeroCommande = Commandes.ListeCommandes[Commandes.ListeCommandes.Count - 1].NumeroCommande + 1;
            else
                numeroCommande = 1;

            return numeroCommande;
        }
    }
}