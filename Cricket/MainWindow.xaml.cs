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

            MessageBox.Show(player.ToString());
        }

        private Player GeneratePlayer()
        {
            return new Player();
        }

        private void btnTestSimInnings_Click(object sender, RoutedEventArgs e)
        {
            Team teamA = new Team();
            Team teamB = new Team();

            for (int i = 0; i < 11; i++) 
            {
                Player newPlayer = GeneratePlayer();

                teamA.AddPlayer(newPlayer);
                teamB.AddPlayer(newPlayer);
            }

            Match match = new Match(SelectFormat.Formats[0], teamA, teamB);
            MessageBox.Show(match.SimulateInnings());
        }
    }
}