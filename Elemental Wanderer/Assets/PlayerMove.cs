using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator anim;
    SpriteRenderer rend;
    Rigidbody2D body;

    [Range(-5, 5)]
    public float walkingSpeed;

    public float jumpForce = 3;

    bool rightPressed;
    bool leftPressed;

    // Start is called before the first frame update
    void Start()
    {
        walkingSpeed = 3f;

        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            body.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            
        if(Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("Walking", true);
            rend.flipX = true;
            rightPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("Walking", true);
            rend.flipX = false;
            leftPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
            rightPressed = false;

        if (Input.GetKeyUp(KeyCode.A))
            leftPressed = false;

        if(!rightPressed && !leftPressed)
            anim.SetBool("Walking", false);
    }

    private void FixedUpdate()
    {
        if (anim.GetBool("Walking"))
        {
            body.velocity = new Vector2(walkingSpeed * (rend.flipX ? 1 : -1), body.velocity.y);
        }
        else
            body.velocity = new Vector2(0, body.velocity.y);

        Debug.Log(body.velocity.x + " " + body.velocity.y);
    }
}
