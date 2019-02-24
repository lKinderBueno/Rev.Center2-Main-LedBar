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
    /// Logica di interazione per Window1.xaml
    /// </summary>
    public partial class Loading : Window
    {
        private double _dbRawWidth;
        private double _dbRawHeight;
        public System.Windows.WindowStartupLocation WindowStartupLocation { get; set; }

        public Loading() { 
         this.InitializeComponent();
      /*    this._dbRawWidth = System.Windows.SystemParameters.PrimaryScreenHeight;;
            this._dbRawHeight = System.Windows.SystemParameters.PrimaryScreenHeight;; 
            this.FitWindowSize();*/
    }

 /* private void FitWindowSize()
    {
        double primaryScreenWidth = SystemParameters.PrimaryScreenWidth;
        double primaryScreenHeight = SystemParameters.PrimaryScreenHeight;
        double num1 = 1920.0 / primaryScreenWidth * 1.2;
        double num2 = 1080.0 / primaryScreenHeight * 1.2;
        Application.Current.MainWindow.Width = this._dbRawWidth / num1;
        Application.Current.MainWindow.Height = this._dbRawHeight / num2;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }
    */
}
}

