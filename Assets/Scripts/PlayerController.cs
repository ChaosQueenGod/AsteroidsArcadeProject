using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////
//Assignment/Lab/Project: Arcade Project
//Name: James Deglow
//Section: 2023SP.SGD.285.4171
//Instructor: Aurore Locklear
//Date: 4/3/2023
/////////////////////////////////////////////
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] Gun gun;
    [SerializeField] float fieldWidth = 3.9f;
    [SerializeField] LayerMask enemy;
    [SerializeField] int maxLives = 3;
    [SerializeField] GameObject[] lifeSprites;
    [SerializeField] GameObject deathPanel;
    [SerializeField] ScoreController scoreController;

    private PlayerInput playerinput;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    Vector2 mousePos = new Vector3();
    private int currentLives;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerinput = new PlayerInput();
        currentLives = maxLives;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            currentLives--;
            if (currentLives <= 0)
            {
                deathPanel.SetActive(true);
                scoreController.PauseScore();
                return;
            }
            lifeSprites[currentLives].SetActive(false);
            rb.MovePosition(PickSafePosition());
        }
    }
    Vector2 PickSafePosition()
    {
        float width = gameObject.GetComponent<PolygonCollider2D>().bounds.size.x;
        float randX = Random.Range((fieldWidth * -1), fieldWidth);
        float randY = Random.Range((fieldWidth * -1), fieldWidth);
        Vector2 target = new Vector2(randX, randY);

        while (Physics2D.OverlapCircle(target, width * 1.25f, enemy))
        {
            randX = Random.Range((fieldWidth * -1), fieldWidth);
            randY = Random.Range((fieldWidth * -1), fieldWidth);
            target = new Vector2(randX, randY);
        }
        return target;
    }

    //Button Controllers
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        /*
        deathPanel.SetActive(false);
        foreach(GameObject life in lifeSprites)
        {
            life.SetActive(true);
        }
        currentLives = maxLives;
        rb.MovePosition(PickSafePosition());
        */
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    //Input stuff

    void OnMove(InputValue input) //Called by Inputsystem
    {
        moveInput = input.Get<Vector2>(); //get input from input system
    }
    void OnShoot(InputValue input) //Called by Inputsystem
    {
        gun.Shoot((Vector2)mousePos - (Vector2)transform.position);
    }
    void OnHyperspace(InputValue input) //Called by Inputsystem
    {
        rb.MovePosition(PickSafePosition());
    }

}
