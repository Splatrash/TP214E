using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TP214E.Data;

namespace TP214E.Pages
{
    /// <summary>
    /// Interaction logic for PageHistoriqueCommandes.xaml
    /// </summary>
    public partial class PageHistoriqueCommandes : Page
    {
        public PageHistoriqueCommandes()
        {
            InitializeComponent();

            CreerListeCommandes();
        }

        private void CreerListeCommandes()
        {
            List<Commande> commandes = Commandes.ListeCommandes;

            foreach (Commande commande in commandes)
                WrpPanelCommandes.Children.Add(CreationButtonsListeCommandes(commande));

        }
        private Button CreationButtonsListeCommandes(Commande commande)
        {

            var hexColor = new BrushConverter();

            Button btnCommande = new Button();

            btnCommande.Tag = commande;
            btnCommande.Content = String.Format("Commande {0}\r\n# items: {1}",commande.NumeroCommande, commande.ObjetsCommande.Count);
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
            btnCommande.Click += new System.Windows.RoutedEventHandler(ClickCommandeDansListeCommandes);

            return btnCommande;
        }

        private void ClickCommandeDansListeCommandes(object sender, RoutedEventArgs e)
        {
            DgCommande.Items.Clear();

            Commande commande = (Commande)(sender as Button).Tag;

            foreach (ObjetCommande objetCommande in commande.ObjetsCommande)
            {
                DgCommande.Items.Add(objetCommande);
            }
            
        }

        private void ClickBoutonRetourVersGestionCommandes(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageCommandes());
        }
    }
}
