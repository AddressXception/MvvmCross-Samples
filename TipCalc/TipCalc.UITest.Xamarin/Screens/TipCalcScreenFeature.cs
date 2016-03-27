using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest;

namespace TipCalc.UITest.Xamarin.TipCalc_UITest_Shared.Screens
{
    public partial class TipCalcScreenFeature : XamarinFeatureBase
    {
        public TipCalcScreenFeature(Platform platform, string iOSSimulator) 
            : base(platform, iOSSimulator)
        {

        }

        [TestFixtureSetUp()]
        public override void FeatureSetupImplementation()
        {
            this.FeatureSetup();
            base.FeatureSetupImplementation();
        }
    }
}
