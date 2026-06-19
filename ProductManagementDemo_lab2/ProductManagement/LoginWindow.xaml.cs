using System;
using System.Windows;
using Services;

namespace ProductManagement
{
    public partial class LoginWindow : Window
    {
        private readonly IAccountService _accountService;

        public LoginWindow()
        {
            InitializeComponent();
            _accountService = new AccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string userName = txtUser.Text.Trim();
            string password = txtPass.Password;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                txtError.Text = "Please enter username and password.";
                return;
            }

            try
            {
                var account = _accountService.CheckLogin(userName, password);
                if (account != null)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    txtError.Text = "Invalid username or password.";
                }
            }
            catch (Exception ex)
            {
                txtError.Text = "Login error: " + ex.Message;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
