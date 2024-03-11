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

namespace snovawpf.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для UserRentInputWindow.xaml
    /// </summary>
    public partial class UserRentInputWindow : Window
    {
        public DateTime SelectedOption { get; private set; }

        public UserRentInputWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DayRadioButton.IsChecked == true)
                SelectedOption = DateTime.Now.AddDays(1);
            else if (WeekRadioButton.IsChecked == true)
                SelectedOption = DateTime.Now.AddDays(7);
            else if (MonthRadioButton.IsChecked == true)
                SelectedOption = DateTime.Now.AddMonths(1);
            else
            {
                MessageBox.Show("Выберите вариант аренды", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }
    }
}
