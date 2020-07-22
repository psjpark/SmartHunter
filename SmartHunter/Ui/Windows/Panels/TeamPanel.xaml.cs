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
