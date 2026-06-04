using System.Windows;

namespace DemoPanel
{
    /// <summary>
    /// Interaction logic for DemoGridPanel.xaml
    /// </summary>
    public partial class DemoGridPanel : Window
    {
        public DemoGridPanel()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string Info = $"Name: {txtName.Text}\n" +
                          $"E-Mail: {txtEmail.Text}\n" +
                          $"Comment: {txtComment.Text}";
            MessageBox.Show(Info, "Submitted Details");
        }
    }
}
