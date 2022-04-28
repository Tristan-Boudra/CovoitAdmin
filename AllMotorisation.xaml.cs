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
    /// Logique d'interaction pour AllMotorisation.xaml
    /// </summary>
    public partial class AllMotorisation : Window
    {
        covoitContext context = new covoitContext();

        public AllMotorisation()
        {
            InitializeComponent();

            DataGridAllMotorisation.ItemsSource = context.Motorization.ToList();
        }

        private void ButtonListeUtilisateurs_Click(object sender, RoutedEventArgs e)
        {
            ListeComptesUtilisateurs utilisateur = new ListeComptesUtilisateurs();
            utilisateur.Show();
            this.Close();
        }

        private void ButtonModificationMotorisation(object sender, RoutedEventArgs e)
        {
            ModificationMotorisation modifier = new ModificationMotorisation();
            modifier.Show();
            this.Close();
        }

        private void ButtonSuppresionMotorisation(object sender, RoutedEventArgs e)
        {
            DeleteMotorisation supprimer = new DeleteMotorisation();
            supprimer.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AjouterMotorisation ajouter = new AjouterMotorisation();
            ajouter.Show();
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
