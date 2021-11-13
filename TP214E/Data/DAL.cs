using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace TP214E.Data
{
    public class DAL
    {
        public MongoClient mongoDBClient;
        public DAL()
        {
            mongoDBClient = OuvrirConnexion();
        }

        public List<Aliment> ChercherAlimentBaseDonnees()
        {
            var aliments = new List<Aliment>();
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
                aliments = db.GetCollection<Aliment>("Aliments").Aggregate().ToList();
            }catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return aliments;
        }

        private MongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try{
                dbClient = new MongoClient("mongodb://localhost:27017/TP2DB");
            }catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dbClient;
        }

    }
}
