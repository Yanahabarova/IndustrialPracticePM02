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
    /// Логика взаимодействия для WinAddAuthor.xaml
    /// </summary>
    public partial class WinAddAuthor : Window
    {
        DbLibraryContext _db = new DbLibraryContext();
        Author _author;
        public WinAddAuthor()
        {
            InitializeComponent();
            _author = new Author();
            this.DataContext = _author;
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (tbSurname.Text.Length < 1)
            {
                error.AppendLine("Введите фамилию автора");
            }
            if (tbName.Text.Length < 1)
            {
                error.AppendLine("Введите имя автора");
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                using (DbLibraryContext _db = new DbLibraryContext())
                {
                    _db.Authors.Add(_author);
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
