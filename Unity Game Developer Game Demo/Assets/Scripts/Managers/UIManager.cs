using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //reference to the game manager
    private GameManager _gameManager;
    
    //references to the buttons on the ui
    public Button fireBtnPlayer1;
    public Button fireBtnPlayer2;
    
    //reference to the itemDuration text that the drops use
    public TMP_Text itemDuration;

    //reference to the UI panel after the game ends
    public GameObject endGamePanel;
    
    //reference to the UI text field that appears in the game over screen
    public TMP_Text winner;
    private void Awake()
    {
        //Adds listeners to the buttons. I am doing this that way because it is a lot more flexible than setting this up in the inspector. Especially for when switching the weapons
        fireBtnPlayer1.onClick.AddListener(ShootP1);
        fireBtnPlayer2.onClick.AddListener(ShootP2);
    }

    private void Start()
    {
        //get the reference from the main singleton
        _gameManager = MasterSingleton.Instance.GameManager;
    }

    private void ShootP1()
    {
        //Check if the player has died, if they have died they can not interact with the button any longer.
        if (_gameManager.player1.canInteract)
        {
            //check if the player has picked up the bazooka buff
            if (_gameManager.player1.hasEquippedBazooka)
            {
                //if they have, the shoot the bazooka's rocket
                _gameManager.player1.bazooka.Fire();
            }
            else
            {    //else they shoot the gun's bullet and play sound effect
                _gameManager.player1.gun.Fire();
                MasterSingleton.Instance.SoundManager.PlaySound(SoundEvents.PlayerShoot);
            }  
        }
        
    }
    private void ShootP2()
    {
        //same as above for the player one, except check for the player 2's condition
        if (_gameManager.player2.canInteract)
        {
            if (_gameManager.player2.hasEquippedBazooka)
            {
                _gameManager.player2.bazooka.Fire();
            }
            else
            {
                _gameManager.player2.gun.Fire();
                MasterSingleton.Instance.SoundManager.PlaySound(SoundEvents.PlayerShoot);
            }
        }
    }
    
    /// <summary>
    /// Method that is called through a button click in the game over screen to restart the level. It reloads the level. If the timescale is 0,
    /// even if the level has been reset the time scale does not change
    /// </summary>
    public void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    /// <summary>
    /// Method that loads the main menu scene
    /// </summary>
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
