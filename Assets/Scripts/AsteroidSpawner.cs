using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AsteroidSpawner : MonoBehaviour
{
    private List<Transform> asteroids = new List<Transform>();
    private List<Transform> activeAsteroids = new List<Transform>();
    private int spawnNum = 5;
    private bool isSpawning = false;


    void Start()
    {
        foreach (Transform obj in gameObject.transform)
        {
            asteroids.Add(obj);
            obj.gameObject.SetActive(false);
        }

        StartSpawning();
    }

    private void FixedUpdate()
    {
        if(activeAsteroids.Count <= 0 && !isSpawning)
        {
            isSpawning = true;
            StartSpawning();
        }
    }

    //Spawn new asteroids with different sizes and speeds
    public void SpawnAsteroid(GameObject brokenAsteroid)
    {
        GameObject newAsteroid = gameObject;

        //Find a new asteroid in object pool
        foreach (Transform obj in asteroids)
        {
            if (!obj.gameObject.activeSelf)
            {
                newAsteroid = obj.gameObject;
                break;
            }
        }

        //Check if this is a fresh asteroid or not by checking the attached class of the gameObject parameter that was passed
        if(brokenAsteroid.GetComponent<AsteroidMovement>())
        {
            //Smaller asteroid being spawned since the previous one was destroyed
            newAsteroid.transform.position = brokenAsteroid.transform.position;
            newAsteroid.GetComponent<AsteroidMovement>().asteroidSize = brokenAsteroid.GetComponent<AsteroidMovement>().asteroidSize - 1;
            newAsteroid.GetComponent<AsteroidMovement>().speed = brokenAsteroid.GetComponent<AsteroidMovement>().speed + 2;
        }
        else
        {
            //Fresh asteroid being spawned
            //Choose which side of the screen to spawned on with a random position
            int randomSideOfScreen = Random.Range(1, 5);
            float randomX = Random.Range(-9.5f, 9.5f);
            float randomY = Random.Range(5.5f, -5.5f);

            switch (randomSideOfScreen)
            {
                case 1:
                    //Top of screen
                    newAsteroid.transform.position = new Vector3(randomX, 5.5f, transform.position.z);
                    break;
                case 2:
                    //Bottom of screen
                    newAsteroid.transform.position = new Vector3(randomX, -5.5f, transform.position.z);
                    break;
                case 3:
                    //Right of screen
                    newAsteroid.transform.position = new Vector3(-9.5f, randomY, transform.position.z);
                    break;
                case 4:
                    //Left of screen
                    newAsteroid.transform.position = new Vector3(9.5f, randomY, transform.position.z);
                    break;
                default:
                    print("Something went wrong.");
                    break;
            }

        }

        activeAsteroids.Add(newAsteroid.transform);
        newAsteroid.SetActive(true);
    }

    public void RemoveAsteroid(GameObject brokenAsteroid)
    {
        //Default asteroid settings
        brokenAsteroid.GetComponent<AsteroidMovement>().asteroidSize = 2;
        brokenAsteroid.GetComponent<AsteroidMovement>().speed = 2;
        activeAsteroids.Remove(brokenAsteroid.transform);
        brokenAsteroid.SetActive(false);
    }

    private void StartSpawning()
    {
        //Increases the amount of asteroids spawned as the game goes on
        for(int i = 0; i < spawnNum; i++)
        {
            SpawnAsteroid(gameObject);
        }

        spawnNum = spawnNum + 1;
        isSpawning = false;
    }
}
