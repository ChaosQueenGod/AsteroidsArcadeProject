using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//////////////////////////////////////////////
//Assignment/Lab/Project: Arcade Project
//Name: James Deglow
//Section: 2023SP.SGD.285.4171
//Instructor: Aurore Locklear
//Date: 4/3/2023
/////////////////////////////////////////////
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 8.0f;
    [SerializeField] float destroyTime = 2f;
    private Vector2 direction;
    private float timer;
    
    
    public void SetTarget(Vector2 target)
    {
        direction = (target - (Vector2)transform.position).normalized;
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
        timer += Time.deltaTime;
        if(timer > destroyTime) { Destroy(gameObject); }
    }
}
