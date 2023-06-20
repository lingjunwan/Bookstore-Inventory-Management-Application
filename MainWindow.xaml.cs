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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookstoreManagement.Classes;

namespace BookstoreManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Book> books;
        public MainWindow()
        {
            InitializeComponent();
            books = new List<Book>();
            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow();
            addBookWindow.ShowDialog();// 'ShowDialog' will wait for the new window to be closed before allowing navigation back to the main window.

            ReadDatabase();

        }

        void ReadDatabase()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Book>();
                books = (conn.Table<Book>().ToList()).OrderBy(b => b.Title).ToList();
            }

            if (books != null)
            {
                booksListView.ItemsSource = books;
            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextbox = sender as TextBox;
            var filteredList = books.Where(b => b.Title.ToLower().Contains(searchTextbox.Text.ToLower())).ToList();
            var filteredList2 = (from b2 in books
                                 where b2.Title.ToLower().Contains(searchTextbox.Text.ToLower())
                                 orderby b2.Author
                                 select b2).ToList();

            booksListView.ItemsSource = filteredList;
        }

        private void booksListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selectedBook = booksListView.SelectedItem as Book;
            if (selectedBook != null)
            {
                BookDetailsWindow bookDetailsWindow = new BookDetailsWindow(selectedBook);
                bookDetailsWindow.ShowDialog();

                ReadDatabase();
            }

        }
    }
}
