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
    /// Logique d'interaction pour InformationsPersonnelles.xaml
    /// </summary>
    public partial class InformationsPersonnelles : Window
    {
        covoitContext context = new covoitContext();

        public InformationsPersonnelles(int idUser, int idVehicle)
        {
            InitializeComponent();

            DataGridInformationsPersonnelles.ItemsSource = context.Users.Where(x => x.IdUser == idUser).ToList();
            DataGridVehicle.ItemsSource = context.Vehicles.Where(x => x.IdUser == idUser).ToList();
        }

        private void ButtonListeUtilisateurs_Click(object sender, RoutedEventArgs e)
        {
            ListeComptesUtilisateurs utilisateur = new ListeComptesUtilisateurs();
            utilisateur.Show();
            this.Close();
        }

        private void Modification(object sender, RoutedEventArgs e)
        {
            int idUser = int.Parse(((Button)sender).Tag.ToString());
            ModificationUser modificationUser = new ModificationUser(idUser);
            modificationUser.Show();
            this.Close();
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            DeleteUser delete = new DeleteUser();
            delete.Show();
            this.Close();
        }

        private void ModificationInformationPersonnelles(object sender, RoutedEventArgs e)
        {
            int IdUser = int.Parse(((Button)sender).Tag.ToString());
            ModificationUser user = new ModificationUser(IdUser);
            user.Show();
            this.Close();
        }

        private void ModificationVehicle(object sender, RoutedEventArgs e)
        {
            ModificationVehicle modificationVehicle = new ModificationVehicle();
            modificationVehicle.Show();
            this.Close();
        }

        private void DeleteVehicle(object sender, RoutedEventArgs e)
        {
            DeleteVehicle deleteVehicle = new DeleteVehicle();
            deleteVehicle.Show();
            this.Close();
        }

        private void ButtonModificationMotorisation_Click(object sender, RoutedEventArgs e)
        {
            AllMotorisation motorisation = new AllMotorisation();
            motorisation.Show();
            this.Close();
        }
    }
}
