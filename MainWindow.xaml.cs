﻿/* **********************************************************************************
 * For use by students taking 60-422 (Fall, 2014) to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * **********************************************************************************/
using System.Data;
using System.Windows;
using System.Windows.Controls;
using BookstoreGUI;
using BookStoreLIB;

namespace BookStoreGUI
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        DataSet dsBookCat;
        UserData userData;
        BookOrder bookOrder;
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new LoginDialog();
            dlg.Owner = this;
            dlg.ShowDialog();
            // Process data entered by user if dialog box is accepted
            if (dlg.DialogResult == true)
            {
                if (userData.Login(dlg.nameTextBox.Text, dlg.passwordTextBox.Text) == true)
                    this.statusTextBlock.Text = "You are logged in as User #" + userData.UserID;
                else
                    MessageBox.Show("You could not be verified. Please try again.");
            }
        }
        private void exitButton_Click(object sender, RoutedEventArgs e) { this.Close(); }
        public MainWindow() { InitializeComponent(); }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            BookCatalog bookCat = new BookCatalog();
            dsBookCat = bookCat.GetBookInfo();
            this.DataContext = dsBookCat.Tables["Category"];
            bookOrder = new BookOrder();
            userData = new UserData();
            this.orderListView.ItemsSource = bookOrder.OrderItemList;
        }
        private void addButton_Click(object sender, RoutedEventArgs e) {

            OrderItemDialog orderItemDialog = new OrderItemDialog();
            DataRowView selectedRow;
            selectedRow = (DataRowView)this.ProductsDataGrid.SelectedItems[0];
            orderItemDialog.isbnTextBox.Text = selectedRow.Row.ItemArray[0].ToString();
            orderItemDialog.titleTextBox.Text = selectedRow.Row.ItemArray[2].ToString();
            orderItemDialog.priceTextBox.Text = selectedRow.Row.ItemArray[4].ToString();
            orderItemDialog.Owner = this;
            orderItemDialog.ShowDialog();
            if (orderItemDialog.DialogResult == true)
            {
                string isbn = orderItemDialog.isbnTextBox.Text;
                string title = orderItemDialog.titleTextBox.Text;
                double unitPrice = double.Parse(orderItemDialog.priceTextBox.Text);
                int quantity = int.Parse(orderItemDialog.quantityTextBox.Text);
                bookOrder.AddItem(new OrderItem(isbn, title, unitPrice, quantity));
            }
        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            var current = (OrderItem)orderListView.SelectedItems[0];
            var id = current.getID();
            var lv = orderListView.SelectedItem;
            orderListView.ClearValue(ItemsControl.ItemsSourceProperty);
            orderListView.ItemsSource = new ItemsControl().ItemsSource;
            MessageBox.Show("hi");
        }
        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            //bookOrder
        }
        private void checkoutButton_Click(object sender, RoutedEventArgs e) {
            if (userData.UserID < 1 || bookOrder.OrderItemList.Count == 0)
                MessageBox.Show("Please sign in and select book(s) before placing the order.");
            else
            {
                int orderId;
                orderId = bookOrder.PlaceOrder(userData.UserID);
                MessageBox.Show("Your order has been placed. Your order id is "  + orderId.ToString());
            }
        }

        private void orderListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
