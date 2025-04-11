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
using Microsoft.EntityFrameworkCore;
using WPFAppLibrary.Models;

namespace WPFAppLibrary
{
    /// <summary>
    /// Логика взаимодействия для WinAddEditDistributingBook.xaml
    /// </summary>
    public partial class WinAddEditDistributingBook : Window
    {
        public WinAddEditDistributingBook()
        {
            InitializeComponent();
        }
        DbLibraryContext _db = new DbLibraryContext();
        DistributingBook _distributingBook;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _db.Authors.Load();
            cbBook.ItemsSource = _db.Books.ToList();
            cbBook.DisplayMemberPath = "FullInf";
            cbReader.ItemsSource = _db.Readers.ToList();
            cbReader.DisplayMemberPath = "FIO";
            if(Data.GetDistributingBook == null)
            {
                _distributingBook = new DistributingBook();
            }
            else
            {
                _distributingBook = _db.DistributingBooks.Find(Data.GetDistributingBook.Id);
            }
            DataContext = _distributingBook;
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if(cbBook.SelectedItem == null)
            {
                error.AppendLine("Выберите книгу");
            }
            if(cbReader.SelectedItem == null)
            {
                error.AppendLine("Выберите читателя");
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                if (Data.GetDistributingBook == null)
                {
                    _db.DistributingBooks.Add(_distributingBook);
                    _db.SaveChanges();
                }
                else
                {
                    _db.SaveChanges();
                }
                this.Close();
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
