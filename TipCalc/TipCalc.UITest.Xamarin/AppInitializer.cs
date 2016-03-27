using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using TipCalc.UITest.Shared.Common;
using TipCalc.UITest.Xamarin.Common;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TipCalc.UITest.Xamarin
{
    public class AppInitializer
    {
        /// <summary>
        /// Create an iApp instance for Android or iOS and start the simulator or emulator specified
        /// </summary>
        /// <param name="platform">Android or iOS</param>
        /// <param name="simulatorOrEmulatorName">The string name of the Android Emulator or iOS simulator</param>
        /// <param name="resetDevice">Wether to reset the device before running the test</param>
        /// <returns></returns>
        public static IApp StartApp(Platform platform, string simulatorOrEmulatorName, bool resetDevice)
        {
            if (platform == Platform.Android)
            {
                bool initializing = false;
                if (!InstrumentsRunner.EmulatorIsStarted)
                {
                    Console.WriteLine(
                        "No Android Emulator Running. Starting device: " + simulatorOrEmulatorName);
                    StartEmulator(simulatorOrEmulatorName);
                    initializing = true;
                }

                while (!InstrumentsRunner.EmulatorIsStarted)
                {
                    Thread.Sleep(5000);
                }

                //Wait another 5 seconds
                //since the device may be connected 
                //but not initialized.
                if (initializing)
                    Thread.Sleep(5000);
            }

            if (resetDevice)
            {
                ResetDevice(platform, simulatorOrEmulatorName);
            }

            return ConfiguredDevice(platform, simulatorOrEmulatorName);
        }

        public static IApp RestartApp(Platform platform, string simulatorOrEmulatorName)
        {
            QuitApp(platform, simulatorOrEmulatorName);
            return ConfiguredDevice(platform, simulatorOrEmulatorName);
        }

        public static void QuitApp(Platform platform, string simulatorOrEmulatorName)
        {
            switch (platform)
            {
                case Platform.Android:
                    QuitAndroidApp(simulatorOrEmulatorName);
                    break;
                case Platform.iOS:
                    StopSimulator(simulatorOrEmulatorName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(platform), platform, null);
            }
        }

        public static void ShutDown(Platform platform, string simulatorOrEmulatorName)
        {
            switch (platform)
            {
                case Platform.Android:
                    StopEmulator(simulatorOrEmulatorName);
                    break;
                case Platform.iOS:
                    StopSimulator(simulatorOrEmulatorName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(platform), platform, null);
            }
        }

        public static void ResetDevice(Platform platform, string simulatorOrEmulatorName)
        {
            switch (platform)
            {
                case Platform.Android:
                    ResetEmulator();
                    break;
                case Platform.iOS:
                    ResetSimulator(simulatorOrEmulatorName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(platform), platform, null);
            }
        }

        static IApp ConfiguredDevice(Platform platform, string simulatorOrEmulatorName)
        {
            switch (platform)
            {
                case Platform.Android:
                    return ConfigureApp.Android.ApkFile(Constants.APK_PATH)
                        //.SetDeviceByName(simulatorOrEmulatorName) //todo if running emulators > 1
                        .EnableLocalScreenshots()
                        //.Debug()
                        .StartApp();
                //.StartRecording ();
                case Platform.iOS:
                    return ConfigureApp.iOS.AppBundle(Constants.IPA_PATH).EnableLocalScreenshots()
                        //.Debug()
                        .SetDeviceByName(simulatorOrEmulatorName)
                        //.DeviceIdentifier(simulatorOrEmulatorName)
                        .StartApp();
                default:
                    throw new ArgumentOutOfRangeException(nameof(platform), platform, null);
            }
        }

        static void StartEmulator(string emulatorName)
        {
            Console.WriteLine("Restarting the ADB server...");
            var killProcess = Process.Start(Constants.ANDROID_ADB, "kill-server");
            killProcess?.WaitForExit();

            var startProcess = Process.Start(Constants.ANDROID_ADB, "start-server");
            startProcess?.WaitForExit();

            Console.WriteLine("Starting the Android Emulator: " + emulatorName);

            Process.Start(Constants.GENYMOTION_PLAYER, $"--vm-name \"{emulatorName}\"");
        }

        static void QuitAndroidApp(string simulatorOrEmulatorName)
        {
            var eraseProcess = Process.Start(Constants.ANDROID_ADB, "shell am force-stop " + Constants.APK_PACKAGENAME);
            eraseProcess?.WaitForExit();
        }

        static void StopEmulator(string emulatorName)
        {
            Console.WriteLine("Shutting down the Android Emulator: " + emulatorName);
            var shutdownProcess = Process.Start("osascript", "-e 'quit app \"Genymotion\"'");
            shutdownProcess?.WaitForExit();

            //Process.Start("ps -ax | grep \"'VirtualBox\\|Genymotion'"," | awk '{print $1}' | xargs kill");
        }

        /// <summary>
        /// Resets the emulator by uninstalling the package.
        /// </summary>
        static void ResetEmulator()
        {
            Console.WriteLine("Uninstalling Package from Android Device");
            var eraseProcess = Process.Start(Constants.ANDROID_ADB, "shell pm uninstall " + Constants.APK_PACKAGENAME);
            eraseProcess?.WaitForExit();
        }

        static void StopSimulator(string simulatorName)
        {
            Console.WriteLine("Shutting down the iOS Simulator: " + simulatorName);
            var deviceId = TextExtensions.GetIosDeviceId(simulatorName);

            if (string.IsNullOrEmpty(deviceId))
            {
                throw new ArgumentException($"No simulator found with device name [{simulatorName}]", simulatorName);
            }

            //var shutdownProcess = Process.Start("xcrun", string.Format("simctl shutdown {0}", deviceId));
            //shutdownProcess.WaitForExit();

            Process.Start("osascript", "-e 'quit app \"iOS Simulator\"'");
        }

        static void ResetSimulator(string simulatorName)
        {
            StopSimulator(simulatorName);
            Console.WriteLine("Resetting iOS device to Factory");
            var deviceId = TextExtensions.GetIosDeviceId(simulatorName);
            var eraseProcess = Process.Start("xcrun", $"simctl erase {deviceId}");
            eraseProcess?.WaitForExit();
        }
    }
}

