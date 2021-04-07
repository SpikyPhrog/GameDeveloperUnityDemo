using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float velocity;
    public Vector2 direction;
    
    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * velocity;
    }
}
