using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SmartHunter.Game.Data.ViewModels;
using SmartHunter.Ui.Windows.Panels;
using SmartHunter.Game.Helpers;


namespace SmartHunter.Ui.Windows
{
    public partial class MainUIWindow : Window
    {
        public MainUIWindow()
        {
            InitializeComponent();
            Current_Locale();
            gridMain.DataContext = SettingsViewModel.Instance;
            hideAllSubpanel();
            init_Localization();
            MainContent.Content = new LogPanel();            
        }

        private void Current_Locale()
        {
            string json_locale = ConfigHelper.Main.Values.LocalizationFileName;
            foreach (ComboBoxItem i in cboxLoc.Items)
            {
                if (i.Tag.ToString() == json_locale)
                {
                    cboxLoc.SelectedItem = i;
                }                
            }            
        }


        private string GetLocString (string stringId)
        {
            return LocalizationHelper.GetString(stringId);
        }
        

        private void init_Localization()
        {            
            btnLog.Content = GetLocString("MAIN_UI_LOG");
            btnSettings.Content = GetLocString("MAIN_UI_Settings");
            btnGeneral.Content = GetLocString("MAIN_UI_S_General");
            btnMonster.Content = GetLocString("MAIN_UI_S_Monster");
            btnTeam.Content = GetLocString("MAIN_UI_S_Team");
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

        private void cboxLoc_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ConfigHelper.Main.Values.LocalizationFileName != cboxLoc.SelectedValue.ToString())
            {
                ConfigHelper.Main.Values.LocalizationFileName = cboxLoc.SelectedValue.ToString();
                ConfigHelper.Main.Save();
                var result = MessageBox.Show(GetLocString("LOC_SETTING_RESTART_DESC"), GetLocString("LOC_SETTING_RESTART"), MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    SettingsViewModel.Instance.restartSmartHunter();
                }
            }                
        }
    }
}

