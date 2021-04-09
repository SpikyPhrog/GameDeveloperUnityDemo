using System.Diagnostics.Eventing.Reader;
using UnityEngine;
/// <summary>
/// Class for the player's properties
/// </summary>
public class Player : MonoBehaviour
{
    //reference to the character controller
    public CharacterController characterController;
    
    //reference to the pistol gun class
    public Gun gun;
    
    //reference to the bazooka class
    public Bazooka bazooka;
    
    //variable that is settable in the inspector for the max health
    public int maxHealth;
    
    //array that holds the UI representation of the healthBar
    public GameObject[] healthBar;
    
    //reference to the shield object that is on the player
    public GameObject shield;
    
    //reference to the pistol 
    public GameObject gunWeapon;
    
    //reference to the bazooka
    public GameObject bazookaWeapon;
    
    //reference to the winner ui that pops above the winner's head
    public GameObject winnerUI;
    
    //check if the player has acquired the bazooka buff 
    public bool hasEquippedBazooka;
    
    //check if the player is dead
    public bool canInteract;
    
    //array for all of the rigidbodies that the player has for the "Explosion" effect
    public Rigidbody2D[] rbs2d;

    //the bleeding particle effect
    public ParticleSystem bleedEffect;

    //variable to store the current health
    private int _currentHealth;
    
    //references to the buffs
    private ShieldBuff _shieldBuff;
    private BazookaBuff _bazookaBuff;
    
    private void Start()
    {
        //check if the id of the player is 2
        if (characterController.id == 2)
        {
            //then rotate the firepoint of the player's gun so it can shoot towards the left player
            gun.firePoint.Rotate(0, 180f, 0);
            
            //change the direction of fire
            gun.direction = -Vector2.right;
            
            //same for the bazooka if the player has equipped the bazooka
            bazooka.firePoint.Rotate(0, 180f, 0);
            bazooka.direction = -Vector2.right;
        }
        else
        {
            //else keep everything normal
            gun.direction = Vector2.right;
            bazooka.direction = Vector2.right;
        }
        
        //set the check for if they are dead. At the start of the game they are not so they can interact with the UI buttons
        canInteract = true;
        
        //the current health equals the max health that was set in the inspector
        _currentHealth = maxHealth;
        
        //by default set if the player has the bazooka to false
        hasEquippedBazooka = false;
        
        //update the healthBarUI
        UpdateHealthBar();
    }

    /// <summary>
    /// Method that runs everytime that the player takes damage, or at the start at the game when the healthbar needs to be set
    /// </summary>
    void UpdateHealthBar()
    {
        //loop through all of the hearts of the healthbar and disable them
        foreach (GameObject health in healthBar)
        {
            health.SetActive(false);    
        }
        
        //Then loop again through the healthbar array for the amount of life the player has
        for (int i = 0; i < _currentHealth; i++)
        {
            healthBar[i].SetActive(true);
        }
    }

    /// <summary>
    /// Method that can be called anywhere outside this class, whenever the said player takes damage, where the damage is the passed parameter,
    /// and update the healthbar
    /// </summary>
    /// <param name="amountDamage"></param>
    public void TakeDamage(int amountDamage)
    {
        _currentHealth -= amountDamage;

        UpdateHealthBar();
    }

    /// <summary>
    /// Much like the method above, except it heals the player by the amount passed as a parameter and updates the UI
    /// </summary>
    /// <param name="amountHeal"></param>
    public void HealPlayer(int amountHeal)
    {
        _currentHealth += amountHeal;
        
        if (_currentHealth > 5) _currentHealth = 5;
        UpdateHealthBar();
    }

    /// <summary>
    /// Method that is called whenever the player acquires the shield drop
    /// </summary>
    public void SpawnShield()
    {
        shield.SetActive(true);
    }

    /// <summary>
    /// Method that is called whenever the player acquires the bazooka drop. Sets the check to true and swaps the weapons
    /// </summary>
    public void EquipBazooka()
    {
        hasEquippedBazooka = true;
        
        gunWeapon.SetActive(false);
        bazookaWeapon.SetActive(true);
    }

    /// <summary>
    /// Helper method to get from outside the class the current health of the player
    /// </summary>
    /// <returns></returns>
    public int GetCurrentPlayerHealth()
    {
        return _currentHealth;
    }
    
    /// <summary>
    /// Method that plays the bleed particle effect. Mainly focused towards the classes that take care of collision detection
    /// </summary>
    /// <param name="other"></param>
    public void PlayBleedEffect(Collision2D other)
    {
        if (other.collider.GetComponentInParent<Player>().characterController.id == 2)
        {
            var bleed = Instantiate(bleedEffect, other.collider.transform);
            bleed.transform.Rotate(0f, 180f, 0f);
            bleedEffect.Play();
        }
        else
        {
            Instantiate(bleedEffect, other.collider.transform);
            bleedEffect.Play();
        }
    }
}
