using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace TipCalc.UITest.Shared.Common
{
    public abstract class StepsBase
    {
        protected IApp App => FeatureContext.Current.Get<IApp>(ScreenNames.App);

        public StepsBase()
        {

        }

        protected abstract void GetScreens();

        /// <summary>
        /// automation logic that has to run before 
        /// executing each scenario or scenario outline example
        /// </summary>
        [BeforeScenario()]
        public virtual void BeforeEachScenario()
        {
            Console.WriteLine("BeforeEachScenarioCalled");
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
            Console.WriteLine("BeforeEachScenarioBlockCalled");
        }

        /// <summary>
        /// automation logic that has to run before
        /// executing each scenario step
        /// </summary>
        [BeforeStep()]
        public virtual void BeforeEachStep()
        {
            Console.WriteLine("BeforeEachStepCalled");
        }

        /// <summary>
        /// automation logic that has to run after
        /// executing each scenario step
        /// </summary>
        [AfterStep()]
        public virtual void AfterEachStep()
        {
            Console.WriteLine("AfterEachStepCalled");
        }

        /// <summary>
        /// automation logic that has to run after
        /// executing each scenario block 
        /// (e.g. between the "givens" and the "whens")
        /// </summary>
        [AfterScenarioBlock()]
        public virtual void AfterEachScenarioBlock()
        {
            Console.WriteLine("AfterEachScenarioBlockCalled");
        }

        /// <summary>
        /// automation logic that has to run after 
        /// executing each scenario or scenario outline example
        /// </summary>
        [AfterScenario()]
        public virtual void AfterEachScenario()
        {
            Console.WriteLine("AfterEachScenarioCalled");
        }
    }
}
