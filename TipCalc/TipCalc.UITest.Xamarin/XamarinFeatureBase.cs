using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TipCalc.UITest.Shared;
using TipCalc.UITest.Shared.Common;
using TipCalc.UITest.Shared.Screens;
using TipCalc.UITest.Xamarin.Common;
using TipCalc.UITest.Xamarin.Screens;
using Xamarin.UITest;

namespace TipCalc.UITest.Xamarin
{
    [TestFixture(Platform.Android, Nexus5.API_21)]
    [TestFixture(Platform.iOS, iPhone6s.OS_9_2)]
    public abstract class XamarinFeatureBase : FeatureBase
    {
        protected static IApp app;
        protected Platform platform;
        protected string emulatorSimulatorName;
        protected bool resetDevice;

        public XamarinFeatureBase(Platform platform, string iOSSimulator)
        {
            this.emulatorSimulatorName = iOSSimulator;
            this.platform = platform;
        }

        protected override void RegisterScreens()
        {
            try
            {
                FeatureContext.Current.Get<ITipCalcScreen>(ScreenNames.TipCalc);
                Console.WriteLine("Screens are already registered, skipping registration");
                return;
            }
            catch (KeyNotFoundException)
            {
                //Keys don't exist so continue
            }

            switch (platform)
            {
                case Platform.iOS:
                    FeatureContext.Current.Add(ScreenNames.TipCalc, new TipCalcScreenIOS());
                    break;
                case Platform.Android:
                    FeatureContext.Current.Add(ScreenNames.TipCalc, new TipCalcScreenAndroid());
                    break;
            }
        }

        [TestFixtureSetUp()]
        public virtual void FeatureSetupImplementation()
        {
            Console.WriteLine("FeatureSetupImplementation Running Feature Tests");
            CreateApp();
            FeatureContext.Current.Add("platform", platform);
            FeatureContext.Current.Add("emulatorSimulatorName", emulatorSimulatorName);
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

            app = AppInitializer.StartApp(platform, emulatorSimulatorName, reset);
            FeatureContext.Current.Add(ScreenNames.App, app);
        }

        [SetUp]
        public void SetUp()
        {
            if (app == null)
            {
                CreateApp(reset: false);
            }
            Console.WriteLine("SetUp NUnit Registering Screens");
            RegisterScreens();
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown NUnit quitting App for next test...");
            AppInitializer.QuitApp(platform, emulatorSimulatorName);
            app = null;
        }

        [TestFixtureTearDown]
        public virtual void FeatureTearDownImplementation()
        {
            Console.WriteLine("FeatureTearDownImplementation Shutting Down the Simulator/Emulator");
            AppInitializer.ShutDown(platform, emulatorSimulatorName);
            FeatureContext.Current.Clear();
        }

        [BeforeTestRun()]
        public new static void BeforeTestRun()
        {
            Console.WriteLine("BeforeTestRun");
        }

        [AfterTestRun()]
        public new static void AfterTestRun()
        {
            Console.WriteLine("AfterTestRun");
        }
    }
}
