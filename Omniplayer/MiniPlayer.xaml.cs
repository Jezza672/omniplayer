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
using PlayerLibrary.Player;

namespace Omniplayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player Player;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Player = new Player();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Player.Play();
        }


        

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Player.Pause();
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Player.Next();
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            Player.Prev();
        }
    }
}
