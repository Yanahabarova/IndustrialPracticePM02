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
    /// Логика взаимодействия для PageBooks.xaml
    /// </summary>
    public partial class PageBooks : Page
    {
        public PageBooks()
        {
            InitializeComponent();
            LoadDbInListView();
        }
        void LoadDbInListView()
        {
            using (DbLibraryContext _db = new DbLibraryContext())
            {
                _db.Authors.Load();
                lvBooks.ItemsSource = _db.Books.ToList();
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            Data.GetBook = null;
            WinAddEditBook winAddEditBook = new WinAddEditBook();
            winAddEditBook.ShowDialog();
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvBooks.SelectedItem != null)
            {
                Data.GetBook = (Book)lvBooks.SelectedItem;
                WinAddEditBook winAddEditBook = new WinAddEditBook();
                winAddEditBook.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выделите строку");
            }
            LoadDbInListView();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if(lvBooks.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (DbLibraryContext _db = new DbLibraryContext())
                        {
                            Book row = (Book)lvBooks.SelectedItem;
                            _db.Books.Remove(row);
                            _db.SaveChanges();
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка удаления");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выделите строку");
            }
            LoadDbInListView();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Data.Status == "Гость" || Data.Status == "Читатель")
            {
                btAdd.Visibility = Visibility.Hidden;
                btEdit.Visibility = Visibility.Hidden;
                btDelete.Visibility = Visibility.Hidden;
            }
        }
    }
}
