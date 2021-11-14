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
            {
                try
                {
                    Button btnCommande = CreationControlButton.TypeDeButtonACreer(commande);
                    btnCommande.Click += new System.Windows.RoutedEventHandler(ClickCommandeDansListeCommandes);
                    WrpPanelCommandes.Children.Add(btnCommande);
                }
                catch (ArgumentNullException exception)
                {
                    MessageBox.Show("Une erreur s'est produite : " + exception.Message, "Ajout d'un boutton");
                    throw;
                }
            }
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
            NavigationService.Navigate(new PageCommandes());
        }
    }
}
