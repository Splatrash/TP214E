using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Moq;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class CreationControlButtonTests
    {
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

            Button boutonCree = CreationControlButton.TypeDeButtonACreer(aliment);
            Button boutonCible = new Button();

            Assert.AreEqual(aliment, boutonCree.Tag);
        }

        [TestMethod]
        public void TypeDeBoutonACreer_Lance_InvalidOperationException_Si_L_Objet_En_Parametre_N_Est_Pas_Valide()
        {
            Assert.ThrowsException<InvalidOperationException>(() => CreationControlButton.TypeDeButtonACreer(null));
        }
    }
}