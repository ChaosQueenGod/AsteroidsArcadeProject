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
