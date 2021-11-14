using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Aliment
    {
        public ObjectId Id { get; set; }
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public string Unite { get; set; }
        public DateTime ExpireLe { get; set; }

        public Aliment(string nom, int quantite, string unite, DateTime expireLe)
        {
           
            Nom = nom;
            Quantite = quantite;
            Unite = unite;
            ExpireLe = expireLe;
        }

    }
}
