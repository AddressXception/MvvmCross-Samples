﻿using System;

namespace TipCalc.UITest.Shared.Common
{
    public static class Constants
    {
        //You can use this on the command line to run the tests manually
        //mono ~/{PROJECT_PATH}/packages/NUnit-Bin/bin/nunit-console.exe ~/PROJECT_PATH/TipCalc.UITest.Xamarin/bin/Debug/TipCalc.UITest.Xamarin.dll

        private const string _adb = "/Library/Developer/Xamarin/android-sdk-macosx/platform-tools/adb";
        public static string ANDROID_ADB => Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + _adb;

        public const string APK_PACKAGENAME = "TipCalc.UI.Droid.TipCalc.UI.Droid";
        public const string APK_PATH = "../../../TipCalc.UI.Droid/bin/Debug/" + APK_PACKAGENAME + ".apk";

        public const string ANDROID_EMULATOR = "/Applications/Genymotion.app/Contents/MacOS/player";
        public const string GENYMOTION_PLAYER = "/Applications/Genymotion.app/Contents/MacOS/player";
        public const string GENYMOTION_SHELL = "/Applications/Genymotion Shell.app/Contents/MacOS/genyshell.command";
        public const string VBOXMANAGE = "/Applications/VirtualBox.app/Contents/MacOS/VBoxManage-x86";
        public const string ADB_RECORD_FILE = "/sdcard/UITestRecording.mp4";

        public const string IPA_PACKAGENAME = "com.mvvmcross.tipcalc-ui-ios";
        public const string IPA_PATH = "../../../TipCalc.UI.iOS/bin/iPhoneSimulator/Debug/" + IPA_PACKAGENAME + ".app";

        //you have to update this value with the value from your local system or you will get initialization/playback errors.
        public const string WIN_APPID = "b47d129b-b06b-47c6-b3ff-199f62cb3f12_scyf5npe3hv32!App";

        public const string WINDOWS_EMULATOR = "C:\\\"Program Files (x86)\"\\\"Microsoft XDE\"\\10.0.1.0";
        public const string APPXFAMILY_PATH = @"..\..\..\Installed-AppxFamilyName.txt";

    }
}
