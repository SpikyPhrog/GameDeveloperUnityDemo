using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    
    public Button fireBtnPlayer1;
    public Button fireBtnPlayer2;
    public TMP_Text itemDuration;

    public GameObject endGamePanel;
    public TMP_Text winner;
    private void Awake()
    {
        fireBtnPlayer1.onClick.AddListener(ShootP1);
        fireBtnPlayer2.onClick.AddListener(ShootP2);
    }

    private void Start()
    {
        _gameManager = MasterSingleton.Instance.GameManager;
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
            MasterSingleton.Instance.SoundManager.PlaySound(SoundEvents.PlayerShoot);
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
            MasterSingleton.Instance.SoundManager.PlaySound(SoundEvents.PlayerShoot);
        }
    }

    public void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
