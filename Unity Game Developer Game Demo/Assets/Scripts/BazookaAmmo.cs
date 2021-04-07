using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaAmmo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponentInParent<Player>() != null) 
        {
            other.collider.GetComponentInParent<Player>().TakeDamage(5);
            
            //do explosion
            
            //destroy the ammo
            Destroy(gameObject);
        }
    }
}
