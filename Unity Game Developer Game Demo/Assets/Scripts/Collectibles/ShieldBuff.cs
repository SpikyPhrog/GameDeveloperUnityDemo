using UnityEngine;
/// <summary>
/// Class for the buff that the player will gain after obtaining the shield drop
/// </summary>
public class ShieldBuff : MonoBehaviour
{
    //sets the duration of the buff
    private float _duration;
    //to check if the buff's duration has expired
    private bool _hasBuff;

    //The shield's game object that will stop the bullets and will display the visual
    public GameObject shield;

    private void Awake()
    {
        //set the duration whenever the drop is spawned
        _duration = 5f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the player that has the buff has been shot in any way, even tho there is no possible way to be shot with a bomb or a bazooka while having this shield
        if (other.GetComponent<PistolAmmo>() != null || other.GetComponent<BazookaAmmo>() != null || other.GetComponent<Bomb>() != null)
        {
            //check if the buff has expired
            if (_hasBuff)
            {
                //destroy the incoming projectiles
                Destroy(other.gameObject);
            }
        }
    }

    private void Update()
    {
        //set the bool state based on whether the duration is greater than 0
        _hasBuff = _duration > 0;

        //decrease the duration with every second, frame independently
        _duration -= Time.deltaTime;

        //if the buff has expired, reset the shield's duration, even tho we set it in the awake, this is fail-safety line
        if (!_hasBuff) _duration = 5f;
        
        //enable and disable the gameObject having the shield based on whether the buff has expired or not
        shield.SetActive(_hasBuff); 
    }
    

}
