using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP214E.Data
{
    public class Commande
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

            //Rappel personnel: Le ? permet de faire le if lorsque on est pas garantie qu'il ne soit pas null
            if (Commandes.ListeCommandes.Any())
                numeroCommande = Commandes.ListeCommandes[Commandes.ListeCommandes.Count - 1].NumeroCommande + 1;
            else
                numeroCommande = 1;

            return numeroCommande;
        }
    }
}
