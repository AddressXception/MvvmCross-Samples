using System;
using TechTalk.SpecFlow;
using TipCalc.UITest.Shared.Common;
using Xamarin.UITest;

namespace TipCalc.UITest.Shared
{
    public abstract class StepsBase
    {
        protected IApp App => FeatureContext.Current.Get<IApp>(ScreenNames.App);

        protected StepsBase()
        {

        }

        /// <summary>
        /// Define the screens that will be used for running this set of tests.
        /// </summary>
        protected abstract void GetScreens();

        /// <summary>
        /// automation logic that has to run before 
        /// executing each scenario or scenario outline example
        /// </summary>
        [BeforeScenario()]
        public virtual void BeforeEachScenario()
        {
            Console.WriteLine("BeforeEachScenario_Called");
            this.GetScreens();
        }

        /// <summary>
        /// automation logic that has to run before
        /// executing each scenario block 
        /// (e.g. between the "givens" and the "whens")
        /// </summary>
        [BeforeScenarioBlock()]
        public virtual void BeforeEachScenarioBlock()
        {
            //Console.WriteLine("BeforeEachScenarioBlockCalled");
        }

        /// <summary>
        /// automation logic that has to run before
        /// executing each scenario step
        /// </summary>
        [BeforeStep()]
        public virtual void BeforeEachStep()
        {
            Console.WriteLine("BeforeEachStep_Called");
        }

        /// <summary>
        /// automation logic that has to run after
        /// executing each scenario step
        /// </summary>
        [AfterStep()]
        public virtual void AfterEachStep()
        {
            Console.WriteLine("AfterEachStep_Called");
        }

        /// <summary>
        /// automation logic that has to run after
        /// executing each scenario block 
        /// (e.g. between the "givens" and the "whens")
        /// </summary>
        [AfterScenarioBlock()]
        public virtual void AfterEachScenarioBlock()
        {
            Console.WriteLine("AfterEachScenarioBlock_Called");
        }

        /// <summary>
        /// automation logic that has to run after 
        /// executing each scenario or scenario outline example
        /// </summary>
        [AfterScenario()]
        public virtual void AfterEachScenario()
        {
            Console.WriteLine("AfterEachScenario_Called");
        }
    }
}
