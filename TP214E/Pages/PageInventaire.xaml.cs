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

        private Aliment alimentSelectionne;

        private readonly DAL dal;

        public PageInventaire()
        {
            dal = new DAL();

            InitializeComponent();

            SetEtatInitialControlsPage();

            AjouterListeAlimentsDansDataGrid();
        }

        private void SetEtatInitialControlsPage()
        {
            BtnAjouterModifier.Content = EtatButton.Ajouter.ToString();
            BtnEffacerSupprimer.Content = EtatButton.Effacer.ToString();
            
            DpDateExpiration.SelectedDate = DateTime.Today;
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
                    DeselectionnerAlimentDansDataGrid();
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
                    if (ValidationAliment())
                    {
                        dal.AjouterAlimentDansBaseDonnees(CreerAlimentSansId());
                        AjouterListeAlimentsDansDataGrid();
                        DeselectionnerAlimentDansDataGrid();
                    }
                    break;
                case nameof(EtatButton.Modifier):
                    if (ValidationAliment())
                    {
                        dal.ModifierAlimentDansBaseDonnees(CreerAlimentApresModification());
                        AjouterListeAlimentsDansDataGrid();
                        DeselectionnerAlimentDansDataGrid();
                    }
                    break;
            }
            
        }

        private bool ValidationAliment()
        {
            string contenuMessageBoxErreur = "";
            if (!ValidationsEntrees.ValiderAlphaNumeriqueAvecEspaceNonVide(TxtNom.Text))
                contenuMessageBoxErreur += "- Le nom doit seulement contenir des caractères alphanumérique et ne pas être vide.\n";
            if (!ValidationsEntrees.ValiderAlphaNumeriqueSansEspaceNonVide(TxtUnite.Text))
                contenuMessageBoxErreur += "- L'unite doit seulement contenir des caractères alphanumérique, pas d'espaces et ne pas être vide.\n";
            if (!ValidationsEntrees.ValiderNumeriqueSansEspaceNonVide(TxtQuantite.Text))
                contenuMessageBoxErreur += "- La quantité doit seulement contenir des caractères numérique, d'espaces et ne pas être vide.\n";

            if (contenuMessageBoxErreur != "")
            {
                MessageBox.Show("L'ajout n'a pas pu se faire, veillez suivre ces conseils: \n \n" + contenuMessageBoxErreur, "Vérifier les données", MessageBoxButton.OK);
                return false;
            }
            else
                return true;
        }

        private Aliment CreerAlimentApresModification()
        {
            Aliment alimentApresModification = CreerAlimentSansId();
            alimentApresModification.Id = alimentSelectionne.Id;

            return alimentApresModification;
        }

        private Aliment CreerAlimentSansId()
        {
            
            Aliment alimentCreer = new Aliment(TxtNom.Text.Trim(), Int32.Parse(TxtQuantite.Text.Trim()), TxtUnite.Text.Trim(), DpDateExpiration.SelectedDate.Value);

            return alimentCreer;
        }

        private void ClickBoutonRetourVersAccueil(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAccueil());
        }
    }
}
