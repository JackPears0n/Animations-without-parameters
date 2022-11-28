using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEditor;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float speed;
    private string currentState;
    public bool notIdle = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5.5f;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.velocity;

        /*
        if (notIdle == true)
        {
            ChangeAnimation("idle");
        }
        */

        // Walk left
        if (Input.GetKeyDown(KeyCode.A))
        {
            vel.x = -3;
            ChangeAnimation("run");
            notIdle = true;
        }

        // Walk right 
        if (Input.GetKeyDown(KeyCode.D))
        {
            vel.x = 3;
            ChangeAnimation("run");
            notIdle = true;
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vel.y = 6;
            ChangeAnimation("jump");
            notIdle = true;
        }

        // Sneeze
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeAnimation("sneeze");
            notIdle = true;
        }

        // Spin
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeAnimation("spin");
            notIdle = true;
        }

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
