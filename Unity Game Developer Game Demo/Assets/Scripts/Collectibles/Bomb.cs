using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.collider.GetComponentInParent<Player>().TakeDamage(5);

        //do the explosion
        //destroy
        Destroy(gameObject);
    }
}
