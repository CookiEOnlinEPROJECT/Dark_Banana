using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_tryMove : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce;
    public float gravityScale = 1f;
    public CharacterController controll;
    public float rightDirction = 1;
    public float dir;
    private Vector3 moveDirection;
    public bool isGrounded;
    
    void Start()
    {
        controll = GetComponent<CharacterController>();
    }

   void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, moveDirection.y, 0);
        moveDirection = (transform.forward * Input.GetAxis("Horizontal"));
        if (controll.isGrounded)
        {
            moveDirection.y = 0;
            
            isGrounded =  true;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                Debug.Log("jump!");
                isGrounded = false;

            }
          


        }
        dir = Input.GetAxis("Horizontal");
        if (dir > 0)
        {
            Debug.Log("right");
            
            rightDirction = 1;


        }
        if (dir < 0)
        {
            Debug.Log("left");
            
            rightDirction = -1;
        }
        if (rightDirction == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        moveDirection.y = moveDirection.y + Physics.gravity.y * gravityScale * Time.deltaTime;
        controll.Move(moveDirection * Time.deltaTime  );

    }

}
    