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
    /// Logique d'interaction pour DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser : Window
    {
        covoitContext context = new covoitContext();

        public DeleteUser()
        {
            InitializeComponent();
        }
       
        private void ButtonListeUtilisateurs_Click(object sender, RoutedEventArgs e)
        {
            ListeComptesUtilisateurs utilisateur = new ListeComptesUtilisateurs();
            utilisateur.Show();
            this.Close();
        }

        private void ButtonDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxId.Text != "")
            {
                context.Users.Remove(
                new Users { IdUser = Int32.Parse(TextBoxId.Text) });
            }
            //sauvegarde des data
            try
            {
                //sauvergarde
                context.SaveChanges();

                MessageBox.Show("La suppresion de cette utilisateur est réussit", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                ListeComptesUtilisateurs utilisateur = new ListeComptesUtilisateurs();
                utilisateur.Show();
                this.Close();
                //recupération de l'exception si echec
            }
            catch (Exception ex)
            {
                //affiche un message d'erreur
                MessageBox.Show(ex.Message, "Une erreur est parvenu lors de la suppression du compte", MessageBoxButton.OK, MessageBoxImage.Error);
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
