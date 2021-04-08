using System;
using UnityEngine;

public class PistolAmmo : MonoBehaviour
{ 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponentInParent<Player>() != null)
        {
            if (other.collider.CompareTag("Head"))
            {
                other.collider.GetComponentInParent<Player>().TakeDamage(3);
            }

            if (other.collider.CompareTag("Torso"))
            {
                other.collider.GetComponentInParent<Player>().TakeDamage(2);
            }

            if (other.collider.CompareTag("Legs") || other.collider.CompareTag("UpperLegs") ||
                other.collider.CompareTag("Knees"))
            {
                other.collider.GetComponentInParent<Player>().TakeDamage(1);
            }
            
            MasterSingleton.Instance.SoundManager.PlaySound(SoundEvents.PlayerHurt);
        }

        if (other.collider.CompareTag("Bomb"))
        {
            other.collider.GetComponent<Rigidbody2D>().AddForce(gameObject.GetComponent<Rigidbody2D>().velocity);
        }
        
        Destroy(gameObject);
    }
}
