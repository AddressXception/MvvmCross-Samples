using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TipCalc.UITest.Shared;
using TipCalc.UITest.Shared.Common;
using TipCalc.UITest.Windows.Common;
using Xamarin.UITest;

namespace TipCalc.UITest.Windows
{
    [TestClass]
    public abstract class WindowsFeatureBase : FeatureBase
    {
        protected static string AppId;
        protected static string Device;
        protected static bool ResetDevice;

        /// <summary>
        /// static constructor acts as [ClassInitialize]
        /// </summary>
        static WindowsFeatureBase()
        {
            Device = Local.Machine;
            AppId = Constants.WIN_APPID;
            ResetDevice = true;
        }

        protected override void CreateApp(bool reset = true)
        {
            IApp value;
            if (FeatureContext.Current.TryGetValue(ScreenNames.App, out value))
            {
                Console.WriteLine(
                    "The IApp context was not properly cleared " +
                    "or the FeatureContext was not disposed.  " +
                    "Removing IApp from current Context");
                value = null;
                FeatureContext.Current.Remove(ScreenNames.App);
            }

            App = AppInitializer
                .StartApp(AppId, Device, ResetDevice);
            FeatureContext.Current.Add(ScreenNames.App, App);
        }

        protected override void RegisterScreens()
        {
            //todo
        }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Debug.WriteLine("WindowsFeatureBase BeforeEachTest() Called");
            RegisterScreens();
            CreateApp();
        }

        [TestCleanup]
        public void AfterEachTest()
        {
            Debug.WriteLine("WindowsFeatureBase AfterEachTest() Called");
            AppInitializer.ShutDown(Device);
        }

        [ClassCleanup]
        public void TearDown()
        {
            Debug.WriteLine("WindowsFeatureBase TearDown() Called");
            AppInitializer.ShutDown(Device);
        }
    }
}
