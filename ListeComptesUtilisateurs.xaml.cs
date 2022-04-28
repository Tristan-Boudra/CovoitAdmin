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
using CovoitAdmin.Model;

namespace CovoitAdmin
{
    /// <summary>
    /// Logique d'interaction pour ListeComptesUtilisateurs.xaml
    /// </summary>
    public partial class ListeComptesUtilisateurs : Window
    {
        covoitContext context = new covoitContext();

        public ListeComptesUtilisateurs()
        {
            InitializeComponent();

            //remplissage du datagrid
            DataGridComptesUtilisateurs.ItemsSource = context.Users.ToList();
        }

        private void ButtonAddUsers_Click(object sender, RoutedEventArgs e)
        {
            AjouterUtilisateurs newUtilisateur = new AjouterUtilisateurs();
            newUtilisateur.Show();
            this.Close();
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
            ModificationUser ModificationUser = new ModificationUser(idUser);
            ModificationUser.Show();
            this.Close();
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            DeleteUser delete = new DeleteUser();
            delete.Show();
            this.Close();
        }

        private void ButtonLookUser_Click(object sender, RoutedEventArgs e)
        {
            int idUser = int.Parse(((Button)sender).Tag.ToString());
            int idVehicle = int.Parse(((Button)sender).Tag.ToString());
            InformationsPersonnelles voirUser = new InformationsPersonnelles(idUser, idVehicle);
            voirUser.Show();
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
