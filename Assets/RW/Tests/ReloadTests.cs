using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class LaserTest
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
    public IEnumerator StopShootingAfterRunningOutOfBullets()
    {
        Ship ship = game.GetShip();
        ship.numberOfBullets = 1;
        ship.startingNumberOfBullets = 1;
        ship.ShootLaser();
        yield return new WaitForSeconds(0.5f);
        Assert.IsFalse(ship.canShoot);
    }

    [UnityTest]
    public IEnumerator CanShootAfterReload()
    {
        Ship ship = game.GetShip();
        ship.numberOfBullets = 1;
        ship.startingNumberOfBullets = 1;
        ship.ShootLaser();
        yield return new WaitForSeconds(2.1f);
        Assert.IsTrue(ship.canShoot);
    }
}