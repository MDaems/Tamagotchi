using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TamagotchiWebService;
using Moq;
using TamagotchiService;

namespace TamagotchiWebServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EatUpdateMethod()
        {
            //Arrange
            Tamagotchi tama = new Tamagotchi();
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            TamagotchiService.TamagotchiService service = new TamagotchiService.TamagotchiService(mockRepo.Object);
            mockRepo.Setup(r => r.Get(tama.ID)).Returns(tama);

            ////Act
            service.Eat(tama.ID);

            ////Assert
            mockRepo.Verify(m => m.Update(tama));
        }
        [TestMethod]
        public void EatPerformActionTrue()
        {
            //Arrange
            Tamagotchi tama = new Tamagotchi();
            tama.Name = "MDaems";
            tama.Hunger = 50;
            tama.Health = 100;
            tama.IsAlive = true;
            tama.BusyTill = DateTime.UtcNow.AddHours(-5);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            TamagotchiService.TamagotchiService service = new TamagotchiService.TamagotchiService(mockRepo.Object);
            mockRepo.Setup(r => r.Get(tama.ID)).Returns(tama);

            ////Act
            service.Eat(tama.ID);

            ////Assert
            Assert.AreEqual(0, tama.Hunger);
        }
        [TestMethod]
        public void EatPerformActionFalse()
        {
            //Arrange
            Tamagotchi tama = new Tamagotchi();
            tama.Name = "MDaems";
            tama.Hunger = 50;
            tama.Health = 100;
            tama.IsAlive = true;
            tama.BusyTill = DateTime.UtcNow.AddHours(1);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            TamagotchiService.TamagotchiService service = new TamagotchiService.TamagotchiService(mockRepo.Object);
            mockRepo.Setup(r => r.Get(tama.ID)).Returns(tama);

            ////Act
            service.Eat(tama.ID);

            ////Assert
            Assert.AreEqual(50, tama.Hunger);
        }

        [TestMethod]
        public void SleepPerformActionTrue()
        {
            //Arrange
            Tamagotchi tama = new Tamagotchi();
            tama.Name = "MDaems";
            tama.Sleep = 25;
            tama.Health = 100;
            tama.IsAlive = true;
            tama.BusyTill = DateTime.UtcNow.AddHours(-5);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            TamagotchiService.TamagotchiService service = new TamagotchiService.TamagotchiService(mockRepo.Object);
            mockRepo.Setup(r => r.Get(tama.ID)).Returns(tama);

            ////Act
            service.Sleep(tama.ID);

            ////Assert
            Assert.AreEqual(0, tama.Sleep);
        }
        [TestMethod]
        public void SleepPerformActionFalseBusy()
        {
            //Arrange
            Tamagotchi tama = new Tamagotchi();
            tama.Name = "MDaems";
            tama.Sleep = 25;
            tama.Health = 100;
            tama.IsAlive = true;
            tama.BusyTill = DateTime.UtcNow.AddHours(1);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            TamagotchiService.TamagotchiService service = new TamagotchiService.TamagotchiService(mockRepo.Object);
            mockRepo.Setup(r => r.Get(tama.ID)).Returns(tama);

            ////Act
            service.Sleep(tama.ID);

            ////Assert
            Assert.AreEqual(25, tama.Sleep);
        }
        [TestMethod]
        public void SleepPerformActionFalseDead()
        {
            //Arrange
            Tamagotchi tama = new Tamagotchi();
            tama.Name = "MDaems";
            tama.Sleep = 25;
            tama.Health = 0;
            tama.IsAlive = false;
            tama.BusyTill = DateTime.UtcNow.AddHours(-1);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            TamagotchiService.TamagotchiService service = new TamagotchiService.TamagotchiService(mockRepo.Object);
            mockRepo.Setup(r => r.Get(tama.ID)).Returns(tama);

            ////Act
            service.Sleep(tama.ID);

            ////Assert
            Assert.AreEqual(25, tama.Sleep);
        }


    }
}
