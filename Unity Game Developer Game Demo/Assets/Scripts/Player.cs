using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public Gun gun;
    public int maxHealth;
    public GameObject[] healthBar;
    private int _currentHealth;
    private int _healthBarID;
    private void Start()
    {
        if (characterController.id == 2)
        {
            gun.firePoint.Rotate(0, 180f, 0);
            gun.direction = -Vector2.right;
        }
        else
        {
            gun.direction = Vector2.right;
        }

        _currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        for (int i = 0; i < _currentHealth; i++)
        {
            healthBar[i].SetActive(true);
            
        }
    }

    public void TakeDamage(int amountDamage)
    {
        _currentHealth -= amountDamage;
        _healthBarID += amountDamage;

        for (int i = 0; i < _healthBarID; i++)
        {
            healthBar[i].SetActive(false);
        }
    }
}
