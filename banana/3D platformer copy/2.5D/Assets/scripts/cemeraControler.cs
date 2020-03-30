using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cemeraControler : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet;
    public bool useOffSetValue = true;
    public float rotateSpeed = 5f;
    public Transform pivot;
    public float maxViewAngle = 45f;
    public float minViewAngle = -45f;
    public bool invertY = true;
    // Start is called before the first frame update
    void Start()
    {
        if (!useOffSetValue)
        {
            offSet = target.position - transform.position;
        }
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;
        Cursor.lockState = CursorLockMode.Locked;


    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0f);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        
        if(invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }else
       
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0f, 0f);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360 + minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360 + minViewAngle, 0f, 0f);
        }
        float deisiredXAngle = pivot.eulerAngles.x;
        float deisiredYAngle = target.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(deisiredXAngle, deisiredYAngle, 0);
        transform.position = target.position - rotation * offSet;
        //transform.position = target.position - offSet;
        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y -.5f, transform.position.z);
        }
        transform.LookAt(target);
    }
}
