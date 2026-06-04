using System.Windows;

namespace DemoPanel
{
    public partial class DemoWrapPanel : Window
    {
        public DemoWrapPanel()
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
