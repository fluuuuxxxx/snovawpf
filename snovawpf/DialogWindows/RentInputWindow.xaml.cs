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
    /// Логика взаимодействия для RentInputWindow.xaml
    /// </summary>
    public partial class RentInputWindow : Window
    {
        public int iduser { get; private set; }
        public int idbook { get; private set; }
        public DateTime datastart { get; private set; }
        public DateTime datafinish { get; private set; }
        public RentInputWindow()
        {
            InitializeComponent();
        }

        private void regBT(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((DateTime)datastartbox.SelectedDate <= DateTime.Today)
                {
                    if ((DateTime)datafinishbox.SelectedDate >= DateTime.Today)
                    {
                        iduser = Convert.ToInt32(iduserbox.Text);
                        idbook = Convert.ToInt32(idbookbox.Text);
                        datastart = (DateTime)datastartbox.SelectedDate;
                        datafinish = (DateTime)datafinishbox.SelectedDate;
                        DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("Дата сдачи книги не может быть раньше чем сегодня.");
                    }
                }
                else
                {
                    MessageBox.Show("Дата взятия книги не может быть позже чем сегодня.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
