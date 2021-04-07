using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBuff : MonoBehaviour
{
    private float _duration;
    private bool _hasBuff;

    public GameObject shield;

    private void Awake()
    {
        _duration = 5f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PistolAmmo>() != null)
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

        // reset the shield's duration
        if (!_hasBuff) _duration = 5f;
        
        // enable and disable the gameObject having the shield
        shield.SetActive(_hasBuff); 
    }
    

}
