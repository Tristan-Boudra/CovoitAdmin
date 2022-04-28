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
    /// Logique d'interaction pour ModificationMotorisation.xaml
    /// </summary>
    public partial class ModificationMotorisation : Window
    {
        covoitContext context = new covoitContext();

        public ModificationMotorisation()
        {
            InitializeComponent();
        }

        private void ButtonListeUtilisateurs_Click(object sender, RoutedEventArgs e)
        {
            ListeComptesUtilisateurs utilisateur = new ListeComptesUtilisateurs();
            utilisateur.Show();
            this.Close();
        }

        private void BouttonModificationMotorisation_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxIdMotorisation.Text != "" && TextBoxModificationLibellet.Text != "")
            {
                context.Motorization.Update(
                new Motorization { IdMotorization = Int32.Parse(TextBoxIdMotorisation.Text), Libellet = TextBoxModificationLibellet.Text });

                //sauvegarde des data
                try
                {
                    //sauvergarde
                    context.SaveChanges();

                    MessageBox.Show("Modification de la motorisation réussit", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    AllMotorisation motorisation = new AllMotorisation();
                    motorisation.Show();
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

        private void ButtonModificationMotorisation_Click(object sender, RoutedEventArgs e)
        {
            AllMotorisation motorisation = new AllMotorisation();
            motorisation.Show();
            this.Close();
        }
    }
}
