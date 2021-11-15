using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class ObjetCommandeTests
    {

        [TestMethod()]
        public void ChangerQuantite_Ajoute_Le_Parametre_En_Entree_A_La_Quantite()
        {
            var aliment = new Aliment("Ketchup", 5, "ml", DateTime.Today);
            int nbAjoute = 5;

            var objetCommande = new ObjetCommande(aliment.Nom, aliment.Quantite);

            objetCommande.ChangerQuantite(nbAjoute);

            Assert.AreEqual(10, objetCommande.QuantiteAliment);
        }

        [TestMethod()]
        public void ChangerQuantite_Retire_Le_Parametre_En_Entree_A_La_Quantite()
        {
            var aliment = new Aliment("Ketchup", 5, "ml", DateTime.Today);
            int nbRetirer = -5;

            var objetCommande = new ObjetCommande(aliment.Nom, aliment.Quantite);

            objetCommande.ChangerQuantite(nbRetirer);

            Assert.AreEqual(0, objetCommande.QuantiteAliment);
        }
    }
}