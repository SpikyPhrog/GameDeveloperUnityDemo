using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Random drop class
/// </summary>
public class SpawnRandomBonuses : MonoBehaviour
{
    //array of all the possible drops, assignable in the inspector
    public GameObject[] bonuses;
    
    //the duration that the drop will disappear after
    private float _dropDuration;
    //the duration that the player has to wait for a new drop
    private float _waitDuration;
    private void Start()
    {
        //set the durations
        _dropDuration = 5f;
        _waitDuration = 7f;
    }

    private void Update()
    {
        //Check if the waiting for a new drop is lesser or equal to 0
        if (_waitDuration <= 0)
        {
            //If it is, reset the drop and wait duration and spawn a drop, from the drops array
            _dropDuration = 5f;
            _waitDuration = 7f;
            SpawnDrop(bonuses);
        }
        else
        {
            //if the duration is greater than 0, decrease the durations
            _dropDuration -= Time.deltaTime;
            _waitDuration -= Time.deltaTime;
        }

        //check if the item duration field is set in the UI Manager, usually not, since every object has their own canvas and UI and they find the main canvas and display the duration there.
        //this check is to prevent null reference error
        if (MasterSingleton.Instance.UIManager.itemDuration != null)
        {
            //if there is a drop and it has found the UI manager, it will set the text field to the drop duration, converted to string to avoid the decimal numbers
            MasterSingleton.Instance.UIManager.itemDuration.text = ((int) _dropDuration).ToString();
        }

    }

    /// <summary>
    /// Method that grabs an item from the array and instantiates it, sets the drop duration and plays the sound effect then destroys the drop after the duration
    /// </summary>
    /// <param name="drops"></param>
    void SpawnDrop(GameObject[] drops)
    {
        MasterSingleton.Instance.SoundManager.PlaySound(SoundEvents.DropSpawn);
        GameObject drop = Instantiate(drops[Random.Range(0, drops.Length)], transform);
        MasterSingleton.Instance.UIManager.itemDuration = drop.GetComponent<DisplayDuration>().duration;
        Destroy(drop, _dropDuration); 
    }
}
