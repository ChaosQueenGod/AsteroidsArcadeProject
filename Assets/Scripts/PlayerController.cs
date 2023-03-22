using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    private PlayerInput playerinput;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    Vector2 mousePos = new Vector3();

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerinput = new PlayerInput();
    }

    private void OnEnable() { playerinput.Control.Enable(); }
    private void OnDisable() { playerinput.Control.Disable(); }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * speed, moveInput.y * speed); //move player

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //fetch mouse position for shooting and aiming
        
        LookAtMouse();

        
    }

    private void LookAtMouse()
    {
        Vector2 lookAt = mousePos;
        float AngleRad = Mathf.Atan2(lookAt.y - transform.position.y, lookAt.x - transform.position.x); //get tangent angle between player and mouse position

        float AngleDeg = (180 / Mathf.PI) * AngleRad; //multiply by 180 over pi to calculate degrees instead of radians

        transform.rotation = Quaternion.Euler(0, 0, AngleDeg); //set rotation to look at mouse
    }

    void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>(); //get input from input system
    }
    void OnShoot(InputValue input)
    {
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.z = 0;
        //gun.Shoot((Vector2)mousePos - (Vector2)transform.position);
        //Debug.Log("pew"); 
    }
    void OnHyperspace(InputValue input)
    {

    }
}
