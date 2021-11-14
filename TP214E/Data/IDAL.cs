#region MÉTADONNÉES

// Nom du fichier : IDAL.cs
// Auteur : William (Proprio)
// Date de création : 2021-11-14
// Date de modification : 2021-11-14

#endregion

using System.Collections.Generic;
using MongoDB.Bson;

namespace TP214E.Data
{
    public interface IDAL
    {
        List<Aliment> ChercherAlimentBaseDonnees();
        void AjouterAlimentDansBaseDonnees(Aliment alimentAjoute);
        void ModifierAlimentDansBaseDonnees(Aliment aliment);
        void SupprimerAlimentDansBaseDonnees(ObjectId idAliment);
    }
}