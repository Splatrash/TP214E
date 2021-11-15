using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TP214E.Data
{
    public static class ValidationsEntrees
    {
        #region MÉTHODES
        public static bool ValiderAlphaNumeriqueAvecEspaceNonVide(string entreeAVerifier)
        {
            if (Regex.IsMatch(entreeAVerifier, "^[a-zA-Z0-9]*$") && entreeAVerifier.Trim() != "")
                return true;

            return false;
        }

        public static bool ValiderNumeriqueSansEspaceNonVide(string entreeAVerifier)
        {
            if (int.TryParse(entreeAVerifier, out _))
                return true;

            return false;
        }

        public static bool ValiderAlphaNumeriqueSansEspaceNonVide(string entreeAVerifier)
        {
            if (Regex.IsMatch(entreeAVerifier, "^[a-zA-Z0-9]*$") && ValidationsEntrees.VerifierSiContientEspacesEtNonVide(entreeAVerifier))
                return true;

            return false;
        }

        private static bool VerifierSiContientEspacesEtNonVide(string entreeAVerifier)
        {
            if (!entreeAVerifier.Any(Char.IsWhiteSpace) && entreeAVerifier.Trim() != "")
                return true;

            return false;
        }

        #endregion
    }
}
