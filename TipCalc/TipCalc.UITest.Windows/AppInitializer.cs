using System;
using System.Diagnostics;
using System.Threading;
using TipCalc.UITest.Shared.Common;
using TipCalc.UITest.Windows.Common;
using Xamarin.UITest;

namespace TipCalc.UITest.Windows
{
    public class AppInitializer
    {
        private static WindowsApp _app;

        public static IApp StartApp(string appId)
        {
            return _app = new WindowsApp()
                .GetAppxPackage(appId)
                .InitializePlayback()
                .StartApp() as WindowsApp;
        }

        public static IApp StartApp(string appId, string deviceId, bool resetDevice)
        {
            if (deviceId.IndexOf("Emulator", StringComparison.Ordinal) > -1)
            {
                var initializing = false;
                if (!InstrumentsRunner.EmulatorIsStarted)
                {
                    Console.WriteLine(
                        "No Windows Emulator Running. Starting device: " + deviceId);

                    StartEmulator(deviceId);
                    initializing = true;
                }

                while (!InstrumentsRunner.EmulatorIsStarted)
                {
                    //just a placeholder.
                    Thread.Sleep(5000);
                }

                //Wait another 1 seconds
                //since the device may be connected 
                //but not initialized.
                if (initializing)
                    Thread.Sleep(1000);
            }

            if (resetDevice)
            {
                ResetEmulator();
            }

            return _app = new WindowsApp()
                .GetAppxPackage(appId)
                .InitializePlayback()
                .StartApp() as WindowsApp;
        }

        public static void ShutDown(string deviceId)
        {
            Console.WriteLine("Shutting down the Windows Emulator");

            _app.Close();

            if (deviceId.IndexOf("Emulator", StringComparison.Ordinal) <= -1) return;

            //http://www.altaro.com/hyper-v/10-awesome-hyper-v-cmdlets/
            var shutdownProcess = Process.Start("stop-vm",
                $"-force \"{deviceId}\"");

            shutdownProcess?.WaitForExit();
        }

        static void StartEmulator(string deviceId)
        {
            Console.WriteLine("Starting the windows Emulator: " + deviceId);
            Process.Start(Constants.WINDOWS_EMULATOR,
                $"-name \"{deviceId}\"");
        }

        static void ResetEmulator()
        {
            Console.WriteLine("Resetting the windows Emulator");

            //todo reset emulator

            //todo deploy new package

        }
    }
}
