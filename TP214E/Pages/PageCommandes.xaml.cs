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
    /// Logique d'interaction pour PageCommandes.xaml
    /// </summary>
    public partial class PageCommandes : Page
    {
        private readonly DAL dal;
        public PageCommandes()
        {
            dal = new DAL();

            InitializeComponent();

            SetEtatInitialControlsPage();

            
        }

        private void SetEtatInitialControlsPage()
        {
            BtnHistoriqueCommande.IsEnabled = false;
            BtnCreerCommande.IsEnabled = false;
            BtnEffacerCommande.IsEnabled = false;
        }

        private void ClickBoutonRetourVersAccueil(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageAccueil());
        }

        private void ClickBoutonCreerCommande(object sender, RoutedEventArgs e)
        {

        }

        private void ClickButtonEffacerCommande(object sender, RoutedEventArgs e)
        {

        }

        private void ClickBoutonConsulterHistoriqueInventaire(object sender, RoutedEventArgs e)
        {

        }

        private void ClickButtonConsulterInventaire(object sender, RoutedEventArgs e)
        {

        }
    }
}
