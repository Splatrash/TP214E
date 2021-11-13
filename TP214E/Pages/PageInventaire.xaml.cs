using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DnsClient.Protocol;
using MongoDB.Bson;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Inventaire.xaml
    /// </summary>
    public partial class PageInventaire : Page
    {
        private List<Aliment> aliments;

        private Aliment alimentSelectionne;

        private DAL dal;

        public PageInventaire()
        {
            dal = new DAL();

            InitializeComponent();

            BtnAjouterModifier.Content = EtatButton.Ajouter.ToString();

            BtnEffacerSupprimer.Content = EtatButton.Effacer.ToString();

            DpDateExpiration.SelectedDate = DateTime.Today;

            btnDeSelectionnerAlimentDatagrid.IsEnabled = false;

            AjouterListeAlimentsDansDataGrid();
        }

        public List<Aliment> ObtenirListeAliments()
        {
            return dal.ChercherAlimentBaseDonnees();
        }

        private void AjouterListeAlimentsDansDataGrid()
        {
            DgInventaire.ItemsSource = ObtenirListeAliments();
        }

        private void EvenementCreationAutomatiqueColonneDansDataGridInventaire(object sender, DataGridAutoGeneratingColumnEventArgs colonneEnCreation)
        {
           FormatageColonneDataGridLorsCreation(colonneEnCreation);
           
        }

        private void FormatageColonneDataGridLorsCreation(DataGridAutoGeneratingColumnEventArgs colonneEnCreation)
        {
            string titreDeLaColonneEnCreation = colonneEnCreation.Column.Header.ToString();

            if (titreDeLaColonneEnCreation == "Id")
                colonneEnCreation.Column.Visibility = Visibility.Collapsed;
        }


        private void EvenementLigneDataGridSelectionneeDoubleClickee(object sender, MouseButtonEventArgs e)
        {
            alimentSelectionne = (Aliment)DgInventaire.SelectedItem;

            btnDeSelectionnerAlimentDatagrid.IsEnabled = true;

            BtnAjouterModifier.Content = nameof(EtatButton.Modifier);
            BtnEffacerSupprimer.Content = nameof(EtatButton.Supprimer);

            RemplissageFormulaireSurAliment();

        }

        private void RemplissageFormulaireSurAliment()
        {
            TxtNom.Text = alimentSelectionne.Nom;
            TxtQuantite.Text = alimentSelectionne.Quantite.ToString();
            TxtUnite.Text = alimentSelectionne.Unite;
            DpDateExpiration.SelectedDate = alimentSelectionne.ExpireLe;
        }

        private void ClickButtonDeSelectionnerAliment(object sender, RoutedEventArgs e)
        {
           DeselectionnerAlimentDansDataGrid();
        }

        private void DeselectionnerAlimentDansDataGrid()
        {
            DgInventaire.UnselectAll();
            BtnAjouterModifier.Content = nameof(EtatButton.Ajouter);
            BtnEffacerSupprimer.Content = nameof(EtatButton.Effacer);
            btnDeSelectionnerAlimentDatagrid.IsEnabled = false;

            EffacerChampsCreationEtModificationAliment();
        }

        private void ClickButtonEffacerOuSupprimerAliment(object sender, RoutedEventArgs e)
        {
            switch (BtnEffacerSupprimer.Content)
            {
                case nameof(EtatButton.Effacer):
                    EffacerChampsCreationEtModificationAliment();
                    break;
                case nameof(EtatButton.Supprimer):
                    dal.SupprimerAlimentDansBaseDonnees(alimentSelectionne.Id);
                    AjouterListeAlimentsDansDataGrid();

                    break;
            }
        }

        private void EffacerChampsCreationEtModificationAliment()
        {
            alimentSelectionne = null;
            TxtNom.Clear();
            TxtQuantite.Clear();
            TxtUnite.Clear();
            DpDateExpiration.SelectedDate = DateTime.Today;
        }
        private void ValidationDesCharactereEcrits(object sender, TextCompositionEventArgs caractereVerifie)
        {
            Regex charactereNumericRegex = new Regex("[0-9]+");
            Regex charactereAlphaNumericRegex = new Regex("[a-zA-Z0-9]+");

            //Comprendre pourquoi le switch ne marche pas...
            //Pt checker pour empecher les espaces
            if(((TextBox)sender).Name == TxtNom.Name)
                caractereVerifie.Handled = !charactereAlphaNumericRegex.IsMatch(caractereVerifie.Text);
            else if (((TextBox)sender).Name == TxtQuantite.Name)
                caractereVerifie.Handled = !charactereNumericRegex.IsMatch(caractereVerifie.Text);
            else if (((TextBox)sender).Name == TxtUnite.Name)
                caractereVerifie.Handled = !charactereAlphaNumericRegex.IsMatch(caractereVerifie.Text);

        }

        private void ClickBoutonAjoutOuModifierAliment(object sender, RoutedEventArgs e)
        {
            switch (BtnAjouterModifier.Content)
            {
                case nameof(EtatButton.Ajouter):
                    dal.AjouterAlimentDansBaseDonnees(CreerAlimentSansId());
                    AjouterListeAlimentsDansDataGrid();
                    break;
                case nameof(EtatButton.Modifier):
                    dal.ModifierAlimentDansBaseDonnees(CreerAlimentApresModification());
                    AjouterListeAlimentsDansDataGrid();
                    DeselectionnerAlimentDansDataGrid();
                    break;
            }
        }

        private Aliment CreerAlimentApresModification()
        {
            Aliment alimentApresModification = CreerAlimentSansId();
            alimentApresModification.Id = alimentSelectionne.Id;
            return alimentApresModification;
        }

        private Aliment CreerAlimentSansId()
        {
            Aliment alimentCreer = new Aliment();
            alimentCreer.Nom = TxtNom.Text.Trim();
            alimentCreer.Quantite = Int32.Parse(TxtQuantite.Text.Trim());
            alimentCreer.Unite = TxtUnite.Text.Trim();
            alimentCreer.ExpireLe = DpDateExpiration.SelectedDate.Value;

            return alimentCreer;
        }
    }
}
