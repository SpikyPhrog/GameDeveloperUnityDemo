using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class for the pistol, to handle shooting
/// </summary>
public class Gun : MonoBehaviour
{
    //transform for the point from where the bullet will be shot
    public Transform firePoint;
    
    //the bullet prefab
    public GameObject bulletPrefab;

    //the bullet's speed
    public float velocity;
    
    //the bullet's direction
    public Vector2 direction;
    
    /// <summary>
    /// Method that instantiates the bullet and sets the velocity of it to create the illusion of shooting
    /// </summary>
    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * velocity;
    }
}
