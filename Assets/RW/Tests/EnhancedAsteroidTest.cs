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

        [SetUp]
        public void Setup()
        {
            GameObject gameGameObject =
              MonoBehaviour.Instantiate(
                Resources.Load<GameObject>("Prefabs/Game"));
            game = gameGameObject.GetComponent<Game>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(game.gameObject);
        }


        [UnityTest]
        public IEnumerator EnhancedAsteroidSpawn()
        {
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();

            asteroid.GetComponent<Asteroid>().EnhanceTest();
            yield return new WaitForSeconds(0.1f);

            Assert.IsTrue(asteroid.GetComponent<Asteroid>().IsEnhanced());
        }

        [UnityTest]
        public IEnumerator SniperBulletDestroyEnhancedAsteroid()
        {
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();
            asteroid.GetComponent<Asteroid>().EnhanceTest();

            GameObject sniperBullet = game.GetShip().SpawnLaser();
            sniperBullet.GetComponent<Laser>().SetSniper();

            sniperBullet.transform.position = asteroid.transform.position;
            yield return new WaitForSeconds(0.1f);

            UnityEngine.Assertions.Assert.IsNull(asteroid);
        }
    }
}
