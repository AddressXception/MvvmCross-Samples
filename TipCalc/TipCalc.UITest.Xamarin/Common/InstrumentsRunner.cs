using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipCalc.UITest.Shared.Common;

namespace TipCalc.UITest.Xamarin.Common
{
    /// <summary>
    /// Based on: https://github.com/RobGibbens/BddWithXamarinUITest/blob/master/InstrumentsRunner.cs
    /// </summary>
    public class InstrumentsRunner
    {
        static string[] GetIosInstrumentsOutput()
        {
            const string cmd = "/usr/bin/xcrun";

            var startInfo = new ProcessStartInfo
            {
                FileName = cmd,
                Arguments = "instruments -s devices",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                StandardOutputEncoding = Encoding.UTF8
            };

            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();
            var result = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();

            var lines = result.Split('\n');
            return lines;
        }

        static string[] GetADBConnectedDevicesOutput()
        {
            var cmd = Constants.ANDROID_ADB;

            var startInfo = new ProcessStartInfo
            {
                FileName = cmd,
                Arguments = "devices",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                StandardOutputEncoding = Encoding.UTF8
            };

            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();
            var result = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();

            var devices = result.Split('\n')
                .Where(line => line.Contains(":")).ToArray();

            Console.WriteLine(
                "Getting Android devices connected to ADB.  Device Count: "
                + devices.Count());
            return devices;
        }

        static string[] GetVboxManagedDeviceList()
        {
            const string cmd = Constants.VBOXMANAGE;

            var aguments = "list vms";

            var startInfo = new ProcessStartInfo
            {
                FileName = cmd,
                Arguments = aguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = false,
                StandardOutputEncoding = Encoding.UTF8
            };

            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();
            var result = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();

            return result.Split('\n');
        }

        public static bool EmulatorIsStarted => GetADBConnectedDevicesOutput().Any();

        public static string[] GetVboxManageRunningDeviceListOutput()
        {
            const string cmd = Constants.VBOXMANAGE;

            var startInfo = new ProcessStartInfo(cmd, "list runningvms");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;

            Process proc = new Process();
            proc.StartInfo = startInfo;
            proc.Start();
            var result = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();

            return result.Split('\n');
        }

        public static Simulator[] GetListOfSimulators()
        {
            var lines = GetIosInstrumentsOutput();

            var simulators = lines?.Select(line => new Simulator(line)).Where(sim => sim.IsValid()).ToArray();

            var names = simulators?
            .Select(x => x.Name)
            .Aggregate((current, next) => current + System.Environment.NewLine + next);
            Console.WriteLine ("iOS Simulators found: " + names);

            return simulators;
        }

        public static Emulator[] GetListOfEmulators()
        {
            //emulators from genymotion
            var lines = GetVboxManagedDeviceList();

            return lines?
                .Select(line => new Emulator(line))
                .Where(emu => emu.IsValid()).ToArray();

        }

        public static Emulator[] GetListOfRunningEmulators()
        {
            //emulators from genymotion
            var lines = GetVboxManageRunningDeviceListOutput();

            var emulators = lines?
                .Select(line => new Emulator(line))
                .Where(emu => emu.IsValid()).ToArray();

            //todo: multi emulator support
            //if (emulators.Count > 1)
            //  throw new Exception ("There is more than one emulator running, and that isn't supported yet");

            return emulators;
        }

        public static string GetDeviceSerial(Emulator emulator)
        {
            //todo: multi emulator support
            //          var devices = GetGenymotionDeviceListOutput(); // from shell call?
            //          var deviceLine = devices.FirstOrDefault(line => line.Contains(emulator.Name));
            //          var ipAddress = string.Empty;
            //			if (deviceLine == null)
            //				string.Format ("The device {0} does not exist in the list of available devices. Using the first device.", emulator.Name);
            //			else 
            //          {
            //				var startIndex = deviceLine.IndexOf ("192.168");
            //				var endIndex = deviceLine.IndexOf ("|", startIndex);
            //				ipAddress = deviceLine.Substring (startIndex, endIndex - 2);
            //			}

            //devices connected
            var lines = GetADBConnectedDevicesOutput();

            //todo: var connectedIp = lines.FirstOrDefault (line => line.Contains (ipAddress));
            var connectedIp = lines.First();
            Console.WriteLine(connectedIp);
            var sub = connectedIp.Substring(0, connectedIp.IndexOf("d", StringComparison.Ordinal) - 1);
            Console.WriteLine(sub);
            return sub;
        }
    }
}
