using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EnhancedAsteroidTest
    {
        private Game game;
        private GameObject asteroid;

        [SetUp]
        public void Setup()
        {
            GameObject gameGameObject =
              MonoBehaviour.Instantiate(
                Resources.Load<GameObject>("Prefabs/Game"));
            game = gameGameObject.GetComponent<Game>();

            asteroid = game.GetSpawner().SpawnAsteroid();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(game.gameObject);
            Object.Destroy(asteroid.gameObject);
        }


        [UnityTest]
        public IEnumerator EnhancedAsteroidSpawn()
        {
            asteroid.GetComponent<Asteroid>().EnhanceTest();
            yield return new WaitForSeconds(0.1f);

            Assert.IsTrue(asteroid.GetComponent<Asteroid>().IsEnhanced());
        }
    }
}
