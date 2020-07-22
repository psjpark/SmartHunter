using System.Windows.Controls;
using SmartHunter.Game.Data.ViewModels;

namespace SmartHunter.Ui.Windows.Panels
{
    /// <summary>
    /// Interaction logic for GeneralPanel.xaml
    /// </summary>
    public partial class GeneralPanel : Page
    {
        public GeneralPanel()
        {
            InitializeComponent();
            gridSettingsGeneral.DataContext = SettingsViewModel.Instance;
        }
    }
}
