using CoreAudioApi;
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

namespace Rev.Center2
{
    /// <summary>
    /// Logica di interazione per Page1.xaml
    /// </summary>
    public sealed partial class UC_volume : UserControl, IComponentConnector
    {
        private double handle_spac = Math.Round(2.68, 2);
        private MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
        private MMDevice defaultDevice;
        private static bool find_device;
        

        public UC_volume()
        {
            this.InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.defaultDevice = this.DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
                this.defaultDevice.AudioEndpointVolume.OnVolumeNotification += new AudioEndpointVolumeNotificationDelegate(this.AudioEndpointVolume_OnVolumeNotification);
                Thread.Sleep(500);
                this.Update_volume();
                find_device = true;
            }
            catch
            {
                this.DisableFunction();
            }
        }

        private void DisableFunction()
        {
            find_device = false;
            this.R_handle.Visibility = Visibility.Hidden;
            this.Arc_layer3.Visibility = Visibility.Hidden;
            this.CB_mute.Visibility = Visibility.Hidden;
            this.set_value_UI(0.0);
        }

        private void Arc_layer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition((IInputElement)this.Arc_layer);
            double x = position.X;
            position = e.GetPosition((IInputElement)this.Arc_layer);
            double y = position.Y;
            this.Update_UI(x, y);
        }

        private void Arc_layer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;
            this.Update_UI(e.GetPosition((IInputElement)this.Arc_layer).X, e.GetPosition((IInputElement)this.Arc_layer).Y);
        }

        private void Update_UI(double Px, double Py)
        {
            if (!find_device)
                return;
            double num1 = this.Arc_layer.Width / 2.0;
            double angle = Math.Floor(this.GetAngleDegree(new Point(0.0, 0.0), new Point(Px - num1, Py >= num1 ? -Py + num1 : num1 - Py)));
            this.R_handle.RenderTransform = (Transform)new RotateTransform(angle);
            if (angle < 225.0 && angle > 135.0)
            {
                this.Arc_layer3.EndAngle = 225.0;
                angle = 225.0;
            }
            else
                this.Arc_layer3.EndAngle = angle;
            double num2;
            if (angle >= 225.0)
            {
                num2 = Math.Floor((angle - 225.0) / this.handle_spac);
                this.T_value.Text = num2.ToString();
            }
            else
            {
                num2 = 50.0 + Math.Floor(angle / this.handle_spac);
                this.T_value.Text = num2.ToString();
            }
            this.defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = (float)num2 / 100f;
            bool? isChecked = this.CB_mute.IsChecked;
            bool flag = false;
            if ((isChecked.GetValueOrDefault() == flag ? (isChecked.HasValue ? 1 : 0) : 0) == 0)
                return;
            this.defaultDevice.AudioEndpointVolume.Mute = false;
            this.CB_mute.IsChecked = new bool?(true);
        }

        private double GetAngleDegree(Point origin, Point target)
        {
            return (270.0 - Math.Atan2(origin.Y - target.Y, origin.X - target.X) * 180.0 / Math.PI) % 360.0;
        }

        public void set_value_UI(double value)
        {
            this.T_value.Text = value.ToString();
            double angle = value <= 50.0 ? 225.0 + value * this.handle_spac : (value - 50.0) * this.handle_spac;
            this.R_handle.RenderTransform = (Transform)new RotateTransform(angle);
            this.Arc_layer3.EndAngle = angle;
        }

        private void AudioEndpointVolume_OnVolumeNotification(AudioVolumeNotificationData data)
        {
            if (!find_device)
                return;
            this.Update_volume();
        }

        private void Update_volume()
        {
            try
            {
                double num = Math.Round((double)this.defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100.0);
                this.CB_mute.IsChecked = new bool?(!this.defaultDevice.AudioEndpointVolume.Mute);
                this.set_value_UI(num);
            }
            catch
            {
            }
        }

        private void CB_mute_Click(object sender, RoutedEventArgs e)
        {
            bool? isChecked = this.CB_mute.IsChecked;
            bool flag = true;
            if ((isChecked.GetValueOrDefault() == flag ? (isChecked.HasValue ? 1 : 0) : 0) != 0)
                this.defaultDevice.AudioEndpointVolume.Mute = false;
            else
                this.defaultDevice.AudioEndpointVolume.Mute = true;
        }

        private void Arc_layer_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            int int16 = (int)Convert.ToInt16(this.T_value.Text);
            int num;
            if (e.Delta > 0)
            {
                num = int16 + 1;
                if (num > 100)
                    num = 100;
            }
            else
            {
                num = int16 - 1;
                if (num < 0)
                    num = 0;
            }
            this.set_value_UI((double)num);
            this.defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = (float)num / 100f;
            bool? isChecked = this.CB_mute.IsChecked;
            bool flag = false;
            if ((isChecked.GetValueOrDefault() == flag ? (isChecked.HasValue ? 1 : 0) : 0) == 0)
                return;
            this.defaultDevice.AudioEndpointVolume.Mute = false;
            this.CB_mute.IsChecked = new bool?(true);
        }


    }
}
