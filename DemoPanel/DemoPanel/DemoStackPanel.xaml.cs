using System.Windows;

namespace DemoPanel
{
    /// <summary>
    /// Interaction logic for DemoStackPanel.xaml
    /// </summary>
    public partial class DemoStackPanel : Window
    {
        public DemoStackPanel()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            string CarInfo = $"Car Name:{txtCarName.Text}\n" +
                $"Color:{txtColor.Text}\nBrand:{txtBrand.Text}";
            MessageBox.Show(CarInfo, "Car Details");
        }
    }
}
