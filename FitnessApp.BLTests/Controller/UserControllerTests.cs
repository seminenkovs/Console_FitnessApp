using FitnessApp.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var gender = "man";
            var dateOfBirth = DateTime.Now.AddYears(- 18);
            var weight = 60;
            var height = 165;
            var controller = new UserController(userName);

            //Act
            controller.SetNewUserData(gender, dateOfBirth, weight, height);
            var controller2 = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(dateOfBirth, controller2.CurrentUser.DateOfBirth);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();

            //Act
            var controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}