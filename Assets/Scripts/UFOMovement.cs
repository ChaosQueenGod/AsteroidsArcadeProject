using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    [SerializeField] private Gun gun;
    private ScoreController scoreController;
    private GameObject player;

    private float speed = 3.0f;
    private bool movingUp = false;
    private bool movingRight = false;

    private bool canFire = true;
    private float timer = 0;
    private float timeBetweenFiring = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SwitchDirection());
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(CleanUp());
        scoreController = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (movingUp)
        {
            transform.position += (Vector3.right + Vector3.up) * speed * Time.deltaTime;
        }
        else //(movingDown)
        {
            transform.position += (Vector3.right + Vector3.down) * speed * Time.deltaTime;
        }

        //Bullet cooldown
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (canFire)
        {
            canFire = false;
            gun.Shoot((Vector2)player.transform.position);
        }

    }

    IEnumerator SwitchDirection()
    {
        //Move the ufo right for 0.7 seconds
        movingRight = true;
        movingUp = false;
        yield return new WaitForSeconds(0.7f);

        //Move the ufo up for 0.7 second
        movingRight = false;
        movingUp = true;
        yield return new WaitForSeconds(0.7f);

        //Move the ufo right for 0.7 seconds
        movingRight = true;
        movingUp = false;
        yield return new WaitForSeconds(0.7f);

        //Move the ufo down for 0.7 second
        movingRight = false;
        movingUp = false;
        yield return new WaitForSeconds(0.7f);

        //Loop
        StartCoroutine(SwitchDirection());
    }

    IEnumerator CleanUp()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            scoreController.AddToScore(600);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
