using System;
using UnityEngine;
/// <summary>
/// Class for handling the collision detection with the bullets and the players
/// </summary>
public class PistolAmmo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if the object that has been hit contains the player class
        if (other.collider.GetComponentInParent<Player>() != null)
        {
            //I couldn't think of anything better than tagging the certain parts of the body to help the collision detection
            //If the bullet hits the head collider, the player plays the bleed effect and takes 3 damage
            if (other.collider.CompareTag("Head"))
            {
                other.collider.GetComponentInParent<Player>().TakeDamage(3);
                other.collider.GetComponentInParent<Player>().PlayBleedEffect(other);
            }
            
            //if the bullet hits the torso collider, the player bleeds and takes 2 damage
            if (other.collider.CompareTag("Torso"))
            {
                other.collider.GetComponentInParent<Player>().TakeDamage(2);
                other.collider.GetComponentInParent<Player>().PlayBleedEffect(other);
            }

            //if the bullet hits the player's lower body, they take 1 damage and the bleed effect. I ended up having 3 colliders on the lower body
            //after my attempt to prevent the bullet hitting multiple colliders at the same time. Having one more did not help.
            if (other.collider.CompareTag("Legs") || other.collider.CompareTag("UpperLegs") ||
                other.collider.CompareTag("Knees"))
            {
                other.collider.GetComponentInParent<Player>().TakeDamage(1);
                other.collider.GetComponentInParent<Player>().PlayBleedEffect(other);
            }
            
            // After the damage is done the sound effect is played
            MasterSingleton.Instance.SoundManager.PlaySound(SoundEvents.PlayerHurt);
        }

        // and if the bullet hits the bomb drop, it applies force to it so it can move to reach the players
        if (other.collider.CompareTag("Bomb"))
        {
            other.collider.GetComponent<Rigidbody2D>().AddForce(gameObject.GetComponent<Rigidbody2D>().velocity);
        }
        //destroy the bullet
        Destroy(gameObject);
    }

   
}
