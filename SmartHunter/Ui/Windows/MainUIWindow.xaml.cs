using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using SmartHunter.Core.Data;
using SmartHunter.Game.Data.ViewModels;
using SmartHunter.Ui.Converters;
using System.ComponentModel;
using SmartHunter.Ui.Windows.Panels;
using System.Windows.Controls;

namespace SmartHunter.Ui.Windows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    ///   

    public partial class MainUIWindow : Window
    {
        public MainUIWindow()
        {
            InitializeComponent();         
            gridMain.DataContext = SettingsViewModel.Instance;
            hideAllSubpanel();
            MainContent.Content = new LogPanel();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();            
        }

        private void hideAllSubpanel()
        {
            SettingsSubpanel.Visibility = Visibility.Collapsed;            
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            hideAllSubpanel();
            MainContent.Content = new LogPanel();
            Highlight.Margin = new Thickness(-90, 100, 0, 0);
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            hideAllSubpanel();
            SettingsSubpanel.Visibility = Visibility.Visible;
            MainContent.Content = new GeneralPanel();
            Highlight.Margin = new Thickness(-90, 152, 0, 0);
        }

        private void btnGeneral_Click(object sender, RoutedEventArgs e)
        {
            hideAllSubpanel();
            SettingsSubpanel.Visibility = Visibility.Visible;
            MainContent.Content = new GeneralPanel();
            Highlight.Margin = new Thickness(-90, 152, 0, 0);
        }

        private void btnMonster_Click(object sender, RoutedEventArgs e)
        {
            hideAllSubpanel();
            SettingsSubpanel.Visibility = Visibility.Visible;
            MainContent.Content = new MonsterPanel();
            Highlight.Margin = new Thickness(-90, 177, 0, 0);
        }

        private void btnTeam_Click(object sender, RoutedEventArgs e)
        {
            hideAllSubpanel();
            SettingsSubpanel.Visibility = Visibility.Visible;
            MainContent.Content = new TeamPanel();
            Highlight.Margin = new Thickness(-90, 202, 0, 0);
        }

    }


}

