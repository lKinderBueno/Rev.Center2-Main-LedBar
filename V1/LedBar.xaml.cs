using Microsoft.Win32;
using System;
using Microsoft.Expression.Shapes;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Management;
using System.Runtime.InteropServices;
using CoreAudioApi;
using MySettingDLL;


namespace Rev.Center2
{
    /// <summary>
    /// Logica di interazione per UserControl1.xaml
    /// </summary>
    public sealed partial class LedBar : UserControl, IComponentConnector
    {

        const string userRoot = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center";
        const string keyName = userRoot + "\\" + "Rev.Center2.0\\LED";
        private string NamePath = @"SOFTWARE\Rev.Center\Rev.Center2.0\LED";


        public static uint g_brightness_level = 2;
        private static uint g_red_level = 5;
        private static uint g_green_level = 5;
        private static uint g_blue_level = 5;
        /* private static bool m_bRedBall_MouseDown = false;
         private static bool m_bGreenBall_MouseDown = false;
         private static bool m_bBlueBall_MouseDown = false;
         private static bool m_bLightBall_MouseDown = false;*/
    //    private static uint g_PowerSaveMode = 1;
     //   private static uint g_BreathingLightEffect = 1;

        private static AutoResetEvent Hook_Event = new AutoResetEvent(false);
     /*   private static bool HookThread_Exit = false;
        private static bool m_bHookLightBarOnOff = true;
        private static int s_MouseHookHandle;
        private static int s_KeyboardHookHandle;
        private static NativeMethod.HookProc s_MouseDelegate;
        private static NativeMethod.HookProc s_KeyBoardDelegate;
        private static Thread HookThread;
*/
        private void WMIHandleEvent(object sender, EventArrivedEventArgs e)
        {
            try
            {
                Convert.ToInt32(e.NewEvent.SystemProperties["ULong"].Value.ToString());
                Application.Current.Dispatcher.Invoke((Action)(() => { }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            // Utility.Log(nameof(SystemEvents_PowerModeChanged));
            if (e.Mode != PowerModes.Resume)
                return;
            /* Utility.Log("---------------" + GetTime() + "---------------");
             Utility.Log("Resume");
            this.LoadRegistry();
            Thread.Sleep(3000);
            this.SetBrightnessLevel(g_brightness_level, true);
            this.SetBrightnessLayout(g_brightness_level);
            this.SetRedLayout(g_red_level);
            this.SetGreenLayout(g_green_level);
            this.SetBlueLayout(g_blue_level);
            this.SetPowerSaveModeLayout(g_PowerSaveMode);
            this.SetBreathingLightEffectLayout(g_BreathingLightEffect);*/
            object data = (object)0;
            if (!WMIEC.WMIReadECRAM(1864UL, ref data))
            {
                Console.WriteLine("[LightBarAPP][SystemEvents_PowerModeChanged]WMIReadECRAM failed ");
            }
            else
            {
                long uint64 = (long)Convert.ToUInt64(data);
                Thread.Sleep(500);
                //this.SetPowerSaveMode(g_PowerSaveMode, true);
                //this.SetBreathingLightEffect(g_BreathingLightEffect, true);
            }
        }



        public LedBar()
        {
//            WMIEC.StartWMIReceiveEvent(new EventArrivedEventHandler(this.WMIHandleEvent));
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(this.SystemEvents_PowerModeChanged);
            this.InitializeComponent();
            //this.LoadRegistry();
            this.LoadSetting();
           // Thread.Sleep(3000);
            /*  this.SetBrightnessLevel(g_brightness_level, true);
              this.SetBrightnessLayout(g_brightness_level);
              this.SetRedLayout(g_red_level);
              this.SetGreenLayout(g_green_level);
              this.SetBlueLayout(g_blue_level);
              this.SetPowerSaveModeLayout(g_PowerSaveMode);
              this.SetBreathingLightEffectLayout(g_BreathingLightEffect);
             */
            Load_Register();
            //CreateListenThread();
            //CreateHookDelegate();
            InitializeComponent();
        }

        private void LoadSetting()
        {
            // Utility.Log(string.Format("LoadSetting()"));
            object data = (object)0;
            if (!WMIEC.WMIReadECRAM(1864UL, ref data))
            {
                Console.WriteLine("[LightBarAPP][LoadSetting]WMIReadECRAM failed ");
            }
            else
            {
                WMIEC.WMIWriteECRAM(1864UL, (ulong)(byte)((uint)(byte)((uint)(byte)(Convert.ToUInt64(data) & (ulong)byte.MaxValue) | 1U) & (uint)sbyte.MaxValue));
                // Utility.Log(string.Format("0x0748.0 = 1"));
                // Utility.Log(string.Format("0x0748.7 = 0"));
            }
        }

        private void UnLoadSetting()
        {
            // Utility.Log(string.Format("UnLoadSetting()"));
            object data = (object)0;
            if (!WMIEC.WMIReadECRAM(1864UL, ref data))
            {
                Console.WriteLine("[LightBarAPP][UnLoadSetting]WMIReadECRAM failed ");
            }
            else
            {
                WMIEC.WMIWriteECRAM(1864UL, (ulong)(byte)((uint)(byte)((uint)(byte)((uint)(byte)((uint)(byte)(Convert.ToUInt64(data) & (ulong)byte.MaxValue) & 254U) & 253U) & 251U) & 247U));
                // Utility.Log(string.Format("0x0748.0 = 0"));
                // Utility.Log(string.Format("0x0748.1 = 0"));
                // Utility.Log(string.Format("0x0748.2 = 0"));
                // Utility.Log(string.Format("0x0748.3 = 0"));
            }
        }

  /*      Green_bar_Value_Changed
            
            Blue_bar_Value_Changed
            Brightness_bar_Value_Changed
*/

        public void Set_Colour(int colour,uint level)
        {
                switch (colour)
                {
                    case 1: //red
                        WMIEC.WMIWriteECRAM(1865UL, (ulong)level * (ulong)g_brightness_level);
                        break;
                case 2: //green
                    WMIEC.WMIWriteECRAM(1866UL, (ulong)level * (ulong)g_brightness_level);
                    break;
                case 3: //blue
                    WMIEC.WMIWriteECRAM(1867UL, (ulong)level * (ulong)g_brightness_level);
                    break;
                case 4: //bright
                    ulong num1 = (ulong)level * (ulong)g_red_level;
                    ulong num2 = (ulong)level * (ulong)g_green_level;
                    ulong num3 = (ulong)level * (ulong)g_blue_level;
                    // Utility.Log(string.Format("SetBrightnessLevel level = {0}", (object) g_brightness_level));
                    // Utility.Log(string.Format("0x0749h = {0}", (object) num1));
                    // Utility.Log(string.Format("0x074Ah = {0}", (object) num2));
                    // Utility.Log(string.Format("0x074Bh = {0}", (object) num3));
                    WMIEC.WMIWriteECRAM(1865UL, num1);
                    WMIEC.WMIWriteECRAM(1866UL, num2);
                    WMIEC.WMIWriteECRAM(1867UL, num3);
                    break;

            }

        }
        private void Red_bar_ValueChanged(object sender, MouseButtonEventArgs e)
        {
            g_red_level = smooth_bar(Red_Colour_Offset1.Value);
            Set_Colour(1, g_red_level);
            e.Handled = true;
        }
        private void Green_bar_ValueChanged(object sender, MouseButtonEventArgs e)
        {
            g_green_level = smooth_bar(Green_Colour_Offset1.Value);
            Set_Colour(2, g_green_level);
            e.Handled = true;
        }
        private void Blue_bar_ValueChanged(object sender, MouseButtonEventArgs e)
        {
            g_blue_level = smooth_bar(Blue_Colour_Offset1.Value);
            Set_Colour(3, g_blue_level);
            e.Handled = true;
        }

        private void Brightness_bar_ValueChanged(object sender, MouseButtonEventArgs e)
        {
            Brightness_perc.Text = (Brightness_Offset.Value * 2.5).ToString() + " %";
            g_brightness_level = smooth_bar(Brightness_Offset.Value);
            Set_Colour(4, g_brightness_level);
            e.Handled = true;
        }

        private void LED_Powesaving_Checked(object sender, RoutedEventArgs e)
        {
            SetPowerSaveMode(1U);
        }

        private void LED_PowerSaving_Unchecked(object sender, RoutedEventArgs e)
        {
            SetPowerSaveMode(0U);

        }

        private uint smooth_bar(double value)
        {
            if (value <= 10)
                return 0U;
            else if (value <= 20)
                return 1U;
            else if (value <= 30)
                return 2U;
            else if (value <= 40)
                return 3U;
            else if (value <= 50)
                return 4U;
            else if (value <= 60)
                return 5U;
            else if (value <= 70)
                return 6U;
            else if (value <= 80)
                return 7U;
            else if (value <= 90)
                return 8U;
            else
                return 9U;
        }


        private void SetPowerSaveMode(uint mode)
        {
            object data = (object)0;
            switch (mode)
            {
                case 0:
                    WMIEC.WMIWriteECRAM(1864UL, (ulong)(byte)((uint)(byte)(Convert.ToUInt64(data) & (ulong)byte.MaxValue) & 253U));
                        break;
                    
               case 1:
                     WMIEC.WMIWriteECRAM(1864UL, (ulong)(byte)((uint)(byte)(Convert.ToUInt64(data) & (ulong)byte.MaxValue) | 2U));
                        // Utility.Log(string.Format("0x0748.1 = 1"));
                        break;
                    }       
        }
        
        private void Save_led_Click(object sender, RoutedEventArgs e)
        {
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "Red", Red_Colour_Offset1.Value, RegistryValueKind.DWord);
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "Green", Green_Colour_Offset1.Value, RegistryValueKind.DWord);
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "Blue", Blue_Colour_Offset1.Value, RegistryValueKind.DWord);
            Utility.RegistryKeyWrite(RegistryHive.LocalMachine, NamePath, "Brightness", Brightness_Offset.Value, RegistryValueKind.DWord);
        //    Regedit.SetValue("First_Launch", "1");
        }

        private void Load_Register()
        {
            //if(Convert.ToInt32(Registry.GetValue(keyName, "First_Launch", 0)) == 1){
                Red_Colour_Offset1.Value = Convert.ToDouble(Registry.GetValue(keyName, "Red", 50));
                Green_Colour_Offset1.Value = Convert.ToDouble(Registry.GetValue(keyName, "Green", 50));
                Blue_Colour_Offset1.Value = Convert.ToDouble(Registry.GetValue(keyName, "Blue", 50));
                Brightness_Offset.Value = Convert.ToDouble(Registry.GetValue(keyName, "Brightness", 40));
                g_brightness_level = smooth_bar(Brightness_Offset.Value);
                g_red_level = smooth_bar(Red_Colour_Offset1.Value);
                g_green_level = smooth_bar(Green_Colour_Offset1.Value);
                g_blue_level = smooth_bar(Blue_Colour_Offset1.Value);
                Set_Colour(1, g_red_level);
                Set_Colour(2, g_green_level);
                Set_Colour(3, g_blue_level);
                Set_Colour(4, g_brightness_level);
                Brightness_perc.Text = (Brightness_Offset.Value * 2.5).ToString() + " %";
            //}

        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            Load_Register();
        }
    }
}
