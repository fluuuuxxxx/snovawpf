using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using snovawpf.pages;
using snovawpf.Model;

namespace snovawpf.pages
{
    /// <summary>
    /// Логика взаимодействия для signinpage.xaml
    /// </summary>
    public partial class signinpage : Page
    {
        public signinpage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var usernow = AppData.db.users.FirstOrDefault(u => u.username == usernameBox.Text && u.pass == passBox.Password);
                if (usernow != null)
                {
                    CurrentUser.Instance.SetCurrentUser(usernow); // Устанавливаем текущего пользователя
                    if (usernow.roleid == 1)
                    {
                        NavigationService.Navigate(new userpage());
                    }
                    else if (usernow.roleid == 2)
                    {
                        NavigationService.Navigate(new adminpage());
                    }
                }
                else
                {
                    MessageBox.Show("Неверно введен логин или пароль, повторите попытку");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
