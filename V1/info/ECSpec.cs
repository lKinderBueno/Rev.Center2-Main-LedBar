// Decompiled with JetBrains decompiler
// Type: V1.ECSpec
// Assembly: MyLightBar, Version=1.5.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EBEC481-DFDA-4AA7-A830-678DCDECD21C
// Assembly location: E:\Users\elio1\OneDrive\Desktop\MyAPP 1.6.1.0\OEM\MyAPP\MyLightBar\MyLightBar.exe

using System;

namespace V1
{
  internal static class ECSpec
  {
    public const ushort BIOSFuncReg = 1142;
    public const ushort ecPowSource = 1168;
    public const ushort ecBt1Temperature = 1186;
    public const ushort ecBt1RSOC = 1195;
    public const uint FAN_MODE_NORMAL = 0;
    public const uint FAN_MODE_BOOST = 1;
    public const uint FAN_MODE_CUSTOMIZE = 2;
    public const uint FAN_LEVEL_ONE = 1;
    public const uint FAN_LEVEL_TWO = 2;
    public const uint FAN_LEVEL_THREE = 3;
    public const uint FAN_LEVEL_FOUR = 4;
    public const uint FAN_LEVEL_FIVE = 5;
    public const ushort ADDR_MAFAN_CONTROL_BYTE = 1873;
    public const ushort ADDR_TRIGGER_BYTE2 = 1885;
    public const ushort ADDR_SUPPORT_BYTE1 = 1893;
    public const ushort ADDR_SUPPORT_BYTE2 = 1894;
    public const ushort ADDR_TRIGGER_BYTE = 1895;
    public const ushort ADDR_STAUTS_BYTE = 1896;
    public const ushort OSD_CAPSLOCK = 1;
    public const ushort OSD_NUMLOCK = 2;
    public const ushort OSD_SROLLOCK = 3;
    public const ushort OSD_TPON = 4;
    public const ushort OSD_TPOFF = 5;
    public const ushort OSD_SILENTON = 6;
    public const ushort OSD_SILENTOFF = 7;
    public const ushort OSD_WLANON = 8;
    public const ushort OSD_WLANOFF = 9;
    public const ushort OSD_WINMAXON = 10;
    public const ushort OSD_WINMAXOFF = 11;
    public const ushort OSD_BTON = 12;
    public const ushort OSD_BTOFF = 13;
    public const ushort OSD_RFON = 14;
    public const ushort OSD_RFOFF = 15;
    public const ushort OSD_3GON = 16;
    public const ushort OSD_3GOFF = 17;
    public const ushort OSD_WEBCAMON = 18;
    public const ushort OSD_WEBCAMOFF = 19;
    public const ushort OSD_BRIGHTNESSUP = 20;
    public const ushort OSD_BRIGHTNESSDOWN = 21;
    public const ushort OSD_RADIOON = 26;
    public const ushort OSD_RADIOOFF = 27;
    public const ushort OSD_POWERSAVEON = 49;
    public const ushort OSD_POWERSAVEOFF = 50;
    public const ushort OSD_MENU = 52;
    public const ushort OSD_MUTE = 53;
    public const ushort OSD_VOLUMEDOWN = 54;
    public const ushort OSD_VOLUMEUP = 55;
    public const ushort OSD_OSD_MENU_2 = 56;
    public const ushort OSD_BREATH_LED_ON = 57;
    public const ushort OSD_BREATH_LED_OFF = 58;
    public const ushort OSD_KB_LED_LEVEL0 = 59;
    public const ushort OSD_KB_LED_LEVEL1 = 60;
    public const ushort OSD_KB_LED_LEVEL2 = 61;
    public const ushort OSD_KB_LED_LEVEL3 = 62;
    public const ushort OSD_KB_LED_LEVEL4 = 63;
    public const ushort OSD_WINKEY_LOCK = 64;
    public const ushort OSD_WINKEY_UNLOCK = 65;
    public const ushort OSD_MENU_JP = 66;
    public const ushort OSD_CAMERAON = 144;
    public const ushort OSD_CAMERAOFF = 145;
    public const ushort OSD_FANBOOST_UPDATE = 167;
    public const ushort OSD_LCD_SW = 169;
    public const ushort OSD_FAN_OVER_TEMP = 170;
    public const ushort OSD_MyBat_ACUpdate = 171;
    public const ushort OSD_MyBat_HPOff = 172;
    public const uint APP_Normal_Mode = 0;
    public const uint APP_ImageProjectionLight_Mode = 1;
    public const uint APP_LightBar_Mode = 2;
    public const ushort ADDR_LIGHTBAR_CONTROL_BYTE = 1864;
    public const ushort ADDR_REDBAR_CONTROL_BYTE = 1865;
    public const ushort ADDR_GREENBAR_CONTROL_BYTE = 1866;
    public const ushort ADDR_BLUEBAR_CONTROL_BYTE = 1867;
    public const uint RED_LEVEL_ZERO = 0;
    public const uint RED_LEVEL_ONE = 1;
    public const uint RED_LEVEL_TWO = 2;
    public const uint RED_LEVEL_THREE = 3;
    public const uint RED_LEVEL_FOUR = 4;
    public const uint RED_LEVEL_FIVE = 5;
    public const uint RED_LEVEL_SIX = 6;
    public const uint RED_LEVEL_SEVEN = 7;
    public const uint RED_LEVEL_EIGHT = 8;
    public const uint RED_LEVEL_NINE = 9;
    public const uint GREEN_LEVEL_ZERO = 0;
    public const uint GREEN_LEVEL_ONE = 1;
    public const uint GREEN_LEVEL_TWO = 2;
    public const uint GREEN_LEVEL_THREE = 3;
    public const uint GREEN_LEVEL_FOUR = 4;
    public const uint GREEN_LEVEL_FIVE = 5;
    public const uint GREEN_LEVEL_SIX = 6;
    public const uint GREEN_LEVEL_SEVEN = 7;
    public const uint GREEN_LEVEL_EIGHT = 8;
    public const uint GREEN_LEVEL_NINE = 9;
    public const uint BLUE_LEVEL_ZERO = 0;
    public const uint BLUE_LEVEL_ONE = 1;
    public const uint BLUE_LEVEL_TWO = 2;
    public const uint BLUE_LEVEL_THREE = 3;
    public const uint BLUE_LEVEL_FOUR = 4;
    public const uint BLUE_LEVEL_FIVE = 5;
    public const uint BLUE_LEVEL_SIX = 6;
    public const uint BLUE_LEVEL_SEVEN = 7;
    public const uint BLUE_LEVEL_EIGHT = 8;
    public const uint BLUE_LEVEL_NINE = 9;
    public const uint COLOR_LEVEL_ZERO = 0;
    public const uint COLOR_LEVEL_ONE = 1;
    public const uint COLOR_LEVEL_TWO = 2;
    public const uint COLOR_LEVEL_THREE = 3;
    public const uint COLOR_LEVEL_FOUR = 4;
    public const uint COLOR_LEVEL_FIVE = 5;
    public const uint COLOR_LEVEL_SIX = 6;
    public const uint COLOR_LEVEL_SEVEN = 7;
    public const uint COLOR_LEVEL_EIGHT = 8;
    public const uint COLOR_LEVEL_NINE = 9;
    public const uint BRIGHTNESS_LEVEL_ZERO = 0;
    public const uint BRIGHTNESS_LEVEL_ONE = 1;
    public const uint BRIGHTNESS_LEVEL_TWO = 2;
    public const uint BRIGHTNESS_LEVEL_THREE = 3;
    public const uint BRIGHTNESS_LEVEL_FOUR = 4;
    public const uint POWERSAVE_MODE_OFF = 0;
    public const uint POWERSAVE_MODE_ON = 1;
    public const uint BREATHINGLIGHTEFFECT_MODE_OFF = 0;
    public const uint BREATHINGLIGHTEFFECT_MODE_ON = 1;

    [Flags]
    public enum MyFanCTLByteFlag
    {
      Normal_Mode = 0,
      FanBoost_Mode = 64, // 0x00000040
      User_Fan_Mode = 128, // 0x00000080
      User_Fan_Level1 = 129, // 0x00000081
      User_Fan_Level2 = 130, // 0x00000082
      User_Fan_Level3 = 131, // 0x00000083
      User_Fan_Level4 = 132, // 0x00000084
      User_Fan_Level5 = 133, // 0x00000085
    }

    [Flags]
    public enum TriggerByteFlag
    {
      WinLock_Trigger = 1,
      LightBar_Trigger = 2,
      FanBoost_Trigger = 4,
      SilentMode_Trigger = 8,
      USBCharger_Trigger = 16, // 0x00000010
      RGBKeybaord_Trigger = 32, // 0x00000020
      RGBLogo_Trigger = 64, // 0x00000040
      RGBKeybaordWelcome_Trigger = 128, // 0x00000080
    }

    [Flags]
    public enum SupportByteOneFlag
    {
      AirplaneMode = 1,
      GPSSwitch = 2,
      OverClock = 4,
      MacroKey = 8,
      ShortCutKey = 16, // 0x00000010
      WinLockKey = 32, // 0x00000020
      LightBar = 64, // 0x00000040
      FanBoost = 128, // 0x00000080
    }

    [Flags]
    public enum SupportByteTwoFlag
    {
      SilentMode = 1,
      USBChargerMode = 2,
      RGBKeyBoard = 4,
      MyBat = 64, // 0x00000040
    }

    [Flags]
    public enum StatusByteOneFlag
    {
      WinLock = 1,
      BreathLed = 2,
      FanBoost = 4,
      MacroKey = 8,
      MyBatPowerBat = 16, // 0x00000010
    }

    [Flags]
    public enum BrightnessByteFlag
    {
      Normal_Mode = 0,
      User_Mode = 0,
      User_Level1 = 1,
      User_Level2 = 2,
      User_Level3 = User_Level2 | User_Level1, // 0x00000003
      User_Level4 = 4,
    }

    [Flags]
    public enum RedBarByteFlag
    {
      Normal_Mode = 0,
      User_Mode = 0,
      User_Level1 = 1,
      User_Level2 = 2,
      User_Level3 = User_Level2 | User_Level1, // 0x00000003
      User_Level4 = 4,
      User_Level5 = User_Level4 | User_Level1, // 0x00000005
      User_Level6 = User_Level4 | User_Level2, // 0x00000006
      User_Level7 = User_Level6 | User_Level1, // 0x00000007
      User_Level8 = 8,
      User_Level9 = User_Level8 | User_Level1, // 0x00000009
    }

    [Flags]
    public enum GreenBarByteFlag
    {
      Normal_Mode = 0,
      User_Mode = 0,
      User_Level1 = 1,
      User_Level2 = 2,
      User_Level3 = User_Level2 | User_Level1, // 0x00000003
      User_Level4 = 4,
      User_Level5 = User_Level4 | User_Level1, // 0x00000005
      User_Level6 = User_Level4 | User_Level2, // 0x00000006
      User_Level7 = User_Level6 | User_Level1, // 0x00000007
      User_Level8 = 8,
      User_Level9 = User_Level8 | User_Level1, // 0x00000009
    }

    [Flags]
    public enum ColorByteFlag
    {
      Normal_Mode = 0,
      User_Mode = 0,
      User_Level1 = 1,
      User_Level2 = 2,
      User_Level3 = User_Level2 | User_Level1, // 0x00000003
      User_Level4 = 4,
      User_Level5 = User_Level4 | User_Level1, // 0x00000005
      User_Level6 = User_Level4 | User_Level2, // 0x00000006
      User_Level7 = User_Level6 | User_Level1, // 0x00000007
      User_Level8 = 8,
      User_Level9 = User_Level8 | User_Level1, // 0x00000009
    }

    [Flags]
    public enum BlueBarByteFlag
    {
      Normal_Mode = 0,
      User_Mode = 0,
      User_Level1 = 1,
      User_Level2 = 2,
      User_Level3 = User_Level2 | User_Level1, // 0x00000003
      User_Level4 = 4,
      User_Level5 = User_Level4 | User_Level1, // 0x00000005
      User_Level6 = User_Level4 | User_Level2, // 0x00000006
      User_Level7 = User_Level6 | User_Level1, // 0x00000007
      User_Level8 = 8,
      User_Level9 = User_Level8 | User_Level1, // 0x00000009
    }

    [Flags]
    public enum RGBLightbarControlByteFlag
    {
      AP_Exist = 0,
      PowerSaveMode = 2,
      S0_Switch = 4,
      S3_Switch = 8,
      Welcome = 128, // 0x00000080
    }
  }
}
