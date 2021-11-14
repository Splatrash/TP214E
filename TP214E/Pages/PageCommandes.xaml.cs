using System;
using System.Collections.Generic;
using System.Linq;
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
       //CHECKER POUR A JOUR INVENTAIRE AUTOMATIQUEMENT

        private readonly DAL dal;
        public PageCommandes()
        {
            dal = new DAL();

            InitializeComponent();

            CreerListeAliments();

            SetEtatInitialControlsPage();
        }

        private void SetEtatInitialControlsPage()
        {
            if (Commandes.ListeCommandes.Count != 0)
                BtnHistoriqueCommande.IsEnabled = true;
        }

        private void CreerListeAliments()
        {
            List<Aliment> alimentsDansInventaire = dal.ChercherAlimentBaseDonnees();

            foreach (Aliment aliment in alimentsDansInventaire)
                WrpPanelAliments.Children.Add(CreationButtonsListeAliments(aliment));
        }

        private Button CreationButtonsListeAliments(Aliment aliment)
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

            Aliment alimentAjoute = (Aliment)(sender as Button).Tag;

            if (DgCommande.Items.Count == 0)
                ChangerEtatBoutonCreerEtEffacer();

            foreach (ObjetCommande objetCommande in DgCommande.Items)
            {
                if (objetCommande.NomAliment == alimentAjoute.Nom)
                {
                    objetCommande.ChangerQuantite(1);
                    DgCommande.Items.Refresh();
                    return;
                }
            }

            ObjetCommande objetAjouterCommande = new ObjetCommande(alimentAjoute.Nom, 1);
            DgCommande.Items.Add(objetAjouterCommande);
        }

        private void EvenementLigneDataGridSelectionneeDoubleClickee(object sender, MouseButtonEventArgs e)
        {
            DgCommande.Items.Remove(DgCommande.SelectedItem);
            if (DgCommande.Items.Count == 0)
                ChangerEtatBoutonCreerEtEffacer();
            
            DgCommande.Items.Refresh();
        }

        private void ChangerEtatBoutonCreerEtEffacer()
        {
            BtnCreerCommande.IsEnabled = !BtnCreerCommande.IsEnabled;
            BtnEffacerCommande.IsEnabled = !BtnEffacerCommande.IsEnabled;
        }

        private void ClickBoutonCreerCommande(object sender, RoutedEventArgs e)
        {
            List<ObjetCommande> objetsCommande = new List<ObjetCommande>();

            foreach (ObjetCommande objetCommande in DgCommande.Items)
                objetsCommande.Add(objetCommande);
            
            Commande commandeCreer = new Commande(objetsCommande, DateTime.Today);

            Commandes.ListeCommandes.Add(commandeCreer);

            BtnHistoriqueCommande.IsEnabled = true;

            EffacerCommande();
        }

    

        private void ClickButtonEffacerCommande(object sender, RoutedEventArgs e)
        {
            EffacerCommande();
        }

        private void EffacerCommande()
        {
            DgCommande.Items.Clear();
            ChangerEtatBoutonCreerEtEffacer();
            DgCommande.Items.Refresh();
        }

        private void ClickBoutonConsulterHistoriqueInventaire(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageHistoriqueCommandes());
        }

        private void ClickButtonConsulterInventaire(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageInventaire());
        }
        private void ClickBoutonRetourVersAccueil(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAccueil());
        }

    }
    
}
