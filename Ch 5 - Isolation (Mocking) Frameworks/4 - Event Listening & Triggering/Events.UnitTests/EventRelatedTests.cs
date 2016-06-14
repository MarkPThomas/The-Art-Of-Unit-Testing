using System;
using NUnit.Framework;
using NSubstitute;

namespace Events.UnitTests
{
    [TestFixture]
    public class EventRelatedTests
    {
        [Test]
        public void Actor_WhenViewIsLoaded_CallsViewRender()
        {
            var mockView = Substitute.For<IView>();

            Presenter p = new Presenter(mockView);

            // Trigger the event with NSubstitute
            mockView.Loaded += Raise.Event<Action>();

            // Check that the view was called
            mockView.Received().Render(Arg.Is<string>(s => s.Contains("Hello World")));
        }

        [Test]
        public void Actor_WhenViewHasError_CallsLogger()
        {
            var stubView = Substitute.For<IView>();
            var mockLogger = Substitute.For<ILogger>();

            Presenter p = new Presenter(stubView, mockLogger);
            stubView.ErrorOccurred += Raise.Event<Action<string>>("fake error");

            mockLogger.Received().LogError(Arg.Is<string>(s => s.Contains("fake error")));
        }

        [Test]
        public void EventFiringManual()
        {
            bool loadFired = false;
            SomeView view = new SomeView();
            view.Loaded += delegate
                            {
                                loadFired = true;
                            };

            view.DoSomethingThatEventuallyFiresThisEvent();

            Assert.IsTrue(loadFired);
        }
    }
}
