using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 8.0f;
    [SerializeField] float destroyTime = 3.0f;
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
