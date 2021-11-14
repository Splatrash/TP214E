using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using MongoDB.Driver;
using Moq;

namespace TP214E.Data.Tests
{
    [TestClass]
    public class DALTests
    {
        [TestMethod]
        public void DAL_Test_Si_ChercherAlimentBaseDonnees_Retourne_La_Liste_Des_Aliments()
        {
            var dalMock = new Mock<IDAL>();
            var mockList = new List<Aliment>
            {
                new Aliment("aliment1", 1, "g", DateTime.Today),
                new Aliment("aliment2", 1, "ml", DateTime.Today)
            };

            dalMock.Setup(x => x.ChercherAlimentBaseDonnees()).Returns(() => mockList);

            

            Assert.Fail();
        }

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

            commandes.Add(new Commande(null,DateTime.Today));
            commandes.Add(new Commande(null,DateTime.Today));

            int numeroCommande = commande.ObtenirNumeroCommande();


            Assert.AreEqual(3, numeroCommande);
            commandes.Clear();
        }
    }
}