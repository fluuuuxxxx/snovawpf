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

namespace snovawpf.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для UserInputWindow.xaml
    /// </summary>
    public partial class UserInputWindow : Window
    {
        public string username { get; private set; }
        public string password { get; private set; }
        public string name { get; private set; }
        public string lastname { get; private set; }
        public DateTime dr { get; private set; }
        public int roleid { get; private set; }

        public UserInputWindow()
        {
            InitializeComponent();
        }
        private void regBT(object sender, RoutedEventArgs e)
        {

            DateTime selectedDate = (DateTime)databox.SelectedDate;
            if (selectedDate <= DateTime.Today)
            {
                username = usernamebox.Text;
                password = passbox.Password;
                name = namebox.Text;
                lastname = surnamebox.Text;
                dr = selectedDate;
                roleid = Convert.ToInt32(rolebox.Text);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Дата рождения не может быть позже сегодняшней даты.");
            }
        }
    }
}
