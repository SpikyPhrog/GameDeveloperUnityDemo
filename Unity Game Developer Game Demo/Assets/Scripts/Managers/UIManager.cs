using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    
    public Button fireBtnPlayer1;
    public Button fireBtnPlayer2;
    
    private void Awake()
    {
        fireBtnPlayer1.onClick.AddListener(ShootP1);
        fireBtnPlayer2.onClick.AddListener(ShootP2);
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    private void ShootP1()
    {
        if (_gameManager.player1.hasEquippedBazooka)
        {
            _gameManager.player1.bazooka.Fire();
        }
        else
        {
            _gameManager.player1.gun.Fire();
        }
    }
    private void ShootP2()
    {
        if (_gameManager.player2.hasEquippedBazooka)
        {
            _gameManager.player2.bazooka.Fire();
        }
        else
        {
            _gameManager.player2.gun.Fire();
        }
    }
}
