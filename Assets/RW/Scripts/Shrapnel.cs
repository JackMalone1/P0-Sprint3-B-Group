using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shrapnel : MonoBehaviour
{
    Vector3 move;
   
    private void Start()
    {
      int  rand = Random.Range(0, 360);
        move = new Vector3(Mathf.Cos(rand), Mathf.Sin(rand), 0);

    }
    [SerializeField]
    private Spawner spawner;


    void Update()
    {

        transform.Translate(move * Time.deltaTime * 5);

        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Asteroid>() != null)
        {
            
        
                Game.AsteroidDestroyed();
                Destroy(gameObject);
                spawner.asteroids.Remove(collision.gameObject);
                Destroy(collision.gameObject);
                

        }
        if (collision.gameObject.GetComponent<Shrapnel>() != null)
        {
            

        }
    }
}
