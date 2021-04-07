using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public Gun gun;
    public Bazooka bazooka;
    
    public int maxHealth;
    
    public GameObject[] healthBar;
    public GameObject shield;
    public GameObject gunWeapon;
    public GameObject bazookaWeapon;
    
    public bool hasEquippedBazooka;

    private int _currentHealth;


    private void Start()
    {
        if (characterController.id == 2)
        {
            gun.firePoint.Rotate(0, 180f, 0);
            gun.direction = -Vector2.right;
            
            bazooka.firePoint.Rotate(0, 180f, 0);
            bazooka.direction = -Vector2.right;
        }
        else
        {
            gun.direction = Vector2.right;
            bazooka.direction = Vector2.right;
        }

        _currentHealth = maxHealth;
        hasEquippedBazooka = false;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        //Reset the healthBar
        foreach (GameObject health in healthBar)
        {
            health.SetActive(false);    
        }
        
        //Refill the healthBar
        for (int i = 0; i < _currentHealth; i++)
        {
            healthBar[i].SetActive(true);
            
        }
    }

    public void TakeDamage(int amountDamage)
    {
        _currentHealth -= amountDamage;

        UpdateHealthBar();
    }

    public void HealPlayer(int amountHeal)
    {
        _currentHealth += amountHeal;
        
        if (_currentHealth > 5) _currentHealth = 5;
        UpdateHealthBar();
    }

    public void SpawnShield()
    {
        shield.SetActive(true);
    }

    public void EquipBazooka()
    {
        hasEquippedBazooka = true;
        
        gunWeapon.SetActive(false);
        bazookaWeapon.SetActive(true);
    }
}
