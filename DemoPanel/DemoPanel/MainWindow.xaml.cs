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

namespace DemoPanel
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

        private void btnCanvas_Click(object sender, RoutedEventArgs e)
        {
            DemoCanvasPanel canvasWin = new DemoCanvasPanel();
            canvasWin.Show();
        }

        private void btnWrap_Click(object sender, RoutedEventArgs e)
        {
            DemoWrapPanel wrapWin = new DemoWrapPanel();
            wrapWin.Show();
        }

        private void btnStack_Click(object sender, RoutedEventArgs e)
        {
            DemoStackPanel stackWin = new DemoStackPanel();
            stackWin.Show();
        }

        private void btnGrid_Click(object sender, RoutedEventArgs e)
        {
            DemoGridPanel gridWin = new DemoGridPanel();
            gridWin.Show();
        }
    }
}