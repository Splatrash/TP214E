using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void CreationButtonsListeAliments_Retourne_Un_Bouton_d_Aliment_Dont_le_Tag_est_L_Aliment_En_Question()
        {
            //var aliment = new Mock<IAliment>();

            //aliment.Setup(n => n.Nom).Returns("alimentTest");
            //aliment.Setup(q => q.Quantite).Returns(1);
            //aliment.Setup(u => u.Unite).Returns("ml");
            //aliment.Setup(d => d.ExpireLe).Returns(DateTime.Today);

            var aliment = new Aliment("alimentTest", 1, "ml", DateTime.Today);

            Button btnCreer = new Button();

            btnCreer = CreationControlButton.CreationButtonsListeAliments(btnCreer, aliment);

            Assert.AreEqual(aliment.Nom, btnCreer.Content);

        }

        [TestMethod]
        public void TypeDeBoutonACreer_Retourne_CreationButtonsListeAliments_Si_lObjet_En_Paramaetre_Est_Un_Aliment()
        {
            var aliment = new Mock<IAliment>();

            aliment.Setup(n => n.Nom).Returns("alimentTest");
            aliment.Setup(q => q.Quantite).Returns(1);
            aliment.Setup(u => u.Unite).Returns("ml");
            aliment.Setup(d => d.ExpireLe).Returns(DateTime.Today);

            Button boutonCree =  CreationControlButton.TypeDeButtonACreer(aliment);
            Button boutonCible = new Button();

            Assert.AreEqual(aliment, boutonCree.Tag);
        }
    }
}