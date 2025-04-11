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
using WPFAppLibrary.Models;

namespace WPFAppLibrary
{
    /// <summary>
    /// Логика взаимодействия для WinAddEditBook.xaml
    /// </summary>
    public partial class WinAddEditBook : Window
    {
        public WinAddEditBook()
        {
            InitializeComponent();
        }

        private void btAddAuthor_Click(object sender, RoutedEventArgs e)
        {
            WinAddAuthor winAddAuthor = new WinAddAuthor();
            winAddAuthor.Owner = this;
            winAddAuthor.ShowDialog();
            cbAuthor.ItemsSource = _db.Authors.ToList();
            cbAuthor.DisplayMemberPath = "FIO";
        }
        DbLibraryContext _db = new DbLibraryContext();
        Book _book;
        Author _author;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbAuthor.ItemsSource = _db.Authors.ToList();
            cbAuthor.DisplayMemberPath = "FIO";
            if (Data.GetBook == null)
            {
                _book = new Book();
            }
            else
            {
                _book = _db.Books.Find(Data.GetBook.Id);
            }
            DataContext = _book;
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if(cbAuthor.SelectedItem == null)
            {
                error.AppendLine("Выберите автора");
            }
            if (tbName.Text.Length < 1)
            {
                error.AppendLine("Введите название книги");
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                if (Data.GetBook == null)
                {
                    _db.Books.Add(_book);
                    _db.SaveChanges();
                }
                else
                {
                    _db.SaveChanges();
                }
                Close();
            }
            
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
