using UnityEngine;

/// <summary>
/// Class for the buff that the player gains after obtaining the bazooka drop
/// </summary>
public class BazookaBuff : MonoBehaviour
{
    //to store the duration of the buff
    private float _duration;
    //check if the buff's duration has expired
    private bool _hasBuff;

    //reference to the game manager, and to keep it short than writing everytime MasterSingleton.Instance.GameManager;
    private GameManager _gameManager;
    
    //reference to the bazooka gun on the player
    public GameObject bazookaWeapon;
    //reference to the pistol gun on the player
    public GameObject gunWeapon;
    
    private void Awake()
    {
        //sets the duration of the buff
        _duration = 5f;
        _gameManager = MasterSingleton.Instance.GameManager;
    }

    private void Update()
    {   
        //change the boolean state based on if the duration is greater than 0
        _hasBuff = _duration > 0;
        
        //decrease the duration with every second, frame independent
        _duration -= Time.deltaTime;

        
        if (!_hasBuff)
        {
            //resets the buff duration
            _duration = 5f;
            //the buff has expired that means the bazooka gets hidden
            bazookaWeapon.SetActive(false);
            //and switched back to pistol
            gunWeapon.SetActive(true);
            
            //and just in case, since we can not check whom had the bazooka equipped change the boolean to false after the buff has expired.
            _gameManager.player1.hasEquippedBazooka = false;
            _gameManager.player2.hasEquippedBazooka = false;
        }
    }
    
}
