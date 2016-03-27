using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Configuration;

namespace TipCalc.UITest.Xamarin.Common
{
    public static class TextExtensions
    {
        //https://forums.xamarin.com/discussion/comment/89870/#Comment_89870
        public static iOSAppConfigurator SetDeviceByName(this iOSAppConfigurator configurator, string simulatorName)
        {
            var deviceId = GetIosDeviceId(simulatorName);
            return configurator.DeviceIdentifier(deviceId);
        }

        public static AndroidAppConfigurator SetDeviceByName(this AndroidAppConfigurator configurator,
            string simulatorName)
        {
            var deviceId = GetAndroidDeviceId(simulatorName);
            return configurator.DeviceSerial(deviceId);
        }

        public static AndroidApp StartRecording(this AndroidApp app)
        {
            //todo start recording adb shell 
            //todo: adb shell screenrecord /sdcard/recording ADB_RECORD_FILE
            return app;
        }

        public static void StopRecording(this AndroidApp app, string filePath)
        {
            //todo: ^C the adb recording process
            //todo: adb pull ADB_RECORD_FILE filePath
        }

        public static string GetIosDeviceId(string simulatorName)
        {
            if (!TestEnvironment.Platform.Equals(TestPlatform.Local))
            {
                return string.Empty;
            }

            // See below for the InstrumentsRunner class.
            IEnumerable<Simulator> simulators = InstrumentsRunner.GetListOfSimulators();

            var simulator = (from sim in simulators
                             where sim.Name.Equals(simulatorName)
                             select sim).FirstOrDefault();

            if (simulator == null)
            {
                throw new ArgumentException("Could not find a device identifier for '" + simulatorName + "'.",
                    simulatorName);
            }

            return simulator.GUID;
        }

        public static string GetAndroidDeviceId(string emulatorName)
        {
            if (!TestEnvironment.Platform.Equals(TestPlatform.Local))
            {
                return string.Empty;
            }

            var emulators = InstrumentsRunner.GetListOfRunningEmulators().ToList();

            var emulator =
                emulators.FirstOrDefault(emu => emu.Name.Contains(emulatorName));

            if (emulator == null)
            {
                throw new ArgumentException("Could not find a device identifier for '" + emulatorName + "'.",
                    emulatorName);
            }

            return InstrumentsRunner.GetDeviceSerial(emulator);
        }
    }
}
