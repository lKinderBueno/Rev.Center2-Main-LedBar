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
    /// Logica di interazione per UserControl_CoreClock.xaml
    /// </summary>
    public sealed partial class UserControl_CoreClock : UserControl, IComponentConnector
    {
        public UserControl_CoreClock()
        {
            InitializeComponent();
        }

        public void core_clock(int level)
        {
            if (level >= 1)
                this.p_layer1.Visibility = Visibility.Visible;
            else
                this.p_layer1.Visibility = Visibility.Hidden;
            if (level >= 2)
                this.p_layer2.Visibility = Visibility.Visible;
            else
                this.p_layer2.Visibility = Visibility.Hidden;
            if (level >= 3)
                this.p_layer3.Visibility = Visibility.Visible;
            else
                this.p_layer3.Visibility = Visibility.Hidden;
            if (level >= 4)
                this.p_layer4.Visibility = Visibility.Visible;
            else
                this.p_layer4.Visibility = Visibility.Hidden;
            if (level >= 5)
                this.p_layer5.Visibility = Visibility.Visible;
            else
                this.p_layer5.Visibility = Visibility.Hidden;
            if (level >= 6)
                this.p_layer6.Visibility = Visibility.Visible;
            else
                this.p_layer6.Visibility = Visibility.Hidden;
            if (level >= 7)
                this.p_layer7.Visibility = Visibility.Visible;
            else
                this.p_layer7.Visibility = Visibility.Hidden;
            if (level >= 8)
                this.p_layer8.Visibility = Visibility.Visible;
            else
                this.p_layer8.Visibility = Visibility.Hidden;
            if (level >= 9)
                this.p_layer9.Visibility = Visibility.Visible;
            else
                this.p_layer9.Visibility = Visibility.Hidden;
            if (level >= 10)
                this.p_layer10.Visibility = Visibility.Visible;
            else
                this.p_layer10.Visibility = Visibility.Hidden;
            if (level >= 11)
                this.p_layer11.Visibility = Visibility.Visible;
            else
                this.p_layer11.Visibility = Visibility.Hidden;
            if (level >= 12)
                this.p_layer12.Visibility = Visibility.Visible;
            else
                this.p_layer12.Visibility = Visibility.Hidden;
            if (level >= 13)
                this.p_layer13.Visibility = Visibility.Visible;
            else
                this.p_layer13.Visibility = Visibility.Hidden;
            if (level >= 14)
                this.p_layer14.Visibility = Visibility.Visible;
            else
                this.p_layer14.Visibility = Visibility.Hidden;
            if (level >= 15)
                this.p_layer15.Visibility = Visibility.Visible;
            else
                this.p_layer15.Visibility = Visibility.Hidden;
            if (level >= 16)
                this.p_layer16.Visibility = Visibility.Visible;
            else
                this.p_layer16.Visibility = Visibility.Hidden;
            if (level >= 17)
                this.p_layer17.Visibility = Visibility.Visible;
            else
                this.p_layer17.Visibility = Visibility.Hidden;
            if (level >= 18)
                this.p_layer18.Visibility = Visibility.Visible;
            else
                this.p_layer18.Visibility = Visibility.Hidden;
            if (level >= 19)
                this.p_layer19.Visibility = Visibility.Visible;
            else
                this.p_layer19.Visibility = Visibility.Hidden;
            if (level >= 20)
                this.p_layer20.Visibility = Visibility.Visible;
            else
                this.p_layer20.Visibility = Visibility.Hidden;
            if (level >= 21)
                this.p_layer21.Visibility = Visibility.Visible;
            else
                this.p_layer21.Visibility = Visibility.Hidden;
            if (level >= 22)
                this.p_layer22.Visibility = Visibility.Visible;
            else
                this.p_layer22.Visibility = Visibility.Hidden;
            if (level >= 23)
                this.p_layer23.Visibility = Visibility.Visible;
            else
                this.p_layer23.Visibility = Visibility.Hidden;
            if (level >= 24)
                this.p_layer24.Visibility = Visibility.Visible;
            else
                this.p_layer24.Visibility = Visibility.Hidden;
            if (level >= 25)
                this.p_layer25.Visibility = Visibility.Visible;
            else
                this.p_layer25.Visibility = Visibility.Hidden;
            if (level >= 26)
                this.p_layer26.Visibility = Visibility.Visible;
            else
                this.p_layer26.Visibility = Visibility.Hidden;
            if (level >= 27)
                this.p_layer27.Visibility = Visibility.Visible;
            else
                this.p_layer27.Visibility = Visibility.Hidden;
            if (level >= 28)
                this.p_layer28.Visibility = Visibility.Visible;
            else
                this.p_layer28.Visibility = Visibility.Hidden;
            if (level >= 29)
                this.p_layer29.Visibility = Visibility.Visible;
            else
                this.p_layer29.Visibility = Visibility.Hidden;
            if (level >= 30)
                this.p_layer30.Visibility = Visibility.Visible;
            else
                this.p_layer30.Visibility = Visibility.Hidden;
            if (level >= 31)
                this.p_layer31.Visibility = Visibility.Visible;
            else
                this.p_layer31.Visibility = Visibility.Hidden;
            if (level >= 32)
                this.p_layer32.Visibility = Visibility.Visible;
            else
                this.p_layer32.Visibility = Visibility.Hidden;
            if (level >= 33)
                this.p_layer33.Visibility = Visibility.Visible;
            else
                this.p_layer33.Visibility = Visibility.Hidden;
            if (level >= 34)
                this.p_layer34.Visibility = Visibility.Visible;
            else
                this.p_layer34.Visibility = Visibility.Hidden;
            if (level >= 35)
                this.p_layer35.Visibility = Visibility.Visible;
            else
                this.p_layer35.Visibility = Visibility.Hidden;
            if (level >= 36)
                this.p_layer36.Visibility = Visibility.Visible;
            else
                this.p_layer36.Visibility = Visibility.Hidden;
        }
    }
}
