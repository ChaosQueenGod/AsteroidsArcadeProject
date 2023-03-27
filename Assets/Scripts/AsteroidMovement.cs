using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public int asteroidSize = 2;

    private Vector3 direction;
    private Rigidbody2D rb;
    private AsteroidSpawner asteroidSpawner;

    private void Start()
    {
        asteroidSpawner = transform.parent.GetComponent<AsteroidSpawner>();
    }

    private void OnEnable()
    {
        Setup();
    }

    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void Setup()
    {
        //Give the asteroid a random direction
        Vector3 randomDir = Random.insideUnitCircle * speed;
        direction = (transform.position - randomDir).normalized;

        //Set the asteroids size
        switch (asteroidSize)
        {
            case 2:
                transform.localScale = new Vector3(2, 2, 2);
                break;
            case 1:
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                break;
            case 0:
                transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                break;
            default:
                print("Something when wrong.");
                break;
        }
    }

    //Checks how big the current asteroid is and creates 2 smaller asteroids while destroying the original asteroid
    private void BreakAsteroid()
    {
        switch (asteroidSize)
        {
            case 2:
                asteroidSpawner.SpawnAsteroid(gameObject);
                asteroidSpawner.SpawnAsteroid(gameObject);
                asteroidSpawner.RemoveAsteroid(gameObject);
                break;
            case 1:
                asteroidSpawner.SpawnAsteroid(gameObject);
                asteroidSpawner.SpawnAsteroid(gameObject);
                asteroidSpawner.RemoveAsteroid(gameObject);
                break;
            case 0:
                asteroidSpawner.RemoveAsteroid(gameObject);
                break;
            default:
                print("Something when wrong.");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BreakAsteroid();
        }
    }

}