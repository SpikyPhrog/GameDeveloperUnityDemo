using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaBuff : MonoBehaviour
{
    private float _duration;
    private bool _hasBuff;

    private GameManager _gameManager;
    
    public GameObject bazookaWeapon;
    public GameObject gunWeapon;
    
    private void Awake()
    {
        _duration = 5f;
        _gameManager = MasterSingleton.Instance.GameManager;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PistolAmmo>() != null || other.GetComponent<BazookaAmmo>() != null)
        {
            if (_hasBuff)
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void Update()
    {
        _hasBuff = _duration > 0;

        _duration -= Time.deltaTime;

        // reset the buff's duration
        if (!_hasBuff)
        {
            _duration = 5f;
            bazookaWeapon.SetActive(false);
            gunWeapon.SetActive(true);

            _gameManager.player1.hasEquippedBazooka = false;
            _gameManager.player2.hasEquippedBazooka = false;
        }
    }
    
}
