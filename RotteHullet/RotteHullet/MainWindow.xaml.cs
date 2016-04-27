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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RotteHullet.Domain;

namespace RotteHullet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UIFacade.getUIFacade().getBogFacade().doBogStuff();
        }


        private void TilmeldEvent(object sender, MouseButtonEventArgs e)
        {

        }

        private void GlemtAdgangskodeEvent(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_LogPå_Click(object sender, RoutedEventArgs e)
        {
            Window panel = new AdminPanel();
            panel.Show();
        }
    }
}
