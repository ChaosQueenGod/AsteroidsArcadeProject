using System;
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
public class Teleporter : MonoBehaviour
{
    [SerializeField] bool isHorizontal;
    [SerializeField] bool isVertical;
    [SerializeField] GameObject goal;


    [NonSerialized] public bool justTeleported = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if(justTeleported == false)
        { goal.GetComponent<Teleporter>().justTeleported = true; }
        
        if (isHorizontal && !justTeleported)
        {
            other.transform.position = new Vector2(other.transform.position.x, goal.transform.position.y);
        }
        if(isVertical && !justTeleported)
        {
            other.transform.position = new Vector2(goal.transform.position.x, other.transform.position.y );
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        justTeleported = false;
    }
}
