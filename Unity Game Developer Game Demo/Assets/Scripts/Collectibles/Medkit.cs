using UnityEngine;
/// <summary>
/// Class for the medkit drop
/// </summary>
public class Medkit : MonoBehaviour
{
    //variable for the health of the drop
    private int _health;

    private void Awake()
    {
        //set the health to 10, this is not displayed as any form or shape on the UI
        _health = 10;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //with every collision decrease the health by one, regardless of the weapon
        _health--;

        if (_health <= 0)
        {
            //Just like with the other buffs, the buff is given based on the last person that hit it and on the bullet's rotation to decide who was the last to hit it
            if (other.collider.transform.rotation.y == 0 )
            {
                MasterSingleton.Instance.GameManager.player1.HealPlayer(3);
            }
            else if (other.collider.transform.rotation.y > 0)
            {
                MasterSingleton.Instance.GameManager.player2.HealPlayer(3);
            }
            
            //destroy the drop
            Destroy(gameObject);
        }
    }
}
