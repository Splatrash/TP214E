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
            {
                try
                {
                    Button btnAliment = CreationControlButton.TypeDeBoutonACreer(aliment);
                    btnAliment.Click += new System.Windows.RoutedEventHandler(ClickAlimentDansListeAliments);
                    WrpPanelAliments.Children.Add(btnAliment);
                }
                catch (ArgumentNullException exception)
                {
                    MessageBox.Show("Une erreur s'est produite : " + exception.Message, "Ajout d'un boutton");
                    throw;
                }
            }
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
            CreerUneCommande();
        }

        private void CreerUneCommande()
        {
            List<ObjetCommande> objetsCommande = new List<ObjetCommande>();

            List<Aliment> inventaireAliments = dal.ChercherAlimentBaseDonnees();

            foreach (ObjetCommande objetCommande in DgCommande.Items)
            {
                foreach (Aliment aliment in inventaireAliments)
                {
                    if (objetCommande.NomAliment == aliment.Nom)
                    {
                        if (!aliment.ChangerQuantiteAliment(objetCommande.QuantiteAliment))
                        {
                            MessageBox.Show(String.Format(
                                "Il manque d'aliment pour la commande:\n -La commande exige {0} {1}\n -Il reste {2} {3}",
                                objetCommande.QuantiteAliment, objetCommande.NomAliment, aliment.Quantite,
                                aliment.Nom));
                            return;
                        }
                        
                        break;
                    }
                }
                objetsCommande.Add(objetCommande);
            }

            foreach (Aliment aliment in inventaireAliments)
                dal.ModifierAlimentDansBaseDonnees(aliment);
            
            Commande commandeCreer = new Commande( objetsCommande, DateTime.Today);

            Commandes.ListeCommandes.Add(commandeCreer);

            EffacerCommande();

            BtnHistoriqueCommande.IsEnabled = true;
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
