using CovoitAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Logique d'interaction pour ModificationUser.xaml
    /// </summary>
    public partial class ModificationUser : Window
    {
        covoitContext context = new covoitContext();

        public ModificationUser(int IdUser)
        {
            InitializeComponent();

            //DataGridModificationUsers.ItemsSource = context.Users.Where(x => x.IdUser == IdUser).ToList();
        }

        private void ButtonListeUtilisateurs_Click(object sender, RoutedEventArgs e)
        {
            ListeComptesUtilisateurs utilisateur = new ListeComptesUtilisateurs();
            utilisateur.Show();
            this.Close();
        }

        private void ButtonApplicationModificationUser_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxId.Text != "" && TextBoxPassword.Text == TextBoxPasswordConfirm.Text)
            {
                string password = TextBoxPassword.Text;
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
                    byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                    string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                    context.Users.Update(
                    new Users { IdUser = Int32.Parse(TextBoxId.Text), LName = TextBoxPrenom.Text, FName = TextBoxNom.Text, Password = hash, Tel = Int32.Parse(TextBoxTel.Text), DateModification = DateTime.Now });
                    
                    //sauvegarde des data
                    try
                    {
                        //sauvergarde
                        context.SaveChanges();

                        MessageBox.Show("Les modificatoins de cette utilisateur est réussit", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
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
