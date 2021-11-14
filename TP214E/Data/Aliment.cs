using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public interface IAliment
    {
        ObjectId Id { get; set; }
        string Nom { get; set; }
        int Quantite { get; set; }
        string Unite { get; set; }
        DateTime ExpireLe { get; set; }
    }

    public class Aliment : IAliment
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
