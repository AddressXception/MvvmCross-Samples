using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TipCalc.UITest.Windows
{
    public class WindowsApp : IApp
    {
        public AppResult[] Query(Func<AppQuery, AppQuery> query = null)
        {
            throw new NotImplementedException();
        }

        public AppResult[] Query(string marked)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
    }
}
