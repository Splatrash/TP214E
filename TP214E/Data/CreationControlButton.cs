﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TP214E.Data
{
    public static class CreationControlButton
    {
        #region MÉTHODES
        public static Button TypeDeBoutonACreer(Object objetABouton)
        {
            Button btnCreer = new Button();

            if (objetABouton is Aliment)
                return CreationBoutonsListeAliments(btnCreer, (Aliment)objetABouton);

            else if(objetABouton is Commande)
                return CreationBoutonsListeCommandes(btnCreer, (Commande) objetABouton);

            else
                throw new InvalidOperationException("Le type de button a créer n'existe pas ou n'est pas pris en charge.");
        }

        public static Button CreationBoutonsListeAliments(Button btnAliment, Aliment aliment)
        {

            var hexColor = new BrushConverter();

            btnAliment.Content = aliment.Nom;
            btnAliment.Tag = aliment;
            btnAliment.Background = (Brush)hexColor.ConvertFrom("#03179c");
            btnAliment.Foreground = Brushes.White;
            btnAliment.BorderBrush = Brushes.White;
            btnAliment.BorderThickness = new Thickness(2, 2, 2, 2);
            btnAliment.Margin = new Thickness(6, 6, 6, 6);
            btnAliment.Padding = new Thickness(10, 10, 10, 10);
            btnAliment.FontSize = 16;
            btnAliment.FontWeight = FontWeights.Bold;
            btnAliment.FontFamily = new FontFamily("Rockwell");

            return btnAliment;
        }

        public static Button CreationBoutonsListeCommandes(Button btnCommande,Commande commande)
        {
            var hexColor = new BrushConverter();

            btnCommande.Tag = commande;
            btnCommande.Content = String.Format("Commande {0}\r\n# items: {1}", commande.NumeroCommande, commande.ObjetsCommande.Count);
            btnCommande.Background = (Brush)hexColor.ConvertFrom("#c95502");
            btnCommande.Foreground = Brushes.White;
            btnCommande.BorderBrush = Brushes.White;
            btnCommande.BorderThickness = new Thickness(2, 2, 2, 2);
            btnCommande.Margin = new Thickness(6, 6, 6, 6);
            btnCommande.Padding = new Thickness(10, 10, 10, 10);
            btnCommande.FontSize = 16;
            btnCommande.FontWeight = FontWeights.Bold;
            btnCommande.FontFamily = new FontFamily("Rockwell");
            btnCommande.Width = 152;

            return btnCommande;
        }
        #endregion
    }

}
