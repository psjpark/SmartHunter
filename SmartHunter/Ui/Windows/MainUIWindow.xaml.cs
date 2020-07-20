using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using SmartHunter.Core.Data;
using SmartHunter.Game.Data.ViewModels;
using SmartHunter.Ui.Converters;
using System.ComponentModel;

namespace SmartHunter.Ui.Windows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    ///
    public class BoolToStringConverter : BoolToValueConverter<String> { }

    public partial class MainUIWindow : Window
    {
        public MainUIWindow()
        {
            InitializeComponent();
            tboxLog.DataContext = ConsoleViewModel.Instance;
            gridMain.DataContext = SettingsViewModel.Instance;
            hideAllGrid();
            hideAllSubpanel();
            tboxLog.Visibility = Visibility.Visible;            
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

        private void hideAllGrid()
        {
            tboxLog.Visibility = Visibility.Collapsed;  
            gridSettingsGeneral.Visibility = Visibility.Collapsed;
            gridSettingsTeam.Visibility = Visibility.Collapsed;
            gridSettingsMonster.Visibility = Visibility.Collapsed;
        }

        private void hideAllSubpanel()
        {
            SettingsSubpanel.Visibility = Visibility.Collapsed;            
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrid();
            hideAllSubpanel();
            tboxLog.Visibility = Visibility.Visible;            
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrid();
            hideAllSubpanel();                       
            SettingsSubpanel.Visibility = Visibility.Visible;
            gridSettingsGeneral.Visibility = Visibility.Visible;
        }

        private void btnGeneral_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrid();
            gridSettingsGeneral.Visibility = Visibility.Visible;
        }

        private void btnMonster_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrid();
            gridSettingsMonster.Visibility = Visibility.Visible;
        }

        private void btnTeam_Click(object sender, RoutedEventArgs e)
        {
            hideAllGrid();
            gridSettingsTeam.Visibility = Visibility.Visible;
        }

    }


}

