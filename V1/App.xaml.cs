using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace Rev.Center2
{
    /// <summary>
    /// Logica di interazione per App.xaml
    /// </summary>
    /// 


    public partial class App : Application
    {
        [DllImport("user32", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindow(string cls, string win);
        [DllImport("user32")]
        static extern IntPtr SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32")]
        static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32")]
        static extern bool OpenIcon(IntPtr hWnd);

        private static Mutex _mutex = null;

      




        protected override void OnStartup(StartupEventArgs e)
        {
            const string appName = "Rev.Center2";
            bool createdNew;

            _mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                ActivateOtherWindow();
                Shutdown();
            }

            base.OnStartup(e);
        }

        private static void ActivateOtherWindow()
        {
            var other = FindWindow(null, "Rev.Center 2.0");
            if (other != IntPtr.Zero)
            {
                SetForegroundWindow(other);
                if (IsIconic(other))
                    OpenIcon(other);
            }
        }


        private void Thumb_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void PART_Track_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
