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




    }
}