using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TamagotchiWebService;
using Moq;
using TamagotchiService;
using System.Collections.Generic;
using TamagotchiWebService.Models;

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
            tama.Health = 90;
            tama.IsAlive = true;
            tama.BusyTill = DateTime.UtcNow.AddHours(-5);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            TamagotchiService.TamagotchiService service = new TamagotchiService.TamagotchiService(mockRepo.Object);
            mockRepo.Setup(r => r.Get(tama.ID)).Returns(tama);

            ////Act
            service.Sleep(tama.ID);

            ////Assert
            Assert.AreEqual(0, tama.Sleep);
            Assert.AreEqual(100, tama.Health);
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


        [TestMethod]
        public void PlayPerformActionTrue()
        {
            //Arrange
            Tamagotchi tama = new Tamagotchi();
            tama.Name = "MDaems";
            tama.Boredom = 35;
            tama.Health = 100;
            tama.IsAlive = true;
            tama.BusyTill = DateTime.UtcNow.AddHours(-5);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            TamagotchiService.TamagotchiService service = new TamagotchiService.TamagotchiService(mockRepo.Object);
            mockRepo.Setup(r => r.Get(tama.ID)).Returns(tama);

            ////Act
            service.Play(tama.ID);

            ////Assert
            Assert.AreEqual(0, tama.Boredom);
        }
        [TestMethod]
        public void PlayPerformActionFalseBusy()
        {
            //Arrange
            Tamagotchi tama = new Tamagotchi();
            tama.Name = "MDaems";
            tama.Boredom = 35;
            tama.Health = 100;
            tama.IsAlive = true;
            tama.BusyTill = DateTime.UtcNow.AddHours(1);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            TamagotchiService.TamagotchiService service = new TamagotchiService.TamagotchiService(mockRepo.Object);
            mockRepo.Setup(r => r.Get(tama.ID)).Returns(tama);

            ////Act
            service.Play(tama.ID);

            ////Assert
            Assert.AreEqual(35, tama.Boredom);
        }
        [TestMethod]
        public void PlayPerformActionFalseDead()
        {
            //Arrange
            Tamagotchi tama = new Tamagotchi();
            tama.Name = "MDaems";
            tama.Boredom = 35;
            tama.Health = 0;
            tama.IsAlive = false;
            tama.BusyTill = DateTime.UtcNow.AddHours(-1);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            TamagotchiService.TamagotchiService service = new TamagotchiService.TamagotchiService(mockRepo.Object);
            mockRepo.Setup(r => r.Get(tama.ID)).Returns(tama);

            ////Act
            service.Play(tama.ID);

            ////Assert
            Assert.AreEqual(35, tama.Boredom);
        }


        [TestMethod]
        public void HugPerformActionTrue()
        {
            //Arrange
            Tamagotchi tama = new Tamagotchi();
            tama.Name = "MDaems";
            tama.Hunger = 10;
            tama.Sleep = 10;
            tama.Boredom = 10;
            tama.Health = 90;
            tama.IsAlive = true;
            tama.BusyTill = DateTime.UtcNow.AddHours(-5);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            TamagotchiService.TamagotchiService service = new TamagotchiService.TamagotchiService(mockRepo.Object);
            mockRepo.Setup(r => r.Get(tama.ID)).Returns(tama);

            ////Act
            service.Hug(tama.ID);

            ////Assert
            Assert.AreEqual(0, tama.Hunger);
            Assert.AreEqual(0, tama.Sleep);
            Assert.AreEqual(0, tama.Boredom);
            Assert.AreEqual(100, tama.Health);
        }
        [TestMethod]
        public void HugPerformActionFalseBusy()
        {
            //Arrange
            Tamagotchi tama = new Tamagotchi();
            tama.Name = "MDaems";
            tama.Hunger = 10;
            tama.Sleep = 10;
            tama.Boredom = 10;
            tama.Health = 90;
            tama.IsAlive = true;
            tama.BusyTill = DateTime.UtcNow.AddHours(1);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            TamagotchiService.TamagotchiService service = new TamagotchiService.TamagotchiService(mockRepo.Object);
            mockRepo.Setup(r => r.Get(tama.ID)).Returns(tama);

            ////Act
            service.Hug(tama.ID);

            ////Assert
            Assert.AreEqual(10, tama.Hunger);
            Assert.AreEqual(10, tama.Sleep);
            Assert.AreEqual(10, tama.Boredom);
            Assert.AreEqual(90, tama.Health);
        }
        [TestMethod]
        public void HugPerformActionFalseDead()
        {
            //Arrange
            Tamagotchi tama = new Tamagotchi();
            tama.Name = "MDaems";
            tama.Hunger = 10;
            tama.Sleep = 10;
            tama.Boredom = 10;
            tama.Health = 0;
            tama.IsAlive = false;
            tama.BusyTill = DateTime.UtcNow.AddHours(-1);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            TamagotchiService.TamagotchiService service = new TamagotchiService.TamagotchiService(mockRepo.Object);
            mockRepo.Setup(r => r.Get(tama.ID)).Returns(tama);

            ////Act
            service.Hug(tama.ID);

            ////Assert
            Assert.AreEqual(10, tama.Hunger);
            Assert.AreEqual(10, tama.Sleep);
            Assert.AreEqual(10, tama.Boredom);
            Assert.AreEqual(0, tama.Health);
        }


        [TestMethod]
        public void StateIsBusy()
        {
            //Arrange
            Tamagotchi tamagotchi = new Tamagotchi();
            tamagotchi.Name = "MDaems";
            tamagotchi.Health = 100;
            tamagotchi.IsAlive = true;
            tamagotchi.BusyTill = DateTime.UtcNow.AddHours(1);
            State state = new State(tamagotchi);

            //Assert
            Assert.AreEqual(false, state.CanPerformAction);
            Assert.AreEqual("Tamagotchi " + tamagotchi.Name + " is busy till: " + tamagotchi.BusyTill.ToLocalTime().ToLongTimeString(), state.BusyMessage);
        }
        [TestMethod]
        public void StateIsDead()
        {
            //Arrange
            Tamagotchi tamagotchi = new Tamagotchi();
            tamagotchi.Name = "MDaems";
            tamagotchi.Health = 0;
            tamagotchi.IsAlive = false;
            State state = new State(tamagotchi);

            //Assert
            Assert.AreEqual(false, state.CanPerformAction);
            Assert.AreEqual("Tamagotchi " + tamagotchi.Name + " has passed away", state.BusyMessage);
        }
        [TestMethod]
        public void StateIsSleep()
        {
            //Arrange
            Tamagotchi tamagotchi = new Tamagotchi();
            tamagotchi.Name = "MDaems";
            tamagotchi.Sleep = 100;
            tamagotchi.IsAlive = false;
            State state = new State(tamagotchi);

            //Assert
            Assert.AreEqual("Sleep", state.HighestProperty);
            Assert.AreEqual("Tamagotchi needs sleep: " + tamagotchi.Sleep, state.HighestPropertyMessage);
        }
        [TestMethod]
        public void StateIsHunger()
        {
            //Arrange
            Tamagotchi tamagotchi = new Tamagotchi();
            tamagotchi.Name = "MDaems";
            tamagotchi.Hunger = 100;
            tamagotchi.IsAlive = false;
            State state = new State(tamagotchi);

            //Assert
            Assert.AreEqual("Hunger", state.HighestProperty);
            Assert.AreEqual("Tamagotchi is hungry: " + tamagotchi.Hunger, state.HighestPropertyMessage);
        }

       [TestMethod]
        public void StateIsBored()
        {
            //Arrange
            Tamagotchi tamagotchi = new Tamagotchi();
            tamagotchi.Name = "MDaems";
            tamagotchi.Boredom = 100;
            tamagotchi.IsAlive = false;
            State state = new State(tamagotchi);

            //Assert
            Assert.AreEqual("Boredom", state.HighestProperty);
            Assert.AreEqual("Tamagotchi is bored: " + tamagotchi.Boredom, state.HighestPropertyMessage);
        }


        [TestMethod]
        public void ExhaustedRuleTrue()
        {
            //Arrange
            Exhausted exhausted = new Exhausted();
            Tamagotchi tamagotchi = new Tamagotchi();
            tamagotchi.Sleep = 85;
            tamagotchi.Health = 100;
            tamagotchi.IsAlive = true;

            //Act
            tamagotchi = exhausted.ExecuteGameRule(tamagotchi);

            //Assert
            Assert.AreEqual(80, tamagotchi.Health);
        }
        [TestMethod]
        public void ExhaustedRuleFalse()
        {
            //Arrange
            Exhausted exhausted = new Exhausted();
            Tamagotchi tamagotchi = new Tamagotchi();
            tamagotchi.Sleep = 75;
            tamagotchi.Health = 100;
            tamagotchi.IsAlive = true;

            //Act
            tamagotchi = exhausted.ExecuteGameRule(tamagotchi);

            //Assert
            Assert.AreEqual(100, tamagotchi.Health);
        }

        [TestMethod]
        public void HungerRuleTrue()
        {
            //Arrange
            Starved starved = new Starved();
            Tamagotchi tamagotchi = new Tamagotchi();
            tamagotchi.Hunger = 85;
            tamagotchi.Health = 100;
            tamagotchi.IsAlive = true;

            //Act
            tamagotchi = starved.ExecuteGameRule(tamagotchi);

            //Assert
            Assert.AreEqual(80, tamagotchi.Health);
        }
        [TestMethod]
        public void HungerRuleFalse()
        {
            //Arrange
            Starved starved = new Starved();
            Tamagotchi tamagotchi = new Tamagotchi();
            tamagotchi.Hunger = 75;
            tamagotchi.Health = 100;
            tamagotchi.IsAlive = true;

            //Act
            tamagotchi = starved.ExecuteGameRule(tamagotchi);

            //Assert
            Assert.AreEqual(100, tamagotchi.Health);
        }

        [TestMethod]
        public void CrazyRuleTrueBecause()
        {
            //Arrange
            Crazy crazy = new Crazy();
            Tamagotchi tamagotchi = new Tamagotchi();
            tamagotchi.Sleep = 75;
            tamagotchi.Hunger = 15;
            tamagotchi.Health = 100;
            tamagotchi.IsAlive = true;

            //Act
            tamagotchi = crazy.ExecuteGameRule(tamagotchi);

            //Assert
            Assert.AreEqual(80, tamagotchi.Health);
        }
        [TestMethod]
        public void CrazyRuleFalse()
        {
            //Arrange
            Crazy crazy = new Crazy();
            Tamagotchi tamagotchi = new Tamagotchi();
            tamagotchi.Sleep = 65;
            tamagotchi.Hunger = 5;
            tamagotchi.Health = 100;
            tamagotchi.IsAlive = true;

            //Act
            tamagotchi = crazy.ExecuteGameRule(tamagotchi);

            //Assert
            Assert.AreEqual(100, tamagotchi.Health);
        }
    }
}
