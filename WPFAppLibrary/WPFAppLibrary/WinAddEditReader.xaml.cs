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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WPFAppLibrary
{
    /// <summary>
    /// Логика взаимодействия для WinAddEditReader.xaml
    /// </summary>
    public partial class WinAddEditReader : Window
    {
        public WinAddEditReader()
        {
            InitializeComponent();
        }
        DbLibraryContext _db = new DbLibraryContext();
        Reader _reader;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

            if (Data.GetReader == null)
            {
                _reader = new Reader();
            }
            else
            {
                _reader = _db.Readers.Find(Data.GetReader.Id);
            }
            DataContext = _reader;  
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (tbReadersCardNumber.Text.Length < 1)
            {
                error.AppendLine("Введите номер читательского билета");
            }
            if (tbSurname.Text.Length < 1)
            {
                error.AppendLine("Введите фамилию");
            }
            if (tbName.Text.Length < 1)
            {
                error.AppendLine("Введите имя");
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            if(Int32.TryParse(tbReadersCardNumber.Text, out int number))
            {
                if (Data.GetReader == null)
                {
                    _db.Readers.Add(_reader);
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
