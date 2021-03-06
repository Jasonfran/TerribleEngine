using NUnit.Framework;
using TerribleEngine.Attributes;
using TerribleEngine.ECS;

namespace UnitTests
{
    [TestFixture]
    public class DependsOnComponentTests
    {

        [Test]
        public void DependsOnComponentsEquality()
        {
            var object1 = new DependsOnComponents(typeof(Transform));
            var object2 = new DependsOnComponents(typeof(Transform));

            Assert.AreEqual(object1, object2);
        }
    }
}