using CategoryService;
using CRUD_FPT.Models;
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

namespace CRUD_FPT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CateService service;
        public MainWindow()
        {
            InitializeComponent();
            service = new CateService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                dgvCategories.ItemsSource = service.GetAllCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showSelected();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            string name = txtCategoryName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Category Name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var category = new Category { CategoryName = name };
            try
            {
                service.InsertCategory(category);
                LoadCategories();
                txtCategoryName.Text = string.Empty;
                MessageBox.Show("Category inserted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting category: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var category = dgvCategories.SelectedItem as Category;
            if (category == null)
            {
                MessageBox.Show("Please select a category from the list to update.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string name = txtCategoryName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Category Name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            category.CategoryName = name;
            try
            {
                service.UpdateCategory(category);
                LoadCategories();
                MessageBox.Show("Category updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating category: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var category = dgvCategories.SelectedItem as Category;
            if (category == null)
            {
                MessageBox.Show("Please select a category from the list to delete.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete the category '{category.CategoryName}'?", 
                                         "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    service.DeleteCategory(category);
                    LoadCategories();
                    txtCategoryID.Text = string.Empty;
                    txtCategoryName.Text = string.Empty;
                    MessageBox.Show("Category deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.InnerException?.Message ?? ex.Message;
                    if (errorMsg.Contains("FK_") || errorMsg.Contains("REFERENCE constraint"))
                    {
                        MessageBox.Show("Cannot delete this category because it contains active products. Please delete its products first.", 
                                        "Referential Integrity Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Error deleting category: {errorMsg}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        public void showSelected()
        {
            var category = dgvCategories.SelectedItem as Category;
            if (category != null)
            {
                txtCategoryID.Text = category.CategoryId.ToString();
                txtCategoryName.Text = category.CategoryName;
            }
            else
            {
                txtCategoryID.Text = string.Empty;
                txtCategoryName.Text = string.Empty;
            }
        }
    }
}