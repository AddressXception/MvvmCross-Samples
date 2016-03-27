using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using TipCalc.UITest.Shared.Common;
using Xamarin.UITest.Queries;

namespace TipCalc.UITest.Windows.Common
{
    public static class TestExtensions
    {
        public static WindowsApp GetAppxPackage(this WindowsApp self, string appId)
        {
            var installedApp = InstrumentsRunner.GetAppxPackage();
            if (string.IsNullOrEmpty(installedApp) || !installedApp.Contains(Constants.WIN_APPID))
            {
                Console.WriteLine(
                    "The AppId specified in Constants does not match the installed app value. " +
                    "Trying to launch app specified in constants");
                self.AppId = appId;
            }
            else
            {
                self.AppId = installedApp;
            }

            Console.WriteLine("Launching App " + self.AppId);
            return self;
        }

        public static WindowsApp InitializePlayback(this WindowsApp self)
        {
            try
            {
                Playback.Initialize();
            }
            catch (UITestException ex)
            {   //If playback is already initialized for the test, 
                //Playback throws an exception.
                Debug.WriteLine(ex);
            }

            return self;
        }

        public static XamlWindow XamlWindow(this UIMapBase self)
        {
            var propertyInfo = self.GetType().GetProperty(self.XamlRoot);
            var windowInstance = propertyInfo?.GetValue(self);
            return windowInstance as XamlWindow;
        }

        /// <summary>
        /// Recursively search the xaml tree for the control.
        /// </summary>
        public static UITestControl FindControl(this UITestControl ui, string controlName)
        {
            try
            {
                if (!ui.Exists) return null;

                UITestControl foundControl = null;

                var children = ui.GetChildren();
                foreach (var child in children)
                {
                    var control = child as XamlControl;
                    if (control == null) continue;

                    var automationId = control.AutomationId;

                    if (automationId.Equals(controlName))
                    {
                        foundControl = control;
                        break;
                    }

                    foundControl = control.FindControl(controlName);
                    if (foundControl != null)
                    {
                        break;
                    }
                }

                return foundControl;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static UITestControl FindControl(this Dictionary<Type, UIMapBase> dictionary, Func<string> function)
        {
            UITestControl control = null;
            string target = function.Invoke();
            List<KeyValuePair<Type, UIMapBase>> activeScreens = dictionary.ToList();

            activeScreens.ForEach(screen =>
            {
                if (control == null)
                    control = screen.Value.XamlWindow().FindControl(target);
            });

            return control;
        }

        public static AppRect ToAppRect(this Rectangle self)
        {
            return new AppRect()
            {
                Width = self.Width,
                Height = self.Height,
                X = self.X,
                Y = self.Y,
                CenterX = self.X + self.Width / 2,
                CenterY = self.Y + self.Height / 2
            };
        }
    }
}
