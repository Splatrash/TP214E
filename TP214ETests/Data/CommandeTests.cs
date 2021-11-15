using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class CommandeTests
    {
        [TestMethod]
        public void ObtenirNumeroCommande_retourne_le_Numero_de_commande_1_Si_la_Liste_De_Commandes_Est_Vide()
        {
            var commandes = Commandes.ListeCommandes;
            var commande = new Commande(null, DateTime.Today);


            int numeroCommande = commande.ObtenirNumeroCommande();


            Assert.AreEqual(1, numeroCommande);
        }
        [TestMethod]
        public void ObtenirNumeroCommande_retourne_le_Numero_de_Commande_3_Si_la_Liste_De_Commandes_Contient_2_Commandes()
        {
            var commandes = Commandes.ListeCommandes;
            var commande = new Commande(null, DateTime.Today);

            commandes.Add(new Commande(null, DateTime.Today));
            commandes.Add(new Commande(null, DateTime.Today));

            int numeroCommande = commande.ObtenirNumeroCommande();


            Assert.AreEqual(3, numeroCommande);
            commandes.Clear();
        }
    }
}