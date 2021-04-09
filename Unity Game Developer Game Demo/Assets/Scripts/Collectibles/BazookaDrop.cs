using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class for the bazooka drop
/// </summary>
public class BazookaDrop : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Check if the drop has been shot by a bullet from the pistol
        if (other.collider.GetComponent<PistolAmmo>() != null)
        {
            //Based on the rotation of the bullet can be determined who shot it, if equal to 0 -> left
            if (other.collider.transform.rotation.y == 0 )
            {
                MasterSingleton.Instance.GameManager.player1.EquipBazooka();
            }
            //else its the right one
            else if (other.collider.transform.rotation.y > 0)
            {
                MasterSingleton.Instance.GameManager.player2.EquipBazooka();
            }
            //destroy the drop's prefab in the scene
            Destroy(gameObject);
        }
    }
}
