﻿using System;
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
using RotteHullet.Domain;

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for OpretÆndreAktiv.xaml
    /// </summary>
    public partial class OpretÆndreAktiv : Window
    {
        public enum IndexTab { Bog, Brætspil, Udstyr, Lokal }

        public OpretÆndreAktiv()
        {
            InitializeComponent();
        }
        //Skal slettes
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        // slut på skal slettes
        private void btn_GemBog_Click(object sender, RoutedEventArgs e)
        {
          UIFacade.HentUIFacade().HentBogFacade().SkabBog(tb_Titel.Text,tb_Forfatter.Text,tb_Genre.Text,tb_Subkategori.Text,tb_Familie.Text,tb_Familie.Text,tb_Kommentar.Text);
        }

        private void btn_GemBrætspil_Click(object sender, RoutedEventArgs e)
        {
            UIFacade.HentUIFacade().HentBrætSpilFacade().SkabBrætSpil(0, tb_Brætspilnavn.Text, tb_BrætspilUdgiver.Text, tb_BrætspilKommentar.Text);
        }

        private void btn_GemUdstyr_Click(object sender, RoutedEventArgs e)
        {
            UIFacade.HentUIFacade().HentUdstyrFacade().SkabUdstyr(0,tb_Udstyrnavn.Text, tb_UdstyrKategori.Text, tb_UdstyrKommentar.Text);
        }

        private void btn_GemLokale_Click(object sender, RoutedEventArgs e)
        {
            UIFacade.HentUIFacade().HentLokaleFacade().SkabLokale(0, tb_Lokalenavn.Text, tb_Lokation.Text, tb_LokaleKommentar.Text, tb_LokaleMøbler.Text);
        }

        private void GåTilMenu() {
            // Gør noget her

        }

        private void btn_AnnullerLokale_Click(object sender, RoutedEventArgs e)
        {
            GåTilMenu();
        }

        private void btn_AnnullerUdstyr_Click(object sender, RoutedEventArgs e)
        {
            GåTilMenu();
        }

        private void btn_AnnullerBrætspil_Click(object sender, RoutedEventArgs e)
        {
            GåTilMenu();

        }

        private void btn_AnnullerBog_Click(object sender, RoutedEventArgs e)
        {
            GåTilMenu();

        }
    }
}
