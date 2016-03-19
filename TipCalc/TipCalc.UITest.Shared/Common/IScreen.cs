using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipCalc.UITest.Shared.Common
{
    public interface IScreen
    {
        /// <summary>
        /// The friendly name is used to identify the screen in Gherkin tests
        /// </summary>
        string FriendlyName { get; }
    }
}
