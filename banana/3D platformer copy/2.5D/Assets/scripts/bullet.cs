
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody rb;
    public Transform body;
   
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

     void OnTriggerEnter(Collider hitInfo)
    {
        
            Debug.Log(hitInfo);
            Destroy(gameObject);
        
    }

}
