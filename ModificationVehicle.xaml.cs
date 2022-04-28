using CovoitAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CovoitAdmin
{
    /// <summary>
    /// Logique d'interaction pour ModificationVehicle.xaml
    /// </summary>
    public partial class ModificationVehicle : Window
    {
        covoitContext context = new covoitContext();

        public ModificationVehicle()
        {
            InitializeComponent();
        }

        private void ButtonListeUtilisateurs_Click(object sender, RoutedEventArgs e)
        {
            ListeComptesUtilisateurs utilisateur = new ListeComptesUtilisateurs();
            utilisateur.Show();
            this.Close();
        }

        private void ButtonModificationVehicle_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxIdVehicle.Text != "")
            {
                context.Vehicles.Update(
                new Vehicles { IdVehicles = Int32.Parse(TextBoxIdVehicle.Text), IdMotorization = Int32.Parse(TextBoxIdMotorisation.Text), IdUser = Int32.Parse(TextBoxIdUser.Text), NbPlaces = Int32.Parse(TextBoxNbPlaces.Text), VehicleName = TextBoxNomVehicle.Text, Color = TextBoxCouleur.Text, DateModification = DateTime.Now });
            }
            //sauvegarde des data
            try
            {
                //sauvergarde
                context.SaveChanges();

                MessageBox.Show("La modification du véhicule est réussit", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                ListeComptesUtilisateurs utilisateur = new ListeComptesUtilisateurs();
                utilisateur.Show();
                this.Close();
                //recupération de l'exception si echec
            }
            catch (Exception ex)
            {
                //affiche un message d'erreur
                MessageBox.Show(ex.Message, "Echec", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonModificationMotorisation_Click(object sender, RoutedEventArgs e)
        {
            AllMotorisation motorisation = new AllMotorisation();
            motorisation.Show();
            this.Close();
        }
    }
}
