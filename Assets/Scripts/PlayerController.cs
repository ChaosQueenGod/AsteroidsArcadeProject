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

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerinput = new PlayerInput();
    }

    private void OnEnable() { playerinput.Control.Enable(); }
    private void OnDisable() { playerinput.Control.Disable(); }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveInput.x * speed, moveInput.y * speed);
        rb.velocity = transform.TransformDirection(movement);
        //gameObject.transform.LookAt(Camera.main.ViewportToScreenPoint(Input.mousePosition)); //lookat is acting weird, im probably passing it a bad position. maybe need to pass it specific positions and only take the x and z value from mouse.
    }

    void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }
    void OnShoot(InputValue input)
    {

    }
    void OnHyperspace(InputValue input)
    {

    }
}
