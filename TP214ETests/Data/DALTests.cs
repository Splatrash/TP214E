using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
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

            dalMock.Setup(x => x.ChercherAlimentBaseDonnees()).Returns(() => new List<Aliment> { 1, 2, 3, 4});


            Assert.Fail();
        }
    }
}