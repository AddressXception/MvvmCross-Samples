using System;
using TechTalk.SpecFlow;
using TipCalc.UITest.Shared.Common;

namespace TipCalc.UITest.Shared.Screens
{
    [Binding]
    public class TipCalcScreenSteps : StepsBase
    {
        private ITipCalcScreen _tipCalcScreen;

        protected override void GetScreens()
        {
            _tipCalcScreen = FeatureContext
                .Current
                .Get<ITipCalcScreen>(ScreenNames.TipCalc);
        }

        [Given(@"I have selected the SubTotal field")]
        public void GivenIHaveSelectedTheSubTotalField()
        {
            App.Tap(_tipCalcScreen.SubTotalEntry);
        }
        
        [When(@"I enter (.*) into the SubTotal field")]
        public void WhenIEnterIntoTheSubTotalField(int p0)
        {
            App.EnterText(_tipCalcScreen.SubTotalEntry, p0.ToString());
        }
        
        [Then(@"the Tip Amount should be (.*) on the screen")]
        public void ThenTheTipAmountShouldBeOnTheScreen(int p0)
        {
            var result = App.Query(_tipCalcScreen.TipAmount)[0].Text;
            Assert.IsTrue(p0.ToString() == result, 
                $"the result {result} does not match the test value {p0}");
        }
    }
}
