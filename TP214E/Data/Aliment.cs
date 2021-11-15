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
        private string _nom;
        private int _quantite;
        private string _unite;
        private DateTime _dateExpiration;

        /*
        * Logiquement il devrait avoir des repas en plus des aliments, mais pour simplifier et
        * puisque je manque de temps, je considère le aliments comme étant les repas aussi.
        */
        public ObjectId Id { get; set; }
        public string Nom
        {
            get { return _nom; }
            set
            {
                if (value.Trim().Length == 0)
                    throw new ArgumentOutOfRangeException("Nom", "Le nom ne doit pas être vide");
                else
                    _nom = value;
            }
        }
        public int Quantite
        {
            get { return _quantite; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Quantité", "La quantité doit être supérieure ou égale à 0");
                else
                    _quantite = value;
            }
        }
        public string Unite
        {
            get { return _unite; }
            set
            {
                if (value.Trim().Length == 0)
                    throw new ArgumentOutOfRangeException("Unité", "L'unité ne peut pas être vide");
                else
                    _unite = value;
            }
        }
        public DateTime ExpireLe
        {
            get { return _dateExpiration; }
            set
            {
                
                    _dateExpiration = value;
            }
        }

        public Aliment(string nom, int quantite, string unite, DateTime expireLe)
        {
           
            Nom = nom;
            Quantite = quantite;
            Unite = unite;
            ExpireLe = expireLe;
        }

        public bool ChangerQuantiteAliment(int valeurChangement )
        {
            if (valeurChangement <= Quantite)
            {
                Quantite -= valeurChangement;
                return true;
            }
            else
                return false;
        }



       

    }
}
