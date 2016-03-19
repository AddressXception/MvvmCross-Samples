using System;

namespace TipCalc.UITest.Shared.Common
{
    public static class Assert
    {
        internal static EventHandler<EventArgs> AssertionFailure;

        public static void IsTrue(bool condition, string message = null)
        {
            if (condition)
                return;
            Assert.HandleFailure("Assert.IsTrue", message);
        }

        public static void IsFalse(bool condition, string message = null)
        {
            if (!condition)
                return;
            Assert.HandleFailure("Assert.IsFalse", message);
        }

        public static void AreEqual<T>(T expected, T actual, string message = null)
        {
            if (object.Equals((object)expected, (object)actual))
                return;
            Assert.HandleFailure("Assert.AreEqual", message);
        }

        public static void Inconclusive()
        {

        }

        internal static void HandleFailure(string assertionName, string message)
        {
            if (Assert.AssertionFailure != null)
                Assert.AssertionFailure((object)null, EventArgs.Empty);
            throw new AssertFailedException(message);
        }
    }
}
