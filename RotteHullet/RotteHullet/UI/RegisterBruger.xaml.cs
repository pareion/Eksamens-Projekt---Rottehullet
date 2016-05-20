using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RotteHullet.Domain;

namespace RotteHullet.UI
{
    /// <summary>
    /// Interaction logic for RegisterBruger.xaml
    /// </summary>
    public partial class RegisterBruger : Window
    {
        public bool ErUdfyldt { get; set; }

        public RegisterBruger()
        {
            InitializeComponent();
            this.Activate();
        }

        private void Tekst_Redigered(object sender, TextChangedEventArgs e)
        {
            redigeringFilter();
        }

        private void Password_Redigered(object sender, RoutedEventArgs e)
        {
            redigeringFilter();
        }

        private void Tilmeld_Click(object sender, RoutedEventArgs e)
        {
            tilmelding();
        }

        private void Annullere_Click(object sender, RoutedEventArgs e)
        {
            LoginSide login = new LoginSide();
            login.Activate();
            login.Show();
            this.Close();
        }

        private void tilmelding()
        {
            if (ErUdfyldt)
            {
                try
                {
                    UIFacade.HentUIFacade().HentMedlemFacade().GemMedlem
                    (
                        tb_Brugernavn.Text,
                        pb_Password.Password,
                        tb_Fornavn.Text,
                        tb_Efternavn.Text,
                        tb_Email.Text
                    );
                    MessageBox.Show("Velkommen til Rottehullet");

                    LoginSide login = new LoginSide();
                    login.Show();
                    login.Activate(); 
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fejl, prøv igen senere");
                }
            }
        }

        private void redigeringFilter()
        {
            if (tb_Brugernavn.Text == null || tb_Brugernavn.Text == string.Empty || tb_Brugernavn.Text.Length < 3)
            {
                ErUdfyldt = false;
            }
            else if ((pb_Password.Password == null || pb_Password.Password == string.Empty) || (pb_Password.Password.Length < 3) || (pb_Password.Password != pb_GenPassword.Password))
            {
                ErUdfyldt = false;
            }
            else if (!tjekEmail(tb_Email.Text))
            {
                ErUdfyldt = false;
            }
            else if (tb_Fornavn.Text == null || tb_Fornavn.Text == string.Empty || tb_Fornavn.Text.Length < 3)
            {
                ErUdfyldt = false;
            }
            else if (tb_Efternavn.Text == null || tb_Efternavn.Text == string.Empty || tb_Efternavn.Text.Length < 3)
            {
                ErUdfyldt = false;
            }
            else
            {
                ErUdfyldt = true;
            }

            if (ErUdfyldt)
            {
                btn_Tilmeld.IsEnabled = true;
            }
            else
            {
                btn_Tilmeld.IsEnabled = false;
            }
        }

        private bool tjekEmail(string email)
        {
            return Regex.IsMatch(email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
        }
    }
}
