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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RotteHullet.Domain;
using RotteHullet.Data;

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DBFacade.AngivDatabaseFacade(DBFacade.DatabaseType.SqlDatabase);
            DBFacade.HentDatabaseFacade().FindAlleUdlån();
            InitializeComponent();
        }

        private void TilmeldEvent(object sender, MouseButtonEventArgs e)
        {

        }

        private void GlemtAdgangskodeEvent(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_LogPå_Click(object sender, RoutedEventArgs e)
        {
            logind();
        }

        private void logind(bool demo = false)
        {
            if (demo == false)
            {
                try
                {
                    if (tb_Brugernavn.Text != string.Empty && tb_Kodeord.Password != string.Empty)
                    {
                        if (UIFacade.HentUIFacade().HentMedlemFacade().TjekLogind(tb_Brugernavn.Text, tb_Kodeord.Password))
                        {
                            // Fjern advarelse
                            advarelse(false);

                            // Tjekker på bruger typer
                            Window panel;
                            if (UIFacade.HentUIFacade().HentMedlemFacade().ErAdmin)
                            {
                                panel = new AdminPanel();
                            }
                            else
                            {
                                panel = new BrugerPanel();
                            }

                            panel.Show();
                            panel.Activate();
                            this.Close();
                        }
                        else
                        {
                            advarelse(true);
                        }
                    }
                    else
                    {
                        advarelse(true);
                    }
                }
                catch
                {
                    MessageBox.Show("Kan ikke få forbindelse til server, prøv igen senere");
                }
            }
            else
            {
                Window panel;

                if (tb_Brugernavn.Text == "admin")
                {
                    panel = new AdminPanel();
                    panel.Show();
                    panel.Activate();
                    this.Close();
                }
                else if (tb_Brugernavn.Text == "medlem")
                {
                    panel = new BrugerPanel();
                    panel.Show();
                    panel.Activate();
                    this.Close();
                }
                else
                {
                    advarelse(true);
                }
            }
        }
        private void advarelse(bool status = true)
        {
            if (status)
            {
                l_Brugernavn.Foreground = Brushes.Red;
                l_Kodeord.Foreground = Brushes.Red;
            }
            else
            {
                l_Brugernavn.Foreground = Brushes.Black;
                l_Kodeord.Foreground = Brushes.Black;
            }
        }

        private void MusOverEffekt(object sender, MouseEventArgs e)
        {
            Label textKnap = sender as Label;
            textKnap.Foreground = Brushes.SkyBlue;
            textKnap.Cursor = Cursors.Hand;
        }

        private void MusForladEffekt(object sender, MouseEventArgs e)
        {
            Label textKnap = sender as Label;
            textKnap.Foreground = Brushes.Black;
            textKnap.Cursor = Cursors.Arrow;
        }

        private void Logpå_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                logind();
            }
        }
    }
}
