using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;
using MySettingDLL;
using BatteryDLL;
using AutoUpdaterDotNET;

/// <summary>
///             R_FanLayer3.RenderTransform = new RotateTransform(e.s);

/// </summary>

namespace Rev.Center2
{



    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MySetting MySetting;
        Loading navigatesWindow = new Loading();
        Setting settings = new Setting();
        Fan_Custom fantable = new Fan_Custom();
        private string NamePath = @"SOFTWARE\Rev.Center\Rev.Center2.0\";

        public MainWindow()
        {
            Process.Start("TrayIcon Rev.Center2.exe");
            navigatesWindow.Show();
            InitializeComponent();
        }

        //-------------------------GUI THINGS-----------------------
        //MAKE THE GUI MOVABLE
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        const string userRoot = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center";
        const string keyName = userRoot + "\\" + "Rev.Center2.0";
        private void BTN_close_Click(object sender, RoutedEventArgs e)
        {
            window.Visibility = Visibility.Collapsed;

            navigatesWindow.Close();
            /*if (Convert.ToInt32(Registry.GetValue(keyName, "ThrottleStop", 1)) == 1)
            {

                foreach (var process in Process.GetProcessesByName("ThrottleStop"))
                {
                    process.Kill();
                }
            }*/
            Timer_CapsNumLk.Stop();
            this.Close();
            Environment.Exit(0);
        }

        private void BTN_min_Click(object sender, RoutedEventArgs e)
        {

            this.WindowState = WindowState.Minimized;
        }

        private void BTN_settings_Click(object sender, RoutedEventArgs e)
        {

            settings.Show();

        }

        private void Title_Name_Copy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://www.paypal.me/EMUNI");
        }
        //--------------------END GUI THINGS.--------------------------


        //----------------------MENU THINGS----------------------------------


        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            this.Main_Grid.Visibility = Visibility.Visible;
            this.LedBar.Visibility = Visibility.Collapsed;
            this.Advanced_Info.Visibility = Visibility.Collapsed;
            this.grid_fan.Visibility = Visibility.Visible;
            this.Advanced_Info.CPU_GPU_value.Stop();
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            this.Main_Grid.Visibility = Visibility.Collapsed;
            this.LedBar.Visibility = Visibility.Visible;
            this.Advanced_Info.Visibility = Visibility.Collapsed;
            this.grid_fan.Visibility = Visibility.Hidden;
            this.Advanced_Info.CPU_GPU_value.Stop();
        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            Process.Start("Rev.Center2 Keyboard.exe");
            this.WindowState = WindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Advanced_Info.CPU_GPU_value.Stop();
        }

        private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            this.Main_Grid.Visibility = Visibility.Collapsed;
            this.LedBar.Visibility = Visibility.Collapsed;
            this.Advanced_Info.Visibility = Visibility.Visible;
            this.grid_fan.Visibility = Visibility.Visible;
            this.Advanced_Info.CPU_GPU_value.Start();
        }

        private void Menu_DropDownClosed_1(object sender, EventArgs e)
        {
            if (Menu.SelectedIndex == 2) //sel ind already updated
            {
                Menu.SelectedIndex = 0;
            }
        }
        //------------------END-MENU THINGS----------------------------------


        //------------------BATTERY CHARGE LEVEL------------------------
        private BatInfo batteryInformation = new BatInfo();
       
        //----------------------END BATTERY CHARGE LEVEL-------------------




        //---------------------------SUSPEND BUTTON----------------------------------------
        private void btn_S3_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.SetSuspendState(System.Windows.Forms.PowerState.Suspend, true, true);
        }
        //HIBERNATE BUTTON
        private void btn_S4_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.SetSuspendState(System.Windows.Forms.PowerState.Hibernate, true, true);
        }

        //---------------------------END SUSPEND BUTTON---------------------------------------




        //-----------------ADDITIONAL FEATURE-----------------------


        private void CB_Led_Unchecked(object sender, RoutedEventArgs e)
        {
            LedBar.Set_Colour(4, 0U);

        }

        private void CB_Led_Checked(object sender, RoutedEventArgs e)
        {
            LedBar.Set_Colour(4, LedBar.g_brightness_level);
        }

        private void CB_Windows_DIS_Checked(object sender, RoutedEventArgs e)
        {
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "WinKeyLk", "0", RegistryValueKind.DWord);
            MySetting.WinKeyOnOff();
        }

        private void CB_Windows_DIS_Unchecked(object sender, RoutedEventArgs e)
        {
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "WinKeyLk", "1", RegistryValueKind.DWord);
            MySetting.WinKeyOnOff();
        }

        private void CB_dGPU_Checked(object sender, RoutedEventArgs e)
        {
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "dGPU", "1", RegistryValueKind.DWord);
            MySetting.SetNVCtrlPanel((byte)1);
        }

        private void CB_dGPU_Unchecked(object sender, RoutedEventArgs e)
        {
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "dGPU", "0", RegistryValueKind.DWord);
            MySetting.SetNVCtrlPanel((byte)0);

        }

        private void CB_Usb_Checked(object sender, RoutedEventArgs e)
        {
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "USB", "0", RegistryValueKind.DWord);
            MySetting.USBChargeOff();
        }

        private void CB_Usb_Unchecked(object sender, RoutedEventArgs e)
        {
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "USB", "1", RegistryValueKind.DWord);
            MySetting.USBChargeOn();
        }



        private DispatcherTimer Timer_CapsNumLk = new DispatcherTimer();
        private void Timer_CapsNumLk_Init()
        {
            Timer_CapsNumLk = new DispatcherTimer();
            Timer_CapsNumLk.Tick += CB_caps_lock_Tick_1;
            Timer_CapsNumLk.Start();
            Timer_CapsNumLk.Interval = new TimeSpan(0, 0, 0, 1, 0);
        }

        private void CB_caps_lock_Tick_1(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock))
                CB_caps_lock.IsChecked = true;
            else CB_caps_lock.IsChecked = false;
            if (System.Windows.Forms.Control.IsKeyLocked(System.Windows.Forms.Keys.NumLock))
                CB_num_lock.IsChecked = true;
            else CB_num_lock.IsChecked = false;
            T_BatteryValue.Text = batteryInformation.BatteryLifePercent();
            if (batteryInformation.ACLineStatus() == "1")
            {
                image_power_2.Visibility = Visibility.Hidden;
                image_power.Visibility = Visibility.Visible;
                RB_Quite.Content = "Silent";

            }
            else
            {
                image_power_2.Visibility = Visibility.Visible;
                image_power.Visibility = Visibility.Hidden;
                RB_Quite.Content = "PowerSaving";
            }
        }
        //---------------------END ADDITIONAL FEATURES-------------------





        //-------------------START FAN MODE------------------------------
        //FAN AUTO
        private void RB_Fan_Auto_Checked(object sender, RoutedEventArgs e)
        {
            FanMode_set(1);
            BTN_fan_custom.Visibility = Visibility.Hidden;
            slider_FAN_AutoOffset.IsEnabled = false;
        }

        //FAN TURBO
        private void RB_Fan_Max_Checked(object sender, RoutedEventArgs e)
        {
            FanMode_set(2);
            BTN_fan_custom.Visibility = Visibility.Hidden;
            slider_FAN_AutoOffset.IsEnabled = false;
        }

        //FAN QUIET
        private void RB_Fan_Silent_Checked(object sender, RoutedEventArgs e)
        {
            FanMode_set(3);
            slider_FAN_AutoOffset.IsEnabled = false;
            BTN_fan_custom.Visibility = Visibility.Hidden;
        }

        //FAN STATIC
        private void RB_Fan_Static_Checked(object sender, RoutedEventArgs e)
        {
            FanMode_set(4);
            slider_FAN_AutoOffset.IsEnabled = true;
            BTN_fan_custom.Visibility = Visibility.Hidden;
         }

        private void RB_Fan_Manual_Checked(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(Registry.GetValue(keyName + "\\FAN", "First_startup", 1)) == 1)
            {
                fantable.fantable.Set_defult_FanTable();
                Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath + "FAN", "First_startup", "0", RegistryValueKind.DWord);
            }
            BTN_fan_custom.Visibility = Visibility.Visible;
            FanMode_set(5);
        }
        private void BTN_fan_custom_Clik(object sender, RoutedEventArgs e)
        {
            fantable.Owner = this;
            fantable.Show();
        }

        //If Fan Speed Slider Value is changed then update FanMode
        private void slider_FAN_AutoOffset_ValueChanged(object sender, MouseButtonEventArgs e)
        {
            FanMode_set(4);
        }

        //Set Fan Mode through FanManger RevCenter2
        public void FanMode_set(int mode)
        {
            foreach (var process in Process.GetProcessesByName("FanManager RevCenter2"))
            {
                process.Kill();
            }
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "FanMode", mode, RegistryValueKind.DWord);
            if (mode == 4)
            {
                Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "StaticFan", slider_FAN_AutoOffset.Value, RegistryValueKind.DWord);

            }

            Process.Start("FanManager RevCenter2.exe");
        }
        //-----------------------END FAN MODE-------------------------------------




        //-------------------START PERFORMANCE MODE------------------------------
        private DispatcherTimer Timer_PerfomanceMode_Setted;
        private Process[] pname = Process.GetProcessesByName("Rev.Center2 Tuner");
        private PowerManager Powermanager = new PowerManager();
        private void Timer_PerfomanceMode_Init()
        {
            Timer_PerfomanceMode_Setted = new DispatcherTimer();
            Timer_PerfomanceMode_Setted.Tick += Timer_PerfomanceMode_Setted_Tick_1;
            Timer_PerfomanceMode_Setted.Interval = new TimeSpan(0, 0, 0, 1, 0);
        }

        //QUIET  MODE
        private void RB_Quite_Checked(object sender, RoutedEventArgs e)
        {
            grid_mode.IsEnabled = false;
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "PerformanceMode", "1", RegistryValueKind.DWord);
            //navigatesWindow.Show();
            Timer_PerfomanceMode_Setted.Start();
            Powermanager.SetPlan(1);
            window.Background = RB_Quite.BorderBrush;
        }
        //PERFORMANCE   MODE
        private void RB_performance_Checked(object sender, RoutedEventArgs e)
        {
            grid_mode.IsEnabled = false;
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "PerformanceMode", "3", RegistryValueKind.DWord);
            RB_Fan_Auto.IsChecked = true;
            //navigatesWindow.Show();
            Timer_PerfomanceMode_Setted.Start();
            Powermanager.SetPlan(3);
            window.Background = RB_performance.BorderBrush;
        }

        //ENTERTAINMENT  MODE
        private void RB_Entertainment_Checked_1(object sender, RoutedEventArgs e)
        {
            grid_mode.IsEnabled = false;
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "PerformanceMode", "2", RegistryValueKind.DWord);
            //navigatesWindow.Show();
            Powermanager.SetPlan(2);
            Timer_PerfomanceMode_Setted.Start();
            window.Background = RB_Entertainment.BorderBrush;
        }

        //CUSTOM PERFORMANCE MODE
        private void RB_Custom_Checked(object sender, RoutedEventArgs e)
        {
            /*  Process.Start("Rev.Center2 Tuner.exe");
              Regedit.SetValue("PerformanceMode", "2");
             */

            window.Background = RB_Custom.BorderBrush;
            MessageBox.Show("Coming Soon :)");
            RB_Custom.IsChecked = false;
        }

        //Quiet Mode/PowerSavingMode works using a WMIEC address and value. 
        //There is a delay between from the input command to the end of the activation
        //I used a Timer that disable the PerformanceMode Grid till the "PowerSave Mode"
        //is enable/ended succesufly.
        private void Timer_PerfomanceMode_Setted_Tick_1(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("Rev.Center2 Tuner");
            if (pname.Length == 0)
            {
                Process.Start("Rev.Center2 Tuner.exe");
                grid_mode.IsEnabled = true;
               // navigatesWindow.Hide();
                Timer_PerfomanceMode_Setted.Stop();
                
            }
        }
        //-------------------END PERFORANCE MODE------------------------------



        private void Load_Register()
        {
            string userRoot = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center";
            string keyName = userRoot + "\\" + "Rev.Center2.0";
            int perf_mode = Convert.ToInt32(Registry.GetValue(keyName, "PerformanceMode", "1"));
            int fan_mode = Convert.ToInt32(Registry.GetValue(keyName, "FanMode", "1"));
            double static_fan = Convert.ToDouble(Registry.GetValue(keyName, "StaticFan", "0"));
            if (Convert.ToInt32(Registry.GetValue(keyName, "WinKeyLk", 0)) == 0)
                CB_Windows_DIS.IsChecked = true;
            if (Convert.ToInt32(Registry.GetValue(keyName + "\\LED", "Brightness", 0)) != 0)
                CB_Led.IsChecked = true;
            if (Convert.ToInt32(Registry.GetValue(keyName, "dGPU", 0)) == 1)
                CB_dGPU.IsChecked = true;
            if (Convert.ToInt32(Registry.GetValue(keyName, "USB", 0)) == 1)
                CB_Usb.IsChecked = true;

            slider_FAN_AutoOffset.Value = static_fan;

            switch (fan_mode)
            {
                case 1:
                    RB_Fan_Auto.IsChecked = true;
                    break;
                case 2:
                    RB_Fan_Max.IsChecked = true;
                    break;
                case 3:
                    RB_Fan_Silent.IsChecked = true;
                    break;
                case 4:
                    RB_Fan_Static.IsChecked = true;
                    break;
                case 5:
                    RB_Fan_Manual.IsChecked = true;
                    break;
            }

            switch (perf_mode)
            {
                case 1:
                    RB_Quite.IsChecked = true;
                    break;
                case 2:
                    RB_Entertainment.IsChecked = true;
                    break;
                case 3:
                    RB_performance.IsChecked = true;
                    RB_Fan_Auto.IsChecked = true;
                    break;
                case 4:
                    RB_Custom.IsChecked = true;
                    break;
            }

        }

        private void Main_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            navigatesWindow.Hide();
            MySetting = new MySetting();
            Timer_PerfomanceMode_Init();
            Timer_CapsNumLk_Init();
            AutoUpdater.Start("http://sitodielio.000webhostapp.com/Rev.Center2/updater.xml");
            AutoUpdater.OpenDownloadPage = true;
            Process.Start("FanManager RevCenter2.exe");


            Load_Register();



            foreach (var process in Process.GetProcessesByName("GamingCenter"))
            {
                MessageBox.Show("It is highly adviced to unistall GamingCenter for avoiding conflict." + " GamingCenter will be Force closed."
                    , "GamingCenter Detected", MessageBoxButton.OK, MessageBoxImage.Error);
                process.Kill();
            }

            foreach (var process in Process.GetProcessesByName("GamingCenterTray"))
            {
                process.Kill();
            }

        }

      
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            window.Visibility = Visibility.Collapsed;
            navigatesWindow.Close();
            if (Convert.ToInt32(Registry.GetValue(keyName, "ThrottleStop", 1)) == 1)
            {

                foreach (var process in Process.GetProcessesByName("ThrottleStop"))
                {
                    process.Kill();
                }
            }
            Timer_CapsNumLk.Stop();
            Environment.Exit(0);
        }

        
    }
      
    }
