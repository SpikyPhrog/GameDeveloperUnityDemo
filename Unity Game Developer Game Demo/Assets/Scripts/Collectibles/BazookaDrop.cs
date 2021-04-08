using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaDrop : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.GetComponent<PistolAmmo>() != null)
        {
            if (other.collider.transform.rotation.y == 0 )
            {
                MasterSingleton.Instance.GameManager.player1.EquipBazooka();
            }
            else if (other.collider.transform.rotation.y > 0)
            {
                MasterSingleton.Instance.GameManager.player2.EquipBazooka();
            }
            
            Destroy(gameObject);
        }
    }
}
