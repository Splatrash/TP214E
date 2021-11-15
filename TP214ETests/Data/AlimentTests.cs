using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class AlimentTests
    {
        [TestMethod()]
        public void Aliment_Envoi_ArgumentOutOfRangeException_Si_Le_Nom_Est_Vide()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Aliment("", 1, "ml", DateTime.Now.AddDays(5)));
        }

        [TestMethod()]
        public void Aliment_Envoi_ArgumentOutOfRangeException_Si_L_Quantite_Est_PLus_Petite_Que_1()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Aliment("Ketchup", 0, "ml", DateTime.Now.AddDays(5)));
        }

        [TestMethod()]
        public void Aliment_Envoi_ArgumentOutOfRangeException_S_Le_Unite_Est_Vide()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Aliment("Ketchup", 1, "", DateTime.Now.AddDays(5)));
        }

        [TestMethod()]
        public void Aliment_Envoi_ArgumentOutOfRangeException_Si_La_Date_D_Expiration_Est_Aujourdhui_Ou_Avant()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Aliment("Ketchup", 1, "ml", DateTime.Now));
        }

        [TestMethod()]
        public void ChangerQuantiteAliment_Retourne_Vrai_Si_Le_Nombre_Retirer_Est_Plus_Petit_Que_Le_nombre_En_Inventaire()
        {
            var aliment = new Aliment("Ketchup", 5, "ml", DateTime.Now);
            var nbCommande = 2;

            bool validationDeLInventaire = aliment.ChangerQuantiteAliment(nbCommande);

            Assert.IsTrue(validationDeLInventaire);
        }

        [TestMethod()]
        public void ChangerQuantiteAliment_Retourne_Vrai_Si_Le_Nombre_Retirer_Est_Plus_Grand_Que_Le_nombre_En_Inventaire()
        {
            var aliment = new Aliment("Ketchup", 5, "ml", DateTime.Now);
            var nbCommande = 10;

            bool validationDeLInventaire = aliment.ChangerQuantiteAliment(nbCommande);

            Assert.IsFalse(validationDeLInventaire);
        }
    }
}