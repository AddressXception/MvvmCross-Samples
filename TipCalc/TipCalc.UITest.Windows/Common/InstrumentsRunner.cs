using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using TipCalc.UITest.Shared.Common;

namespace TipCalc.UITest.Windows.Common
{
    public static class InstrumentsRunner
    {
        static string[] GetInstalledAppxPackages()
        {
            //Todo: fire the ps1 script to query for the installed appx
            return null;
        }

        // ReSharper disable once InconsistentNaming
        static Emulator[] GetXDEManagedDeviceList()
        {
            var emulators = new List<Emulator>();
            using (var ps = PowerShell.Create())
            {
                ps.AddScript("Get-VM");
                Collection<PSObject> output = ps.Invoke();

                emulators.AddRange(
                    from item in output
                    select item.BaseObject.GetType()
                    into obj
                        let name = obj.GetProperty("Name").GetValue(obj).ToString()
                        let id = obj.GetProperty("Id").GetValue(obj).ToString()
                        let state = obj.GetProperty("State").GetValue(obj).ToString()
                    select new Emulator(name, id, state));
            }

            return emulators.ToArray();
        }

        public static string GetAppxPackage()
        {
            var file = Path.GetFullPath(Constants.APPXFAMILY_PATH);
            if (File.Exists(file))
                return File.ReadAllLines(file).Last();

            Console.WriteLine(
                    "The Installed-AppxFamilyName.txt file was not found.  " +
                    "This file is necessary to determine the installed app's unique name." +
                    "Run your post-build powershell script to deploy the app & resolve its family name.");

            return GetInstalledAppxPackages()?[0];
        }

        public static bool EmulatorIsStarted => GetListOfRunningEmulators().Any();

        private static Emulator[] GetListOfRunningEmulators()
        {
            return GetListOfEmulators()
                .Where(e => e.State == EmulatorStates.Running.ToString())
                .ToArray();
        }

        public static Emulator[] GetListOfEmulators()
        {
            //emulators from XDE
            return GetXDEManagedDeviceList();
        }
    }
}
