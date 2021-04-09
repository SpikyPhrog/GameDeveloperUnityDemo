using System.Collections;
using UnityEngine;

/// <summary>
/// Class that holds nearly all the data for the "Gameplay" in the first scene
/// </summary>
public class GameManager : MonoBehaviour
{
    //public members for the existing in the scene players. Needed for the logic of whether the one or the other shoots
    public Player player1;
    public Player player2;

    //Reference to the ui manager, so we can set ui objects on and off and to display text, also not to reference the long MasterSingleton.Instance.UIManager...
    private UIManager _uiManager;
    
    //Check members for if one of the players has won
    private bool _player1Wins;
    private bool _player2Wins;

    private void Start()
    {
        //set the ui manager variable
        _uiManager = MasterSingleton.Instance.UIManager;
    }

    private void Update()
    {
        //Check every frame if any of the players has died
        if (player1.GetCurrentPlayerHealth() <= 0 || player2.GetCurrentPlayerHealth() <= 0)
        {
            //conditions for if the player on the left dies
            if (player1.GetCurrentPlayerHealth() <= 0)
            {
                _player2Wins = true;
                player2.winnerUI.SetActive(true);
                player1.canInteract = false;
            }
            
            //conditions for if the player on the right dies
            if (player2.GetCurrentPlayerHealth() <= 0)
            {
                _player1Wins = true;
                player1.winnerUI.SetActive(true);
                player2.canInteract = false;
            }
            
            //start the coroutine that will fire up after a second when a winner has been announced
            StartCoroutine(nameof(ShowEndGameScreen));
        }
        else
        {
            //Called in the else, in case the user has pressed restart. The scene will restart, but the time scale will be still 0, keeping it in its Paused state.
            UnPauseGame();
        }

    }

    /// <summary>
    /// Method to pause the game after someone has died, to prevent the players from shooting over and over again after the game is over
    /// </summary>
    void PauseGame()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// To reset the timescale back to the original state in order to keep the game running after pressing the restart button in the UI menu
    /// </summary>
    void UnPauseGame()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// Coroutine to show up the game over UI screen. Waits for 3 seconds, then pauses the game to prevent any possible input from the players, after that shows the UI, and turns off the
    /// winner UI over the head of the players, then sets the title of the UI to either Left/Right player won.
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowEndGameScreen()
    {
        yield return new WaitForSecondsRealtime(3f);
        PauseGame();
        
        _uiManager.endGamePanel.SetActive(true);

        player1.winnerUI.SetActive(false);
        player2.winnerUI.SetActive(false);
        
        if (_player1Wins) _uiManager.winner.text = "Left player won!"; 
        if (_player2Wins) _uiManager.winner.text = "Right player won!";
    }
}


