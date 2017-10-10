using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingExercise.Services;
using System.Linq;

namespace TabCorpCodeExercise.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Data_Path()
        {
            // Arrange
            var meetingService = new MeetingService();
            meetingService.DataPath = null;

            //Act
            var meetings = meetingService.Get();

            //Assert
            // Exception expected
        }

        [TestMethod]
        public void No_Data_Found()
        {
            // Arrange
            var meetingService = new MeetingService();
            meetingService.DataPath = @"\";

            //Act
            var meetings = meetingService.Get();

            //Assert
            Assert.AreEqual(0, meetings.Count());
        }

        [TestMethod]
        public void Successful_Meeting_Data_Found()
        {
            // Arrange
            var meetingService = new MeetingService();

            //Act
            var meetings = meetingService.Get();

            //Assert
            Assert.AreEqual(1, meetings.Count());
            Assert.AreEqual(3, meetings.First().Races.Count());
            Assert.AreEqual(meetings.First().Id, meetings.First().Races.First()?.MeetingId);

        }
    }
}
