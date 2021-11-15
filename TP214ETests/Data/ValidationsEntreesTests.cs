using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class ValidationsEntreesTests
    {
        [TestMethod()]
        public void ValiderAlphaNumeriqueAvecEspaceNonVide_Retourne_True_Si_La_Donne_En_Parametre_Respecte_Les_Contraintes()
        {
            string donneeEnParametre = "Ketchup";

            bool validation = ValidationsEntrees.ValiderAlphaNumeriqueAvecEspaceNonVide(donneeEnParametre);

            Assert.IsTrue(validation);
        }

        [TestMethod()]
        public void ValiderAlphaNumeriqueAvecEspaceNonVide_Retourne_False_Si_La_Donne_En_Parametre_Ne_Respecte_Pas_Les_Contraintes()
        {
            string donneeEnParametre = "Ketchup!$/";

            bool validation = ValidationsEntrees.ValiderAlphaNumeriqueAvecEspaceNonVide(donneeEnParametre);

            Assert.IsFalse(validation);
        }

        [TestMethod()]
        public void ValiderNumeriqueSansEspaceNonVide_Retourne_True_Si_La_Donne_En_Parametre_Respecte_Les_Contraintes()
        {
            string donneEnParametre = "12";

            bool validation = ValidationsEntrees.ValiderNumeriqueSansEspaceNonVide(donneEnParametre);

            Assert.IsTrue(validation);

        }

        [TestMethod()]
        public void ValiderNumeriqueSansEspaceNonVide_Retourne_False_Si_La_Donne_En_Parametre_Ne_Respecte_Pas_Les_Contraintes()
        {
            string donneEnParametre = "pqowp";

            bool validation = ValidationsEntrees.ValiderNumeriqueSansEspaceNonVide(donneEnParametre);

            Assert.IsFalse(validation);

        }

        [TestMethod()]
        public void ValiderAlphaNumeriqueSansEspaceNonVide_Retourne_True_Si_La_Donne_En_Parametre_Respecte_Les_Contraintes()
        {
            string donneEnParametre = "ml";

            bool validation = ValidationsEntrees.ValiderAlphaNumeriqueSansEspaceNonVide(donneEnParametre);

            Assert.IsTrue(validation);
        }

        [TestMethod()]
        public void ValiderAlphaNumeriqueSansEspaceNonVide_Retourne_False_Si_La_Donne_En_Parametre_Ne_Respecte_Pas_Les_Contraintes()
        {
            string donneEnParametre = "ml   !";

            bool validation = ValidationsEntrees.ValiderAlphaNumeriqueSansEspaceNonVide(donneEnParametre);

            Assert.IsFalse(validation);
        }
    }
}