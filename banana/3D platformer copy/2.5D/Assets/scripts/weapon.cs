
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
   
    void Update()
    {
       if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
