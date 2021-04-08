using UnityEngine;

public class Medkit : MonoBehaviour
{
    private int _health;

    private void Awake()
    {
        _health = 10;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _health--;

        if (_health <= 0)
        {
            if (other.collider.transform.rotation.y == 0 )
            {
                MasterSingleton.Instance.GameManager.player1.HealPlayer(3);
            }
            else if (other.collider.transform.rotation.y > 0)
            {
                MasterSingleton.Instance.GameManager.player2.HealPlayer(3);
            }
            Destroy(gameObject);
        }
    }
}
