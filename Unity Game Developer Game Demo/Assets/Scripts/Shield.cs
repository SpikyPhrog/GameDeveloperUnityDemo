using System;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.GetComponent<PistolAmmo>() != null)
        {
            if (other.collider.transform.rotation.y == 0 )
            {
                MasterSingleton.Instance.GameManager.player1.SpawnShield();
            }
            else if (other.collider.transform.rotation.y > 0)
            {
                MasterSingleton.Instance.GameManager.player2.SpawnShield();
            }
            
            Destroy(gameObject);
        }
    }
}
