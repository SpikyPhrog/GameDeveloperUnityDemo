using System;
using UnityEngine;

/// <summary>
/// Class for the Shield drop
/// </summary>
public class Shield : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Check if the drop has been damaged by a pistol bullet       
        if (other.collider.GetComponent<PistolAmmo>() != null)
        {
            //Check for the rotation of the bullet. This indicates from which player it comes. If 0, then the bullet rotation is not
            //modified, therefore it comes from the player on the left or Player, else if its modified and different than 0 then it's the second player in the scene
            if (other.collider.transform.rotation.y == 0 )
            {
                MasterSingleton.Instance.GameManager.player1.SpawnShield();
            }
            else if (other.collider.transform.rotation.y > 0)
            {
                MasterSingleton.Instance.GameManager.player2.SpawnShield();
            }
            //Destroys the drop after the collision
            Destroy(gameObject);
        }
    }
}
