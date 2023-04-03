using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{

    [SerializeField] GameObject enemyUFO;

    // Start is called before the first frame update
    void Start()
    {
        //Increase the amount of UFO's over time
        InvokeRepeating("StartSpawning", 10, 12);
        InvokeRepeating("StartSpawning", 36, 12);
        InvokeRepeating("StartSpawning", 74, 12);
    }

    private void StartSpawning()
    {
        float randomY = Random.Range(-2f, 2f);
        Vector3 spawnPos = new Vector3(-10, randomY, transform.position.z);
        GameObject newUFO = Instantiate(enemyUFO, spawnPos, Quaternion.identity);
    }
}
