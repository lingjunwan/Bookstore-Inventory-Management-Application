using BookstoreManagement.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace BookstoreManagement
{
    /// <summary>
    /// Interaction logic for BookDetailsWindow.xaml
    /// </summary>
    public partial class BookDetailsWindow : Window
    {
        Book book;
        public BookDetailsWindow(Book book)
        {
            InitializeComponent();
            this.book = book;
            titleTextBox.Text = book.Title;
            authorTextBox.Text = book.Author;
            publicationYearTextBox.Text = book.Year.ToString();
            genreTextBox.Text = book.Genre;
            quantityInStockTextBox.Text = book.QuantityInStock.ToString();

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Book>();
                connection.Delete(book);
            }
            Close();
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            book.Title = titleTextBox.Text;
            book.Author = authorTextBox.Text;
            book.Year = int.Parse(publicationYearTextBox.Text);
            book.Genre = genreTextBox.Text;
            book.QuantityInStock = int.Parse(quantityInStockTextBox.Text);

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Book>();
                connection.Update(book);
            }
            Close();
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
