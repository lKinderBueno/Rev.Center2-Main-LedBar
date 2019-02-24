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

namespace Rev.Center2
{
    /// <summary>
    /// Logica di interazione per Fan_Custom.xaml
    /// </summary>
    public partial class Fan_Custom : Window
    {
        public Fan_Custom()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {



        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
         //   if (e.ChangedButton == MouseButton.Left)
           //     this.DragMove();
        }

        private void BTN_Reset_Fan_Click(object sender, RoutedEventArgs e)
        {
            this.fantable.Set_defult_FanTable();

        }
        private void BTN_SAVE_Fan_Click(object sender, RoutedEventArgs e)
        {
            this.fantable.save_reg();
            ((MainWindow)this.Owner).FanMode_set(5);

        }
        private void Window_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            window.Topmost = true;
        }

        private void Grid_GotFocus(object sender, RoutedEventArgs e)
        {
            window.Topmost = false;

        }
        private void UC_FanTable_MouseMove(object sender, MouseEventArgs e)
        {
        
        }

        private void BTN_close_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
