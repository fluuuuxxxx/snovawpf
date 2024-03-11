using snovawpf.Model;
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
using snovawpf.DialogWindows;
using System.Diagnostics;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using MenuItem = System.Windows.Controls.MenuItem;

namespace snovawpf.pages
{
    /// <summary>
    /// Логика взаимодействия для adminpage.xaml
    /// </summary>
    public partial class adminpage : Page
    {
        public adminpage()
        {
            InitializeComponent();
            this.Loaded += Adminpage_Loaded;
        }

        private void Adminpage_Loaded(object sender, RoutedEventArgs e)
        {
            UsersGrid.ItemsSource = AppData.db.users.ToList();
            BooksGrid.ItemsSource = AppData.db.books.ToList();
            RentsGrid.ItemsSource = AppData.db.rents.ToList();
        } 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new signinpage());
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string menuItemHeader = ((MenuItem)sender).Header.ToString();
                Window inputWindow = null;

                switch (menuItemHeader)
                {
                    case "Пользователи":
                        inputWindow = new UserInputWindow();
                        break;
                    case "Книги":
                        inputWindow = new BookInputWindow();
                        break;
                    case "Аренда книг":
                        inputWindow = new RentInputWindow();
                        break;
                    default:
                        MessageBox.Show("Выбрана некорректная таблица.");
                        break;
                }

                if (inputWindow != null && inputWindow.ShowDialog() == true)
                {
                    if (inputWindow is UserInputWindow)
                    {
                        UserInputWindow userInputWindow = (UserInputWindow)inputWindow;
                        users addUser = new users();
                        addUser.id = AppData.db.users.Any() ? AppData.db.users.Max(u => u.id) + 1 : 1;
                        addUser.username = userInputWindow.username;
                        addUser.pass = userInputWindow.password;
                        addUser.name = userInputWindow.name;
                        addUser.lastname = userInputWindow.lastname;
                        addUser.dr = userInputWindow.dr;
                        addUser.roleid = userInputWindow.roleid;
                        AppData.db.users.Add(addUser);
                        UsersGrid.ItemsSource = AppData.db.users.ToList();
                    }
                    else if (inputWindow is BookInputWindow)
                    {
                        BookInputWindow bookInputWindow = (BookInputWindow)inputWindow;
                        books addBook = new books();
                        addBook.id = AppData.db.books.Any() ? AppData.db.books.Max(b => b.id) + 1 : 1;
                        addBook.name = bookInputWindow.name;
                        addBook.author = bookInputWindow.author;
                        addBook.genre = bookInputWindow.genre;
                        addBook.year = bookInputWindow.year;
                        AppData.db.books.Add(addBook);
                        BooksGrid.ItemsSource = AppData.db.books.ToList();
                    }
                    else if (inputWindow is RentInputWindow)
                    {
                        RentInputWindow rentInputWindow = (RentInputWindow)inputWindow;
                        rents addRent = new rents();
                        addRent.id = AppData.db.rents.Any() ? AppData.db.rents.Max(r => r.id) + 1 : 1;
                        addRent.userid = rentInputWindow.iduser;
                        addRent.bookid = rentInputWindow.idbook;
                        addRent.datastart = rentInputWindow.datastart;
                        addRent.datafinish = rentInputWindow.datafinish;
                        AppData.db.rents.Add(addRent);
                        RentsGrid.ItemsSource = AppData.db.rents.ToList();
                    }

                    AppData.db.SaveChanges();
                    MessageBox.Show("Успешно!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var menuItem = sender as MenuItem;
                if (menuItem != null)
                {
                    string menuItemHeader = menuItem.Header.ToString();
                    Debug.WriteLine("Selected MenuItem: " + menuItemHeader);

                    if (menuItemHeader == "Пользователи")
                    {
                        var curUser = UsersGrid.SelectedItem as users;
                        AppData.db.users.Remove(curUser);
                        AppData.db.SaveChanges();
                        UsersGrid.ItemsSource = AppData.db.users.ToList();
                        MessageBox.Show("Пользователь успешно удалён");
                    }
                    else if (menuItemHeader == "Книги")
                    {
                        var curBook = BooksGrid.SelectedItem as books;
                        AppData.db.books.Remove(curBook);
                        AppData.db.SaveChanges();
                        BooksGrid.ItemsSource = AppData.db.books.ToList();
                        MessageBox.Show("Книга успешно удалена");
                    }
                    else if (menuItemHeader == "Аренда книг")
                    {
                        var curRent = RentsGrid.SelectedItem as rents;
                        AppData.db.rents.Remove(curRent);
                        AppData.db.SaveChanges();
                        RentsGrid.ItemsSource = AppData.db.rents.ToList();
                        MessageBox.Show("Аренда успешно удалена");
                    }
                    else
                    {
                        MessageBox.Show("Выбрана некорректная таблица");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
            }

        }

        private void refreshBT(object sender, RoutedEventArgs e)
        {
            UsersGrid.ItemsSource = AppData.db.users.ToList();
            BooksGrid.ItemsSource = AppData.db.books.ToList();
            RentsGrid.ItemsSource = AppData.db.rents.ToList();
        }
    }
}
