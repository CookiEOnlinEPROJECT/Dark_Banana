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
    public Animator animator;


    private Vector3 moveDirection;


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

        // moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
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

        moveDirection.y = moveDirection.y + Physics.gravity.y * gravityScale * Time.deltaTime;

        controll.Move(moveDirection * Time.deltaTime);

        animator.SetBool("isground", controll.isGrounded);
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }
}
