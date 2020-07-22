
using System.Windows.Controls;
using SmartHunter.Game.Data.ViewModels;

namespace SmartHunter.Ui.Windows.Panels
{
    /// <summary>
    /// Interaction logic for MonsterPanel.xaml
    /// </summary>
    public partial class MonsterPanel : Page
    {
        public MonsterPanel()
        {
            InitializeComponent();
            gridSettingsMonster.DataContext = SettingsViewModel.Instance;
        }
    }
}
