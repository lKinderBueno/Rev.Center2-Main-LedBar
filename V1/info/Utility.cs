// Decompiled with JetBrains decompiler
// Type: V1.Utility
// Assembly: MyLightBar, Version=1.5.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 0EBEC481-DFDA-4AA7-A830-678DCDECD21C
// Assembly location: E:\Users\elio1\OneDrive\Desktop\MyAPP 1.6.1.0\OEM\MyAPP\MyLightBar\MyLightBar.exe

using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace V1
{
  public static class Utility
  {
    private static bool b_LogEnable = true;

    public static object RegistrySoftwareKeyRead(
      RegistryHive hKey,
      string SubKey,
      string Name,
      object defaultvalue)
    {
      if (Environment.Is64BitOperatingSystem)
        return RegistryKey.OpenBaseKey(hKey, RegistryView.Registry64).OpenSubKey("SOFTWARE\\WOW6432Node" + SubKey).GetValue(Name, defaultvalue);
      return RegistryKey.OpenBaseKey(hKey, RegistryView.Registry32).OpenSubKey("SOFTWARE" + SubKey).GetValue(Name, defaultvalue);
    }

    public static void RegistrySoftwareKeyWrite(
      RegistryHive hKey,
      string SubKey,
      string Name,
      object setvalue,
      RegistryValueKind valuekind)
    {
      if (Environment.Is64BitOperatingSystem)
        RegistryKey.OpenBaseKey(hKey, RegistryView.Registry64).CreateSubKey("SOFTWARE\\WOW6432Node" + SubKey).SetValue(Name, setvalue, valuekind);
      else
        RegistryKey.OpenBaseKey(hKey, RegistryView.Registry32).CreateSubKey("SOFTWARE" + SubKey).SetValue(Name, setvalue, valuekind);
    }

    public static object RegistryKeyRead(
      RegistryHive hKey,
      string SubKey,
      string Name,
      object defaultvalue)
    {
      if (Environment.Is64BitProcess)
        return RegistryKey.OpenBaseKey(hKey, RegistryView.Registry64).OpenSubKey(SubKey).GetValue(Name, defaultvalue);
      return RegistryKey.OpenBaseKey(hKey, RegistryView.Registry32).OpenSubKey(SubKey).GetValue(Name, defaultvalue);
    }

    public static void RegistryKeyWrite(
      RegistryHive hKey,
      string SubKey,
      string Name,
      object setvalue,
      RegistryValueKind valuekind)
    {
      if (Environment.Is64BitProcess)
        RegistryKey.OpenBaseKey(hKey, RegistryView.Registry64).CreateSubKey(SubKey).SetValue(Name, setvalue, valuekind);
      else
        RegistryKey.OpenBaseKey(hKey, RegistryView.Registry32).CreateSubKey(SubKey).SetValue(Name, setvalue, valuekind);
    }

    public static void CheckProcessExistAndCreate(string processeName, string path)
    {
      bool flag = false;
      try
      {
        foreach (Process process in Process.GetProcessesByName(processeName))
          flag = true;
      }
      catch
      {
      }
      if (flag)
        return;
      try
      {
        Process.Start(new ProcessStartInfo()
        {
          FileName = processeName,
          WorkingDirectory = path,
          UseShellExecute = true,
          CreateNoWindow = false,
          RedirectStandardInput = false,
          RedirectStandardOutput = false
        });
        Thread.Sleep(1000);
      }
      catch
      {
        Console.WriteLine("CheckProcessExistAndCreate failed");
      }
    }

    public static void EnableLog()
    {
      try
      {
        Utility.b_LogEnable = (int) Utility.RegistryKeyRead(RegistryHive.LocalMachine, "SOFTWARE\\OEM\\MyColor2\\Debug", "enable", (object) 0) > 0;
      }
      catch
      {
        Utility.b_LogEnable = false;
        return;
      }
      try
      {
        if ((int) Utility.RegistryKeyRead(RegistryHive.LocalMachine, "SOFTWARE\\OEM\\MyColor2\\Debug", "create", (object) 0) <= 0)
          return;
        File.Delete("C:\\MyColor2.log");
      }
      catch
      {
      }
    }

    public static void DisableLog()
    {
      Utility.b_LogEnable = false;
    }

    public static void Log(string logMessage)
    {
      if (Utility.b_LogEnable)
      {
        using (StreamWriter streamWriter = File.AppendText("C:\\MyLightBar.log"))
          streamWriter.WriteLine("{0}", (object) logMessage);
      }
      else
        Console.WriteLine(logMessage);
    }
  }
}
