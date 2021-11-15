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
        public void VerifierEtMettreAJourQuantiteAliments_Retourne_Message_D_Erreur_Si_La_Quantite_Commande_Est_Superieur_A_La_Quantite_D_Inventaire()
        {
            var commande = new List<Aliment>();
            var aliment1 = new Aliment("Ketchup", 5, "ml", DateTime.Today);

            commande .Add(aliment1);

            var objetCommande = new ObjetCommande(aliment1.Nom, 6);

            string message = objetCommande.VerifierEtMettreAJourQuantiteAliments(commande);
            string messageRecherche = String.Format(
                "Il manque d'aliment pour la commande:\n -La commande exige {0} {1}\n -Il reste {2} {3}",
                objetCommande.QuantiteAliment, objetCommande.NomAliment, aliment1.Quantite, aliment1.Nom);

            Assert.AreEqual(messageRecherche, message);
        }

        [TestMethod()]
        public void VerifierEtMettreAJourQuantiteAliments_Retourne_Aucun_Message_Si_La_Quantite_Commande_Est_Inferieur_A_La_Quantite_D_Inventaire()
        {
            var commande = new List<Aliment>();
            var aliment1 = new Aliment("Ketchup", 5, "ml", DateTime.Today);

            commande.Add(aliment1);

            var objetCommande = new ObjetCommande(aliment1.Nom, 3);

            string message = objetCommande.VerifierEtMettreAJourQuantiteAliments(commande);
            string messageRecherche = "";

            Assert.AreEqual(messageRecherche, message);
        }
        [TestMethod()]
        public void VerifierEtMettreAJourQuantiteAliments_Retourne_KeyNotFoundException_Si_L_Aliment_Commande_N_Existe_Pas_Dans_Inventaire()
        {
            var commande = new List<Aliment>();
            var aliment1 = new Aliment("Ketchup", 5, "ml", DateTime.Today);

            var objetCommande = new ObjetCommande(aliment1.Nom, 3);


            Assert.ThrowsException<KeyNotFoundException>(() =>
                objetCommande.VerifierEtMettreAJourQuantiteAliments(commande));
        }
    }
}