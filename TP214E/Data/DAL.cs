﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace TP214E.Data
{
    public class DAL : IDAL
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
                IMongoDatabase baseDonnees = mongoDBClient.GetDatabase("TP2DB");
                aliments = baseDonnees.GetCollection<Aliment>("Aliments").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return aliments;
        }

        public void AjouterAlimentDansBaseDonnees(Aliment alimentAjoute)
        {
            try
            {
                IMongoDatabase baseDonnees = mongoDBClient.GetDatabase("TP2DB");
                baseDonnees.GetCollection<Aliment>("Aliments").InsertOne(alimentAjoute);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void ModifierAlimentDansBaseDonnees(Aliment aliment)
        {
            try
            {
                IMongoDatabase baseDonnees = mongoDBClient.GetDatabase("TP2DB");
                var conditions = Builders<Aliment>.Filter.Eq("_id", aliment.Id);
                var modificationEffectuee = Builders<Aliment>.Update.Set("Nom", aliment.Nom)
                    .Set("Quantite", aliment.Quantite).Set("Unite", aliment.Unite).Set("ExpireLe", aliment.ExpireLe);
                var requeteSupression = baseDonnees.GetCollection<Aliment>("Aliments").UpdateOne(conditions, modificationEffectuee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SupprimerAlimentDansBaseDonnees(ObjectId idAliment)
        {
            try
            {
                IMongoDatabase baseDonnees = mongoDBClient.GetDatabase("TP2DB");
                var conditions = Builders<Aliment>.Filter.Eq("_id", idAliment);
                var requeteSupression = baseDonnees.GetCollection<Aliment>("Aliments").DeleteOne(conditions);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private MongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try
            {
                dbClient = new MongoClient("mongodb://localhost:27017/TP2DB");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dbClient;
        }

    }
}
