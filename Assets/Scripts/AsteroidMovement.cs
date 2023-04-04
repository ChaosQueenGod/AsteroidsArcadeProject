using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////
//Assignment/Lab/Project: Arcade Project
//Name: Joel Hill
//Section: 2023SP.SGD.285.4171
//Instructor: Aurore Locklear
//Date: 4/3/2023
/////////////////////////////////////////////

public class AsteroidMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public int asteroidSize = 2;

    private Vector3 direction;
    private Rigidbody2D rb;
    private AsteroidSpawner asteroidSpawner;
    private ScoreController scoreController;

    private void Start()
    {
        asteroidSpawner = transform.parent.GetComponent<AsteroidSpawner>();
        scoreController = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>();
    }

    private void OnEnable()
    {
        Setup();
    }

    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
        CheckOutOfBounds();
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
                scoreController.AddToScore(50);
                asteroidSpawner.SpawnAsteroid(gameObject);
                asteroidSpawner.SpawnAsteroid(gameObject);
                asteroidSpawner.RemoveAsteroid(gameObject);
                break;
            case 1:
                scoreController.AddToScore(100);
                asteroidSpawner.SpawnAsteroid(gameObject);
                asteroidSpawner.SpawnAsteroid(gameObject);
                asteroidSpawner.RemoveAsteroid(gameObject);
                break;
            case 0:
                scoreController.AddToScore(200);
                asteroidSpawner.RemoveAsteroid(gameObject);
                break;
            default:
                print("Something when wrong.");
                break;
        }
    }

    private void CheckOutOfBounds()
    {

        if (transform.position.x <= -10)
        {
            float randomY = Random.Range(5.5f, -5.5f);
            transform.position = new Vector3(9.5f, randomY, transform.position.z);
        }

        if(transform.position.x >= 10)
        {
            float randomY = Random.Range(5.5f, -5.5f);
            transform.position = new Vector3(-9.5f, randomY, transform.position.z);
        }

        if(transform.position.y <= -6)
        {
            float randomX = Random.Range(-9.5f, 9.5f);
            transform.position = new Vector3(randomX, 5.5f, transform.position.z);
        }

        if (transform.position.y >= 6)
        {
            float randomX = Random.Range(-9.5f, 9.5f);
            transform.position = new Vector3(randomX, -5.5f, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BreakAsteroid();
        }

        if(collision.CompareTag("PlayerBullet"))
        {
            BreakAsteroid();
            Destroy(collision.gameObject);
        }
    }

}
