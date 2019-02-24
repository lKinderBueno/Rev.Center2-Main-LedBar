
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Management;
using OpenHardwareMonitor.Hardware;
using System.ServiceProcess;


namespace Rev.Center2
{
    /// <summary>
    /// Logica di interazione per system_info.xaml
    /// </summary>
    /// 
    public sealed partial class system_info : UserControl, IComponentConnector
    {

        Computer computer = new Computer();

        public system_info()
        {
            InitializeComponent();
            Start_Data();
           
            //MessageBox.Show(ServiceInfo[0].Data);  //monitor.GetMonitorValue(1000));

        }

        private int cpu_default_speed=2200;
        private int cpu_max_speed=4000;

        private void Start_Data()
        {
         //   cpu_default_speed = (int)Math.Round(Convert.ToDouble(monitor.GetMonitorValue(15)) * 22 / 100, 1) * 100;
            CPU_TurboMin_Value.Text= cpu_default_speed.ToString();
            computer.Open();
            computer.CPUEnabled = true;
            computer.GPUEnabled = true;
            computer.RAMEnabled = true;
           // computer.HDDEnabled = true;
            CPU_NAME_Value.Text=computer.Hardware[0].Name;

            float ram=0;
            foreach (IHardware hardware in computer.Hardware)
            {
                hardware.Update();
                foreach (ISensor sensor in hardware.Sensors)
                {
                    if (sensor.Name == "Available Memory")
                    {
                        ram+= (float)sensor.Value;
                    }
                    else if (sensor.Name == "Used Memory")
                        ram += (float)sensor.Value;
                }
            }
            T_RAM_Size_Value.Text = Math.Round(ram).ToString();

            CPU_TurboMax_Value.Text = cpu_max_speed.ToString();
            CPU_GPU_value_Init();

        }




        public DispatcherTimer CPU_GPU_value = new DispatcherTimer();
        private void CPU_GPU_value_Init()
        {
            CPU_GPU_value = new DispatcherTimer();
            CPU_GPU_value.Tick += CPU_GPU_value_Tick_1;
            CPU_GPU_value.Interval = new TimeSpan(0, 0, 0, 2, 0);
        }
   

        private void CPU_GPU_value_Tick_1(object sender, EventArgs e)
        {
            foreach (IHardware hardware in computer.Hardware)
            {
                hardware.Update();
                foreach (ISensor sensor in hardware.Sensors)
                {
                    if (sensor.Name == "Memory")
                    {
                        progressBar_RAM_Usage.Value = (int)sensor.Value;
                        break;
                    }

                }
            }

            int temp= (int)computer.Hardware[0].Sensors[13].Value;
            CPU_util_value.Text = ((int)computer.Hardware[0].Sensors[6].Value).ToString();
            T_cpu_temp_value.Text = temp.ToString();
            UpdateUI_CPUTemp(Convert.ToInt32(temp));
            CPU_Core_Value.Text= ((int)computer.Hardware[0].Sensors[14].Value).ToString();
            GPU_Core_Value.Text = ((int)computer.Hardware[0].Sensors[16].Value).ToString();
            UpdateUI_GPUUtiliztion(computer.Hardware[1].Sensors[4].Value.ToString());
            UC_CPUCoreClock.core_clock((int)(computer.Hardware[0].Sensors[14].Value / 114));
            UC_GPUCoreClock.core_clock((int)computer.Hardware[1].Sensors[1].Value / (1700 / 20) + 3);
            UpdateUI_VRAM_Clock((int)computer.Hardware[1].Sensors[2].Value);
            UpdateUI_GPUTemp(Convert.ToInt32(computer.Hardware[1].Sensors[0].Value));
            T_CPU_W_Value.Text= Math.Round((double)computer.Hardware[0].Sensors[20].Value, 2).ToString();

            // UpdateUI_RAM_Clock(monitor.GetMonitorValue(17));

        }

        private void UpdateUI_VRAM_Clock(int clock)
        {
            if (this.VRAMClock_Value.Text == clock.ToString())
                return;
            this.R_mem1.Visibility = Visibility.Hidden;
            this.R_mem2.Visibility = Visibility.Hidden;
            this.R_mem3.Visibility = Visibility.Hidden;
            this.R_mem4.Visibility = Visibility.Hidden;
            this.R_mem5.Visibility = Visibility.Hidden;
            if (clock <= 405)
                this.R_mem1.Visibility = Visibility.Visible;
            else if (clock <= 810)
                this.R_mem2.Visibility = Visibility.Visible;
            else if (clock < 3500)
                this.R_mem3.Visibility = Visibility.Visible;
            else if (clock - 3500< 10)
                this.R_mem4.Visibility = Visibility.Visible;
            else
                this.R_mem5.Visibility = Visibility.Visible;
            this.VRAMClock_Value.Text = clock.ToString();
        }

        private void UpdateUI_GPUTemp(int GPU_Temp_new)
        {
            if (this.GPUTemp_value.Text == GPU_Temp_new.ToString())
                return;
            RotateTransform rotateTransform = new RotateTransform((double)GPU_Temp_new * 1.8 + 135.0);
            this.GPUTemp_needle_layer1.RenderTransform = (Transform)rotateTransform;
            this.GPUTemp_needle_layer2.RenderTransform = (Transform)rotateTransform;
            this.GPUTemp_value.Text = GPU_Temp_new.ToString();
        }

        private void UpdateUI_GPUUtiliztion(string util)
        {
            if (this.GPU_util_value.Text == util)
                return;
            this.gpu_unilization_layer3.Width = Convert.ToDouble(util) * 3.72;
            this.GPU_util_value.Text = util;
        }

        private void UpdateUI_CPUTemp(int CPU_Temp_new)
        {
            RotateTransform rotateTransform = new RotateTransform((double)CPU_Temp_new * 1.8 + 135.0);
            this.CPUTemp_needle_layer1.RenderTransform = (Transform)rotateTransform;
            this.CPUTemp_needle_layer2.RenderTransform = (Transform)rotateTransform;
        }


      


        private void UpdateUI_RAM_Clock(string ram_clock)
        {
            if (this.RAMClock_Value.Text == ram_clock)
                return;
            this.R_CPU_mem1.Visibility = Visibility.Hidden;
            this.R_CPU_mem2.Visibility = Visibility.Hidden;
            this.R_CPU_mem3.Visibility = Visibility.Hidden;
            this.R_CPU_mem4.Visibility = Visibility.Hidden;
            this.R_CPU_mem5.Visibility = Visibility.Hidden;
            int clock = (int)(Convert.ToDouble(Math.Round(Convert.ToDecimal(ram_clock))));

           /* if (clock <= 405)
                this.R_CPU_mem1.Visibility = Visibility.Visible;
            else if (clock <= 810)
                this.R_CPU_mem2.Visibility = Visibility.Visible;
            else if (clock < Convert.ToInt32(ServiceInfo[3].Data))
                this.R_CPU_mem3.Visibility = Visibility.Visible;
            else if (clock - Convert.ToInt32(ServiceInfo[3].Data) < 10)
                this.R_CPU_mem4.Visibility = Visibility.Visible;
            else
                this.R_CPU_mem5.Visibility = Visibility.Visible;*/
            this.RAMClock_Value.Text = clock.ToString();
        }



        private void RBTN_GPU1_Checked(object sender, RoutedEventArgs e)
        {
            /*if (Set_GPU_Number(0) != 0)
                return;
            this.GPU_BASE_Value.Text = Get_GPU_Base_Clock().ToString();
            this.GPU_BOOST_Value.Text = Get_GPU_Boost_Clock().ToString();
            this.Read_NVIDIA_Data();*/
        }

        private void RBTN_GPU2_Checked(object sender, RoutedEventArgs e)
        {
           /* if (Set_GPU_Number(1) != 0)
                return;
            this.GPU_BASE_Value.Text = Get_GPU_Base_Clock().ToString();
            this.GPU_BOOST_Value.Text = Get_GPU_Boost_Clock().ToString();
            this.Read_NVIDIA_Data();*/
        }

    }
    }