using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Attack_AxeDurbilityAfterEachAttack()
        {
            //Arrange
            Axe axe = new Axe(20, 15);
            Dummy dummy = new Dummy(200, 50);

            //Act   
            axe.Attack(dummy);
            axe.Attack(dummy);

            //Assert    
            Assert.That(axe.DurabilityPoints, Is.EqualTo(13), "Axe durability points are decreased");

        }
        [Test]
        public void Attack_WithBrokenSword()
        {
            //Arrange
            Axe axe = new Axe(1, 2);
            Dummy dummy = new Dummy(100, 100);

            //Act 
            Assert.Multiple(() =>
            {
                axe.Attack(dummy);
                axe.Attack(dummy);
                Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException, "Axe is broken.");
            });
        }
    }
}