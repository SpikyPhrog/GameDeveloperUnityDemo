using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    private UIManager _uiManager;
    public Player player1;
    public Player player2;

    private bool _player1Wins;
    private bool _player2Wins;

    private void Start()
    {
        _uiManager = MasterSingleton.Instance.UIManager;
    }

    private void Update()
    {
        if (player1.GetCurrentPlayerHealth() <= 0 || player2.GetCurrentPlayerHealth() <= 0)
        {
            if (player1.GetCurrentPlayerHealth() <= 0)
            {
                _player2Wins = true;
                player2.winnerUI.SetActive(true);
            }

            if (player2.GetCurrentPlayerHealth() <= 0)
            {
                _player1Wins = true;
                player1.winnerUI.SetActive(true);
            }
            PauseGame();
            
            StartCoroutine(nameof(ShowEndGameScreen));
        }

        else
        {
            UnPauseGame();
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void UnPauseGame()
    {
        Time.timeScale = 1;
    }

    IEnumerator ShowEndGameScreen()
    {
        yield return new WaitForSecondsRealtime(1f);
        _uiManager.endGamePanel.SetActive(true);

        player1.winnerUI.SetActive(false);
        player2.winnerUI.SetActive(false);
        
        if (_player1Wins) _uiManager.winner.text = "Left player won!"; 
        if (_player2Wins) _uiManager.winner.text = "Right player won!";
    }
}


