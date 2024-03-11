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
using snovawpf.pages;
using snovawpf.Model;
using System.Runtime.Remoting.Contexts;

namespace snovawpf.pages
{
    /// <summary>
    /// Логика взаимодействия для registerpage.xaml
    /// </summary>
    public partial class registerpage : Page
    {
        public static DateTime dateTime = DateTime.Now;
        public registerpage()
        {
            InitializeComponent();
        }

        private void regBT(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(usernamebox.Text) &&
                !string.IsNullOrEmpty(passbox.Password) &&
                !string.IsNullOrEmpty(passbox2.Password) &&
                !string.IsNullOrEmpty(namebox.Text) &&
                !string.IsNullOrEmpty(surnamebox.Text) &&
                !string.IsNullOrEmpty(databox.Text))
            {
                if (passbox.Password == passbox2.Password)
                {
                    DateTime selectedDate = (DateTime)databox.SelectedDate;
                    if (selectedDate <= DateTime.Today)
                    {
                        users regpers = new users();
                        regpers.id = AppData.db.users.Any() ? AppData.db.users.Max(u => u.id) + 1 : 1;
                        regpers.username = usernamebox.Text;
                        regpers.pass = passbox.Password;
                        regpers.name = namebox.Text;
                        regpers.lastname = surnamebox.Text;
                        regpers.dr = selectedDate;
                        regpers.roleid = 1;
                        AppData.db.users.Add(regpers);
                        AppData.db.SaveChanges();
                        MessageBox.Show("Успешно!");
                    }
                    else
                    {
                        MessageBox.Show("Дата рождения не может быть позже сегодняшней даты.");
                    }
                }
                else
                {
                    MessageBox.Show("Повторный пароль не совпадает.");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля.");
            }

        }

    }
}
