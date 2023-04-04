using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////
//Assignment/Lab/Project: Arcade Project
//Name: James Deglow
//Section: 2023SP.SGD.285.4171
//Instructor: Aurore Locklear
//Date: 4/3/2023
/////////////////////////////////////////////
public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public void Shoot(Vector2 target)
    {
        GameObject go = Instantiate(bullet, transform.position, Quaternion.identity);
        //go.transform.parent = null;
        go.GetComponent<Bullet>().SetTarget(target);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
