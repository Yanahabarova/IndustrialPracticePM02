using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbLibraryContext _db = new DbLibraryContext();
        public MainWindow()
        {
            InitializeComponent();
            if(Data.ChangeAccount == false)
            {
                WinAuthorization winAuthorization = new WinAuthorization();
                winAuthorization.ShowDialog();
            }
            this.Hide();
            if (Data.Enter == false)
            {
                this.Show();
                this.Close();
            }
            else
            {
                this.Show();
                if (Data.Status == "Гость" || Data.Status == "Читатель")
                {
                    btDistributingBooks.Visibility = Visibility.Hidden;
                    btReaders.Visibility = Visibility.Hidden;
                }
            }
            frBooks.Visibility = Visibility.Visible;
            frReaders.Visibility = Visibility.Hidden;
            frDistributingBooks.Visibility = Visibility.Hidden;
        }

        private void btBooks_Click(object sender, RoutedEventArgs e)
        {
            frBooks.Visibility = Visibility.Visible;
            lbTitleBooks.Visibility = Visibility.Visible;
            lbTitleReaders.Visibility = Visibility.Collapsed;
            frReaders.Visibility = Visibility.Collapsed;
            lbTitleDistributingBooks.Visibility = Visibility.Collapsed;
            frDistributingBooks.Visibility = Visibility.Collapsed;
        }

        private void btReaders_Click(object sender, RoutedEventArgs e)
        {
            frBooks.Visibility = Visibility.Collapsed;
            lbTitleBooks.Visibility = Visibility.Collapsed;
            lbTitleReaders.Visibility = Visibility.Visible;
            frReaders.Visibility = Visibility.Visible;
            lbTitleDistributingBooks.Visibility = Visibility.Collapsed;
            frDistributingBooks.Visibility = Visibility.Collapsed;
        }

        private void btDistributingBooks_Click(object sender, RoutedEventArgs e)
        {
            frBooks.Visibility = Visibility.Collapsed;
            lbTitleBooks.Visibility = Visibility.Collapsed;
            lbTitleReaders.Visibility = Visibility.Collapsed;
            frReaders.Visibility = Visibility.Collapsed;
            lbTitleDistributingBooks.Visibility = Visibility.Visible;
            frDistributingBooks.Visibility = Visibility.Visible;
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}