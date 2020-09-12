using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    public FloatingJoystick joystick;
    public float moveMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(joystick.Horizontal * moveMultiplier,
            transform.position.y,transform.position.z);
    }
    

}
