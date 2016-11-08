using System;
using NUnit.Framework;

namespace TimeLoggerProj.UnitTests
{
    [TestFixture]
    public class TimeLoggerTests
    {
        [Test]
        public void SettingSystemTime_Always_ChangesTime()
        {
            // Set fake date
            SystemTime.Set(new DateTime(2000, 1, 1));

            string output = TimeLogger.CreateMessage("a");

            StringAssert.Contains("1/1/2000", output);
        }

        [Test]
        public void SettingSystemTime_Always_Default_Time()
        {
            StringAssert.Contains(DateTime.Now.ToShortDateString(), TimeLogger.CreateMessage("a"));
        }


        [TearDown]
        public void afterEachTest()
        {
            // Reset date at the end of each test
            SystemTime.Reset();
        }
    }
}
