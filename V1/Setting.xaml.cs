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
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;
using MySettingDLL;

namespace Rev.Center2
{
    /// <summary>
    /// Logica di interazione per Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {

        private string NamePath = @"SOFTWARE\Rev.Center\Rev.Center2.0\";
        public Setting()
        {
            InitializeComponent();

        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            const string path = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0";
            if (Convert.ToInt32(Registry.GetValue(path, "ThrottleStop", 1)) == 1)
                Throttlestop.IsChecked = false;
            else Throttlestop.IsChecked = true;


        }

        private void Label_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ThrottleStop Compatibility Mode let you use ThrottleStop without any issue. Leave off if you want to use Rev.Center tuning");
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "ThrottleStop", "0", RegistryValueKind.DWord);
            foreach (var process in Process.GetProcessesByName("ThrottleStop"))
            {
                process.Kill();
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "ThrottleStop", "1", RegistryValueKind.DWord);
            foreach (var process in Process.GetProcessesByName("ThrottleStop"))
            {
                process.Kill();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
