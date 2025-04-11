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
using Microsoft.EntityFrameworkCore;
using WPFAppLibrary.Models;

namespace WPFAppLibrary
{
    /// <summary>
    /// Логика взаимодействия для PageDistributingBooks.xaml
    /// </summary>
    public partial class PageDistributingBooks : Page
    {
        public PageDistributingBooks()
        {
            InitializeComponent();
            LoadDbInListView(); 
        }
        void LoadDbInListView()
        {
            using (DbLibraryContext _db = new DbLibraryContext())
            {
                _db.Books.Load();
                _db.Readers.Load();
                _db.Authors.Load();
                lvDistributingBooks.ItemsSource = _db.DistributingBooks.ToList();
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            Data.GetDistributingBook = null;
            WinAddEditDistributingBook winAddEditDistributingBook = new WinAddEditDistributingBook();
            winAddEditDistributingBook.ShowDialog();
            LoadDbInListView();
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            if(lvDistributingBooks.SelectedItem != null)
            {
                Data.GetDistributingBook = (DistributingBook)lvDistributingBooks.SelectedItem;
                WinAddEditDistributingBook winAddEditDistributingBook = new WinAddEditDistributingBook();
                winAddEditDistributingBook.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выделите строку");
            }
            LoadDbInListView();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if(lvDistributingBooks.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    using (DbLibraryContext _db = new DbLibraryContext())
                    {
                        try
                        {
                            DistributingBook row = (DistributingBook)lvDistributingBooks.SelectedItem;
                            _db.DistributingBooks.Remove(row);
                            _db.SaveChanges();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка удаления");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выделите строку");
            }
            LoadDbInListView();
        }
    }
}
