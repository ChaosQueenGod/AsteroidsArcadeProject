using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public void Shoot(Vector2 target)
    {
        GameObject go = Instantiate(bullet, transform.position, Quaternion.identity);
        //go.transform.parent = null;
        go.GetComponent<Bullet>().SetTarget(target);
    }
}
