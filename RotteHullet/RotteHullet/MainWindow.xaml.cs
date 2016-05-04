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
using RotteHullet.Domain.BusinessLogic;

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DBFacade.AngivDatabaseFacade(DatabaseType.SqlDatabase);
            InitializeComponent();

            /*
            List<Udstyr> udstyr = new List<Udstyr>();
            Udstyr s = new Udstyr(1, "sko", "lol", "lol");
            Udstyr s2 = new Udstyr(0, "sko", "lol", "lol");
            Udstyr s3 = new Udstyr(3, "sko", "lol", "lol");
            Udstyr s4 = new Udstyr(0, "sko", "lol", "lol");
            Udstyr s5 = new Udstyr(0, "sko", "lol", "lol");
            Udstyr s6 = new Udstyr(0, "sko", "lol", "lol");
            udstyr.Add(s);
            udstyr.Add(s2);
            udstyr.Add(s3);
            udstyr.Add(s4);
            udstyr.Add(s5);
            udstyr.Add(s6);
            DBSQLFacade.HentDBSQLFacade().checkLister(0, udstyr);
            */
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

        private void logind()
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
