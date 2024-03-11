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
    /// Логика взаимодействия для BookInputWindow.xaml
    /// </summary>
    public partial class BookInputWindow : Window
    {
        public string name { get; private set; }
        public string author { get; private set; }
        public string genre { get; private set; }
        public int year { get; private set; }

        public BookInputWindow()
        {
            InitializeComponent();
        }

        private void regBT(object sender, RoutedEventArgs e)
        {
            try
            {
                name = namebookbox.Text;
                author = authorbox.Text;
                genre = genrebox.Text;
                year = Convert.ToInt32(yearbox.Text);
                DialogResult = true;
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }

        }
    }
}
