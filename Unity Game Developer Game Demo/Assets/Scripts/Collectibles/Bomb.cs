using UnityEngine;
/// <summary>
/// Class for the bomb bonus
/// </summary>
public class Bomb : MonoBehaviour
{
    //Reference to the "explosion" particle effect
    public ParticleSystem explosionParticle;
    //reference to the sprite renderer
    public SpriteRenderer sprite;

    //check if the bomb has collided with something, this is to prevent colliding with more than one collider at a time,
    //due to the size of the bomb it can hit more than one collider, causing it to explode more than once.
    private bool _firstCollision;


    private void OnCollisionEnter2D(Collision2D other)
    {
        //if we are not colliding with anything
        if (!_firstCollision)
        {
            //and collide with player
            if (other.collider.GetComponentInParent<Player>() != null)
            {
                //set the check boolean to true so we can not collide anymore with anything that has the player class on it
                _firstCollision = true;
                    
                if (_firstCollision)
                {
                    //Plays the sound effect
                    MasterSingleton.Instance.SoundManager.PlaySound(SoundEvents.BombExplosion);
                    
                    //the player that has been hit by the bomb takes 5 damage
                    other.collider.GetComponentInParent<Player>().TakeDamage(5);
                    
                    //"Explosion" effect. Since I couldn't quite get my head around how does 2D ragdolls work, I could not create the explosion effect that I was required
                    //to do. My way around this effect is by applying force to every single rigidbody that the player that the bomb has collided with. Looks alright,
                    //no disassembling of the character unfortunately
                    foreach (var rb in other.collider.GetComponentInParent<Player>().rbs2d)
                    {
                        rb.AddForceAtPosition(Vector2.left * 100, other.collider.transform.position, ForceMode2D.Impulse);
                    }
                    
                    //Hide the sprite of the bomb
                    sprite.enabled = false;
                    //Play the explosion particle and fake the illusion of the bomb disappearing and exploding
                    explosionParticle.Play();
            
                    //Destroy the bomb after the explosion has finished playing
                    Destroy(gameObject, explosionParticle.main.duration);
                }
            }
        }
    }
}
