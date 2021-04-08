using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponentInParent<Player>() != null)
        {
            other.collider.GetComponentInParent<Player>().TakeDamage(5);
            
            //do the explosion
            MasterSingleton.Instance.SoundManager.PlaySound(SoundEvents.BombExplosion);
            
            //destroy
            Destroy(gameObject);
        }
    }
}
