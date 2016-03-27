using TipCalc.UITest.Shared.Screens;

namespace TipCalc.UITest.Windows.Screens
{
    public class TipCalcScreen : ITipCalcScreen
    {
        public string FriendlyName => "Tip";
        public string SubTotalEntry => "SubTotal_TextBox";
        public string TipAmount => "TipAmount_TextBox";
    }
}
