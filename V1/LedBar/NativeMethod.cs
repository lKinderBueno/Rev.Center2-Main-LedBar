// Decompiled with JetBrains decompiler
// Type: MyLightBar2.NativeMethod
// Assembly: MyLightBar, Version=1.5.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EBEC481-DFDA-4AA7-A830-678DCDECD21C
// Assembly location: E:\Users\elio1\OneDrive\Desktop\MyAPP 1.6.1.0\OEM\MyAPP\MyLightBar\MyLightBar.exe

using System;
using System.Runtime.InteropServices;

namespace Rev.Center2
{
  internal static class NativeMethod
  {
    public const int WH_MOUSE_LL = 14;
    public const int WH_KEYBOARD_LL = 13;

   /* [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    public static extern int SetWindowsHookEx(
      int idHook,
      NativeMethod.HookProc lpfn,
      IntPtr hMod,
      int dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    public static extern int UnhookWindowsHookEx(int idHook);*/

    public delegate int HookProc(int nCode, int wParam, IntPtr lParam);
  }
}
