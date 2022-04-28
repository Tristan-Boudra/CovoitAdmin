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
    /// Logique d'interaction pour AjouterUtilisateurs.xaml
    /// </summary>
    public partial class AjouterUtilisateurs : Window
    {
        covoitContext context = new covoitContext();

        public AjouterUtilisateurs()
        {
            InitializeComponent();
        }

        private void ButtonAddUsers_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxPrenom.Text != "" && TextBoxNom.Text != "" && TextBoxPassword.Text != "" && TextBoxTel.Text != "")
            {
                string password = TextBoxPassword.Text;
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
                    byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                    string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                    context.Users.Add(
                    new Users { LName = TextBoxPrenom.Text, FName = TextBoxNom.Text, Password = hash, Tel = Int32.Parse(TextBoxTel.Text), DateCreate = DateTime.Now, DateModification = DateTime.Now });
                    //sauvegarde des data
                    try
                    {
                        //sauvergarde
                        context.SaveChanges();

                        MessageBox.Show("Ajout d'un nouvel utilisateur avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void ButtonListeUtilisateurs_Click(object sender, RoutedEventArgs e)
        {
            ListeComptesUtilisateurs utilisateur = new ListeComptesUtilisateurs();
            utilisateur.Show();
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
