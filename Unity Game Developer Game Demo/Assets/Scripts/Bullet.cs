using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Head") && other.GetComponentInParent<Player>() != null)
        {
            other.GetComponentInParent<Player>().TakeDamage(3);
        }

        if (other.CompareTag("Torso") && other.GetComponentInParent<Player>() != null) 
        {
            other.GetComponentInParent<Player>().TakeDamage(2);
        }

        if (other.CompareTag("Legs") && other.GetComponentInParent<Player>() != null) 
        {
            other.GetComponentInParent<Player>().TakeDamage(1);
        }
        
        Destroy(gameObject);
    }
    
}
