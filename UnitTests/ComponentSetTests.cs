using System.Collections.Generic;
using NUnit.Framework;
using TerribleEngine.Attributes;
using TerribleEngine.ComponentModels;
using TerribleEngine.ECS;

namespace TerribleEngine.UnitTests
{
    [TestFixture]
    public class ComponentSetTests
    {
        [Test]
        public void ComponentSetsAreComparable()
        {
            var object1 = new ComponentSet(typeof(Transform));
            var object2 = new ComponentSet(typeof(Transform));
            var object3 = new ComponentSet(typeof(Transform), typeof(Renderable));
            Assert.AreEqual(object1, object2);
            Assert.AreNotEqual(object1, object3);
        }

        [Test]
        public void DictionaryLookupIsSuccessful()
        {
            var dictionary = new Dictionary<ComponentSet, int>();
            
            dictionary.Add(new ComponentSet(typeof(Transform)), 123);

            var lookup = new ComponentSet(typeof(Transform));

            Assert.That(dictionary[lookup], Is.EqualTo(123));
        }
    }
}