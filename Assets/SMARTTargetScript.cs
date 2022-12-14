using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMARTTargetScript : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    bool isJumping;

    HelperScript helper;

    private Animator anim;
    private string currentState;
    public bool attack;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        helper = gameObject.AddComponent<HelperScript>();

        attack = false;

        speed = 3.25F;
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.velocity;

        // check for walk left button
        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -3;
            ChangeAnimation("Run");
            helper.FlipObject(true);    // this will execute the method in HelperScript.cs
        }

        // check for walk right button
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = 3;
            ChangeAnimation("Run");
            helper.FlipObject(false);    // this will execute the method in HelperScript.cs
        }

        // Check for jump button
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            vel.y = 6;
            if (isJumping == true)
            {
                ChangeAnimation("Jump");
            }
        }

        // Play the 1st attack
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeAnimation("Attack1");
            attack = true;
        }

        // Play the 2nd attack
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeAnimation("Attack2");
            attack = true;
        }

        // Play the 3rd attack
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeAnimation("Attack3");
            attack = true;
        }

        attack = false;

        if (vel.x == 0f && vel.y == 0f && attack == false)
        {
            ChangeAnimation("Idle");
        }

        rb.velocity = vel;
    }

    void ChangeAnimation(string newState)
    {
        // Stop the animation iterupting itself
        if (currentState == newState) return;

        // Play the animation
        anim.Play(newState);

        // Reassign the currentState#
        currentState = newState;
    }

}

