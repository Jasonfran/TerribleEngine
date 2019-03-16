using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TerribleEngine.ComponentModels;
using TerribleEngine.ECS;

namespace TerribleEngine.UnitTests
{
    [TestFixture]
    public class EntityManagerTests
    {
        protected class TestComponent : IComponent
        {

        }

        protected EntityManager EntityManager { get; set; }

        protected ISystemManager SystemManager { get; set; }

        [SetUp]
        public void Setup()
        {
            SystemManager = Mock.Of<ISystemManager>();
            EntityManager = new EntityManager(SystemManager);

            Mock.Get(SystemManager).Setup(x => x.SystemsWhichSatisfy(It.IsAny<ComponentSet>()))
                .Returns(new List<ITerribleSystem>());
        }

        [Test]
        public void NewEntityIdsAreCorrectlyIncremented()
        {

            var entity1 = EntityManager.NewEntity();
            var entity2 = EntityManager.NewEntity();

            Assert.That(entity2.Id, Is.EqualTo(entity1.Id + 1));
        }

        [Test]
        public void HasComponentWhenAdded()
        {

            var entity = EntityManager.NewEntity();
            EntityManager.AddComponent(entity, new TestComponent());

            Assert.That(EntityManager.HasComponent<TestComponent>(entity));
        }

        [Test]
        public void DoesntHaveComponentWhenRemoved()
        {

            var entity = EntityManager.NewEntity();
            EntityManager.AddComponent(entity, new TestComponent());

            Assert.That(EntityManager.HasComponent<TestComponent>(entity));

            EntityManager.RemoveComponent<TestComponent>(entity);

            Assert.That(!EntityManager.HasComponent<TestComponent>(entity));
        }

        [Test]
        public void EntityIsAddedToSystems()
        {
            var system = Mock.Of<ITerribleSystem>(x=>x.Entities == new List<Entity>());

            Mock.Get(SystemManager).Setup(x => x.SystemsWhichSatisfy(It.IsAny<ComponentSet>()))
                .Returns(new List<ITerribleSystem> {system});

            var entity = EntityManager.NewEntity();
            entity.AddComponent(new TestComponent());

            Assert.That(system.Entities.Contains(entity));
        }

        [Test]
        public void EntityIsRemovedFromSystems()
        {
            var system = Mock.Of<ITerribleSystem>(x => x.Entities == new List<Entity>());

            Mock.Get(SystemManager).Setup(x => x.SystemsWhichSatisfy(It.IsAny<ComponentSet>()))
                .Returns(new List<ITerribleSystem> { system });

            var entity = EntityManager.NewEntity();
            entity.AddComponent(new TestComponent());
            entity.RemoveComponent<TestComponent>();

            Assert.That(!system.Entities.Contains(entity));
        }
    }
}