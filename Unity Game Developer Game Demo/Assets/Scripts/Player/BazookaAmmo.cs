using UnityEngine;

/// <summary>
/// Class that is attached to the rocket's prefab, used for checking if it is colliding with something
/// </summary>
public class BazookaAmmo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if the rocket collides with something that holds the player script
        if (other.collider.GetComponentInParent<Player>() != null) 
        {
            //the player takes 5 damage
            other.collider.GetComponentInParent<Player>().TakeDamage(5);
            
            //"Explosion" effect. Since I couldn't quite get my head around how does 2D ragdolls work, I could not create the explosion effect that I was required
            //to do. My way around this effect is by applying force to every single rigidbody that the player that the bomb has collided with. Looks alright,
            //no disassembling of the character unfortunately
            foreach (var rb in other.collider.GetComponentInParent<Player>().rbs2d)
            {
                rb.AddForceAtPosition(Vector2.left * 100, other.collider.transform.position, ForceMode2D.Impulse);
            }
            
            //play the bleeding particle effect to make it even cooler :D
            other.collider.GetComponentInParent<Player>().PlayBleedEffect(other);
            
            //destroy the rocket
            Destroy(gameObject);
        }
    }
}
