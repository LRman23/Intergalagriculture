using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    private float moveSpeed = 4f;

    public float walkSpeed = 4f;
    public float runSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        //Gets hor and vert inputs as numbers
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //direction in normalized vector
        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 velocity = moveSpeed * Time.deltaTime * dir;

        //Detect sprint key
        if (Input.GetButton("Sprint"))
        {
            moveSpeed = runSpeed;
            animator.SetBool("Running", true);
        }
        else
        {
            moveSpeed = walkSpeed;
            animator.SetBool("Running", false);
        }

        //Detects movement
        if(dir.magnitude >= 0.1f)
        {
            //Looking toward a direction
            transform.rotation = Quaternion.LookRotation(dir);

            //Move
            controller.Move(velocity);

        }

        //Speed parameter
        animator.SetFloat("Speed", velocity.magnitude);
    }
}
