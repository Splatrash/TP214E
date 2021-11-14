using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace TP214E.Data
{
    public class Commande
    {
        //Si dans le futur on a besoin de mettre dans une base de données
        //public ObjectId Id { get; set; }
        public int NumeroCommande { get; set; }
        public List<ObjetCommande> ObjetsCommande { get; set; }
        public DateTime CreerLe { get; set; }

        public Commande(int numeroCommande, List<ObjetCommande> objetsCommande, DateTime creerLe)
        {
            NumeroCommande = numeroCommande;
            ObjetsCommande = objetsCommande;
            CreerLe = creerLe;
        }

        
    }
}
