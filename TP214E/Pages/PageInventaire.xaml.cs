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
using System.Windows.Navigation;
using System.Windows.Shapes;
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

        public PageInventaire(DAL dal)
        {
            InitializeComponent();

            AjouterListeAlimentsDansDataGrid(dal);
        }

        public List<Aliment> ObtenirListeAliments(DAL dal)
        {
            return dal.ChercherAlimentBaseDonnees();
        }

        private void AjouterListeAlimentsDansDataGrid(DAL dal)
        {
            DgInventaire.ItemsSource = ObtenirListeAliments(dal);
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

            RemplissageFormulaireSurAliment();

        }

        private void RemplissageFormulaireSurAliment()
        {
            TxtNom.Text = alimentSelectionne.Nom;
            TxtQuantite.Text = alimentSelectionne.Quantite.ToString();
            TxtUnite.Text = alimentSelectionne.Unite;
            DpDateExpiration.SelectedDate = alimentSelectionne.ExpireLe;
        }
    }
}
