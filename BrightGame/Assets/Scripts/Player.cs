using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;

    public float health;

    public FloatingJoystick joystick;

    [Tooltip("This is the right left move Speed")]
    public float moveSpeed;

    [Tooltip("This is the forward run Speed")]
    public float runSpeed;

    public float sizechangeSpeed;
    public float moveMultiplier;

    bool isRunning;


    public static Player instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        health = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        //handles right left input
        HandleInput();
        //Handles forward running
        HandleRunning();
        //Calculates Scale based on health
        CalculateScale();

    }

    void HandleRunning()
    {
        //Start running on Tap
        if (GameController.instance.playing && !isRunning)
        {
            anim.SetBool("Running", true);
            isRunning = true;
            Debug.Log("running is true!");
            return;
        }
        //Apply Forward force
        if (isRunning)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, runSpeed);
        }
    }

    private void HandleInput()
    {
        Vector3 targetPos = new Vector3(joystick.Horizontal * moveMultiplier,
            transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    private void CalculateScale()
    {
        Vector3 newScale = new Vector3(health , health , health );
        if (transform.localScale != newScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, newScale, sizechangeSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage()
    {
        if (health > 0)
        {
            health -= 1;
           
        }
        if (health <= 0)
        {
            Lose();
        }

    }

    private void Lose()
    {
        //set animation to death
        Debug.Log("You Lose");
        Time.timeScale = 0;

        Time.timeScale = 0;

        //show popup

    }

    public void IncreaseHealth()
    {
        if (health < 6)
        {
            health++;
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "HealthPickup")
        {
            IncreaseHealth();
            Destroy(other.gameObject);
            //TODO: add a particle effect
            //TODO:add a sound effect
        }

        else if(other.gameObject.tag == "Obstacle")
        {
            TakeDamage();
            Destroy(other.gameObject);
            //TODO: add a particle effect
            //TODO:add a sound effect
        }

    }

}
