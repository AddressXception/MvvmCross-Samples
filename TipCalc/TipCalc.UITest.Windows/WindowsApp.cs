using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using TipCalc.UITest.Windows.Common;
using TipCalc.UITest.Windows.Screens.TipCalcViewUIMapClasses;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TipCalc.UITest.Windows
{
    /// <summary>
    /// Windows implementation of Xamarin's IApp interface based on the following gesture examples:
    /// http://blogs.msdn.com/b/visualstudioalm/archive/2013/08/17/coded-ui-test-gesture-support-in-visual-studio-2013.aspx
    /// </summary>
    public class WindowsApp : IApp, IDisposable
    {
        private XamlWindow _window;
        private Rectangle _windowBounds;

        private readonly Dictionary<Type, UIMapBase> _screenDictionary;

        public string AppId { get; set; }

        public WindowsApp()
        {
            _screenDictionary = new Dictionary<Type, UIMapBase>()
            {
                { typeof(TipCalcViewUIMap), new TipCalcViewUIMap() },
            };
        }

        internal IApp StartApp()
        {
            try
            {
                _window = XamlWindow.Launch(AppId);
                return this;
            }
            catch (UITestControlNotFoundException)
            {
                Console.WriteLine(
                    "The Test Framework could not get a handle on the application. " +
                    "Try re-running the tests.");
                throw;
            }
        }

        public void Close()
        {
            Keyboard.SendKeys(_window, "{F4}", ModifierKeys.Alt);
            Dispose();
        }

        public AppResult[] Query(Func<AppQuery, AppQuery> query = null)
        {
            throw new NotImplementedException();
        }

        public AppResult[] Query(string marked)
        {
            try
            {
                var control = _screenDictionary
                    .FindControl(_window.AutomationId, () => marked);
                return new AppResult[]
                {
                    new WindowsAppResult(control)
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public AppWebResult[] Query(Func<AppQuery, AppWebQuery> query)
        {
            throw new NotImplementedException();
        }

        public T[] Query<T>(Func<AppQuery, AppTypedSelector<T>> query)
        {
            throw new NotImplementedException();
        }

        public string[] Query(Func<AppQuery, InvokeJSAppQuery> query)
        {
            throw new NotImplementedException();
        }

        public AppResult[] Flash(Func<AppQuery, AppQuery> query = null)
        {
            throw new NotImplementedException();
        }

        public AppResult[] Flash(string marked)
        {
            throw new NotImplementedException();
        }

        public void EnterText(string text)
        {
            throw new NotImplementedException();
        }

        public void EnterText(Func<AppQuery, AppQuery> query, string text)
        {
            throw new NotImplementedException();
        }

        public void EnterText(string marked, string text)
        {
            var control = _screenDictionary
                .FindControl(_window.FriendlyName, () => marked);
            Keyboard.SendKeys(control, text);
        }

        public void EnterText(Func<AppQuery, AppWebQuery> query, string text)
        {
            throw new NotImplementedException();
        }

        public void ClearText(Func<AppQuery, AppQuery> query)
        {
            throw new NotImplementedException();
        }

        public void ClearText(string marked)
        {
            throw new NotImplementedException();
        }

        public void ClearText()
        {
            throw new NotImplementedException();
        }

        public void PressEnter()
        {
            throw new NotImplementedException();
        }

        public void DismissKeyboard()
        {
            throw new NotImplementedException();
        }

        public void Tap(Func<AppQuery, AppQuery> query)
        {
            throw new NotImplementedException();
        }

        public void Tap(string marked)
        {
            throw new NotImplementedException();
        }

        public void Tap(Func<AppQuery, AppWebQuery> query)
        {
            throw new NotImplementedException();
        }

        public void TapCoordinates(float x, float y)
        {
            throw new NotImplementedException();
        }

        public void TouchAndHold(Func<AppQuery, AppQuery> query)
        {
            throw new NotImplementedException();
        }

        public void TouchAndHold(string marked)
        {
            throw new NotImplementedException();
        }

        public void TouchAndHoldCoordinates(float x, float y)
        {
            throw new NotImplementedException();
        }

        public void DoubleTap(Func<AppQuery, AppQuery> query)
        {
            throw new NotImplementedException();
        }

        public void DoubleTap(string marked)
        {
            throw new NotImplementedException();
        }

        public void DoubleTapCoordinates(float x, float y)
        {
            throw new NotImplementedException();
        }

        public void PinchToZoomIn(Func<AppQuery, AppQuery> query, TimeSpan? duration = null)
        {
            throw new NotImplementedException();
        }

        public void PinchToZoomIn(string marked, TimeSpan? duration = null)
        {
            throw new NotImplementedException();
        }

        public void PinchToZoomInCoordinates(float x, float y, TimeSpan? duration)
        {
            throw new NotImplementedException();
        }

        public void PinchToZoomOut(Func<AppQuery, AppQuery> query, TimeSpan? duration = null)
        {
            throw new NotImplementedException();
        }

        public void PinchToZoomOut(string marked, TimeSpan? duration = null)
        {
            throw new NotImplementedException();
        }

        public void PinchToZoomOutCoordinates(float x, float y, TimeSpan? duration)
        {
            throw new NotImplementedException();
        }

        public void WaitFor(Func<bool> predicate, string timeoutMessage = "Timed out waiting...", TimeSpan? timeout = null,
            TimeSpan? retryFrequency = null, TimeSpan? postTimeout = null)
        {
            throw new NotImplementedException();
        }

        public AppResult[] WaitForElement(Func<AppQuery, AppQuery> query, string timeoutMessage = "Timed out waiting for element...",
            TimeSpan? timeout = null, TimeSpan? retryFrequency = null, TimeSpan? postTimeout = null)
        {
            throw new NotImplementedException();
        }

        public AppResult[] WaitForElement(string marked, string timeoutMessage = "Timed out waiting for element...",
            TimeSpan? timeout = null, TimeSpan? retryFrequency = null, TimeSpan? postTimeout = null)
        {
            throw new NotImplementedException();
        }

        public AppWebResult[] WaitForElement(Func<AppQuery, AppWebQuery> query, string timeoutMessage = "Timed out waiting for element...",
            TimeSpan? timeout = null, TimeSpan? retryFrequency = null, TimeSpan? postTimeout = null)
        {
            throw new NotImplementedException();
        }

        public void WaitForNoElement(Func<AppQuery, AppQuery> query, string timeoutMessage = "Timed out waiting for no element...",
            TimeSpan? timeout = null, TimeSpan? retryFrequency = null, TimeSpan? postTimeout = null)
        {
            throw new NotImplementedException();
        }

        public void WaitForNoElement(string marked, string timeoutMessage = "Timed out waiting for no element...",
            TimeSpan? timeout = null, TimeSpan? retryFrequency = null, TimeSpan? postTimeout = null)
        {
            throw new NotImplementedException();
        }

        public void WaitForNoElement(Func<AppQuery, AppWebQuery> query, string timeoutMessage = "Timed out waiting for no element...",
            TimeSpan? timeout = null, TimeSpan? retryFrequency = null, TimeSpan? postTimeout = null)
        {
            throw new NotImplementedException();
        }

        public FileInfo Screenshot(string title)
        {
            throw new NotImplementedException();
        }

        public void SwipeRight()
        {
            throw new NotImplementedException();
        }

        public void SwipeLeftToRight(double swipePercentage = 0.67, int swipeSpeed = 500, bool withInertia = true)
        {
            throw new NotImplementedException();
        }

        public void SwipeLeftToRight(string marked, double swipePercentage = 0.67, int swipeSpeed = 500, bool withInertia = true)
        {
            throw new NotImplementedException();
        }

        public void SwipeLeft()
        {
            throw new NotImplementedException();
        }

        public void SwipeRightToLeft(double swipePercentage = 0.67, int swipeSpeed = 500, bool withInertia = true)
        {
            throw new NotImplementedException();
        }

        public void SwipeRightToLeft(string marked, double swipePercentage = 0.67, int swipeSpeed = 500, bool withInertia = true)
        {
            throw new NotImplementedException();
        }

        public void SwipeLeftToRight(Func<AppQuery, AppQuery> query, double swipePercentage = 0.67, int swipeSpeed = 500, bool withInertia = true)
        {
            throw new NotImplementedException();
        }

        public void SwipeRightToLeft(Func<AppQuery, AppQuery> query, double swipePercentage = 0.67, int swipeSpeed = 500, bool withInertia = true)
        {
            throw new NotImplementedException();
        }

        public void ScrollUp(Func<AppQuery, AppQuery> query = null, ScrollStrategy strategy = ScrollStrategy.Auto, double swipePercentage = 0.67, int swipeSpeed = 500,
            bool withInertia = true)
        {
            throw new NotImplementedException();
        }

        public void ScrollUp(string withinMarked, ScrollStrategy strategy = ScrollStrategy.Auto, double swipePercentage = 0.67, int swipeSpeed = 500,
            bool withInertia = true)
        {
            throw new NotImplementedException();
        }

        public void ScrollDown(Func<AppQuery, AppQuery> withinQuery = null, ScrollStrategy strategy = ScrollStrategy.Auto, double swipePercentage = 0.67,
            int swipeSpeed = 500, bool withInertia = true)
        {
            throw new NotImplementedException();
        }

        public void ScrollDown(string withinMarked, ScrollStrategy strategy = ScrollStrategy.Auto, double swipePercentage = 0.67, int swipeSpeed = 500,
            bool withInertia = true)
        {
            throw new NotImplementedException();
        }

        public void ScrollTo(string toMarked, string withinMarked = null, ScrollStrategy strategy = ScrollStrategy.Auto, double swipePercentage = 0.67,
            int swipeSpeed = 500, bool withInertia = true, TimeSpan? timeout = null)
        {
            throw new NotImplementedException();
        }

        public void ScrollUpTo(string toMarked, string withinMarked = null, ScrollStrategy strategy = ScrollStrategy.Auto,
            double swipePercentage = 0.67, int swipeSpeed = 500, bool withInertia = true, TimeSpan? timeout = null)
        {
            throw new NotImplementedException();
        }

        public void ScrollUpTo(Func<AppQuery, AppWebQuery> toQuery, string withinMarked, ScrollStrategy strategy = ScrollStrategy.Auto, double swipePercentage = 0.67,
            int swipeSpeed = 500, bool withInertia = true, TimeSpan? timeout = null)
        {
            throw new NotImplementedException();
        }

        public void ScrollDownTo(string toMarked, string withinMarked = null, ScrollStrategy strategy = ScrollStrategy.Auto,
            double swipePercentage = 0.67, int swipeSpeed = 500, bool withInertia = true, TimeSpan? timeout = null)
        {
            throw new NotImplementedException();
        }

        public void ScrollDownTo(Func<AppQuery, AppWebQuery> toQuery, string withinMarked, ScrollStrategy strategy = ScrollStrategy.Auto, double swipePercentage = 0.67,
            int swipeSpeed = 500, bool withInertia = true, TimeSpan? timeout = null)
        {
            throw new NotImplementedException();
        }

        public void ScrollUpTo(Func<AppQuery, AppQuery> toQuery, Func<AppQuery, AppQuery> withinQuery = null, ScrollStrategy strategy = ScrollStrategy.Auto, double swipePercentage = 0.67,
            int swipeSpeed = 500, bool withInertia = true, TimeSpan? timeout = null)
        {
            throw new NotImplementedException();
        }

        public void ScrollUpTo(Func<AppQuery, AppWebQuery> toQuery, Func<AppQuery, AppQuery> withinQuery = null, ScrollStrategy strategy = ScrollStrategy.Auto, double swipePercentage = 0.67,
            int swipeSpeed = 500, bool withInertia = true, TimeSpan? timeout = null)
        {
            throw new NotImplementedException();
        }

        public void ScrollDownTo(Func<AppQuery, AppQuery> toQuery, Func<AppQuery, AppQuery> withinQuery = null, ScrollStrategy strategy = ScrollStrategy.Auto, double swipePercentage = 0.67,
            int swipeSpeed = 500, bool withInertia = true, TimeSpan? timeout = null)
        {
            throw new NotImplementedException();
        }

        public void ScrollDownTo(Func<AppQuery, AppWebQuery> toQuery, Func<AppQuery, AppQuery> withinQuery = null, ScrollStrategy strategy = ScrollStrategy.Auto, double swipePercentage = 0.67,
            int swipeSpeed = 500, bool withInertia = true, TimeSpan? timeout = null)
        {
            throw new NotImplementedException();
        }

        public void SetOrientationPortrait()
        {
            throw new NotImplementedException();
        }

        public void SetOrientationLandscape()
        {
            throw new NotImplementedException();
        }

        public void Repl()
        {
            throw new NotImplementedException();
        }

        public void Back()
        {
            throw new NotImplementedException();
        }

        public void PressVolumeUp()
        {
            throw new NotImplementedException();
        }

        public void PressVolumeDown()
        {
            throw new NotImplementedException();
        }

        public object Invoke(string methodName, object argument = null)
        {
            throw new NotImplementedException();
        }

        public object Invoke(string methodName, object[] arguments)
        {
            throw new NotImplementedException();
        }

        public void DragCoordinates(float fromX, float fromY, float toX, float toY)
        {
            throw new NotImplementedException();
        }

        public void DragAndDrop(Func<AppQuery, AppQuery> @from, Func<AppQuery, AppQuery> to)
        {
            throw new NotImplementedException();
        }

        public void DragAndDrop(string @from, string to)
        {
            throw new NotImplementedException();
        }

        public void SetSliderValue(string marked, double value)
        {
            throw new NotImplementedException();
        }

        public void SetSliderValue(Func<AppQuery, AppQuery> query, double value)
        {
            throw new NotImplementedException();
        }

        public AppPrintHelper Print { get; }
        public IDevice Device { get; }
        public ITestServer TestServer { get; }

        #region IDisposable

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _window = null;
                _screenDictionary.Clear();
            }
            _disposed = true;
        }

        ~WindowsApp()
        {
            Dispose(false);
        }

        #endregion
    }
}
