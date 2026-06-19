using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BusinessObjects;
using Services;

namespace ProductManagement
{
    public partial class MainWindow : Window
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public MainWindow()
        {
            InitializeComponent();
            _productService = new ProductService();
            _categoryService = new CategoryService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategories();
            LoadProducts();
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _categoryService.GetCategories();
                cboCategory.ItemsSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        private void LoadProducts()
        {
            try
            {
                var products = _productService.GetProducts();
                dgData.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtUnitsInStock.Text = "";
            cboCategory.SelectedIndex = -1;
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is Product product)
            {
                txtProductID.Text = product.ProductId.ToString();
                txtProductName.Text = product.ProductName;
                txtPrice.Text = product.Price?.ToString() ?? "";
                txtUnitsInStock.Text = product.UnitsInStock?.ToString() ?? "";
                cboCategory.SelectedValue = product.CategoryId;
            }
        }

        private bool ValidateInput(out Product product)
        {
            product = new Product();

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Product name is required.");
                return false;
            }

            decimal? price = null;
            if (!string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                if (!decimal.TryParse(txtPrice.Text, out decimal parsedPrice))
                {
                    MessageBox.Show("Price must be a valid number.");
                    return false;
                }
                price = parsedPrice;
            }

            int? unitsInStock = null;
            if (!string.IsNullOrWhiteSpace(txtUnitsInStock.Text))
            {
                if (!int.TryParse(txtUnitsInStock.Text, out int parsedUnits))
                {
                    MessageBox.Show("Units in stock must be a valid integer.");
                    return false;
                }
                unitsInStock = parsedUnits;
            }

            product.ProductName = txtProductName.Text.Trim();
            product.Price = price;
            product.UnitsInStock = unitsInStock;
            product.CategoryId = cboCategory.SelectedValue as int?;

            return true;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput(out Product product)) return;

            try
            {
                _productService.CreateProduct(product);
                MessageBox.Show("Product created successfully.");
                LoadProducts();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating product: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                MessageBox.Show("Please select a product to update.");
                return;
            }

            if (!ValidateInput(out Product product)) return;
            product.ProductId = int.Parse(txtProductID.Text);

            try
            {
                bool success = _productService.UpdateProduct(product);
                if (success)
                {
                    MessageBox.Show("Product updated successfully.");
                    LoadProducts();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Product not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this product?",
                                          "Confirm Delete", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            try
            {
                int id = int.Parse(txtProductID.Text);
                bool success = _productService.DeleteProduct(id);
                if (success)
                {
                    MessageBox.Show("Product deleted successfully.");
                    LoadProducts();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Product not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
