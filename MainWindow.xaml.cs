using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CovoitAdmin.Model;

namespace CovoitAdmin
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        covoitContext context = new covoitContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connection(object sender, RoutedEventArgs e)
        {
            covoitContext context = new covoitContext();

            int tel = Int32.Parse(TextBoxTel.Text);

            string password = TextBoxMdp.Text;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                Users users = context.Users.Where(x => x.Password == hash && x.Tel == tel).First();
                if( users != null){
                    ListeComptesUtilisateurs utilisateur = new ListeComptesUtilisateurs();
                    utilisateur.Show();
                    this.Close();
                }

                try
                {
                    context.SaveChanges();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Téléphone incorrecte", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
