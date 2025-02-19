using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cricket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGeneratePlayer_Click(object sender, RoutedEventArgs e)
        {
            Player player = GeneratePlayer();

            MessageBox.Show($"Name: {player.Name}\nRole: {player.Role.Name}\nBatting Category: {player.BattingPos.Category.Name}\nPreffered Position: {player.BattingPos.PrefferedPosition}");
        }

        private Player GeneratePlayer()
        {
            return new Player();
        }
    }
}