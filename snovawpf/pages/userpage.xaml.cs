using snovawpf.DialogWindows;
using snovawpf.Model;
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

namespace snovawpf.pages
{
    /// <summary>
    /// Логика взаимодействия для userpage.xaml
    /// </summary>
    public partial class userpage : Page
    {
        public userpage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new signinpage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Window inputWindow = new UserRentInputWindow();
                if (inputWindow != null && inputWindow.ShowDialog() == true)
                {
                    if (inputWindow is UserRentInputWindow)
                    {
                        UserRentInputWindow userRentInputWindow = (UserRentInputWindow)inputWindow;

                        users currentUser = CurrentUser.Instance.User;
                        if (currentUser == null)
                        {
                            MessageBox.Show("Не удалось определить текущего пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        rents addUser = new rents();
                        addUser.id = AppData.db.users.Any() ? AppData.db.users.Max(u => u.id) + 1 : 1;
                        addUser.userid = currentUser.id;
                        addUser.bookid = 1;
                        addUser.datastart = DateTime.Now;
                        addUser.datafinish = userRentInputWindow.SelectedOption;
                        AppData.db.rents.Add(addUser);
                        AppData.db.SaveChanges();
                        MessageBox.Show("Вы взяли книгу в аренду", "Успешно");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Window inputWindow = new UserRentInputWindow();
                if (inputWindow != null && inputWindow.ShowDialog() == true)
                {
                    if (inputWindow is UserRentInputWindow)
                    {
                        UserRentInputWindow userRentInputWindow = (UserRentInputWindow)inputWindow;

                        users currentUser = CurrentUser.Instance.User;
                        if (currentUser == null)
                        {
                            MessageBox.Show("Не удалось определить текущего пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        rents addUser = new rents();
                        addUser.id = AppData.db.users.Any() ? AppData.db.users.Max(u => u.id) + 1 : 1;
                        addUser.userid = currentUser.id;
                        addUser.bookid = 2;
                        addUser.datastart = DateTime.Now;
                        addUser.datafinish = userRentInputWindow.SelectedOption;
                        AppData.db.rents.Add(addUser);
                        AppData.db.SaveChanges();
                        MessageBox.Show("Вы взяли книгу в аренду", "Успешно");
                    }
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                Window inputWindow = new UserRentInputWindow();
                if (inputWindow != null && inputWindow.ShowDialog() == true)
                {
                    if (inputWindow is UserRentInputWindow)
                    {
                        UserRentInputWindow userRentInputWindow = (UserRentInputWindow)inputWindow;

                        users currentUser = CurrentUser.Instance.User;
                        if (currentUser == null)
                        {
                            MessageBox.Show("Не удалось определить текущего пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        rents addUser = new rents();
                        addUser.id = AppData.db.users.Any() ? AppData.db.users.Max(u => u.id) + 1 : 1;
                        addUser.userid = currentUser.id;
                        addUser.bookid = 3;
                        addUser.datastart = DateTime.Now;
                        addUser.datafinish = userRentInputWindow.SelectedOption;
                        AppData.db.rents.Add(addUser);
                        AppData.db.SaveChanges();
                        MessageBox.Show("Вы взяли книгу в аренду", "Успешно");
                    }
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
