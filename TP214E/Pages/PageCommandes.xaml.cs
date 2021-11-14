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

            CreerListeAliments();



        }

        private void SetEtatInitialControlsPage()
        {
            BtnHistoriqueCommande.IsEnabled = false;
            BtnCreerCommande.IsEnabled = false;
            BtnEffacerCommande.IsEnabled = false;
        }

        private void CreerListeAliments()
        {
            List<Aliment> alimentsDansInventaire = dal.ChercherAlimentBaseDonnees();

            foreach (Aliment aliment in alimentsDansInventaire)
                WrpPanelAliments.Children.Add(CreationButtonAliment(aliment));
            
        }

        private Button CreationButtonAliment(Aliment aliment)
        {
            
            var hexColor = new BrushConverter();

            Button btnAliment = new Button();

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
            btnAliment.Click += new System.Windows.RoutedEventHandler(ClickAlimentDansListeAliments);

            return btnAliment;
        }

        private void ClickAlimentDansListeAliments(object sender, EventArgs e)
        {
            Aliment alimentClicke = (Aliment)((Button)sender).Tag;

            DgCommande.Items.Add(alimentClicke);
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
