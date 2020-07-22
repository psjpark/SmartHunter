using System.Windows.Controls;
using SmartHunter.Game.Data.ViewModels;

namespace SmartHunter.Ui.Windows.Panels
{
    /// <summary>
    /// Interaction logic for TeamPanel.xaml
    /// </summary>
    public partial class TeamPanel : Page
    {
        public TeamPanel()
        {
            InitializeComponent();
            gridSettingsTeam.DataContext = SettingsViewModel.Instance;
        }
    }
}
