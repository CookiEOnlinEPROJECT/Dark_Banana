using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    //public Rigidbody RB;
    public float jumpForce;
    public CharacterController controll;
    public float gravityScale = 1f;
    //public Animator animator;
    public Transform pivot;
    public float turnSpeed;
    public float dir;
    public float rightDirction = 1;
    
    public Vector3 moveDirection;

    
    void Start()
    {
        controll = GetComponent<CharacterController>();
    }


    void Update()
    {

        // RB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, RB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        /*if (Input.GetButtonDown("Jump"))
        {
            RB.velocity = new Vector3(RB.velocity.x, jumpForce, RB.velocity.z);
        }
        */
        
        moveDirection = new Vector3(rightDirction * moveSpeed, moveDirection.y, 0);
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;
        if (controll.isGrounded)
        {
            moveDirection.y = 0;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;

            }

        }


        rightDirction = Input.GetAxis("Horizontal");
        moveDirection.y = moveDirection.y + Physics.gravity.y * gravityScale * Time.deltaTime;
        moveDirection.x = moveDirection.x * rightDirction;
        moveDirection.z = 0f;
        controll.Move(moveDirection * Time.deltaTime );
        dir = Input.GetAxis("Horizontal");

        if (dir > 0.1 && dir != 0)
        {
            //Debug.Log("right");

            rightDirction = 1;


        }
        if (dir < -0.1 && dir != 0)
        {
            //Debug.Log("left");

            rightDirction = -1;
        }
        if (rightDirction == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, 0f));
        }
        if (rightDirction == -1)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }


        //animator.SetBool("isground", controll.isGrounded);
        //animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }
}
