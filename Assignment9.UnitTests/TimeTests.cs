using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment9.UnitTests
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void TimeValueInitialization_InvalidHours()
        {
            Assert.ThrowsException<Exception>(() => new Time(25, 30));
        }

        [TestMethod]
        public void TimeValueInitialization_InvalidMinutes()
        {
            Assert.ThrowsException<Exception>(() => new Time(20, 62));
        }

        [TestMethod]
        public void AddingTwoTimeValues_ResultTimeHoursExceeds23()
        {
            var leftTime = new Time(15, 30);
            var rightTime = new Time(10, 0);

            Assert.ThrowsException<Exception>(() => leftTime + rightTime);
        }
        [TestMethod]
        public void ImplicitCoversionFromMinutesToTime_OutOfOneDayBoundariesMinutes()
        {
            Assert.ThrowsException<Exception>(() => (Time)(1500));
        }

        [TestMethod]
        public void AddingTwoTimeValues()
        {
            var leftTime = new Time(3, 30);
            var rightTime = new Time(3, 0);

            //Arrange
            var expectedTime = new Time(6, 30);

            //Act
            var resTime = leftTime + rightTime;

            //Assert
            Assert.AreEqual(expectedTime, resTime);
        }

        [TestMethod]
        public void SubstractingTwoTimeValues()
        {
            var leftTime = new Time(3, 30);
            var rightTime = new Time(3, 0);

            //Arrange
            var expectedTime = new Time(0, 30);

            //Act
            var resTime = leftTime - rightTime;

            //Assert
            Assert.AreEqual(expectedTime, resTime);
        }

        [TestMethod]
        public void ImplicitCoversionFromMinutesToTime()
        {
            //Arrange
            var expected = new Time(1, 50);

            //Act
            var resTime = (Time)110;

            //Assert
            Assert.AreEqual(expected, resTime);
        }

        [TestMethod]
        public void ExplicitConversionFromTimeToMinutes()
        {
            var time = new Time(4, 10);

            //Arrange
            var expected = 250;

            //Act
            var resMinutes = (int)time;

            //Assert
            Assert.AreEqual(expected, resMinutes);
        }

        [TestMethod]
        public void CheckNoonTime()
        {
            var expected = new Time(12, 0);

            var resNoonTime = Time.Noon;

            Assert.AreEqual(expected, resNoonTime);
        }

        [TestMethod]
        public void PrintTimeDetails()
        {
            var time = new Time(8, 0);

            var expected = "08 : 00";

            var resString = time.ToString();

            Assert.AreEqual(expected, resString);
        }
    }
}
