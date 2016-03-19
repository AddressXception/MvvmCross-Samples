using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace TipCalc.UITest.Shared
{
    public abstract class FeatureBase
    {
        protected IApp App;

        protected FeatureBase()
        {

        }

        protected abstract void CreateApp(bool reset = true);

        protected abstract void RegisterScreens();

        //The SpecFlow's Aspects are called as follows:
        // BeforeTestRun -> BeforeFeature -> BeforeScenario -> BeforeScenarioBlock -> BeforeStep
        // AfterStep <- AfterScenarioBlock <- AfterScenario <- AfterFeature <- AfterTestRun

        /// <summary>
        /// automation logic that has to run before
        /// the entire test run
        /// </summary>
        [BeforeTestRun()]
        public static void BeforeTestRun()
        {
            Console.WriteLine("BeforeTestRun_Called");
        }

        /// <summary>
        /// automation logic that has to run before
        /// executing each feature
        /// </summary>
        [BeforeFeature()]
        public static void BeforeFeature()
        {
            Console.WriteLine("BeforeFeature_Called");
        }

        /// <summary>
        /// automation logic that has to run after 
        /// executing each feature
        /// </summary>
        [AfterFeature()]
        public static void AfterFeature()
        {
            Console.WriteLine ("AfterFeature_Called");
        }

        /// <summary>
        /// automation logic that has to run after 
        /// the entire test run
        /// </summary>
        [AfterTestRun()]
        public static void AfterTestRun()
        {
            Console.WriteLine ("AfterTestRun_Called");
        }
    }
}
