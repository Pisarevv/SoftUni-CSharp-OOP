using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Test_DummyLosingHealthAfterAttack()
        {
            //Arrange
            Dummy dummy = new Dummy(100, 100);
            //Act 
            dummy.TakeAttack(5);
            //Assert 
            Assert.That(dummy.Health, Is.EqualTo(95));
        }
        [Test]
        public void Test_DummyThrowsExceptionWhenDeadAndAttacked()
        {
            //Arrange
            Dummy dummy = new Dummy(2, 100);
            //Act and Assert
            Assert.Multiple(() =>
            {
                dummy.TakeAttack(2);
                Assert.That(() => dummy.TakeAttack(4), Throws.InvalidOperationException, "Dummy is dead.");
            });
        }
        [Test]
        public void Test_DummyShoudNotGiveExeprienceWhenDead()
        {
            //Arrange
            Dummy dummy = new Dummy(2, 100);
            //Act and Assert
            Assert.Multiple(() =>
            {
                dummy.TakeAttack(3);
                Assert.That(() => dummy.GiveExperience().Equals(100));
            });
        }
        [Test]
        public void Test_AliveDummyShoudNotGiveExperince()
        {
            //Arrange
            Dummy dummy = new Dummy(22, 100);
            //Act and Assert
            Assert.Multiple(() =>
            {
                dummy.TakeAttack(2);
                Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException, "Target is not dead.");
            });
        }
    }
}