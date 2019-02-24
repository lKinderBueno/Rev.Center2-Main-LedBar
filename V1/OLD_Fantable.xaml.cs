using Microsoft.Win32;
using System;
using Microsoft.Expression.Shapes;
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
namespace Rev.Center2
{
    /// <summary>
    /// Logica di interazione per usercontrol_fantable2.xaml
    /// </summary>
    public sealed partial class usercontrol_fantable2_2 : UserControl, IComponentConnector
    {
        public bool T1_move;
        public bool T2_move;
        public bool T3_move;
        public int select_T;
        public usercontrol_fantable2_2()
        {
            InitializeComponent();
        }
        const string userRoot = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center";
        const string keyName = userRoot + "\\" + "Rev.Center2.0\\Fan";
        public int Get_Fan_Table_duty(int FanIndex, int DutyIndex)
        {
            string str = Registry.GetValue(keyName, "D" + DutyIndex.ToString(), "0").ToString();
            if (str == "0")
                return 0;
            return Convert.ToInt32(str);
        }

        public int Get_Fan_Table_temp(int FanIndex, int TempIndex)
        {
            string str = Registry.GetValue(keyName, "T" + TempIndex.ToString(), (object)"null").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public void Init(int FanTable)
        {
            string empty = string.Empty;
            int Fan1 = Get_Fan_Table_duty(FanTable, 1);
            int temp1 = Get_Fan_Table_temp(FanTable, 1);
            int Fan2 = Get_Fan_Table_duty(FanTable, 2);
            int temp2 = Get_Fan_Table_temp(FanTable, 2);
            int Fan3 = Get_Fan_Table_duty(FanTable, 3);
            int temp3 = Get_Fan_Table_temp(FanTable, 3);
            int Fan4 = Get_Fan_Table_duty(FanTable, 4);
            int temp4 = Get_Fan_Table_temp(FanTable, 4);
            if (0 >= Fan1 || Fan1 >= Fan2 || (Fan2 >= Fan3 || Fan3 >= Fan4) || Fan4 > 100)
                empty += string.Format("The Fan{0} duty value ERROR!", (object)FanTable);
            if (empty != string.Empty)
                empty += "\n";
            if (0 >= temp1 || temp1 >= temp2 || (temp2 >= temp3 || temp3 >= temp4) || temp4 > 100)
                empty += string.Format("The Fan{0} temp value ERROR!", (object)FanTable);
            if (empty != string.Empty)
            {
                string str = empty + "\n" + "Control Center will set the legal value!";
                Fan1 = 50;
                Fan2 = 60;
                Fan3 = 70;
                Fan4 = 100;
                temp1 = 40;
                temp2 = 60;
                temp3 = 80;
                temp4 = 100;
            }
            this.Update_T1_UI(Fan1, temp1);
            this.Update_T2_UI(Fan2, temp2);
            this.Update_T3_UI(Fan3, temp3);
            this.Update_T4_UI(Fan4, temp4);
        }

        public void R_layer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
            {
                this.T2_move = false;
                this.T3_move = false;
            }
            else
            {
                Point position = e.GetPosition((IInputElement)this.R_layer);
                double num1 = Math.Floor(position.X);
                position = e.GetPosition((IInputElement)this.R_layer);
                double num2 = Math.Floor(position.Y);
                Thickness thickness = new Thickness();
                thickness.Left = num1;
                thickness.Top = num2;
                Thickness margin;
                


                    if (this.T2_move)
                {
                    double num3 = num1;
                    margin = this.T3_point.Margin;
                    double num4 = margin.Left - 7.0;
                    if (num3 >= num4)
                    {
                        ref Thickness local = ref thickness;
                        margin = this.T3_point.Margin;
                        double num5 = margin.Left - 7.0;
                        local.Left = num5;
                    }
                    else
                    {
                        double num5 = num1;
                        margin = this.T1_point.Margin;
                        double left = margin.Left;
                        if (num5 <= left)
                        {
                            ref Thickness local = ref thickness;
                            margin = this.T1_point.Margin;
                            double num6 = margin.Left + 7.0;
                            local.Left = num6;
                        }
                        else
                            thickness.Left = num1;
                    }
                    double num7 = num2;
                    margin = this.T3_point.Margin;
                    double num8 = margin.Top - 3.0;
                    if (num7 >= num8)
                    {
                        ref Thickness local = ref thickness;
                        margin = this.T3_point.Margin;
                        double num5 = margin.Top - 3.0;
                        local.Top = num5;
                    }
                    else
                    {
                        double num5 = num2;
                        margin = this.T1_point.Margin;
                        double top = margin.Top;
                        if (num5 <= top)
                        {
                            ref Thickness local = ref thickness;
                            margin = this.T1_point.Margin;
                            double num6 = margin.Top + 3.0;
                            local.Top = num6;
                        }
                        else
                            thickness.Top = num2;
                    }
                    this.T_temp.Text = (Math.Ceiling(thickness.Left / 7.0) + 35.0).ToString();
                    this.T_fan.Text = Math.Ceiling(thickness.Top / 3.0).ToString();
                    this.Update_T2_UI((int)Convert.ToInt16(this.T_fan.Text), (int)Convert.ToInt16(this.T_temp.Text));
                }
                if (!this.T3_move)
                    return;
                double num9 = num1;
                margin = this.T4_point.Margin;
                double num10 = margin.Left - 7.0;
                if (num9 >= num10)
                {
                    ref Thickness local = ref thickness;
                    margin = this.T4_point.Margin;
                    double num3 = margin.Left - 7.0;
                    local.Left = num3;
                }
                else
                {
                    double num3 = num1;
                    margin = this.T2_point.Margin;
                    double left = margin.Left;
                    if (num3 <= left)
                    {
                        ref Thickness local = ref thickness;
                        margin = this.T2_point.Margin;
                        double num4 = margin.Left + 7.0;
                        local.Left = num4;
                    }
                    else
                        thickness.Left = num1;
                }
                double num11 = num2;
                margin = this.T4_point.Margin;
                double num12 = margin.Top - 3.0;
                if (num11 >= num12)
                {
                    ref Thickness local = ref thickness;
                    margin = this.T4_point.Margin;
                    double num3 = margin.Top - 6.0;
                    local.Top = num3;
                }
                else
                {
                    double num3 = num2;
                    margin = this.T2_point.Margin;
                    double top = margin.Top;
                    if (num3 <= top)
                    {
                        ref Thickness local = ref thickness;
                        margin = this.T2_point.Margin;
                        double num4 = margin.Top + 3.0;
                        local.Top = num4;
                    }
                    else
                        thickness.Top = num2;
                }
                this.T_temp.Text = (Math.Ceiling(thickness.Left / 7.0) + 35.0).ToString();
                this.T_fan.Text = Math.Ceiling(thickness.Top / 3.0).ToString();
                this.Update_T3_UI((int)Convert.ToInt16(this.T_fan.Text), (int)Convert.ToInt16(this.T_temp.Text));
            }
        }

        public void Update_T1_UI(int Fan, int temp)
        {
            Thickness thickness = new Thickness();
            this.T1.ToolTip = (object)("Fan = " + (object)Fan + "%\nTemp = " + (object)temp + " °C");
            thickness.Left = (double)((temp - 35) * 7);
            thickness.Top = (double)(Fan * 3);
            thickness.Bottom = -20.0;
            thickness.Right = -20.0;
            this.T1_point.Margin = thickness;
            Thickness margin1 = this.T2_point.Margin;
            double left1 = margin1.Left;
            margin1 = this.T1_point.Margin;
            double left2 = margin1.Left;
            double num1 = left1 - left2;
            Thickness margin2 = this.T2_point.Margin;
            double top1 = margin2.Top;
            margin2 = this.T1_point.Margin;
            double top2 = margin2.Top;
            double num2 = top1 - top2;
            this.R12.Width = num1;
            this.R12.Height = num2;
        }

        public void Update_T2_UI(int Fan, int temp)
        {
            Thickness thickness = new Thickness();
            this.T2.ToolTip = (object)("Fan = " + (object)Fan + "%\nTemp = " + (object)temp + " °C");
            thickness.Left = (double)((temp - 35) * 7);
            thickness.Top = (double)(Fan * 3);
            thickness.Bottom = -20.0;
            thickness.Right = -20.0;
            this.T2_point.Margin = thickness;
            Thickness margin1 = this.T2_point.Margin;
            double left1 = margin1.Left;
            margin1 = this.T1_point.Margin;
            double left2 = margin1.Left;
            double num1 = left1 - left2;
            Thickness margin2 = this.T2_point.Margin;
            double top1 = margin2.Top;
            margin2 = this.T1_point.Margin;
            double top2 = margin2.Top;
            double num2 = top1 - top2;
            this.R12.Width = num1;
            this.R12.Height = num2;
            Thickness margin3 = this.T3_point.Margin;
            double left3 = margin3.Left;
            margin3 = this.T2_point.Margin;
            double left4 = margin3.Left;
            double num3 = left3 - left4;
            Thickness margin4 = this.T3_point.Margin;
            double top3 = margin4.Top;
            margin4 = this.T2_point.Margin;
            double top4 = margin4.Top;
            double num4 = top3 - top4;
            this.R23.Width = num3;
            this.R23.Height = num4;
        }

        public void Update_T3_UI(int Fan, int temp)
        {
            Thickness thickness = new Thickness();
            this.T3.ToolTip = (object)("Fan = " + (object)Fan + "%\nTemp = " + (object)temp + " °C");
            thickness.Left = (double)((temp - 35) * 7);
            thickness.Top = (double)(Fan * 3);
            thickness.Bottom = -20.0;
            thickness.Right = -20.0;
            this.T3_point.Margin = thickness;
            Thickness margin1 = this.T3_point.Margin;
            double left1 = margin1.Left;
            margin1 = this.T2_point.Margin;
            double left2 = margin1.Left;
            double num1 = left1 - left2;
            Thickness margin2 = this.T3_point.Margin;
            double top1 = margin2.Top;
            margin2 = this.T2_point.Margin;
            double top2 = margin2.Top;
            double num2 = top1 - top2;
            this.R23.Width = num1;
            this.R23.Height = num2;
            Thickness margin3 = this.T4_point.Margin;
            double left3 = margin3.Left;
            margin3 = this.T3_point.Margin;
            double left4 = margin3.Left;
            double num3 = left3 - left4;
            Thickness margin4 = this.T4_point.Margin;
            double top3 = margin4.Top;
            margin4 = this.T3_point.Margin;
            double top4 = margin4.Top;
            double num4 = top3 - top4;
            this.R34.Width = num3;
            this.R34.Height = num4;
        }

        public void Update_T4_UI(int Fan, int temp)
        {
            Thickness thickness = new Thickness();
            this.T4.ToolTip = (object)("Fan = " + (object)Fan + "%\nTemp = " + (object)temp + " °C");
            thickness.Left = (double)((temp - 35) * 7);
            thickness.Top = (double)(Fan * 3);
            thickness.Bottom = -20.0;
            thickness.Right = -20.0;
            this.T4_point.Margin = thickness;
            Thickness margin1 = this.T4_point.Margin;
            double left1 = margin1.Left;
            margin1 = this.T3_point.Margin;
            double left2 = margin1.Left;
            double num1 = left1 - left2;
            Thickness margin2 = this.T4_point.Margin;
            double top1 = margin2.Top;
            margin2 = this.T3_point.Margin;
            double top2 = margin2.Top;
            double num2 = top1 - top2;
            this.R34.Width = num1;
            this.R34.Height = num2;
        }

        public void T1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.T1_move = true;
            this.change_select_T(1);
            this.userControl.Tag = (object)"1";
        }

        public void T2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.T2_move = true;
            this.change_select_T(2);
            this.userControl.Tag = (object)"1";
        }

        public void T3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.T3_move = true;
            this.change_select_T(3);
            this.userControl.Tag = (object)"1";
        }

        public void change_select_T(int T)
        {
            this.select_T = T;
            Brush brush1 = (Brush)new SolidColorBrush(Color.FromArgb(byte.MaxValue, (byte)160, (byte)160, (byte)160));
            this.T2.Stroke = brush1;
            this.T3.Stroke = brush1;
            this.T2.StrokeThickness = 2.0;
            this.T3.StrokeThickness = 2.0;
            this.T_temp.Text = "";
            this.T_fan.Text = "";
            Brush brush2 = (Brush)new SolidColorBrush(Color.FromArgb(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
            if (T == 2)
            {
                this.T2.Stroke = brush2;
                this.T2.StrokeThickness = 4.0;
                double num = this.T2_point.Margin.Left / 7.0 + 35.0;
                this.T_temp.Text = num.ToString();
                num = this.T2_point.Margin.Top / 3.0;
                this.T_fan.Text = num.ToString();
            }
            if (T != 3)
                return;
            this.T3.Stroke = brush2;
            this.T3.StrokeThickness = 4.0;
            double num1 = this.T3_point.Margin.Left / 7.0 + 35.0;
            this.T_temp.Text = num1.ToString();
            num1 = this.T3_point.Margin.Top / 3.0;
            this.T_fan.Text = num1.ToString();
        }

        public void userControl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.userControl.IsEnabled)
            {
                this.R12.StrokeThickness = 6.0;
                this.R23.StrokeThickness = 6.0;
                this.R34.StrokeThickness = 6.0;
            }
            else
            {
                this.R12.StrokeThickness = 3.0;
                this.R23.StrokeThickness = 3.0;
                this.R34.StrokeThickness = 3.0;
            }
        }

        public void Set_Fan_Table_duty(int FanIndex, int DutyIndex, int value)
        {
            Registry.SetValue(keyName + FanIndex.ToString(), "D" + (object)DutyIndex, (object)value, RegistryValueKind.DWord);
        }
        public void Set_Fan_Table_temp(int FanIndex, int TempIndex, int value)
        {
            Registry.SetValue(keyName + FanIndex.ToString(), "T" + (object)TempIndex, (object)value, RegistryValueKind.DWord);
        }
        public void Save_FanTable(int FanTableIndex)
        {
            this.userControl.Tag = (object)"0";
            double num1 = this.T2_point.Margin.Top / 3.0;
            Set_Fan_Table_duty(FanTableIndex, 2, (int)num1);
            double num2 = this.T3_point.Margin.Top / 3.0;
            Set_Fan_Table_duty(FanTableIndex, 3, (int)num2);
            double num3 = this.T2_point.Margin.Left / 7.0 + 35.0;
            Set_Fan_Table_temp(FanTableIndex, 2, (int)num3);
            double num4 = this.T3_point.Margin.Left / 7.0 + 35.0;
            Set_Fan_Table_temp(FanTableIndex, 3, (int)num4);
        }

        public bool CheckFanTableDefaultDuty(int fan_index)
        {
            int fanTableDuty1 = Get_Fan_Table_duty(fan_index, 1);
            int tableDutyDefault1 = Get_Fan_Table_duty_default(fan_index, 2);
            int tableDutyDefault2 = Get_Fan_Table_duty_default(fan_index, 3);
            int fanTableDuty2 = Get_Fan_Table_duty(fan_index, 4);
            return 0 < fanTableDuty1 && fanTableDuty1 < tableDutyDefault1 && (tableDutyDefault1 < tableDutyDefault2 && tableDutyDefault2 < fanTableDuty2) && fanTableDuty2 <= 100;
        }

        public bool CheckFanTableDefaultTemp(int fan_index)
        {
            int fanTableTemp1 = Get_Fan_Table_temp(fan_index, 1);
            int tableTempDefault1 = Get_Fan_Table_temp_default(fan_index, 2);
            int tableTempDefault2 = Get_Fan_Table_temp_default(fan_index, 3);
            int fanTableTemp2 = Get_Fan_Table_temp(fan_index, 4);
            return 0 < fanTableTemp1 && fanTableTemp1 < tableTempDefault1 && (tableTempDefault1 < tableTempDefault2 && tableTempDefault2 < fanTableTemp2) && fanTableTemp2 <= 100;
        }

        public void SetFanLegalDuty(int fan_index)
        {
            Set_Fan_Table_duty(fan_index, 1, 50);
            Set_Fan_Table_duty(fan_index, 2, 60);
            Set_Fan_Table_duty(fan_index, 3, 70);
            Set_Fan_Table_duty(fan_index, 4, 100);
        }

        public void SetFanLegalTemp(int fan_index)
        {
            Set_Fan_Table_temp(fan_index, 1, 40);
            Set_Fan_Table_temp(fan_index, 2, 60);
            Set_Fan_Table_temp(fan_index, 3, 80);
            Set_Fan_Table_temp(fan_index, 4, 100);
        }

        public void ResetAllUI(int FanTableIndex)
        {
            this.reset_UI(FanTableIndex);
            this.Update_T1_UI(Get_Fan_Table_duty(FanTableIndex, 1), Get_Fan_Table_temp(FanTableIndex, 1));
            this.Update_T2_UI(Get_Fan_Table_duty(FanTableIndex, 2), Get_Fan_Table_temp(FanTableIndex, 2));
            this.Update_T3_UI(Get_Fan_Table_duty(FanTableIndex, 3), Get_Fan_Table_temp(FanTableIndex, 3));
            this.Update_T4_UI(Get_Fan_Table_duty(FanTableIndex, 4), Get_Fan_Table_temp(FanTableIndex, 4));
        }

        public int Get_Fan_Table_duty_default(int FanIndex, int DutyIndex)
        {
            string str = Registry.GetValue(keyName + FanIndex.ToString(), "Default_D" + (object)DutyIndex, (object)"null").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }
        public int Get_Fan_Table_temp_default(int FanIndex, int TempIndex)
        {
            string str = Registry.GetValue(keyName + FanIndex.ToString(), "Default_T" + (object)TempIndex, (object)"null").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public void Set_defult_FanTable(int FanTableIndex)
        {
            if (this.CheckFanTableDefaultDuty(FanTableIndex) && this.CheckFanTableDefaultTemp(FanTableIndex))
            {
                Set_Fan_Table_duty(FanTableIndex, 2, Get_Fan_Table_duty_default(FanTableIndex, 2));
                Set_Fan_Table_duty(FanTableIndex, 3, Get_Fan_Table_duty_default(FanTableIndex, 3));
                Set_Fan_Table_temp(FanTableIndex, 2, Get_Fan_Table_temp_default(FanTableIndex, 2));
                Set_Fan_Table_temp(FanTableIndex, 3, Get_Fan_Table_temp_default(FanTableIndex, 3));
                this.reset_UI(FanTableIndex);
            }
            else
            {
                this.SetFanLegalDuty(FanTableIndex);
                this.SetFanLegalTemp(FanTableIndex);
                this.ResetAllUI(FanTableIndex);
            }
            this.Init(FanTableIndex);
        }

        public void reset_UI(int FanTableIndex)
        {
            this.Update_T3_UI(Get_Fan_Table_duty(FanTableIndex, 4) - 1, Get_Fan_Table_temp(FanTableIndex, 4) - 1);
            this.Update_T2_UI(Get_Fan_Table_duty(FanTableIndex, 1) + 1, Get_Fan_Table_temp(FanTableIndex, 1) + 1);
        }

       
    }
}
