using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }
     
    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        //Debug.Log(change);
    }

    private void FixedUpdate()
    {
       UpdateAnimationAndMove();

    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            if (change.y == 0)
            {
                animator.SetFloat("moveX", change.x);
                animator.SetFloat("moveY", 0);


            }
            else if (change.x == 0)
            {
                animator.SetFloat("moveY", change.y);
                animator.SetFloat("moveX", 0);

            }
            animator.SetBool("moving", true);



        }
        else
        {
            animator.SetBool("moving", false);


        }

    }


    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change.normalized * speed * Time.fixedDeltaTime
            );
    }
}
