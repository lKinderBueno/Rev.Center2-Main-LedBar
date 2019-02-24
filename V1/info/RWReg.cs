using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace Rev.Center2
{
    public class RWReg
    {
        public string UI_language = "en-US";
        private const int CPU_REMOTE = 18;
        private const int GPU1_REMOTE = 21;
        private const int GPU2_REMOTE = 24;
        private int cpu_temp;
        private int gpu1_temp;
        private int gpu2_temp;
        private string TDP;
        public string CurrentMode;
        public int AirplaneMode;
        public int TouchPad;
        public int CCD;
        public int WhiteLedKB_Brightness;
        public int HeadPhone;
        public int KBSleepTimer;

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection(
          string lpAppName,
          byte[] lpszReturnBuffer,
          int nSize,
          string lpFileName);

        public RWReg()
        {
            string str1 = string.Empty;
            foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor").Get())
                str1 = managementBaseObject["Name"].ToString().ToLower();
            str1.Contains("intel");
            string directoryName = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            byte[] numArray1 = new byte[2048];
            RWReg.GetPrivateProfileSection("91W", numArray1, 2048, directoryName + "\\cpu.ini");
            foreach (string str2 in Encoding.ASCII.GetString(numArray1).Trim(new char[1]).Split(new char[1]))
            {
                try
                {
                    if (str1.Contains(str2))
                        this.TDP = "91W";
                }
                catch
                {
                }
            }
            if (this.TDP != "")
                return;
            byte[] numArray2 = (byte[])null;
            byte[] numArray3 = new byte[2048];
            RWReg.GetPrivateProfileSection("84W", numArray3, 2048, directoryName + "\\cpu.ini");
            foreach (string str2 in Encoding.ASCII.GetString(numArray3).Trim(new char[1]).Split(new char[1]))
            {
                try
                {
                    if (str1.Contains(str2))
                        this.TDP = "84W";
                }
                catch
                {
                }
            }
            if (this.TDP != "")
                return;
            numArray2 = (byte[])null;
            byte[] numArray4 = new byte[2048];
            RWReg.GetPrivateProfileSection("65W", numArray4, 2048, directoryName + "\\cpu.ini");
            foreach (string str2 in Encoding.ASCII.GetString(numArray4).Trim(new char[1]).Split(new char[1]))
            {
                try
                {
                    if (str1.Contains(str2))
                        this.TDP = "65W";
                }
                catch
                {
                }
            }
            if (this.TDP != "")
                return;
            numArray2 = (byte[])null;
            byte[] numArray5 = new byte[2048];
            RWReg.GetPrivateProfileSection("35W", numArray5, 2048, directoryName + "\\cpu.ini");
            foreach (string str2 in Encoding.ASCII.GetString(numArray5).Trim(new char[1]).Split(new char[1]))
            {
                try
                {
                    if (str1.Contains(str2))
                        this.TDP = "35W";
                }
                catch
                {
                }
            }
            if (this.TDP != "")
                return;
            byte[] numArray6 = new byte[2048];
            RWReg.GetPrivateProfileSection("47W", numArray6, 2048, directoryName + "\\cpu.ini");
            foreach (string str2 in Encoding.ASCII.GetString(numArray6).Trim(new char[1]).Split(new char[1]))
            {
                try
                {
                    if (str1.Contains(str2))
                        this.TDP = "47W";
                }
                catch
                {
                }
            }
        }

        public void init()
        {
        }

        public int window_FullScreen
        {
            get
            {
                string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\UI\\", nameof(window_FullScreen), (object)"null").ToString();
                if (str == "null")
                    return 1;
                return (int)Convert.ToInt16(str);
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\UI\\", nameof(window_FullScreen), (object)value.ToString());
            }
        }

        public int window_Color
        {
            get
            {
                string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\UI\\", nameof(window_Color), (object)"null").ToString();
                if (str == "null")
                    return 10617087;
                return Convert.ToInt32(str);
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\UI\\", nameof(window_Color), (object)value.ToString());
            }
        }

        public int UAC_Behavior
        {
            get
            {
                string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "ConsentPromptBehaviorAdmin", (object)"5").ToString();
                if (str == "null")
                    return 5;
                return Convert.ToInt32(str);
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "ConsentPromptBehaviorAdmin", (object)value, RegistryValueKind.DWord);
            }
        }

        public int Support_Page_SystemMonitor()
        {
            return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\UI\\", nameof(Support_Page_SystemMonitor), (object)"0"));
        }

        public int Support_Page_LEDDevice()
        {
            return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\UI\\", nameof(Support_Page_LEDDevice), (object)"0"));
        }

      

        public int KB_language()
        {
            return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\UI\\", nameof(KB_language), (object)"0"));
        }

        private void WriteLanguage(string strLang)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\UI\\", "language", (object)strLang);
        }

        public int GPUOC_Freq
        {
            get
            {
                return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\GPU", nameof(GPUOC_Freq), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\GPU", nameof(GPUOC_Freq), (object)value, RegistryValueKind.DWord);
            }
        }

        public int GPUOC2_Freq
        {
            get
            {
                return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\GPU", nameof(GPUOC2_Freq), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\GPU", nameof(GPUOC2_Freq), (object)value, RegistryValueKind.DWord);
            }
        }

        public int GPUMOC_Freq
        {
            get
            {
                return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\GPU", nameof(GPUMOC_Freq), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\GPU", nameof(GPUMOC_Freq), (object)value, RegistryValueKind.DWord);
            }
        }

        public int GPUMOC2_Freq
        {
            get
            {
                return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\GPU", nameof(GPUMOC2_Freq), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\GPU", nameof(GPUMOC2_Freq), (object)value, RegistryValueKind.DWord);
            }
        }

        public int GPU_CoreINC_MAX()
        {
            return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\GPU", "GPUOCMax", (object)"0"));
        }

        public int GPU_CoreINC_MIN()
        {
            return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\GPU", "GPUOCMin", (object)"0"));
        }

        public int GPU_VRAMINC_MAX()
        {
            return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\GPU", "MEMOCMax", (object)"0"));
        }

        public int GPU_VRAMINC_MIN()
        {
            return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\GPU", "MEMOCMin", (object)"0"));
        }

        public int WMI_122()
        {
            return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\WMI\\", nameof(WMI_122), (object)"0").ToString());
        }

        public int Get_GPUSwitchStatus()
        {
            return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\WMI\\", "WMI_84", (object)"0").ToString());
        }

        public int Get_TP()
        {
            return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\WMI\\", "WMI_42", (object)"0").ToString());
        }

        public int Get_CCD()
        {
            return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\WMI\\", "WMI_34", (object)"0").ToString());
        }

        public int Get_LeftWinKey()
        {
            return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0", "LeftWinKey", (object)"1").ToString());
        }

        public bool Get_DisableAirplane()
        {
            return Convert.ToBoolean(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0", "Disable_Airplane", (object)null));
        }

        public int Get_Fan_Table_duty(int FanIndex, int DutyIndex)
        {
            string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC\\Fan" + FanIndex.ToString(), "D" + (object)DutyIndex, (object)"null").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public void Set_Fan_Table_duty(int FanIndex, int DutyIndex, int value)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC\\Fan" + FanIndex.ToString(), "D" + (object)DutyIndex, (object)value, RegistryValueKind.DWord);
        }

        public int Get_Fan_Table_temp(int FanIndex, int TempIndex)
        {
            string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC\\Fan" + FanIndex.ToString(), "T" + (object)TempIndex, (object)"null").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public void Set_Fan_Table_temp(int FanIndex, int TempIndex, int value)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC\\Fan" + FanIndex.ToString(), "T" + (object)TempIndex, (object)value, RegistryValueKind.DWord);
        }

        public int Get_Fan_Table_duty_default(int FanIndex, int DutyIndex)
        {
            string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC\\Fan" + FanIndex.ToString(), "Default_D" + (object)DutyIndex, (object)"null").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public int Get_Fan_Table_temp_default(int FanIndex, int TempIndex)
        {
            string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC\\Fan" + FanIndex.ToString(), "Default_T" + (object)TempIndex, (object)"null").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public int CPUFan_duty()
        {
            string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC\\Fan1", "duty", (object)"0").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public int GPUFan_duty()
        {
            string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC\\Fan2", "duty", (object)"0").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public int GPUFan2_duty()
        {
            string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC\\Fan3", "duty", (object)"0").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public int CPUFan_rpm()
        {
            string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC\\Fan1", "rpm", (object)"0").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public int GPUFan_rpm()
        {
            string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC\\Fan2", "rpm", (object)"0").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public int GPUFan2_rpm()
        {
            string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC\\Fan3", "rpm", (object)"0").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public int FanMode()
        {
            string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC", nameof(FanMode), (object)"0").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public int FanOffset()
        {
            string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC", nameof(FanOffset), (object)"0").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public int FanCount()
        {
            string str = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC", nameof(FanCount), (object)"0").ToString();
            if (str == "null")
                return 0;
            return Convert.ToInt32(str);
        }

        public byte FanOCMode
        {
            get
            {
                return Convert.ToByte(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC", nameof(FanOCMode), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC", nameof(FanOCMode), (object)value, RegistryValueKind.DWord);
            }
        }

        public bool SupportFanLess
        {
            get
            {
                return Convert.ToBoolean(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0", nameof(SupportFanLess), (object)null));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0", nameof(SupportFanLess), (object)value);
            }
        }

        public bool SupportMaxqFan
        {
            get
            {
                return Convert.ToBoolean(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\EC\\", "SupportMaxQ_FAN", (object)null));
            }
        }

        public void LoadCurrentMode()
        {
            this.CurrentMode = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\", "CurrentMode", (object)"entertainment").ToString();
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\ControlCenter2.0\\" + this.CurrentMode, false);
            this.CCD = (int)registryKey.GetValue("CCD");
            this.TouchPad = (int)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0", "TouchPad", (object)null);
            this.AirplaneMode = (int)registryKey.GetValue("AirplaneMode");
            this.HeadPhone = (int)registryKey.GetValue("HeadPhone");
            this.KBSleepTimer = (int)registryKey.GetValue("KBSleepTimer");
        }

        public int KBType()
        {
            return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED", nameof(KBType), (object)"0"));
        }

        public int PerkeySpeed
        {
            get
            {
                return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED", "KBSpeed", (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED", "KBSpeed", (object)value, RegistryValueKind.DWord);
            }
        }

        public int KBStatus
        {
            get
            {
                return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED", nameof(KBStatus), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED", nameof(KBStatus), (object)value, RegistryValueKind.DWord);
            }
        }

        public int KBbrightness
        {
            get
            {
                return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED", nameof(KBbrightness), (object)"3"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED", nameof(KBbrightness), (object)value, RegistryValueKind.DWord);
            }
        }

        public int KB_RGB_Mode
        {
            get
            {
                return (int)Convert.ToInt16(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED", nameof(KB_RGB_Mode), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED", nameof(KB_RGB_Mode), (object)value, RegistryValueKind.DWord);
            }
        }

        public void Set_KB_RGB(string part, int R, int G, int B)
        {
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\" + part, nameof(R), (object)R, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\" + part, nameof(G), (object)G, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\" + part, nameof(B), (object)B, RegistryValueKind.DWord);
        }

        public int Get_KB_R(string part)
        {
            return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED" + part, "R", (object)"0").ToString());
        }

        public int Get_KB_G(string part)
        {
            return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED" + part, "G", (object)"0").ToString());
        }

        public int Get_KB_B(string part)
        {
            return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED" + part, "B", (object)"0").ToString());
        }

        public void Set_Perkey_Static_RGB(string id, byte R, byte G, byte B)
        {
            int num = ((int)R << 16) + ((int)G << 8) + (int)B;
            Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\Static", id, (object)num, RegistryValueKind.DWord);
        }

        public int Get_Perkey_Static_RGB(string id)
        {
            return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\Static", id, (object)"0").ToString());
        }

        public int Perkey_EffectMode
        {
            get
            {
                return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", "EffectMode", (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", "EffectMode", (object)value, RegistryValueKind.DWord);
            }
        }

        public int Perkey_BlinkStatus
        {
            get
            {
                return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", "BlinkStatus", (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", "BlinkStatus", (object)value, RegistryValueKind.DWord);
            }
        }

        public byte Blink_R
        {
            get
            {
                return Convert.ToByte(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Blink_R), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Blink_R), (object)value, RegistryValueKind.DWord);
            }
        }

        public byte Blink_G
        {
            get
            {
                return Convert.ToByte(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Blink_G), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Blink_G), (object)value, RegistryValueKind.DWord);
            }
        }

        public byte Blink_B
        {
            get
            {
                return Convert.ToByte(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Blink_B), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Blink_B), (object)value, RegistryValueKind.DWord);
            }
        }

        public int Perkey_BreathStatus
        {
            get
            {
                return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", "BreathStatus", (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", "BreathStatus", (object)value, RegistryValueKind.DWord);
            }
        }

        public byte Breath_R
        {
            get
            {
                return Convert.ToByte(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Breath_R), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Breath_R), (object)value, RegistryValueKind.DWord);
            }
        }

        public byte Breath_G
        {
            get
            {
                return Convert.ToByte(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Breath_G), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Breath_G), (object)value, RegistryValueKind.DWord);
            }
        }

        public byte Breath_B
        {
            get
            {
                return Convert.ToByte(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Breath_B), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Breath_B), (object)value, RegistryValueKind.DWord);
            }
        }

        public int Perkey_RippleStatus
        {
            get
            {
                return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", "RippleStatus", (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", "RippleStatus", (object)value, RegistryValueKind.DWord);
            }
        }

        public byte Ripple_R
        {
            get
            {
                return Convert.ToByte(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Ripple_R), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Ripple_R), (object)value, RegistryValueKind.DWord);
            }
        }

        public byte Ripple_G
        {
            get
            {
                return Convert.ToByte(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Ripple_G), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Ripple_G), (object)value, RegistryValueKind.DWord);
            }
        }

        public byte Ripple_B
        {
            get
            {
                return Convert.ToByte(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Ripple_B), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", nameof(Ripple_B), (object)value, RegistryValueKind.DWord);
            }
        }

        public int Perkey_StaticStatus
        {
            get
            {
                return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", "StaticStatus", (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\LED\\PKB\\", "StaticStatus", (object)value, RegistryValueKind.DWord);
            }
        }

        private string GetTDP()
        {
            return this.TDP;
        }

        private int CalCPUTemp(string CPUTDP, int set_remote)
        {
            int num = set_remote;
            return (int)Math.Round(CPUTDP == "84W" || CPUTDP == "88W" ? (num <= 60 ? (double)(num - 1) : (double)(num - 12) * 0.33 + 44.0) : (!(CPUTDP == "65W") ? (!(CPUTDP == "91W") ? (!(CPUTDP == "35W") ? (!(CPUTDP == "47W") ? (double)num : (num <= 26 ? (double)num : (double)num * 0.5 + 13.0)) : (num <= 32 ? (double)num : (double)num * 0.5 + 16.0)) : (num <= 50 ? (double)(num - 5) : (double)(num - 9) * 0.22 + 43.7)) : (num <= 50 ? (double)(num - 1) : (double)(num - 35) * 0.41 + 43.7)), 0);
        }

        public void UpdateWMI12()
        {
            byte[] numArray = (byte[])Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\wmi", "WMI_12", (object)"");
            this.cpu_temp = this.CalCPUTemp(this.GetTDP(), (int)numArray[18]);
            this.gpu1_temp = (int)numArray[21];
            this.gpu2_temp = (int)numArray[24];
        }

        public int CpuTemp()
        {
            return this.cpu_temp;
        }

        public int GpuTemp(int num)
        {
            if (num == 0)
                return this.gpu1_temp;
            if (num == 1)
                return this.gpu2_temp;
            return 0;
        }

        public int FlexiKey_KB_Enable
        {
            get
            {
                return Convert.ToInt32(Registry.GetValue("HKEY_CURRENT_USER\\Software\\ComboKey\\", "KBEnable", (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\ComboKey", "KBEnable", (object)value.ToString());
            }
        }

        public int FlexiKey_Mouse_Enable
        {
            get
            {
                return Convert.ToInt32(Registry.GetValue("HKEY_CURRENT_USER\\Software\\ComboKey\\", "MouseEnable", (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\ComboKey", "MouseEnable", (object)value.ToString());
            }
        }

        public int FlexiAccessStatus
        {
            get
            {
                return Convert.ToInt32(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\FA", nameof(FlexiAccessStatus), (object)"0"));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\FA", nameof(FlexiAccessStatus), (object)value, RegistryValueKind.DWord);
            }
        }

        public string FA_ClientName
        {
            get
            {
                return Convert.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\FA", "ClientName", (object)""));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\FA", "ClientName", (object)value, RegistryValueKind.String);
            }
        }

        public string FA_Port
        {
            get
            {
                return Convert.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\FA", "Port", (object)""));
            }
            set
            {
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Rev.Center\\Rev.Center2.0\\FA", "Port", (object)value, RegistryValueKind.String);
            }
        }
    }
}
