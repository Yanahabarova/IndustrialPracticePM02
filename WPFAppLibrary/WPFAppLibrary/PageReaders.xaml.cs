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
using WPFAppLibrary.Models;

namespace WPFAppLibrary
{
    /// <summary>
    /// Логика взаимодействия для PageReaders.xaml
    /// </summary>
    public partial class PageReaders : Page
    {
        public PageReaders()
        {
            InitializeComponent();
            LoadDbInListView();
        }

        void LoadDbInListView()
        {
            using (DbLibraryContext _db = new DbLibraryContext())
            {
                lvReaders.ItemsSource = _db.Readers.ToList();
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            Data.GetReader = null;
            WinAddEditReader winAddEditReader = new WinAddEditReader();
            winAddEditReader.ShowDialog();
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvReaders.SelectedItem != null)
            {
                Data.GetReader = (Reader)lvReaders.SelectedItem;
                WinAddEditReader winAddEditReader = new WinAddEditReader();
                winAddEditReader.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выделите строку");
            }
            LoadDbInListView();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if(lvReaders.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes) 
                {
                    using (DbLibraryContext _db = new DbLibraryContext())
                    {
                        Reader row = (Reader)lvReaders.SelectedItem;
                        _db.Readers.Remove(row);
                        _db.SaveChanges();
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
