# Bookstore Inventory Management Application
## Introduction
 A Windows Presentation Foundation(`WPF`) application using `C#` that interacts with an `SQLite` database to manage the bookstore's inventory.  
 Building and Managing a Dynamic ListView with SQLite in C#: Data Binding, Filtering, and CRUD Operations.  
### Multiple Windows:  
The application includes a main window that displays the current inventory, a window for adding new books, another for editing/deleting existing book details, and a search box to look for specific books.  
### Database Connection:  
The application could connect to an SQLite database (or another database of your choosing) where the bookstore's inventory data will be stored. The database should contain, at least, book title, author, publication year, genre, and quantity in stock.  
### CRUD Operations:  
The application should cover the complete spectrum of CRUD operations (Create, Read, Update, Delete). The bookstore owner should be able to add new books to the inventory, view existing inventory, update book details, and remove books that are no longer in stock.
### Data Display:  
The application displays the bookstore's inventory in a user-friendly way.
### Search Functionality:  
Incorporate a search functionality that allows the bookstore owner to quickly find a specific book or books within their inventory. The search can be based on a criteria like book title, author, or genre.  
## Database
Code in `App.xaml.cs` sets up the file name and path for a database file called "`Books.db`" within the project folder/bin/debug.
