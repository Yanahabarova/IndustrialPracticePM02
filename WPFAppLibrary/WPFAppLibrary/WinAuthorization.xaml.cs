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
    /// Логика взаимодействия для WinAuthorization.xaml
    /// </summary>
    public partial class WinAuthorization : Window
    {
        public WinAuthorization()
        {
            InitializeComponent();
            Data.Enter = false;

        }

        private void btEnter_Click(object sender, RoutedEventArgs e)
        {
            using (DbLibraryContext _db = new DbLibraryContext())
            {
                _db.Users.Load();
                _db.Roles.Load();
                try
                {
                    var user = _db.Users.Where(p => p.Login == tbLogin.Text && p.Password == pbPassword.Password).First();
                    if (user != null)
                    {
                        Data.Status = user.IdRoleNavigation.Role1;

                        if (user.IdRoleNavigation.Role1 == "Читатель")
                        {
                            Data.GetReader = _db.Readers.Where(p => p.Id == user.IdReader).First();
                        }
                        this.Close();
                        Data.Enter = true;
                    }
                }
                catch (System.InvalidOperationException)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }

        private void btContinueAsGuest_Click(object sender, RoutedEventArgs e)
        {
            Data.Status = "Гость";
            Data.Enter = true;
            this.Close();
        }
    }
}
