using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipCalc.UITest.Shared.Screens;

namespace TipCalc.UITest.Xamarin.Screens
{
    public class TipCalcScreenAndroid : ITipCalcScreen
    {
        public string FriendlyName => "Tip";
        public string SubTotalEntry => "subTotal_EditText";
        public string TipAmount => "tipAmount_TextView";
    }

    public class TipCalcScreenIOS : ITipCalcScreen
    {
        public string FriendlyName => "Tip";
        public string SubTotalEntry => "SubTotalTextField";
        public string TipAmount => "TipLabel";
    }
}
