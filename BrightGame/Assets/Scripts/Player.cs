using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;

    public FloatingJoystick joystick;

    [Tooltip("This is the right left move Speed")]
    public float moveSpeed;

    [Tooltip("This is the forward run Speed")]
    public float runSpeed;

    public float moveMultiplier;

    bool isRunning;


    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos= new Vector3(joystick.Horizontal * moveMultiplier,
            transform.position.y,transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);


        //Start running on Tap
        if (GameController.instance.gameStarted && !isRunning)
        {
            anim.SetBool("Running", true);
            isRunning = true;
            Debug.Log("running is true!");
            return;

        }

        if (isRunning)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, runSpeed);
        }
        
    }

    private void SetAnimState()
    {
        
    }
}
