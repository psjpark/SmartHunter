
using System.Windows.Controls;
using SmartHunter.Game.Data.ViewModels;

namespace SmartHunter.Ui.Windows
{
    /// <summary>
    /// Interaction logic for LogPanel.xaml
    /// </summary>
    public partial class LogPanel : Page
    {
        public LogPanel()
        {
            InitializeComponent();
            tboxLog.DataContext = ConsoleViewModel.Instance;
        }
    }
}
