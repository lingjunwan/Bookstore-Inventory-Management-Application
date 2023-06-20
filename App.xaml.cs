using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BookstoreManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "Books.db";
        static string projectFolderPath = AppDomain.CurrentDomain.BaseDirectory; // in project folder
        public static string databasePath = System.IO.Path.Combine(projectFolderPath, databaseName);
    }
}
