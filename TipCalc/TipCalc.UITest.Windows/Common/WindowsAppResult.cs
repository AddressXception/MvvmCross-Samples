using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Xamarin.UITest.Queries;

namespace TipCalc.UITest.Windows.Common
{
   public  class WindowsAppResult : AppResult
    {
        public WindowsAppResult(UITestControl testControl)
        {
            var xaml = testControl as XamlControl;
            if (xaml == null) return;

            Id = xaml.AutomationId;

            try
            {
                Text = testControl.Name;
                Description = testControl.ControlType.Name;
                Enabled = testControl.Enabled;
                Class = testControl.ClassName;
                Label = testControl.FriendlyName;
                Rect = testControl.BoundingRectangle.ToAppRect();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error setting WindowsAppResult from UITestControl: " + ex.Message);
            }
        }
    }
}
